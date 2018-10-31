using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.KatUzemie;
using AUDS2.Nehnutelnost;
using AUDS2.Obcan;
using AVL;

namespace AUDS2.ListVlasnictva
{
    public class ListVlasnictva : IComparable<ListVlasnictva>
    {
        public ListVlasnictva(KatUzemie.KatUzemie uzemie, int cisloListu)
        {
            Uzemie = uzemie;
            CisloListu = cisloListu;
            NehnutelnostiNaListe = new AvlTree<Nehnutelnosti>();
            podiely = new AvlTree<Vlasnik>();
        }

        public KatUzemie.KatUzemie Uzemie { get; set; }

        public AvlTree<Nehnutelnosti> NehnutelnostiNaListe { get; set; }

        public int CisloListu { get; set; }
        public AvlTree<Vlasnik> podiely { get; set; }


        public int CompareTo(ListVlasnictva other)
        {
            return CisloListu.CompareTo(other.CisloListu);
        }
    }
}
