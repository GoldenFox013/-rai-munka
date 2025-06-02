using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tz
{
    internal class Foci
    {
        public DateTime datum;
        public string ellenfel;
        public string helyszin;
        public int sajatgol;
        public int ellenfelgol;
        public bool kimenetel;

        public Foci(string datum, string ellenfel, string helyszin, string sajatgol, string ellenfelgol, string kimenetel)
        {
            this.datum = DateTime.Parse(datum);
            this.ellenfel = ellenfel;
            this.helyszin = helyszin;
            this.sajatgol = int.Parse(sajatgol);
            this.ellenfelgol = int.Parse(ellenfelgol);
            this.kimenetel = bool.Parse(kimenetel);
        }
    }
}
