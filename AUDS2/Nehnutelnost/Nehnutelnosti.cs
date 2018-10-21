using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Nehnutelnost
{
    public class Nehnutelnosti
    {
        public Nehnutelnosti(int cislo, string adresa, string popis)
        {
            Cislo = cislo;
            Adresa = adresa;
            Popis = popis;
        }

        public int Cislo { get; set; }
        public string Adresa { get; set; }
        public string Popis { get; set; }
    }
}
