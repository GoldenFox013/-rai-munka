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
    public partial class Form1 : Form
    {
        public Form1()
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
                    string query = "insert into regisztracio(nev, email, jelszo, szuletesidatum) values (@nev, @email, @jelszo, @szuletesidatum)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nev", textBox1.Text);
                        cmd.Parameters.AddWithValue("@email", textBox2.Text);
                        cmd.Parameters.AddWithValue("@jelszo", textBox3.Text);
                        cmd.Parameters.AddWithValue("@szuletesidatum", dateTimePicker1.Value);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Sikeres votl a regisztráció!");
                        //Bejelentkezés b = new Bejelentkezés();
                        //b.Show();
                        //this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }
    }
}
