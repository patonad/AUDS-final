using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL.Nehnutelnosti
{
    class NehnutelnostiPodlaCisla : Nehnutelnosti, IComparable<NehnutelnostiPodlaCisla>

    {
        public NehnutelnostiPodlaCisla(int supCislo, string adresa = "",string popis = "")
        {
            SupCislo = supCislo;
            Adresa = adresa;
            Popis = popis;
        }

        public int CompareTo(NehnutelnostiPodlaCisla other)
        {
            return SupCislo.CompareTo(other.SupCislo);
        }
    }
}
