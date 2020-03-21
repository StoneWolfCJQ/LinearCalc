using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinearCalc
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            label1.Text += Utilities.UtilityParameters.version;
            this.KeyPreview = true;
            this.KeyDown += AboutForm_KeyDown;
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Escape))
            {
                this.Close();
            }
        }

        public void _Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contactMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:StoneWolfCJQ@Gmail.com");
            }
            catch (Exception ex)
            {

            }
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }
    }
}
