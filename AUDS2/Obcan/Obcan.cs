﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.KatUzemie;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2.Obcan
{
    public class Obcan
    {
        public Obcan(string meno, string priezvisko, string rodCislo, DateTime? datNarodenia)
        {
            Meno = meno;
            Priezvisko = priezvisko;
            RodCislo = rodCislo;
            DatNarodenia = datNarodenia;
        }

        public string Meno { get; set; }
        public string Priezvisko { get; set; }
        public string RodCislo { get; set; }
        public DateTime? DatNarodenia { get; set; }
        public Nehnutelnosti TrvalyPobyt { get; set; }
        
    }
}
