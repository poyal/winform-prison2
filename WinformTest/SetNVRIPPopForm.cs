using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformTest
{
    public partial class SetNVRIPPopForm : Form
    {
        public SetNVRIPPopForm()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = (Form1) Owner;
            frm.ipVal = textBox1.Text;
            this.Close();
        }
    }
}
