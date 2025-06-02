using MySql.Data.MySqlClient;
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
    public partial class Profil : Form
    {
        public string nev;
        public Profil(string benev)
        {
            InitializeComponent();
            nev = benev;
        }
        public static string connection = "server=localhost;database=Foci;user=root;password=;";
        private void label1_Click(object sender, EventArgs e)
        {
            Meccsek m = new Meccsek(nev);
            this.Hide();
            m.Show();
        }
        private void Profil_Load(object sender, EventArgs e)
        {
            label3.Text = nev;
            Kiolvas();
        }
        public void Kiolvas()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM regisztracio";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("id");
                                string nev = reader.GetString("nev");
                                string email = reader.GetString("email");
                                string jelszo = reader.GetString("jelszo");
                                DateTime szuletesidatum = reader.GetDateTime("szuletesidatum");

                                dataGridView1.Rows.Add(nev, email, jelszo, szuletesidatum);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "delete * FROM regisztracio where id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connection))
                {
                    conn.Open();
                    string query = "update regisztracio set nev=@nev, email=@email, jelszo=@jelszo, datum=@datum where id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", int.Parse(textBox5.Text));
                        cmd.Parameters.AddWithValue("@nev", textBox1.Text);
                        cmd.Parameters.AddWithValue("@email", textBox2.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox3.Text);
                        cmd.Parameters.AddWithValue("@szuletesidatum", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
