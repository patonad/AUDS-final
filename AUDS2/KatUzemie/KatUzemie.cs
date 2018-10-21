using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.ListVlasnictva;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2.KatUzemie
{
    public class KatUzemie
    {
        public int Cislo { get; set; }
        public string Nazov { get; set; }
        public AvlTree<NehnutelnostiPodlaCisla> ZoznamNehnutelnostiPodlaCisla { get; set; }
        public AvlTree<ListVlasnictvaPodlaCisla> ZoznamListovVlasnictvaPodlaCisla { get; set; }

        public KatUzemie(int cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
            ZoznamNehnutelnostiPodlaCisla = new AvlTree<NehnutelnostiPodlaCisla>();
            ZoznamListovVlasnictvaPodlaCisla = new AvlTree<ListVlasnictvaPodlaCisla>();
        }

 
    }
}
