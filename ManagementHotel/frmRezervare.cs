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
using static ManagementHotel.frmParteneri;

namespace ManagementHotel
{
    public partial class frmRezervare : Form
    {
        DBConnect dbCon = new DBConnect();
        public string IdRezervareCamera;
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
            btnActualizeaza.Visible = false;
            btnSterge.Visible = false;
            btnAdauga.Visible = true;
            dtpDataInceput.Value = DateTime.Now;
            dtpDataSfarsit.Value = DateTime.Now.AddDays(1);
            BindRezervare();
            BindDupaClient();
            CautaDupaDenumireClient();
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
        private void BindDupaClient()
        {
            SqlCommand cmd = new SqlCommand("getClient", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbCauta.DataSource = dt;
            cmbCauta.DisplayMember = "NumePrenume";
            cmbCauta.ValueMember = "ID";
            dbCon.CloseCon();
        }
        private void CautaDupaDenumireClient()
        {
            SqlCommand cmd = new SqlCommand("getClient", dbCon.GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbCauta.DataSource = dt;
            cmbCauta.DisplayMember = "NumePrenume";
            cmbCauta.ValueMember = "ID";
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
                int nrZile = (int)(dtpDataSfarsit.Value - dtpDataInceput.Value).TotalDays;
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
                else if (nrZile == 0)
                {
                    MessageBox.Show("Data de sfarsit a rezervarii trebuie sa fie mai mare decat data de inceput", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDataSfarsit.Focus();
                    return;
                }
                else if (dtpDataInceput.Value > dtpDataSfarsit.Value)
                {
                    MessageBox.Show("Data de inceput nu poate fi mai mare decat data de sfarsit", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDataInceput.Focus();
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            btnActualizeaza.Visible = true;
            btnSterge.Visible = true;
            btnAdauga.Visible = false;
            IdRezervareCamera = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DenumireClient = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            IdClient = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            DenumireCamera = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            IdCamera = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            PretZi = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            txtClient.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtCamera.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[5].Value is DateTime dataInceput)
            {
                dtpDataInceput.Value = dataInceput;
            }

            if (dataGridView1.SelectedRows[0].Cells[6].Value is DateTime dataSfarsit)
            {
                dtpDataSfarsit.Value = dataSfarsit;
            }
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                int nrZile = (int)(dtpDataSfarsit.Value - dtpDataInceput.Value).TotalDays;
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
                else if (nrZile == 0)
                {
                    MessageBox.Show("Data de sfarsit a rezervarii trebuie sa fie mai mare decat data de inceput", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDataSfarsit.Focus();
                    return;
                }
                else if (dtpDataInceput.Value > dtpDataSfarsit.Value)
                {
                    MessageBox.Show("Data de inceput nu poate fi mai mare decat data de sfarsit", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtpDataInceput.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("actualizareRezervare", dbCon.GetCon());
                    dbCon.OpenCon();
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IdRezervareCamera));
                    cmd.Parameters.AddWithValue("@DenumireClient", txtClient.Text);
                    cmd.Parameters.AddWithValue("@IdClient", Convert.ToInt32(IdClient));
                    cmd.Parameters.AddWithValue("@DenumireCamera", txtCamera.Text);
                    cmd.Parameters.AddWithValue("@IdCamera", Convert.ToInt32(IdCamera));
                    cmd.Parameters.AddWithValue("@DataInceput", dtpDataInceput.Value.Date);
                    cmd.Parameters.AddWithValue("@DataSfarsit", dtpDataSfarsit.Value.Date);
                    cmd.Parameters.AddWithValue("@NrZile", nrZile);
                    cmd.Parameters.AddWithValue("@PretZi", Convert.ToDecimal(PretZi));
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Rezervare a fost modificata cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnSterge_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecateaza o rezervare", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Vrei sa stergi aceasta rezervare?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("stergeRezervare", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IdRezervareCamera));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Rezervare stearsa", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindRezervare();
                            btnActualizeaza.Visible = false;
                            btnSterge.Visible = false;
                            btnAdauga.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Stergerea nu s-a finalizat", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtClear();
                        }
                        dbCon.CloseCon();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RezultatRezervari()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("getRezervari_DupaClient", dbCon.GetCon());
                cmd.Parameters.AddWithValue("@ID", cmbCauta.SelectedValue);
                cmd.CommandType = CommandType.StoredProcedure;
                dbCon.OpenCon();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dbCon.CloseCon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmRezervare_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RezultatRezervari();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindRezervare();
        }
    }
}
