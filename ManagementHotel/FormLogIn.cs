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
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }
        DBConnect dbCon = new DBConnect();
        public static string loginname, logintype;
        private void FormLogIn_Load(object sender, EventArgs e)
        {
            cmbFunctie.SelectedIndex = 1;
            txtUtilizator.Text = "Dragos";
            txtParola.Text = "123";
        }
        private void btnAutentifica_Click(object sender, EventArgs e)
        {

            try
            {
                if (cmbFunctie.SelectedIndex > 0)
                {
                    if (txtUtilizator.Text == String.Empty)
                    {
                        MessageBox.Show("Introdu un utilizator valid", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUtilizator.Focus();
                        return;
                    }
                    if (txtParola.Text == String.Empty)
                    {
                        MessageBox.Show("Introdu o parola valida", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtParola.Focus();
                        return;
                    }

                    if (cmbFunctie.SelectedIndex > 0 && txtUtilizator.Text != String.Empty && txtParola.Text != String.Empty)
                    {
                        //login code
                        if (cmbFunctie.Text == "Administrator")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 Utilizator,Parola,NumePrenume from tblUtilizator where Utilizator=@Utilizator and Parola=@Parola and Functie like 'Administrator'", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text);
                            cmd.Parameters.AddWithValue("@Parola", txtParola.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Autentificare reusita", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname = txtUtilizator.Text;
                                logintype = cmbFunctie.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Autentificare esuata, verifica utilizatorul si parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else if (cmbFunctie.Text == "Receptioner")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 Utilizator,Parola,NumePrenume from tblUtilizator where Utilizator=@Utilizator and Parola=@Parola and Functie like 'Receptioner'", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@Utilizator", txtUtilizator.Text);
                            cmd.Parameters.AddWithValue("@Parola", txtParola.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Autentificare reusita", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loginname = txtUtilizator.Text;
                                logintype = cmbFunctie.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Autentificare esuata, verifica utilizatorul si parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Introdu un utilizator si o parola", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clrValue();
                    }

                }
                else
                {
                    MessageBox.Show("Seleacteaza o functie", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clrValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCurata_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esti sigur ca vrei sa inchizi aceasta aplicatie?", "Inchide", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                Application.Exit();
            }
        }

        private void clrValue()
        {
            cmbFunctie.SelectedIndex = 0;
            txtUtilizator.Clear();
            txtParola.Clear();
        }
    }
}
