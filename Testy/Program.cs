using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVL;

namespace Testy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Test3());
            Console.ReadLine();

        }

        public static bool Test3()
        {
            for (int i = 0; i < 100; i++) // kolko trestov s inou nasadou
            {
                Console.WriteLine();
                Console.WriteLine(i);
                var list = new List<int>();
                var rand = new Random(i);
                var a = new AvlTree<int>();
                for (int j = 0; j < 1000;)  // kolko prvkov sa ma vlozit
                {
                    //Console.WriteLine(j);
                    var cislo = rand.Next(0, 10000000);
                    if (!list.Contains(cislo))
                    {
                        a.Insert(cislo);
                        list.Add(cislo);
                        j++;
                    }

                }

                if (a.SkontrolujVysku() == false)
                    return false;

                var kolko = rand.Next(0, list.Count); // kolko prvkov sa ma odstranit
                for (int j = 0; j < kolko; j++)
                {

                    // Console.WriteLine(j);
                    var ktory = rand.Next(0, list.Count - 1);
                    a.Delete(list[ktory]);
                    if (a.SkontrolujVysku() == false)
                        return false;
                    list.Remove(list[ktory]);
                }

                var listIn = a.InOrder();
                list.Sort();
                if (listIn.Count == list.Count)
                {
                    for (int aa = 0; aa < listIn.Count; aa++)
                    {
                        if (list[aa] != listIn[aa])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Test2()
        {

            var a = new AvlTree<int>();
            for (int i = 0; i <= 100; i++)
            {
                a.Insert(i);
            }

            foreach (var VARIABLE in a)
            {
                Console.WriteLine(VARIABLE);
            }
           
            return true;
        }

        public static bool Test()
        {
            for (int i = 0; i < 100; i++)  // kolko testov
            {
                Console.WriteLine(i);
                var a = new AvlTree<int>();
                var list = new List<int>();
                var rand = new Random();
                for (int j = 0; j < 10000; j++)  // kolko operacii
                {

                    if (rand.Next() % 10 < 7)
                    {

                        var c = rand.Next(0, 10000000);
                        if (!list.Contains(c))
                        {
                            a.Insert(c);
                            list.Add(c);
                            if (j % 1000 == 0)
                            {
                                if (!a.SkontrolujVysku())
                                {
                                    return false;
                                }
                            }
                        }
                            
                    }
                    else
                    {
                        var c = rand.Next(0, 10000000);
                        if (list.Contains(c))
                        {
                            a.Delete(c);
                            list.Remove(c);
                            if (j % 1000 == 0)
                            {
                                if (!a.SkontrolujVysku())
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                list.Sort();
                var listIn = a.InOrder();
                if (listIn.Count == list.Count)
                {
                    for (int aa = 0; aa < listIn.Count; aa++)
                    {
                        if (list[aa] != listIn[aa])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;

        }
    }
}
