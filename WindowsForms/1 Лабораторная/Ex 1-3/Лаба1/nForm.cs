using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Лаба1
{
    public partial class nForm : Лаба1.FormTreyg
    {
        public nForm()
        {
            InitializeComponent();
        }

        private void nForm_Load(object sender, EventArgs e)
        {

        }
        private void Main()
        {
            Application.Run(new nForm());
        }
    }
}
