using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace DiffBkRestore
{
    public partial class ExpForm : Form
    {
        public ExpForm()
        {
            InitializeComponent();
        }

        public class Rep
        {
            public String fp;
            public int Cur, Max;
        }

        private void bwExp_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Rep stat = e.UserState as Rep;
            if (stat == null) return;
            lPos.Text = stat.fp;// stat.Cur + "/" + stat.Max;
            pbTotal.Maximum = stat.Max;
            pbTotal.Value = Math.Min(pbTotal.Maximum, stat.Cur);
        }

        private void bwExp_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bStop.Enabled = false;
            Text = "終了しました";

            if (null != e.Error)
            {
                var lvi = new ListViewItem("");
                lvi.SubItems.Add(e.Error.Message);
                lve.Items.Add(lvi);
            }
        }

        private void ExpForm_Load(object sender, EventArgs e)
        {
            Sync = SynchronizationContext.Current;
        }

        SynchronizationContext Sync;

        internal List<KeyValuePair<string, Exception>> errors = new List<KeyValuePair<string, Exception>>();

        private void ExpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                if (bwExp.IsBusy)
                {
                    switch (MessageBox.Show(this, "復元中です。\n\n中止しますか?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                    {
                        case DialogResult.Yes:
                            bwExp.CancelAsync();
                            break;
                        case DialogResult.No:
                        default:
                            e.Cancel = true;
                            break;
                    }
                }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            if (bwExp.IsBusy)
            {
                switch (MessageBox.Show(this, "復元中です。\n\n中止しますか?", null, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.Yes:
                        bwExp.CancelAsync();
                        break;
                }
            }
        }

        delegate void ReportErrorDelegate(FPErr fpe);

        internal void ReportError(FPErr fpe)
        {
            Sync.Send(delegate
            {
                var lvi = new ListViewItem(fpe.fp);
                lvi.SubItems.Add(fpe.err.Message);
                lve.Items.Add(lvi);
            }, null);
        }
    }
}