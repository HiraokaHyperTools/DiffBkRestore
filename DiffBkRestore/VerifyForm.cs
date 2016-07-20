using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DiffBkRestore {
    public partial class VerifyForm : Form {
        public VerifyForm() {
            InitializeComponent();
        }

        internal void SetDone(Exception err) {
            if (IsDisposed) return;

            pbWIP.Hide();
            lWIP.Hide();
            lPos.Hide();

            lDone.Show();
            llRep.Visible = err != null;
            llRep.Tag = err;
        }

        private void llRep_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Control me = (Control)sender;
            Exception err = (Exception)me.Tag;
            MessageBox.Show(this, err.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        internal void SetHere(string p) {
            if (IsDisposed) return;

            lPos.Text = p;
        }

        private void VerifyForm_Load(object sender, EventArgs e) {

        }

        internal ISelPath SP = null;

        private void mSel_Click(object sender, EventArgs e) {
            bool showHash = sender == mHash;
            foreach (ListViewItem lvi in lvF.SelectedItems) {
                String fn = lvi.SubItems[chName.Index].Text;
                String dir = lvi.SubItems[chPlace.Index].Text;
                if (showHash) {
                    Process.Start("explorer.exe", " /select,\"" + lvi.SubItems[chHashfp.Index].Text + "\"");
                }
                else if (SP != null) {
                    SP.SelPath(dir, fn);
                }
                break;
            }
        }

        private void lvF_ItemActivate(object sender, EventArgs e) {
            mSel.PerformClick();
        }
    }
}