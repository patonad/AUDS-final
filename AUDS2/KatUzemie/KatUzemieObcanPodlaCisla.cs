using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2.KatUzemie
{
    public class KatUzemieObcanPodlaCisla : IComparable<KatUzemieObcanPodlaCisla>
    {
        public KatUzemieObcanPodlaCisla(int cislo, string nazov)
        {
            Cislo = cislo;
            Nazov = nazov;
            StromNehnutelnostiPodlaCisla = new AvlTree<Nehnutelnosti>();
        }

        public int CompareTo(KatUzemieObcanPodlaCisla other)
        {
            return Cislo.CompareTo(other.Cislo);
        }

        public int Cislo { get; set; }
        public string Nazov { get; set; }
        public AvlTree<Nehnutelnosti> StromNehnutelnostiPodlaCisla{ get; set; }
    }
}
