using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
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
    public partial class Bejelentkezes : Form
    {
        public Bejelentkezes()
        {
            InitializeComponent();
        }
        public static string conenction = "server=localhost;database=Foci;user=root;password=;";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(conenction))
                {
                    conn.Open();
                    string query = "SELECT nev FROM regisztracio WHERE email = @email AND jelszo = @jelszo";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", textBox1.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox2.Text);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Sikeres volt a bejelentkezés!");
                                Profil p = new Profil(reader.GetString("nev"));
                                this.Hide();
                                p.Show();
                            }
                            else
                            {
                                MessageBox.Show("Hibás e-mail vagy jelszó.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
