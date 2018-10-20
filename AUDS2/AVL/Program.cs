using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    public class Program
    {
        void Spusit(string[] args){
            
           

            //AvlTree<Kniha> a = new AvlTree<Kniha>();
            //a.Insert(new Kniha(1,"aa"));
            //a.Insert(new Kniha(2, "bb"));
            //a.Insert(new Kniha(3, "cc"));
            //a.Insert(new Kniha(4, "dd"));
            //a.Insert(new Kniha(5, "ee"));
            //var kniha = a.Find(new Kniha(3, ""));

        }

        public string test2()
        {
            return "Ahoj samo";
        }

        public bool Test()

        {
            Console.WriteLine("ahoj");
            return true;
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine(i);
            //    var a = new AvlTree<int>();
            //    var list = new List<int>();
            //    var rand = new Random();
            //    for (int j = 0; j < 10000; j++)
            //    {

            //        if (rand.Next() % 10 < 7)
            //        {

            //            var c = rand.Next(0, 10000000);
            //            if (!list.Contains(c))
            //            {
            //                a.Insert(c);
            //                list.Add(c);
            //                if (!a.SkontrolujVysku())
            //                {
            //                    return false;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            var c = rand.Next(0, 10000000);
            //            if (list.Contains(c))
            //            {
            //                a.Delete(c);
            //                list.Remove(c);
            //                if (!a.SkontrolujVysku())
            //                {
            //                    return false;
            //                }
            //            }
            //        }
            //    }
            //    list.Sort();
            //    var listIn = a.InOrder();
            //    if (listIn.Count == list.Count)
            //    {
            //        for (int aa = 0; aa < listIn.Count; aa++)
            //        {
            //            if (list[aa] != listIn[aa])
            //            {
            //                return false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return false;
            //    }


            //}
            //return true;


            //Stopwatch w = new Stopwatch();

            //var a = new AvlTree<int>();
            //for (int i = 0; i <= 10000000; i++)
            //{
            //    a.Insert(i);
            //}
            //w.Start();
            //for (int i = 5000000; i >= 0; i--)
            //{
            //    a.Delete(i);
            //}
            //w.Stop();
            //Console.WriteLine(w.Elapsed);
            //return true;


            ////for (int k = 1; k < 200; k++)
            ////{

            //   // Console.WriteLine();
            //  //  Console.WriteLine(k);

            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine(i);
            //        var list = new List<int>();
            //        var rand = new Random(i);
            //        var a = new AvlTree<int>();
            //        for (int j = 0; j < 10000;)
            //        {
            //            //Console.WriteLine(j);
            //            var cislo = rand.Next(0, 10000000);
            //            if (!list.Contains(cislo))
            //            {
            //                a.Insert(cislo);
            //                list.Add(cislo);
            //                j++;
            //            }

            //        }

            //        if (a.SkontrolujVysku() == false)
            //            return false;

            //        var kolko = rand.Next(0, list.Count);
            //        for (int j = 0; j < kolko; j++)
            //        {

            //            // Console.WriteLine(j);
            //            var ktory = rand.Next(0, list.Count - 1);
            //            a.Delete(list[ktory]);
            //            if (a.SkontrolujVysku() == false)
            //                return false;
            //            list.Remove(list[ktory]);
            //        }

            //        var listIn = a.InOrder();
            //        list.Sort();
            //        if (listIn.Count == list.Count)
            //        {
            //            for (int aa = 0; aa < listIn.Count; aa++)
            //            {
            //                if (list[aa] != listIn[aa])
            //                {
            //                    return false;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            return false;
            //        }
            //   // }
            //}

            // return true;
        }
    }
}
