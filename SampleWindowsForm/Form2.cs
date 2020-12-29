using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWindowsForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private Form1 mainFrom = null;
        public Form2(Form callingForm)
        {
            mainFrom = callingForm as Form1;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainFrom.LabelText = textBox1.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cbxWindowSize.Items.Add("Full Screen");
            cbxWindowSize.Items.Add("Half Screen");
            cbxWindowSize.Items.Add("Quarter Screen");
        }

        private void cbxWindowSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.mainFrom.LabelText = cbxWindowSize.SelectedItem.ToString();
            this.mainFrom.splitContainer1.Panel1Collapsed = true;
            this.mainFrom.splitContainer1.SplitterWidth = 1;
            this.mainFrom.splitContainer1.Panel1.Hide();

            //menghilangkan border
            this.mainFrom.FormBorderStyle = FormBorderStyle.None;
            this.mainFrom.LabelText = cbxWindowSize.SelectedItem.ToString();
        }
    }
}
