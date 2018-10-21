using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.KatUzemie
{
    public class KatUzemiePodlaNazvu : IComparable<KatUzemiePodlaNazvu>
    {
        public KatUzemie KatUzemie { get; set; }
        public KatUzemiePodlaNazvu(KatUzemie kat)
        {
            KatUzemie = kat;
        }

        public int CompareTo(KatUzemiePodlaNazvu other)
        {
            return KatUzemie.Nazov.CompareTo(other.KatUzemie.Nazov);
        }
    }
}
