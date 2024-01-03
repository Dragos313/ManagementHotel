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
    public partial class frmUtilizator : Form
    {
        DBConnect dbCon = new DBConnect();
        public string IDUtilizator;
        public frmUtilizator()
        {
            InitializeComponent();
        }

        private void frmUtilizator_Load(object sender, EventArgs e)
        {
            btnActualizeaza.Visible = false;
            btnSterge.Visible = false;
            btnAdauga.Visible = true;
            cmbFunctie.SelectedIndex = 0;
            BindUtilizator();
        }

        private void txtClear()
        {
            txtUtilizator.Clear();
            txtNumePrenume.Clear();
            txtCNP.Clear();
            txtParola.Clear();
            txtTelefon.Clear();
            cmbFunctie.SelectedIndex = 0;
        }
        private void BindUtilizator()
        {
            SqlCommand cmd = new SqlCommand("select * from tblUtilizator", dbCon.GetCon());
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.CloseCon();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            btnActualizeaza.Visible = true;
            btnSterge.Visible = true;
            btnAdauga.Visible = false;
            IDUtilizator = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtUtilizator.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtUtilizator.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtNumePrenume.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtParola.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtCNP.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtTelefon.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cmbFunctie.SelectedIndex = dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "Administrator" ? 1 :
                                       dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "Receptioner" ? 2 : 0;
        }

        private void btnSterge_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecateaza un vanzator", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Vrei sa stergi acest utilizator?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("stergeUtilizator", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDUtilizator));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Vanzator sters", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindUtilizator();
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

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecteaza un utilizator", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (txtUtilizator.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nume de utilizator", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUtilizator.Focus();
                    return;
                }
                else if (txtParola.Text == String.Empty)
                {
                    MessageBox.Show("Introdu o parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParola.Focus();
                    return;
                }
                else if (cmbFunctie.SelectedIndex == 0)
                {
                    MessageBox.Show("Alege o functie", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFunctie.Focus();
                    return;
                }
                else
                {

                    SqlCommand cmd = new SqlCommand("actualizareUtilizator", dbCon.GetCon());
                    dbCon.OpenCon();
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDUtilizator));
                    cmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text);
                    cmd.Parameters.AddWithValue("@NumePrenume", txtNumePrenume.Text);
                    cmd.Parameters.AddWithValue("@Parola", txtParola.Text);
                    cmd.Parameters.AddWithValue("@CNP", Convert.ToInt64(txtCNP.Text));
                    cmd.Parameters.AddWithValue("@Telefon", Convert.ToInt32(txtTelefon.Text));
                    cmd.Parameters.AddWithValue("@Functie", cmbFunctie.SelectedItem.ToString());
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    dbCon.CloseCon();
                    if (i > 0)
                    {
                        MessageBox.Show("Utilizator actualizat", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindUtilizator();
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

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUtilizator.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nume de utilizator", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUtilizator.Focus();
                    return;
                }
                else if (txtParola.Text == String.Empty)
                {
                    MessageBox.Show("Introdu o parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParola.Focus();
                    return;
                }
                else if (cmbFunctie.SelectedIndex == 0)
                {
                    MessageBox.Show("Alege o functie", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbFunctie.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select Utilizator from tblUtilizator where Utilizator=@Utilizator", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text);

                    dbCon.OpenCon();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("Utilizatorul exista deja in baza de date", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        cmd = new SqlCommand("adaugareUtilizator", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text);
                        cmd.Parameters.AddWithValue("@NumePrenume", txtNumePrenume.Text);
                        cmd.Parameters.AddWithValue("@Parola", txtParola.Text);
                        cmd.Parameters.AddWithValue("@CNP", Convert.ToInt64(txtCNP.Text));
                        cmd.Parameters.AddWithValue("@Telefon", Convert.ToInt32(txtTelefon.Text));
                        cmd.Parameters.AddWithValue("@Functie", cmbFunctie.SelectedItem.ToString());
                        cmd.CommandType = CommandType.StoredProcedure;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Utlizatorul a fost adaugat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindUtilizator();
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
    }
}
