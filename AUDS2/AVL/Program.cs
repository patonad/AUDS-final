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
        public AvlTree<KatUzemiePodlaNazvu> StromkatUzemiPodlaNazvu { get; set; }
        public AvlTree<KatUzemiePodlaCisla> StromKatUzemiPodlaCisla{ get; set; }
        public AvlTree<Obcan> StromObcanoPodlaRc { get; set; }

        public void pridajUzemie(string nazov, int cislo)
        {
            var kat = new KatUzemie(cislo,nazov);
            StromKatUzemiPodlaCisla.Insert(new KatUzemiePodlaCisla(kat));
            StromkatUzemiPodlaNazvu.Insert(new KatUzemiePodlaNazvu(kat));
        }

        public void getKatUzemia()
        {
            var list = StromkatUzemiPodlaNazvu.InOrder();
        }

        public void pridanieNeh(int cisloKat)
        {
           var kat = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKat, "")));
           // kat.KatUzemie.
        }

        public bool ContainsToUzemiaPodlaNazvu(string nazov)
        {
            return StromkatUzemiPodlaNazvu.Contains(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov)));
        }
        public bool ContainsToUzemiaPodlaCisla(int cislo)
        {
            return StromKatUzemiPodlaCisla.Contains(new KatUzemiePodlaCisla(new KatUzemie(cislo, "")));
        }

        public Program()
        {
            StromKatUzemiPodlaCisla = new AvlTree<KatUzemiePodlaCisla>();
            StromkatUzemiPodlaNazvu = new AvlTree<KatUzemiePodlaNazvu>();
            StromObcanoPodlaRc = new AvlTree<Obcan>();


            var katt = new KatUzemie(1, "aaa");
            var katn = new KatUzemiePodlaNazvu(katt);
            var katc = new KatUzemiePodlaCisla(katt);
            StromkatUzemiPodlaNazvu.Insert(katn);
            StromKatUzemiPodlaCisla.Insert(katc);
            var neh = new NehnutelnostiPodlaC(new Nehnutelnosti(1, "aa", "dfghj"));
            katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            neh = new NehnutelnostiPodlaC(new Nehnutelnosti(2, "bb", "dfghj"));
            katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            neh = new NehnutelnostiPodlaC(new Nehnutelnosti(3, "cc", "dfghj"));
            katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            
            
        }

        //public string[][] Uloha01(int supCislo, int cisloKatastru)
        //{
        //   var nehnutelnost= StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKatastru,"")))
        //        .GetNehnutelnostPodlaCisla(supCislo);
        //   var list = nehnutelnost.ListVlasnictva;
        //    string[][] pole = new string[3][];
        //    pole[0] =new[] { nehnutelnost.Cislo.ToString(),nehnutelnost.Adresa,nehnutelnost.Popis,list.CisloListu.ToString()}
            
        //    ;


        //}
        public void Uloha02(string rc)
        {
            var obyvatel = StromObcanoPodlaRc.Find(new Obcan("", "", rc, null));
            var trvalyPobyt = obyvatel.TrvalyPobyt;

        }

        public void Uloha3(int cisloKat, int cisloListu, int supCislo)
        {
            var a = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKat, "")))
                .GetNehnutelnostPodlaCisla(supCislo);
            var list = a.TrvalýPobyt;
        }




        public List<NehnutelnostiPodlaC> VypisNehnutelPodlaKat(string uzemie)
        {
            var kataster = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1,uzemie)));
            return kataster.KatUzemie.StromNehnutelnostiPodlaCisla.InOrder();
        }
        public void PridajNehnutelnostNaListVlasnictva(int cislo, string adresa, string popis, int list, int kataster)
        {
            var neh = new NehnutelnostiPodlaC(new Nehnutelnosti(cislo,adresa,popis));
            var kat = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kataster, "")));
            var listVl = kat.KatUzemie.StromListovVlasnictvaPodlaCisla.Find(
                new ListVlasnictvaPodlaC(new ListVlasnictva(null, list)));
          //  listVl.ListVlasnictva.NehnutelnostiNaListe.Insert(neh);
            kat.KatUzemie.StromNehnutelnostiPodlaCisla.Insert(neh);

        }

        public void PridajListVlasnictva(string nazov,int cislo)
        {
            var kat = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov)));
            kat.KatUzemie.StromListovVlasnictvaPodlaCisla.Insert(new ListVlasnictvaPodlaC(new ListVlasnictva(kat.KatUzemie,cislo)));
        }

        public void pridajObcana(string meno, string priezvisko, string rc, DateTime? datum)
        {
            StromObcanoPodlaRc.Insert(new Obcan(meno,priezvisko,rc,datum));
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
