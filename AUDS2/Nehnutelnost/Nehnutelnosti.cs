﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVL;

namespace AUDS2.Nehnutelnost
{
    public class Nehnutelnosti : IComparable<Nehnutelnosti>
    {
        public Nehnutelnosti(int cislo, string adresa, string popis)
        {
            Cislo = cislo;
            Adresa = adresa;
            Popis = popis;
            TrvalýPobyt =new AvlTree<Obcan.Obcan>();
        }
        public int CompareTo(Nehnutelnosti other)
        {
            return Cislo.CompareTo(other.Cislo);
        }
        public int Cislo { get; set; }
        public string Adresa { get; set; }
        public string Popis { get; set; }
        public AvlTree<Obcan.Obcan> TrvalýPobyt { get; set; }
        public ListVlasnictva.ListVlastnictva ListVlasnictva { get; set; }
        public override string ToString()
        {
            return "Číslo: " + $"{Cislo,8}" + "  Adresa: " + $"{Adresa,15}" + "  Popis: " + $"{Popis,8}";
        }

    }
}
