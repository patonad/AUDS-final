using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Obcan
{
    public class Vlastnik : IComparable<Vlastnik>
    {
        public Vlastnik(int podiel, Obcan obcan)
        {
            Podiel = podiel;
            Obcan = obcan;
        }

        public int Podiel { get; set; }
        public Obcan Obcan { get; set; }


        public int CompareTo(Vlastnik other)
        {
            return Obcan.CompareTo(other.Obcan);
        }

        public override string ToString()
        {
            return Obcan.ToString() + "  Podiel je:  "+Podiel;
        }
    }
}
