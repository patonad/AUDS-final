using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AVL
{


    class Kniha : IComparable<Kniha>

    {
        public int cislo;
        public string la;

        public Kniha(int cislo, string la)
        {
            this.cislo = cislo;
            this.la = la;
        }

        public int CompareTo(Kniha obj)
        {
            if (this.cislo == (obj).cislo)
            {
                return 0;
            }
            else if (this.cislo > (obj).cislo)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
