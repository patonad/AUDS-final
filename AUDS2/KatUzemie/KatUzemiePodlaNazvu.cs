using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUDS2.ListVlasnictva;
using AUDS2.Nehnutelnost;

namespace AUDS2.KatUzemie
{
    public class KatUzemiePodlaNazvu : IComparable<KatUzemiePodlaNazvu>
    {
        public KatUzemie KatUzemie { get; set; }
        public KatUzemiePodlaNazvu(KatUzemie kat)
        {
            KatUzemie = kat;
        }

        public int CompareTo(KatUzemiePodlaNazvu other)
        {
            return KatUzemie.Nazov.CompareTo(other.KatUzemie.Nazov);
        }
        public KatUzemie GetKatastralneUzemie()
        {
            return KatUzemie;
        }

        public Nehnutelnosti GetNehnutelnostPodlaCisla(int cislo)
        {
            return KatUzemie.StromNehnutelnostiPodlaCisla.Find(
                new NehnutelnostiPodlaC(new Nehnutelnosti(cislo, "", ""))).Nehnutelnost;
        }

        public ListVlasnictva.ListVlasnictva GetListVlasnictvaPodlaCisla(int cislo)
        {
            return KatUzemie.StromListovVlasnictvaPodlaCisla.Find(
                new ListVlasnictvaPodlaC(new ListVlasnictva.ListVlasnictva(null, cislo))).ListVlasnictva;
        }
    }
}
