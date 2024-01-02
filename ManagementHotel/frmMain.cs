using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementHotel
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = FormLogIn.loginname;
            timer1.Start();
            if (FormLogIn.logintype == "Vanzator")
            {
                camereToolStripMenuItem.Enabled = false;
                camereToolStripMenuItem.ForeColor = Color.Red;
                parteneriToolStripMenuItem.Enabled = false;
                parteneriToolStripMenuItem.ForeColor = Color.Red;
                adaugaUtilizatorToolStripMenuItem.Enabled = false;
                adaugaUtilizatorToolStripMenuItem.ForeColor = Color.Red;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esti sigur ca vrei sa inchizi aceasta aplicatie?", "Inchide", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esti sigur ca vrei sa inchizi aceasta aplicatie?", "Inchide", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                timer1.Stop();
                Application.Exit();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void adaugaUtilizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUtilizator fu = new frmUtilizator();
            fu.Show();
        }

        private void parteneriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmParteneri fp = new frmParteneri();
            fp.Show();
        }
    }
}
