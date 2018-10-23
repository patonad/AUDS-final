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
        public AvlTree<NehnutelnostiPodlaC> StromNehnutelnostiPodlaCisla { get; set; }
        public AvlTree<ListVlasnictvaPodlaC> StromListovVlasnictvaPodlaCisla { get; set; }

        public KatUzemie(int cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
            StromNehnutelnostiPodlaCisla = new AvlTree<NehnutelnostiPodlaC>();
            StromListovVlasnictvaPodlaCisla = new AvlTree<ListVlasnictvaPodlaC>();
        }

 
    }
}
