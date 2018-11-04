using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AUDS2.KatUzemie;
using AUDS2.Nehnutelnost;
using AUDS2.Obcan;
using AVL;

namespace AUDS2.ListVlasnictva
{
    public class ListVlastnictva : IComparable<ListVlastnictva>
    {
        public ListVlastnictva(KatUzemie.KatUzemie uzemie, int cisloListu)
        {
            Uzemie = uzemie;
            CisloListu = cisloListu;
            NehnutelnostiNaListe = new AvlTree<Nehnutelnosti>();
            Podiely = new AvlTree<Vlastnik>();
        }

        public KatUzemie.KatUzemie Uzemie { get; set; }

        public AvlTree<Nehnutelnosti> NehnutelnostiNaListe { get; set; }
        public int MAX { get; set; }
        public int CisloListu { get; set; }
        public AvlTree<Vlastnik> Podiely { get; set; }

        public void PridajMax(int a)
        {
            if (MAX < a)
            {
                MAX = a;
            }
        }

        public int CompareTo(ListVlastnictva other)
        {
            return CisloListu.CompareTo(other.CisloListu);
        }
    }
}
