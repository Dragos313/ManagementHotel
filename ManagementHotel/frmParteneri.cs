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
    public partial class frmParteneri : Form
    {

        DBConnect dbCon = new DBConnect();
        public frmParteneri()
        {
            InitializeComponent();
        }

        private void frmParteneri_Load(object sender, EventArgs e)
        {
            IncarcaTari();
            IncarcaJudete();
        }
        private void IncarcaTari()
        {
            var tari = new List<Tara>();
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
            var judete = new List<Judet>();
            SqlCommand cmd = new SqlCommand("SELECT CodTara, Descriere FROM nom_Adrese_Judete", dbCon.GetCon());

            dbCon.OpenCon();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    judete.Add(new Judet { Descriere = reader["Descriere"].ToString(), CodTara = reader["CodTara"].ToString() });
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
            public string CodTara { get; set; }
            public string Descriere { get; set; }
        }
    }
}
