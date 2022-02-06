using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DiffBkRestore
{
    public partial class SelSetForm : Form
    {
        String[] alfp;

        public SelSetForm(String[] alfp)
        {
            this.alfp = alfp;

            InitializeComponent();
        }

        private void SelSetForm_Load(object sender, EventArgs e)
        {
            foreach (String fp in alfp)
            {
                FileInfo fi = new FileInfo(fp);
                ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(fi.Name));
                lvi.SubItems.Add(fi.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss"));
                lvi.Tag = fp;
                lvset.Items.Add(lvi);
            }

            lvset.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            lvset_ColumnClick(sender, new ColumnClickEventArgs(1));

            foreach (ListViewItem lvi in lvset.Items)
            {
                lvi.Selected = lvi.Focused = true;
                break;
            }
        }

        class Sort : System.Collections.IComparer
        {
            int i, s;

            public Sort(int i, bool asc)
            {
                this.i = i;
                this.s = asc ? +1 : -1;
            }

            #region IComparer ÉÅÉìÉo

            public int Compare(object xx, object yy)
            {
                ListViewItem x = (ListViewItem)xx;
                ListViewItem y = (ListViewItem)yy;
                return s * x.SubItems[i].Text.CompareTo(y.SubItems[i].Text);
            }

            #endregion
        }

        private void lvset_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvset.ListViewItemSorter = (e.Column == 0)
                ? new Sort(e.Column, 0 == (ModifierKeys & Keys.Shift))
                : new Sort(e.Column, 0 != (ModifierKeys & Keys.Shift))
            ;
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            lvset_ItemActivate(sender, e);
        }

        public String SelectedFilePath = String.Empty;

        private void lvset_ItemActivate(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvset.SelectedItems)
            {
                this.SelectedFilePath = (String)lvi.Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}