using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AVL.KatUzemie;
using AVL.Nehnutelnosti;

namespace AVL
{
    class HlavnyProgram
    {
        AvlTree<KatUzemiePodlaCisla> zoznamKatUzemi = new AvlTree<KatUzemiePodlaCisla>();


        public void Spracuj()
        {
            Console.WriteLine("Zadaj co chces robit");
            var a = Console.ReadLine();
            switch (a)
            {
                case "1":
                    Console.WriteLine("Zadaj cislo katastra");
                    int temp;
                    int temp2;
                    if (int.TryParse(Console.ReadLine(), out temp))
                    {
                        if (int.TryParse(Console.ReadLine(), out temp2))
                        {
                            try
                            {
                                var uzemie = zoznamKatUzemi.Find(new KatUzemiePodlaCisla(temp));
                                var nehnutelnost = uzemie.ZoznamNehnutelnosti.Find(new NehnutelnostiPodlaCisla(temp2));
                                Console.WriteLine(nehnutelnost.SupCislo);
                                Console.WriteLine(nehnutelnost.Adresa);
                                Console.WriteLine(nehnutelnost.Popis);
                               // Console.WriteLine(nehnutelnost.list.);

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Zla nehnutelnost");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Zle kat uzemie");
                    }
                    break;

            }
        }

    }
}
