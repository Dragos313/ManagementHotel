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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManagementHotel
{
    public partial class frmParteneri : Form
    {

        DBConnect dbCon = new DBConnect();
        public string IDPartener;
        public List<Tara> tari = new List<Tara>();
        public List<Judet> judete = new List<Judet>();
        public string DenumireClient;
        public bool DeschisDinFrmRezervare;
        public frmParteneri()
        {
            InitializeComponent();
        }

        private void frmParteneri_Load(object sender, EventArgs e)
        {
            BindPartener();
            IncarcaTari();
            IncarcaJudete();
        }
        private void IncarcaTari()
        {
            SqlCommand cmd = new SqlCommand("SELECT CodTara, Descriere FROM nom_Adrese_Tari", dbCon.GetCon());

            dbCon.OpenCon();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    tari.Add(new Tara { Descriere = reader["Descriere"].ToString(), CodTara = reader["CodTara"].ToString() });
                }
            }
            dbCon.CloseCon();

            cmbTara.DataSource = tari;
            cmbTara.DisplayMember = "Descriere";

            Tara defaultSelectedTara = tari.Find(t => t.CodTara == "RO");
            if (defaultSelectedTara != null)
            {
                cmbTara.SelectedItem = defaultSelectedTara;
            }
        }
        private void IncarcaJudete()
        {
            SqlCommand cmd = new SqlCommand("SELECT Cod, Descriere FROM nom_Adrese_Judete", dbCon.GetCon());

            dbCon.OpenCon();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    judete.Add(new Judet { Descriere = reader["Descriere"].ToString(), Cod = reader["Cod"].ToString() });
                }
            }
            dbCon.CloseCon();

            cmbJudet.DataSource = judete;
            cmbJudet.DisplayMember = "Descriere";

        }
        public class Tara
        {
            public string CodTara { get; set; }
            public string Descriere { get; set; }
        }
        public class Judet
        {
            public string Cod { get; set; }
            public string Descriere { get; set; }
        }
        private void BindPartener()
        {
            SqlCommand cmd = new SqlCommand("select * from tblPartener", dbCon.GetCon());
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.CloseCon();
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            long parsedValue;
            try
            {
                if (txtNumePrenume.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nume si un prenume", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumePrenume.Focus();
                    return;
                }
                else if (txtCNP.Text == String.Empty || ((!Int64.TryParse(txtCNP.Text, out parsedValue))))
                {
                    MessageBox.Show("Introdu un CNP valid", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCNP.Focus();
                    return;
                }
                else if (cmbTara.SelectedIndex == 0)
                {
                    MessageBox.Show("Alege o tara", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTara.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select CNP from tblPartener where CNP=@CNP", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@CNP", txtCNP.Text);

                    dbCon.OpenCon();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("Un partener cu acelasi CNP exista deja in baza de date", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        cmd = new SqlCommand("adaugarePartener", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@NumePrenume", txtNumePrenume.Text);
                        cmd.Parameters.AddWithValue("@CNP", Convert.ToInt64(txtCNP.Text));
                        cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                        cmd.Parameters.AddWithValue("@Localitate", txtLocalitate.Text);
                        Tara selectedTara = cmbTara.SelectedItem as Tara;
                        cmd.Parameters.AddWithValue("@Tara", selectedTara.Descriere.ToString());
                        if (cmbJudet.SelectedItem != null)
                        {
                            Judet selectedJudet = cmbJudet.SelectedItem as Judet;
                            cmd.Parameters.AddWithValue("@Judet", selectedJudet.Descriere.ToString());
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Judet", cmbJudet.Text);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Utlizatorul a fost adaugat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindPartener();
                        }
                    }
                    dbCon.CloseCon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtClear()
        {
            txtNumePrenume.Clear();
            txtCNP.Clear();
            txtLocalitate.Clear();
            txtTelefon.Clear();
            cmbJudet.SelectedIndex = 0;
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            long parsedValue;
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecteaza un utilizator", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (txtNumePrenume.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nume si un prenume", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumePrenume.Focus();
                    return;
                }
                else if (txtCNP.Text == String.Empty || ((!Int64.TryParse(txtCNP.Text, out parsedValue))))
                {
                    MessageBox.Show("Introdu un CNP valid", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCNP.Focus();
                    return;
                }
                else if (cmbTara.SelectedIndex == 0)
                {
                    MessageBox.Show("Alege o tara", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbTara.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("actualizarePartener", dbCon.GetCon());
                    dbCon.OpenCon();
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDPartener));
                    cmd.Parameters.AddWithValue("@NumePrenume", txtNumePrenume.Text);
                    cmd.Parameters.AddWithValue("@CNP", Convert.ToInt64(txtCNP.Text));
                    cmd.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
                    cmd.Parameters.AddWithValue("@Localitate", txtLocalitate.Text);
                    Tara selectedTara = cmbTara.SelectedItem as Tara;
                    cmd.Parameters.AddWithValue("@Tara", selectedTara.Descriere.ToString());
                    if (cmbJudet.SelectedItem != null)
                    {
                        Judet selectedJudet = cmbJudet.SelectedItem as Judet;
                        cmd.Parameters.AddWithValue("@Judet", selectedJudet.Descriere.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Judet", cmbJudet.Text);
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    dbCon.CloseCon();
                    if (i > 0)
                    {
                        MessageBox.Show("Partener actualizat", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindPartener();
                        btnActualizeaza.Visible = false;
                        btnSterge.Visible = false;
                        btnAdauga.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Actualizare esuata", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtClear();
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
            IDPartener = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNumePrenume.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtCNP.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtTelefon.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            Tara selectedTara = tari.Find(t => t.Descriere == dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            if (selectedTara != null)
            {
                cmbTara.SelectedItem = selectedTara;
            }
            Judet selectedJudet = judete.Find(t => t.Descriere == dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            if (selectedJudet != null)
            {
                cmbJudet.SelectedItem = selectedJudet;
            }
            txtLocalitate.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecateaza un partener", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Vrei sa stergi acest partener?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("stergePartener", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDPartener));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Partener sters", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindPartener();
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (DeschisDinFrmRezervare)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    IDPartener = dataGridView1.SelectedRows[0].Cells[0].Value?.ToString();
                    DenumireClient = dataGridView1.SelectedRows[0].Cells[1].Value?.ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
