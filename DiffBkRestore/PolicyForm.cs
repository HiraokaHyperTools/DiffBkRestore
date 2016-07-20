using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DiffBkRestore {
    public partial class PolicyForm : Form {
        public PolicyForm() {
            InitializeComponent();
        }

        private void PolicyForm_Load(object sender, EventArgs e) {

        }

        public bool IfOverwrite, IfContinueOnError;

        private void bOk_Click(object sender, EventArgs e) {
            IfOverwrite = rbOverw.Checked;
            IfContinueOnError = rbCont.Checked;
        }
    }
}