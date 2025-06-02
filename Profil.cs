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
        string nev;
        public Profil(string benev)
        {
            InitializeComponent();
            string nev = benev;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            Meccsek m = new Meccsek(nev);
            this.Hide();
            m.Show();
        }
    }
}
