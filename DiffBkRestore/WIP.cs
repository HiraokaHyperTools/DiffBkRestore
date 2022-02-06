using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DiffBkRestore
{
    public partial class WIP : UserControl
    {
        public WIP()
        {
            InitializeComponent();
        }

        public static WIP Show(Control parent)
        {
            WIP o = new WIP();
            o.Parent = parent;
            o.Location = Point.Empty;
            o.Size = parent.Size;
            o.Show();
            o.BringToFront();
            o.Update();

            return o;
        }
    }
}
