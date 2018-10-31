using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using AUDS2.KatUzemie;
using AUDS2.ListVlasnictva;
using AUDS2.Nehnutelnost;
using AUDS2.Obcan;


namespace AVL
{
    public class Program
    {
        public AvlTree<KatUzemiePodlaNazvu> StromkatUzemiPodlaNazvu { get; set; }
        public AvlTree<KatUzemiePodlaCisla> StromKatUzemiPodlaCisla { get; set; }
        public AvlTree<Obcan> StromObcanoPodlaRc { get; set; }

        public string Uloha21(string nazov, int cislo)
        {
            var kat = new KatUzemie(cislo, nazov);
            if (!StromkatUzemiPodlaNazvu.Contains(new KatUzemiePodlaNazvu(kat)) &&
                !StromKatUzemiPodlaCisla.Contains(new KatUzemiePodlaCisla(kat)))
            {
                StromKatUzemiPodlaCisla.Insert(new KatUzemiePodlaCisla(kat));
                StromkatUzemiPodlaNazvu.Insert(new KatUzemiePodlaNazvu(kat));
                return "Kataster ból pridaný";
            }

            return "Kataster už exzistuje";

        }

        public List<KatUzemiePodlaNazvu> getKatUzemia()
        {
            var list = StromkatUzemiPodlaNazvu.InOrder();
            return list;
        }

        public List<Obcan> getObcania()
        {
            var list = StromObcanoPodlaRc.InOrder();
            return list;
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


            var katt = new KatUzemie(1, "a");
            var katt2 = new KatUzemie(2, "b");

            var katn = new KatUzemiePodlaNazvu(katt);
            var katc = new KatUzemiePodlaCisla(katt);
            var katn2 = new KatUzemiePodlaNazvu(katt2);
            var katc2 = new KatUzemiePodlaCisla(katt2);

            StromkatUzemiPodlaNazvu.Insert(katn);
            StromKatUzemiPodlaCisla.Insert(katc);
            StromkatUzemiPodlaNazvu.Insert(katn2);
            StromKatUzemiPodlaCisla.Insert(katc2);

            var obcan = new Obcan("Patrik", "Lahký", "rc", null);
            var obcan1 = new Obcan("Matej", "Super", "rc1", null);
            var obcan2 = new Obcan("Fero", "Taky", "rc2", null);

            var List = new ListVlasnictva(katt, 1);
            var List2 = new ListVlasnictva(katt, 2);
            var List3 = new ListVlasnictva(katt2, 1);

            var neh = new Nehnutelnosti(1, "prva", "prvaneh");
            var neh2 = new Nehnutelnosti(2, "druha", "druhaNeh");
            var neh3 = new Nehnutelnosti(1, "tretia", "tretiaNeh");

            obcan.TrvalyPobyt = neh;
            obcan2.TrvalyPobyt = neh;
            obcan1.TrvalyPobyt = neh2;

            neh.TrvalýPobyt.Add(obcan);
            neh.TrvalýPobyt.Add(obcan2);
            neh2.TrvalýPobyt.Add(obcan1);

            List.podiely.Insert(new Vlasnik(1, obcan));
            List.podiely.Insert(new Vlasnik(2, obcan1));
            List.podiely.Insert(new Vlasnik(3, obcan2));
            List2.podiely.Insert(new Vlasnik(1, obcan));
            List3.podiely.Insert(new Vlasnik(1, obcan));

            List.NehnutelnostiNaListe.Insert(neh);
            neh.ListVlasnictva = List;
            List.NehnutelnostiNaListe.Insert(neh2);
            neh2.ListVlasnictva = List;
            List3.NehnutelnostiNaListe.Insert(neh3);

            obcan.ListyVlasnictva.Add(List);
            obcan.ListyVlasnictva.Add(List3);
            obcan1.ListyVlasnictva.Add(List);
            obcan2.ListyVlasnictva.Add(List);
            obcan.ListyVlasnictva.Add(List2);

            StromObcanoPodlaRc.Insert(obcan);
            StromObcanoPodlaRc.Insert(obcan1);
            StromObcanoPodlaRc.Insert(obcan2);

            katt.StromListovVlasnictvaPodlaCisla.Insert(List);
            katt.StromListovVlasnictvaPodlaCisla.Insert(List2);
            katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            katt.StromNehnutelnostiPodlaCisla.Insert(neh2);
            katt2.StromListovVlasnictvaPodlaCisla.Insert(List3);
            katt2.StromNehnutelnostiPodlaCisla.Insert(neh3);

            //neh = new NehnutelnostiPodlaC(new Nehnutelnosti(2, "bb", "dfghj"));
            //katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            //neh = new NehnutelnostiPodlaC(new Nehnutelnosti(3, "cc", "dfghj"));
            //katt.StromNehnutelnostiPodlaCisla.Insert(neh);


        }

        public string[] Uloha01(int supCislo, int cisloKatastru)
        {
            var nehnutelnost = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKatastru, "")))
                 .GetNehnutelnostPodlaCisla(supCislo);
            var list = nehnutelnost.ListVlasnictva;
           
            var pole = new[] { nehnutelnost.Cislo.ToString(), nehnutelnost.Adresa, nehnutelnost.Popis, list.CisloListu.ToString() };
            return pole;

        }
        public string [] Uloha02(string rc)
        {
            var obyvatel = StromObcanoPodlaRc.Find(new Obcan("", "", rc, null));
            var nehnutelnost= obyvatel.TrvalyPobyt;
            string[] pole;
            if (nehnutelnost == null)
            {
                pole = new[] {"nic"};
                return pole;
            }

            pole = new[] { nehnutelnost.Cislo.ToString(), nehnutelnost.Adresa, nehnutelnost.Popis};
            return pole;

        }
        public List<string> Uloha3(int cisloKat, int cisloListu, int supCislo)
        {
            var nehnutelnost = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKat, ""))).
                KatUzemie.StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null,cisloListu)).NehnutelnostiNaListe.Find(new Nehnutelnosti(supCislo,"",""));
            List<string> pole = new List<string>();
            foreach (var pom in nehnutelnost.TrvalýPobyt)
            {
                pole.Add(pom.ToString());
            }

            return pole;
        }
        public List<string> Uloha4(int cisloKat, int cisloListu)
        {
            var list = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKat, ""))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, cisloListu));
            List<string> pole = new List<string>();
            foreach (var pom in list.podiely)
            {
                pole.Add(pom.ToString());
            }

            return pole;
        }
        public string[] Uloha05(int supCislo, string nazovKatastru)
        {
            var nehnutelnost = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, nazovKatastru)))
                .GetNehnutelnostPodlaCisla(supCislo);
            var list = nehnutelnost.ListVlasnictva;

            var pole = new[] { nehnutelnost.Cislo.ToString(), nehnutelnost.Adresa, nehnutelnost.Popis, list.CisloListu.ToString() };
            return pole;

        }
        public List<string> Uloha6(string nazovKat, int cisloListu)
        {
            var list = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, nazovKat))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, cisloListu));
            List<string> pole = new List<string>();
            foreach (var pom in list.podiely)
            {
                pole.Add(pom.ToString());
            }

            return pole;
        }
        public List<string> Uloha7(string uzemie)
        {
            List<string> pole = new List<string>();
            var kataster = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, uzemie)));
            foreach (var pom in kataster.KatUzemie.StromNehnutelnostiPodlaCisla)
            {
                pole.Add(pom.ToString());
            }

            return pole;
        }
        public List<string> Uloha8(string rodCislo, int kat)
        {
            List<string> retList = new List<string>();
            var obcan = StromObcanoPodlaRc.Find(new Obcan("", "", rodCislo, null));
            var neh = obcan.ListyVlasnictva;
            foreach (var list in neh)
            {
                if (list.Uzemie.Cislo == kat)
                {
                    foreach (var nehnu in list.NehnutelnostiNaListe)
                    {
                        retList.Add(nehnu.ToString() + list.podiely.Find(new Vlasnik(-1, obcan)).ToString());
                    }
                }
            }

            return retList;
        }
        public List<string> Uloha9(string rodCislo)
        {
            List<string> retList = new List<string>();
            var obcan = StromObcanoPodlaRc.Find(new Obcan("", "", rodCislo, null));
            var neh = obcan.ListyVlasnictva;
            foreach (var list in neh)
            {
                foreach (var nehnu in list.NehnutelnostiNaListe)
                {
                    retList.Add(nehnu.ToString() + list.podiely.Find(new Vlasnik(-1, obcan)).ToString());
                }
            }
            return retList;
        }

        //public List<Nehnutelnosti> uloha8(string rodCislo)
        //{
        //   var obcan = StromObcanoPodlaRc.Find(new Obcan("", "", rodCislo, null));
        //    var neh = obcan.nehnutelnosti.InOrder();
        //    foreach (var pom in neh)
        //    {
        //        if(pom.ListVlasnictva.Uzemie.)
        //    }
        //}



        public void Uloha18(int cislo, string adresa, string popis, int list, int kataster)
        {
            var neh = new Nehnutelnosti(cislo, adresa, popis);
            var kat = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kataster, "")));
            var listVl = kat.KatUzemie.StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, list));
            kat.KatUzemie.StromNehnutelnostiPodlaCisla.Insert(neh);
            listVl.NehnutelnostiNaListe.Insert(neh);
        }

        public void Uloha12ZmenPodiel(int kat,int list, string rc, int pod)
        {
            var listt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, list));
            listt.podiely.Find(new Vlasnik(0, new Obcan("", "", rc, null))).Podiel = pod;
        }
        public void Uloha12ZmenPodiel(int kat, int list, List<string> pod)
        {

            var listt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, list));
            foreach (var p in pod)
            {
                var rc = p.Split('/');
                listt.podiely.Find(new Vlasnik(0, new Obcan("", "", rc[0], null))).Podiel = Int32.Parse(rc[1]);
            }
            
        }

        public void Uloha12PridajPodiel(int kat, int list, string rc, int pod)
        {
            var listt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, list));

            var ob = StromObcanoPodlaRc.Find(new Obcan("","",rc,null));
            listt.podiely.Insert(new Vlasnik(pod,ob));
            ob.ListyVlasnictva.Add(listt);
            
        }

      

        public List<string> Uloha12VratPodiely(int kat,int cisloListu)
        {
            List<string> retList = new List<string>();
            var list = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlasnictvaPodlaCisla.Find(new ListVlasnictva(null, cisloListu));
            foreach (var vlasnik in list.podiely)
            {
                retList.Add(vlasnik.ToString() +"/" +vlasnik.Obcan.RodCislo);
            }

            return retList;
        }

        public void Uloha17(string nazov,int cislo)
        {
            var kat = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov)));
            kat.KatUzemie.StromListovVlasnictvaPodlaCisla.Insert(new ListVlasnictva(kat.KatUzemie,cislo));
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
