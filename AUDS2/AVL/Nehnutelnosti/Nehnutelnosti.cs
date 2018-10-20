using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL.Nehnutelnosti
{
    class Nehnutelnosti
    {
        public int SupCislo { get; set; }
        public string Adresa { get; set; }
        public string Popis { get; set; }
        public ListVlastnictva list { get; set; }
    }
}
