using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.ListVlasnictva
{
    public class ListVlasnictvaPodlaCisla : IComparable<ListVlasnictvaPodlaCisla>
    {
        public ListVlasnictvaPodlaCisla(ListVlasnictva listVlasnictva)
        {
            ListVlasnictva = listVlasnictva;
        }

        public ListVlasnictva ListVlasnictva { get; set; }
        public int CompareTo(ListVlasnictvaPodlaCisla other)
        {
            return ListVlasnictva.CisloListu.CompareTo(other.ListVlasnictva.CisloListu);
        }
    }
}
