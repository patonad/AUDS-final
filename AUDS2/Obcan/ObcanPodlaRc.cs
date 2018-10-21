using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUDS2.Obcan
{
    public class ObcanPodlaRc :IComparable<ObcanPodlaRc>
    {
        public ObcanPodlaRc(Obcan obcan)
        {
            Obcan = obcan;
        }

        public Obcan Obcan { get; set; }

        public int CompareTo(ObcanPodlaRc other)
        {
            return Obcan.RodCislo.CompareTo(other.Obcan.RodCislo);
        }
    }
}
