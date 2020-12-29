using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_08
{
    public partial class FormSettings : Form
    {
        private FormUtama fu = null;
        private Form callingForm;

        public FormSettings()
        {
            InitializeComponent();
            //fu = callingForm as FormUtama;
        }

        public FormSettings(Form callingForm)
        {
            fu = callingForm as FormUtama;
            InitializeComponent();
            //fu = callingForm as FormUtama;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbxWindowSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            fu.splitContainer1.Panel1Collapsed = true;
            fu.splitContainer1.SplitterWidth = 1;
            fu.splitContainer1.Panel1.Hide();
           
            //menghilangkan border
            fu.FormBorderStyle = FormBorderStyle.None;

            switch (cbxWindowSize.SelectedItem)
            {
                case "Full Screen":
                    fu.WindowState = FormWindowState.Maximized;
                    break;

                case "Half Screen":
                    fu.WindowState = FormWindowState.Normal;
                    fu.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
                    fu.Height = Screen.PrimaryScreen.WorkingArea.Height;
                    fu.Location = new Point(0 , 0);
                    break;

                case "Quarter Screen":
                    fu.WindowState = FormWindowState.Normal;
                    fu.Width = Screen.PrimaryScreen.WorkingArea.Width / 2;
                    fu.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
                    fu.Location = new Point(0, 0);
                    break;
            }
            
            //fu.event_ChangedLayout();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            cbxWindowSize.Items.Add("Full Screen");
            cbxWindowSize.Items.Add("Half Screen");
            cbxWindowSize.Items.Add("Quarter Screen");
        }

        private void cbxTopM_CheckedChanged(object sender, EventArgs e)
        {
            fu.TopMost = cbxTopM.Checked;
        }
    }
}