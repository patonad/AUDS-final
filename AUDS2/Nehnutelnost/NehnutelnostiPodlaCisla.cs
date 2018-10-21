using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Nehnutelnost
{
    public class NehnutelnostiPodlaCisla: IComparable<NehnutelnostiPodlaCisla>

    {
        public Nehnutelnosti  Nehnutelnost { get; set; }
        public NehnutelnostiPodlaCisla(Nehnutelnosti nehnutelnost )
        {
            Nehnutelnost = nehnutelnost;
        }

        public int CompareTo(NehnutelnostiPodlaCisla other)
        {
            return Nehnutelnost.Cislo.CompareTo(other.Nehnutelnost.Cislo);
        }
    }
}
