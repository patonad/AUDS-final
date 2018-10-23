using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Obcan
{
    public class Vlasnik : IComparable<Vlasnik>
    {
        public Vlasnik(int podiel, Obcan obcan)
        {
            Podiel = podiel;
            Obcan = obcan;
        }

        public int Podiel { get; set; }
        public Obcan Obcan { get; set; }


        public int CompareTo(Vlasnik other)
        {
            return Obcan.CompareTo(other.Obcan);
        }
    }
}
