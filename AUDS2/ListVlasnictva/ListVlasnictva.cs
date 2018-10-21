using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.KatUzemie;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2.ListVlasnictva
{
    public class ListVlasnictva
    {
        public ListVlasnictva(KatUzemie.KatUzemie uzemie, int cisloListu)
        {
            Uzemie = uzemie;
            CisloListu = cisloListu;
            NehnutelnostiNaListe = new AvlTree<NehnutelnostiPodlaCisla>();
        }

        public KatUzemie.KatUzemie Uzemie { get; set; }
        public AvlTree<NehnutelnostiPodlaCisla> NehnutelnostiNaListe { get; set; }
        public int CisloListu { get; set; }
    }
}
