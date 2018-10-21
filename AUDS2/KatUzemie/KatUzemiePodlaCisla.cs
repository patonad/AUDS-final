using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.KatUzemie
{
    public class KatUzemiePodlaCisla : IComparable<KatUzemiePodlaCisla>
    {
        public KatUzemie KatUzemie { get; set; }
        public KatUzemiePodlaCisla(KatUzemie kat)
        {
            KatUzemie = kat;
        }

        public int CompareTo(KatUzemiePodlaCisla other)
        {
            return KatUzemie.Cislo.CompareTo(other.KatUzemie.Cislo);
        }
    }
}
