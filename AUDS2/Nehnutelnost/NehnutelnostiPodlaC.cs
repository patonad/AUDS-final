using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Nehnutelnost
{
    public class NehnutelnostiPodlaC: IComparable<NehnutelnostiPodlaC>

    {
        public Nehnutelnosti  Nehnutelnost { get; set; }
        public NehnutelnostiPodlaC(Nehnutelnosti nehnutelnost )
        {
            Nehnutelnost = nehnutelnost;
        }

        public int CompareTo(NehnutelnostiPodlaC other)
        {
            return Nehnutelnost.Cislo.CompareTo(other.Nehnutelnost.Cislo);
        }
    }
}
