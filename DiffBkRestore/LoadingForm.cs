using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DiffBkRestore
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        internal static LoadingForm Create()
        {
            LoadingForm form = new LoadingForm();
            form.Show();
            form.Update();
            return form;
        }
    }
}