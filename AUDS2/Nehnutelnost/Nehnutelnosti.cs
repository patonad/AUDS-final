using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Nehnutelnost
{
    public class Nehnutelnosti : IComparable<Nehnutelnosti>
    {
        public Nehnutelnosti(int cislo, string adresa, string popis)
        {
            Cislo = cislo;
            Adresa = adresa;
            Popis = popis;
        }
        public int CompareTo(Nehnutelnosti other)
        {
            return Cislo.CompareTo(other.Cislo);
        }
        public int Cislo { get; set; }
        public string Adresa { get; set; }
        public string Popis { get; set; }
        public List<Obcan.Obcan> TrvalýPobyt { get; set; }
        public ListVlasnictva.ListVlasnictva ListVlasnictva { get; set; }

        
    }
}
