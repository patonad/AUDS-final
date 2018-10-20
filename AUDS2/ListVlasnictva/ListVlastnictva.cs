using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    class ListVlastnictva
    {
        public KatUzemie.KatUzemie KatUzemie{ get; set; }
        public int Cislo { get; set; }
        public List<Nehnutelnosti.Nehnutelnosti> ListNehnutelnosti { get; set; }
        public Dictionary<Obcan,int> Type { get; set; }
    }
}
