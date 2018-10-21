using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AUDS2.KatUzemie;
using AUDS2.ListVlasnictva;
using AUDS2.Nehnutelnost;
using AUDS2.Obcan;


namespace AVL
{
    public class Program
    {
        public AvlTree<KatUzemiePodlaNazvu> ZoznamKatUzemiPodlaNazvu { get; set; }
        public AvlTree<KatUzemiePodlaCisla> ZoznamKatUzemiPodlaCisla{ get; set; }
        public AvlTree<ObcanPodlaRc> ZoznamObcanoPodlaRc { get; set; }

        public Program()
        {
            ZoznamKatUzemiPodlaCisla = new AvlTree<KatUzemiePodlaCisla>();
            ZoznamKatUzemiPodlaNazvu = new AvlTree<KatUzemiePodlaNazvu>();
            ZoznamObcanoPodlaRc = new AvlTree<ObcanPodlaRc>();
            var katt = new KatUzemie(1, "aaa");
            var katn = new KatUzemiePodlaNazvu(katt);
            var katc = new KatUzemiePodlaCisla(katt);
            ZoznamKatUzemiPodlaNazvu.Insert(katn);
            ZoznamKatUzemiPodlaCisla.Insert(katc);
            var neh = new NehnutelnostiPodlaCisla(new Nehnutelnosti(1, "aa", "dfghj"));
            katt.ZoznamNehnutelnostiPodlaCisla.Insert(neh);
            neh = new NehnutelnostiPodlaCisla(new Nehnutelnosti(2, "bb", "dfghj"));
            katt.ZoznamNehnutelnostiPodlaCisla.Insert(neh);
            neh = new NehnutelnostiPodlaCisla(new Nehnutelnosti(3, "cc", "dfghj"));
            katt.ZoznamNehnutelnostiPodlaCisla.Insert(neh);
            
            
        }

        public List<NehnutelnostiPodlaCisla> VypisNehnutelPodlaKat(string uzemie)
        {
            var kataster = ZoznamKatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1,uzemie)));
            return kataster.KatUzemie.ZoznamNehnutelnostiPodlaCisla.InOrder();
        }
        public void PridajNehnutelnostNaListVlasnictva(int cislo, string adresa, string popis, int list, int kataster)
        {
            var neh = new NehnutelnostiPodlaCisla(new Nehnutelnosti(cislo,adresa,popis));
            var kat = ZoznamKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kataster, "")));
            var listVl = kat.KatUzemie.ZoznamListovVlasnictvaPodlaCisla.Find(
                new ListVlasnictvaPodlaCisla(new ListVlasnictva(null, list)));
            listVl.ListVlasnictva.NehnutelnostiNaListe.Insert(neh);
            kat.KatUzemie.ZoznamNehnutelnostiPodlaCisla.Insert(neh);

        }

        public void PridajListVlasnictva(string nazov,int cislo)
        {
            var kat = ZoznamKatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov)));
            kat.KatUzemie.ZoznamListovVlasnictvaPodlaCisla.Insert(new ListVlasnictvaPodlaCisla(new ListVlasnictva(kat.KatUzemie,cislo)));
        }

        public void pridajObcana(string meno, string priezvisko, string rc, DateTime? datum)
        {
            ZoznamObcanoPodlaRc.Insert(new ObcanPodlaRc(new Obcan(meno,priezvisko,rc,datum)));
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
