using System;


namespace AVL.KatUzemie
{
    class KatUzemiePodlaCisla : KatUzemie,IComparable<KatUzemiePodlaCisla>
    {
        public KatUzemiePodlaCisla(int cislo, string nazov = "") 
        {
            Cislo = cislo;
            Nazov = nazov;

        }

        public int CompareTo(KatUzemiePodlaCisla other)
        {
            return Cislo.CompareTo(other.Cislo);
            
        }
    }
}
