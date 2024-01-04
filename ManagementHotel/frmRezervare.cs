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
    public partial class frmRezervare : Form
    {
        DBConnect dbCon = new DBConnect();
        public string IdCamera;
        public string IdClient;
        public string DenumireCamera;
        public string DenumireClient;
        public string PretZi;
        public string Utilizator;
        public frmRezervare()
        {
            InitializeComponent();
        }

        private void frmRezervare_Load(object sender, EventArgs e)
        {
            BindRezervare();
        }
        private void BindRezervare()
        {
            SqlCommand cmd = new SqlCommand("select * from tblRezervareContinut", dbCon.GetCon());
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.CloseCon();
        }
        private void txtClear()
        {
            txtClient.Clear();
            txtCamera.Clear();
            dtpDataInceput.Value = DateTime.Now;
            dtpDataSfarsit.Value = DateTime.Now.AddDays(1);
        }
        private void btnClient_Click(object sender, EventArgs e)
        {
            frmParteneri fp = new frmParteneri();
            fp.DeschisDinFrmRezervare = true;
            if (fp.ShowDialog() == DialogResult.OK)
            { 
                IdClient = fp.IDPartener;
                txtClient.Text = fp.DenumireClient;
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            frmCamere fc = new frmCamere();
            fc.DeschisDinFrmRezervare = true;
            if (fc.ShowDialog() == DialogResult.OK)
            {
                IdCamera = fc.IDCamera;
                PretZi = fc.PretZi;
                txtCamera.Text = fc.DenumireCamera;

            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtClient.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nume de client", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtClient.Focus();
                    return;
                }
                else if (txtCamera.Text == String.Empty)
                {
                    MessageBox.Show("Introdu o camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCamera.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("adaugareRezervare", dbCon.GetCon());
                    dbCon.OpenCon();
                    cmd.Parameters.AddWithValue("@DenumireClient", txtClient.Text);
                    cmd.Parameters.AddWithValue("@IdClient", Convert.ToInt32(IdClient));
                    cmd.Parameters.AddWithValue("@DenumireCamera", txtCamera.Text);
                    cmd.Parameters.AddWithValue("@IdCamera", Convert.ToInt32(IdCamera));
                    cmd.Parameters.AddWithValue("@DataInceput", dtpDataInceput.Value.Date);
                    cmd.Parameters.AddWithValue("@DataSfarsit", dtpDataSfarsit.Value.Date);
                    int nrZile = (int)(dtpDataSfarsit.Value - dtpDataInceput.Value).TotalDays;
                    cmd.Parameters.AddWithValue("@NrZile", nrZile);
                    cmd.Parameters.AddWithValue("@PretZi", Convert.ToDecimal(PretZi));
                    cmd.Parameters.AddWithValue("@Utilizator", Utilizator);
                    cmd.Parameters.AddWithValue("@DataAdaugare", DateTime.Now);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Rezervarea a fost adaugata cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindRezervare();
                    }

                    dbCon.CloseCon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
