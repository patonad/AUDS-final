
using AVL.Nehnutelnosti;

namespace AVL.KatUzemie
{
    class KatUzemie
    {
        public int Cislo { get; set; }
        public string Nazov { get; set; }

        public AvlTree<NehnutelnostiPodlaCisla> ZoznamNehnutelnosti { get; set; }
        
    }
}
