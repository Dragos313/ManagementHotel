using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementHotel
{
    public partial class frmMain : Form
    {
        DBConnect dbCon = new DBConnect();
        public string Utilizator;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = FormLogIn.loginname;
            IncarcaRezervariViitoare();
            IncarcaRezervari();
            IncarcaTotalClienti();
            IncarcaVenituri();
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
            fp.FormClosed += (senderForm, eForm) =>
            {
                if (fp.DialogResult == DialogResult.OK)
                {
                    IncarcaTotalClienti();
                }
            };
            fp.Show();
        }

        private void camereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCamere fc = new frmCamere();
            fc.Show();
        }

        private void rezervariToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRezervare rz = new frmRezervare();
            rz.Utilizator = FormLogIn.loginname;
            rz.FormClosed += (senderForm, eForm) =>
            {
                if (rz.DialogResult == DialogResult.OK)
                {
                    IncarcaTotalClienti();
                    IncarcaRezervariViitoare();
                    IncarcaRezervari();
                    IncarcaVenituri();
                }
            };
            rz.Show();
        }
        private void IncarcaRezervariViitoare()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblRezervareContinut WHERE DataInceput > GETDATE()", dbCon.GetCon()))
            {
                dbCon.OpenCon();

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblRezViitoare.Text = result.ToString();
                }
            }
            dbCon.CloseCon();
        }
        private void IncarcaRezervari()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblRezervareContinut", dbCon.GetCon()))
            {
                dbCon.OpenCon();

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblRezervari.Text = result.ToString();
                }
            }
            dbCon.CloseCon();
        }
        private void IncarcaTotalClienti()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tblPartener", dbCon.GetCon()))
            {
                dbCon.OpenCon();

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblTotalClienti.Text = result.ToString();
                }
            }
            dbCon.CloseCon();
        }
        private void IncarcaVenituri()
        {
            using (SqlCommand cmd = new SqlCommand("SELECT SUM(PretZi * NrZile) AS TotalCost FROM tblRezervareContinut WHERE DataSfarsit <= GETDATE()", dbCon.GetCon()))
            {
                dbCon.OpenCon();

                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    lblVenituri.Text = result.ToString();
                }
            }
            dbCon.CloseCon();
        }
    }
}
