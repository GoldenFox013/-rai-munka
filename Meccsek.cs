using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tz
{
    public partial class Meccsek : Form
    {
        string nev;
        public Meccsek(string benev)
        {
            InitializeComponent();
            nev = benev;
        }
        public static string conenction = "server=localhost;database=Foci;user=root;password=;";
        List<Foci> lista = new List<Foci>();
        private void Meccsek_Load(object sender, EventArgs e)
        {
            try
            {
                string[] sorok = File.ReadAllLines("foci.txt");
                foreach (string s in sorok)
                {
                    string[] adat = s.Split(';');
                    lista.Add(new Foci(adat[0], adat[1], adat[2], adat[3], adat[4], adat[5]));
                    dataGridView1.Rows.Add(adat[0], adat[1], adat[2], adat[3], adat[4], adat[5]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Profil p = new Profil(nev);
            this.Hide();
            p.Show();
        }
    }
}
