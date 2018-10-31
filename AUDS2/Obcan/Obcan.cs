using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using AUDS2.KatUzemie;
using AUDS2.ListVlasnictva;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2.Obcan
{
    public class Obcan : IComparable<Obcan>
    {
        public Obcan(string meno, string priezvisko, string rodCislo, DateTime? datNarodenia)
        {
            Meno = meno;
            Priezvisko = priezvisko;
            RodCislo = rodCislo;
            DatNarodenia = datNarodenia;
            ListyVlasnictva = new List<ListVlasnictva.ListVlasnictva>();
        }

        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string RodCislo { get; set; }
        public DateTime? DatNarodenia { get; set; }
        public Nehnutelnosti TrvalyPobyt { get; set; }
        public List<ListVlasnictva.ListVlasnictva> ListyVlasnictva { get; set; }
        public int CompareTo(Obcan other)
        {
            return RodCislo.CompareTo(other.RodCislo);
        }

        override public string ToString()
        {

            return "Meno: " + $"{Meno,15}" + "   Priezvisko: " + $"{Priezvisko,15}" + "   Rodné číslo: " + RodCislo;
        }
    }
}
