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
        public AvlTree<Nehnutelnosti> StromNehnutelnostiPodlaCisla { get; set; }
        public AvlTree<ListVlasnictva.ListVlastnictva> StromListovVlastnictvaPodlaCisla { get; set; }

        public KatUzemie(int cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
            StromNehnutelnostiPodlaCisla = new AvlTree<Nehnutelnosti>();
            StromListovVlastnictvaPodlaCisla = new AvlTree<ListVlasnictva.ListVlastnictva>();
        }

        public int MaxList { get; set; }

        public void PridajMaxList(int a)
        {
            if (MaxList < a)
            {
                MaxList = a;
            }
        }
        public int MaxNeh { get; set; }

        public void PridajMaxNeh(int a)
        {
            if (MaxNeh < a)
            {
                MaxNeh = a;
            }
        }
    }
}
