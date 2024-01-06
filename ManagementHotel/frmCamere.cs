using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementHotel
{
    public partial class frmCamere : Form
    {
        DBConnect dbCon = new DBConnect();
        byte[] ImageData = null;
        public string IDCamera;
        public string DenumireCamera;
        public string PretZi;
        public bool DeschisDinFrmRezervare;
        public frmCamere()
        {
            InitializeComponent();
        }
        private void frmCamere_Load(object sender, EventArgs e)
        {
            if (FormLogIn.logintype == "Receptioner")
            {
                btnActualizeaza.Visible = false;
                btnSterge.Visible = false;
                btnAdauga.Visible = false;
            }
            else
            {
                btnActualizeaza.Visible = false;
                btnSterge.Visible = false;
                btnAdauga.Visible = true;
            }
            if (DeschisDinFrmRezervare)
            {
                lblSelectare.Visible = true;
            }
            else
            {
                lblSelectare.Visible = false;
            }
            BindCamera();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream stream = openFileDialog.OpenFile();

                    Image selectedImage = Image.FromStream(stream);

                    pictureBox1.Image = selectedImage;

                    ImageData = File.ReadAllBytes(openFileDialog.FileName);

                    stream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdauga_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipCamera.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un tip de camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTipCamera.Focus();
                    return;
                }
                else if (txtEtaj.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un etaj", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEtaj.Focus();
                    return;
                }
                else if (txtNrCamera.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nr de camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNrCamera.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("select NrCamera from tblCamera where NrCamera=@NrCamera", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@NrCamera", txtNrCamera.Text);

                    dbCon.OpenCon();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        MessageBox.Show("Camera exista deja in baza de date", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClear();
                    }
                    else
                    {
                        cmd = new SqlCommand("adaugareCamera", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@TipCamera", txtTipCamera.Text);
                        cmd.Parameters.AddWithValue("@NrCamera", txtNrCamera.Text);
                        cmd.Parameters.AddWithValue("@NrLocuri", Convert.ToInt32(txtNrLocuri.Text));
                        cmd.Parameters.AddWithValue("@Etaj", txtNrLocuri.Text);
                        cmd.Parameters.AddWithValue("@PretZi", Convert.ToDecimal(txtPretZi.Text));
                        if (ImageData != null)
                        {
                            cmd.Parameters.AddWithValue("@Imagine", ImageData);
                        }
                        
                        cmd.CommandType = CommandType.StoredProcedure;
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Utlizatorul a fost adaugat cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindCamera();
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
            txtNrCamera.Clear();
            txtEtaj.Clear();
            txtNrLocuri.Clear();
            txtPretZi.Clear();
            txtTipCamera.Clear();
            pictureBox1.Image = null;
        }
        private void BindCamera()
        {
            SqlCommand cmd = new SqlCommand("select * from tblCamera", dbCon.GetCon());
            dbCon.OpenCon();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.CloseCon();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (FormLogIn.logintype == "Receptioner")
            {
                btnActualizeaza.Visible = false;
                btnSterge.Visible = false;
                btnAdauga.Visible = false;
            }
            else
            {
                btnActualizeaza.Visible = true;
                btnSterge.Visible = true;
                btnAdauga.Visible = false;
            }
            IDCamera = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtTipCamera.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtNrCamera.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtNrLocuri.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtEtaj.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPretZi.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            ImageData = dataGridView1.SelectedRows[0].Cells[6].Value as byte[];
            if (ImageData != null)
            {
                using (MemoryStream ms = new MemoryStream(ImageData))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTipCamera.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un tip de camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTipCamera.Focus();
                    return;
                }
                else if (txtEtaj.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un etaj", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEtaj.Focus();
                    return;
                }
                else if (txtNrCamera.Text == String.Empty)
                {
                    MessageBox.Show("Introdu un nr de camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNrCamera.Focus();
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("actualizareCamera", dbCon.GetCon());
                    dbCon.OpenCon();
                    cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDCamera));
                    cmd.Parameters.AddWithValue("@TipCamera", txtTipCamera.Text);
                    cmd.Parameters.AddWithValue("@NrCamera", txtNrCamera.Text);
                    cmd.Parameters.AddWithValue("@NrLocuri", Convert.ToInt32(txtNrLocuri.Text));
                    cmd.Parameters.AddWithValue("@Etaj", txtEtaj.Text);
                    cmd.Parameters.AddWithValue("@PretZi", Convert.ToDecimal(txtPretZi.Text));
                    if (ImageData != null)
                    {
                        cmd.Parameters.AddWithValue("@Imagine", ImageData);
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Camera a fost adaugata cu succes", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        BindCamera();
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
                    MessageBox.Show("Selecateaza o camera", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Vrei sa stergi aceasta camera?", "Confirmare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("stergeCamera", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(IDCamera));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Camera stearsa", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtClear();
                            BindCamera();
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
                IDCamera = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                DenumireCamera = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                PretZi = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        
    }
}
