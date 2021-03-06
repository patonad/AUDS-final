﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

        public void Uloha21(string nazov, int cislo)
        {
           var kat = new KatUzemie(cislo,nazov);
                StromKatUzemiPodlaCisla.Insert(new KatUzemiePodlaCisla(kat));
                StromkatUzemiPodlaNazvu.Insert(new KatUzemiePodlaNazvu(kat));
            
        }
        public void Uloha22(int cisloK1, int cisloK2)
        {
            var kat1 = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloK1, "")));
            var kat2 = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloK2, "")));
            foreach (var list in kat1.KatUzemie.StromListovVlastnictvaPodlaCisla)
            {
                foreach (var neh in list.NehnutelnostiNaListe)
                {
                    neh.Cislo = kat2.KatUzemie.MaxNeh + 1;
                    kat2.KatUzemie.PridajMaxNeh(neh.Cislo);
                    kat2.KatUzemie.StromNehnutelnostiPodlaCisla.Insert(neh);
                }

                list.CisloListu = kat2.KatUzemie.MaxList + 1;
                list.Uzemie = kat2.KatUzemie;
                kat2.KatUzemie.PridajMaxList(list.CisloListu);
                kat2.KatUzemie.StromListovVlastnictvaPodlaCisla.Insert(list);
            }
            StromKatUzemiPodlaCisla.Delete(kat1);
            StromkatUzemiPodlaNazvu.Delete(new KatUzemiePodlaNazvu(kat1.KatUzemie));
        }
        
        public List<KatUzemiePodlaNazvu> GetKatUzemia()
        {
            var list = StromkatUzemiPodlaNazvu.InOrder();
            return list;
        }

        public List<Obcan> GetObcania()
        {
            var list = StromObcanoPodlaRc.InOrder();
            return list;
        }

        public void PridanieNeh(int cisloKat)
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
           
           
            //Generuj();
            //Nacitaj();
            //Uloz();
            

            //var katt = new KatUzemie(1, "a");
            //var katt2 = new KatUzemie(2, "b"); // mam

            //var katn = new KatUzemiePodlaNazvu(katt);
            //var katc = new KatUzemiePodlaCisla(katt);
            //var katn2 = new KatUzemiePodlaNazvu(katt2);
            //var katc2 = new KatUzemiePodlaCisla(katt2); //mam

            ////var kato1 = new KatUzemieObcanPodlaCisla(1,"a");
            ////var kato2 = new KatUzemieObcanPodlaCisla(2, "b");
         
            //StromkatUzemiPodlaNazvu.Insert(katn);
            //StromKatUzemiPodlaCisla.Insert(katc);
            //StromkatUzemiPodlaNazvu.Insert(katn2);
            //StromKatUzemiPodlaCisla.Insert(katc2); //mam

            //var obcan = new Obcan("Patrik", "Lahký", "rc", null);
            //var obcan1 = new Obcan("Matej", "Super", "rc1", null);
            //var obcan2 = new Obcan("Fero", "Taky", "rc2", null); //mam

            //var List = new ListVlasnictva(katt, 1);
            //var List2 = new ListVlasnictva(katt, 2);
            //var List3 = new ListVlasnictva(katt2, 1); //mam

            //var neh = new Nehnutelnosti(1, "prva", "prvaneh");
            //var neh2 = new Nehnutelnosti(2, "druha", "druhaNeh");
            //var neh3 = new Nehnutelnosti(1, "tretia", "tretiaNeh"); //mam

            //obcan.TrvalyPobyt = neh;  // mam
            //obcan2.TrvalyPobyt = neh;
            //obcan1.TrvalyPobyt = neh2;

            ////obcan.StromKatUzemi.Insert(kato1);
            ////obcan.StromKatUzemi.Insert(kato2);
            ////obcan1.StromKatUzemi.Insert(kato1);
            ////obcan1.StromKatUzemi.Insert(kato2);
            ////obcan2.StromKatUzemi.Insert(kato1);
            ////obcan2.StromKatUzemi.Insert(kato2);

            //neh.TrvalýPobyt.Insert(obcan); //mam
            //neh.TrvalýPobyt.Insert(obcan2);
            //neh2.TrvalýPobyt.Insert(obcan1);

            //List.Podiely.Insert(new Vlasnik(1, obcan)); //mam
            //List.Podiely.Insert(new Vlasnik(2, obcan1));
            //List.Podiely.Insert(new Vlasnik(3, obcan2));
            //List2.Podiely.Insert(new Vlasnik(1, obcan));
            //List3.Podiely.Insert(new Vlasnik(1, obcan));

            //List.NehnutelnostiNaListe.Insert(neh); //mam
            //neh.ListVlasnictva = List;
            //List.NehnutelnostiNaListe.Insert(neh2);
            //neh2.ListVlasnictva = List;
            //List3.NehnutelnostiNaListe.Insert(neh3);


            ////kato1.StromNehnutelnostiPodlaCisla.Insert(neh);
            ////kato1.StromNehnutelnostiPodlaCisla.Insert(neh2);
            ////kato2.StromNehnutelnostiPodlaCisla.Insert(neh3);

            //obcan.ListyVlasnictva.Add(List); //mam
            //obcan.ListyVlasnictva.Add(List3);
            //obcan1.ListyVlasnictva.Add(List);
            //obcan2.ListyVlasnictva.Add(List);
            //obcan.ListyVlasnictva.Add(List2);

            //StromObcanoPodlaRc.Insert(obcan); //mam
            //StromObcanoPodlaRc.Insert(obcan1);
            //StromObcanoPodlaRc.Insert(obcan2);

            //katt.StromListovVlastnictvaPodlaCisla.Insert(List);
            //katt.StromListovVlastnictvaPodlaCisla.Insert(List2);
            //katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            //katt.StromNehnutelnostiPodlaCisla.Insert(neh2);
            //katt2.StromListovVlastnictvaPodlaCisla.Insert(List3);
            //katt2.StromNehnutelnostiPodlaCisla.Insert(neh3);

            ////neh = new NehnutelnostiPodlaC(new Nehnutelnosti(2, "bb", "dfghj"));
            ////katt.StromNehnutelnostiPodlaCisla.Insert(neh);
            ////neh = new NehnutelnostiPodlaC(new Nehnutelnosti(3, "cc", "dfghj"));
            ////katt.StromNehnutelnostiPodlaCisla.Insert(neh);



        }

        public List<List<String>> Uloha01(int supCislo, int cisloKatastru)
        {
            var nehnutelnost = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKatastru, "")))
                 .GetNehnutelnostPodlaCisla(supCislo);
            var list = nehnutelnost.ListVlasnictva;
            List<List<string>> pole = new List<List<string>>();
            pole.Add(new List<string>{ nehnutelnost.Cislo.ToString(), nehnutelnost.Adresa, nehnutelnost.Popis, list.CisloListu.ToString() });
            pole.Add(new List<string>());
            foreach (var po in list.Podiely)
            {
                pole[1].Add(po.ToString());
            }
            pole.Add(new List<string>());
            foreach (var po in list.NehnutelnostiNaListe)
            {
                pole[2].Add(po.ToString());
            }
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
                KatUzemie.StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null,cisloListu)).NehnutelnostiNaListe.Find(new Nehnutelnosti(supCislo,"",""));
            List<string> pole = new List<string>();
            foreach (var pom in nehnutelnost.TrvalýPobyt)
            {
                pole.Add(pom.ToString());
            }

            return pole;
        }
        public List<List<String>> Uloha4(int cisloKat, int cisloListu)
        {
            var list = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(cisloKat, ""))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, cisloListu));
            List<List<string>> pole = new List<List<string>>();
            pole.Add(new List<string>());
            foreach (var po in list.Podiely)
            {
                pole[0].Add(po.ToString());
            }
            pole.Add(new List<string>());
            foreach (var po in list.NehnutelnostiNaListe)
            {
                pole[1].Add(po.ToString());
            }
            return pole;
        }
        public List<List<String>> Uloha05(int supCislo, string nazovKatastru)
        {
            var nehnutelnost = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, nazovKatastru)))
                .GetNehnutelnostPodlaCisla(supCislo);
            var list = nehnutelnost.ListVlasnictva;

            List<List<string>> pole = new List<List<string>>();
            pole.Add(new List<string> { nehnutelnost.Cislo.ToString(), nehnutelnost.Adresa, nehnutelnost.Popis, list.CisloListu.ToString() });
            pole.Add(new List<string>());
            foreach (var po in list.Podiely)
            {
                pole[1].Add(po.ToString());
            }
            pole.Add(new List<string>());
            foreach (var po in list.NehnutelnostiNaListe)
            {
                pole[2].Add(po.ToString());
            }
            return pole;

        }
        public List<List<String>> Uloha6(string nazovKat, int cisloListu)
        {
            var list = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, nazovKat))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, cisloListu));
            List<List<string>> pole = new List<List<string>>();
            pole.Add(new List<string>());
            foreach (var po in list.Podiely)
            {
                pole[0].Add(po.ToString());
            }
            pole.Add(new List<string>());
            foreach (var po in list.NehnutelnostiNaListe)
            {
                pole[1].Add(po.ToString());
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
                        retList.Add(nehnu.ToString() +"  "+ list.Podiely.Find(new Vlastnik(-1, obcan)).ToString());
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
                    retList.Add(nehnu.ToString() + list.Podiely.Find(new Vlastnik(-1, obcan)).ToString());
                }
            }
            return retList;
        }
        public void Uloha10(string rc,string nazov,int cislo)
        {
            var obcan = StromObcanoPodlaRc.Find(new Obcan("", "", rc, null));
            Nehnutelnosti pomNeh = null;
            if (obcan.TrvalyPobyt != null)
            {
                pomNeh = obcan.TrvalyPobyt;
            }
            var neh = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov))).KatUzemie
                .StromNehnutelnostiPodlaCisla.Find(new Nehnutelnosti(cislo, "", ""));
            obcan.TrvalyPobyt = neh;
            neh.TrvalýPobyt.Insert(obcan);
            if (pomNeh != null)
            {
                pomNeh.TrvalýPobyt.Delete(obcan);
            }

        }
        public void Uloha11(string rc1, int kat, int cislo,string rc2)
        {
            var neh = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromNehnutelnostiPodlaCisla.Find(new Nehnutelnosti(cislo, "", ""));
            var obcan1 = StromObcanoPodlaRc.Find(new Obcan("", "", rc1, null));
            var obcan2 = StromObcanoPodlaRc.Find(new Obcan("", "", rc2, null));
            var list = neh.ListVlasnictva;
            try
            {
                var vlasnik2 = list.Podiely.Find(new Vlastnik(0, obcan2));
                var vlasnik = list.Podiely.Find(new Vlastnik(0, obcan1));
                vlasnik2.Podiel += vlasnik.Podiel;
                obcan1.ListyVlasnictva.Remove(list);
                list.Podiely.Delete(vlasnik);
            }
            catch (Exception)
            {
                var vlsnik = list.Podiely.Find(new Vlastnik(0, obcan1));

                obcan1.ListyVlasnictva.Remove(list);
                list.Podiely.Delete(vlsnik);

                vlsnik.Obcan = obcan2;

                list.Podiely.Insert(vlsnik);
                obcan2.ListyVlasnictva.Add(list);
            }
            
        }
        public void Uloha13(int kat, int clist, string rc)
        {
            var list = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, clist));
            var obcan = StromObcanoPodlaRc.Find(new Obcan("", "", rc, null));
            list.Podiely.Delete(new Vlastnik(0,obcan));
            obcan.ListyVlasnictva.Remove(list);
        }

        public List<string> Uloha15()
        {
            List<string> pole = new List<string>();
            foreach (var pom in StromkatUzemiPodlaNazvu)
            {
                pole.Add(pom.ToString());
            }

            return pole;
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
            var listVl = kat.KatUzemie.StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, list));
            kat.KatUzemie.StromNehnutelnostiPodlaCisla.Insert(neh);
            kat.KatUzemie.PridajMaxNeh(neh.Cislo);
            neh.ListVlasnictva = listVl;
            listVl.NehnutelnostiNaListe.Insert(neh);
            listVl.PridajMax(cislo);
        }

        public void Uloha12ZmenPodiel(int kat,int list, string rc, int pod)
        {
            var listt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, list));
            listt.Podiely.Find(new Vlastnik(0, new Obcan("", "", rc, null))).Podiel = pod;
        }
       

        public void Uloha12PridajPodiel(int kat, int list, string rc, int pod)
        {
            var listt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, list));

            var ob = StromObcanoPodlaRc.Find(new Obcan("","",rc,null));
            listt.Podiely.Insert(new Vlastnik(pod,ob));
            ob.ListyVlasnictva.Add(listt);
            
        }

      

        public List<string> Uloha12VratPodiely(int kat,int cisloListu)
        {
            List<string> retList = new List<string>();
            var list = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, ""))).KatUzemie
                .StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, cisloListu));
            foreach (var vlasnik in list.Podiely)
            {
                retList.Add(vlasnik.ToString());
            }

            return retList;
        }

        public void Uloha17(string nazov,int cislo)
        {
            var kat = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(-1, nazov)));
            var list = new ListVlastnictva(kat.KatUzemie, cislo);
            kat.KatUzemie.StromListovVlastnictvaPodlaCisla.Insert(list);
            kat.KatUzemie.PridajMaxList(list.CisloListu);
        }

        public void Uloha19(int list1, int list2, int kat)
        {
            var katt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, "")));
            var listt1 = katt.GetListVlasnictvaPodlaCisla(list1);
            var listt2 = katt.GetListVlasnictvaPodlaCisla(list2);
            if (listt2.MAX != 0)
            {
                throw new System.Exception("List nieje prazdny");
            }
            katt.KatUzemie.StromListovVlastnictvaPodlaCisla.Delete(listt1);
            katt.KatUzemie.StromListovVlastnictvaPodlaCisla.Delete(listt2);
            listt1.CisloListu = list2;
            katt.KatUzemie.StromListovVlastnictvaPodlaCisla.Insert(listt1);
        }
        public void Uloha20(int list, int sup, int kat)
        {
            var katt = StromKatUzemiPodlaCisla.Find(new KatUzemiePodlaCisla(new KatUzemie(kat, "")));
            var listt = katt.GetListVlasnictvaPodlaCisla(list);
            var neh = listt.NehnutelnostiNaListe.Find(new Nehnutelnosti(sup, "", ""));
            listt.NehnutelnostiNaListe.Delete(neh);
            katt.KatUzemie.StromNehnutelnostiPodlaCisla.Delete(neh);
            foreach (var obcan in neh.TrvalýPobyt)
            {
                obcan.TrvalyPobyt = null;
            }
        }

        public void PridajObcana(string meno, string priezvisko, string rc, DateTime? datum)
        {
            StromObcanoPodlaRc.Insert(new Obcan(meno,priezvisko,rc,datum));
        }

        public void Generuj()
        {
            Random ran = new Random(1);
            string[] mena = new string[]
            {
                "Jakub","Adam","Samuel","Michal","Tomáš","Martin","Filip","Oliver","Matej","Matúš","Lukáš"
            };
            string[] priezviska = new string[]
            {
                "Horváth","Kováč","Varga","Tóth","Bednár","Szabó","Molnár","Balog","Lukáč","Slovák","Kučera"
            };
            List<Obcan> obcania = new List<Obcan>();
            for (int i = 0; i < 30000; i++)  //kolko obcanov
            {
                var ob = new Obcan(mena[ran.Next(0, mena.Length)], priezviska[ran.Next(0, priezviska.Length)],
                    i.ToString(), DateTime.Now.Date);
                StromObcanoPodlaRc.Insert(ob);
                obcania.Add(ob);
            }
            List<KatUzemie> katastre = new List<KatUzemie>();
            List<ListVlastnictva> listyVsetky = new List<ListVlastnictva>();
            List<Nehnutelnosti> nehnutelnostVsetky = new List<Nehnutelnosti>();
            for (int i = 0; i < 20; i++) //katastre
            {
                var kat =new KatUzemie(i,"Kataster"+i);
                StromKatUzemiPodlaCisla.Insert(new KatUzemiePodlaCisla(kat));
                StromkatUzemiPodlaNazvu.Insert(new KatUzemiePodlaNazvu(kat));
                katastre.Add(kat);
                List<ListVlastnictva> listy = new List<ListVlastnictva>();
                for (int j = 0; j < 1000; j++) // listy vlasnictva
                {
                    var list = new ListVlastnictva(kat, j);
                    kat.StromListovVlastnictvaPodlaCisla.Insert(list);
                    kat.PridajMaxList(list.CisloListu);
                    listy.Add(list);
                    listyVsetky.Add(list);
                }
                List<Nehnutelnosti> nehnutelnost = new List<Nehnutelnosti>();
                for (int j = 0;j < 1500; j++) //nehnutelnosti
                {
                    var neh = new Nehnutelnosti(j, "adresa" + j, "popis" + j+" kataster" + i);
                    nehnutelnost.Add(neh);
                    nehnutelnostVsetky.Add(neh);
                }
                for (int j = 0; j < nehnutelnost.Count; j++) // priradenie na list
                {
                    var neh = nehnutelnost[j];
                    var list = listy[ran.Next(0, listy.Count)];
                    list.PridajMax(neh.Cislo);
                    list.NehnutelnostiNaListe.Insert(neh);
                    neh.ListVlasnictva = list;
                }
            }
            for (int i = 0; i < obcania.Count; i++) //trvaly pobyt
            {
                var ob = obcania[i];
                if (ran.Next(0, 10) > -1)
                {

                    var neh = nehnutelnostVsetky[ran.Next(0, nehnutelnostVsetky.Count)];
                    ob.TrvalyPobyt = neh;
                    neh.TrvalýPobyt.Insert(ob);
                }

                if (ran.Next(0, 10) > -1)
                {
                    var list = listyVsetky[ran.Next(0, listyVsetky.Count)];
                    while (list.NehnutelnostiNaListe.Root == null)
                    {
                        list = listyVsetky[ran.Next(0, listyVsetky.Count)];
                    }// pridanie vlasnika
                    list.Podiely.Insert(new Vlastnik(ran.Next(0, 10), ob));
                    ob.ListyVlasnictva.Add(list);
                }
            }
            foreach (var kat in katastre)
            {
                foreach (var list in kat.StromListovVlastnictvaPodlaCisla)
                {
                    foreach (var VARIABLE in list.NehnutelnostiNaListe)
                    {
                        kat.StromNehnutelnostiPodlaCisla.Insert(VARIABLE);
                        kat.PridajMaxNeh(VARIABLE.Cislo);
                    }
                }

            }


            /*

            List<ListVlastnictva>listy =new List<ListVlastnictva>();
            for (int i = 0; i < 5000; i++) // listy vlasnictva
            {
                var kat = katastre[ran.Next(0, katastre.Count)];
                var list = new ListVlastnictva(kat,i);
                kat.StromListovVlastnictvaPodlaCisla.Insert(list);
                kat.PridajMaxList(list.CisloListu);
                listy.Add(list);
            }
            List<Nehnutelnosti> nehnutelnost =new List<Nehnutelnosti>();
            for (int i = 0; i < 10000; i++) //nehnutelnosti
            {
                var neh = new Nehnutelnosti(i,"adresa"+i,"popis"+i);
                nehnutelnost.Add(neh);
            }
                   
            for (int i = 0; i < obcania.Count; i++) //trvaly pobyt
            {
                var ob = obcania[i];
                if (ran.Next(0, 10) > -1)
                {
                    
                    var neh = nehnutelnost[ran.Next(0, nehnutelnost.Count)];
                    ob.TrvalyPobyt = neh;
                    neh.TrvalýPobyt.Insert(ob);
                }

                if (ran.Next(0, 10) > -1)
                {
                    var list = listy[ran.Next(0, listy.Count)]; // pridanie vlasnika
                    list.Podiely.Insert(new Vlastnik(ran.Next(0, 10), ob));
                    ob.ListyVlasnictva.Add(list);
                }
            }

            for (int i = 0; i < nehnutelnost.Count; i++) // priradenie na list
            {
                var neh = nehnutelnost[i];
                var list = listy[ran.Next(0, listy.Count)];
                if (list.Podiely.Root != null)
                {
                    list.PridajMax(neh.Cislo);
                    list.NehnutelnostiNaListe.Insert(neh); 
                    neh.ListVlasnictva =  list;
                }
                
            }

            foreach (var kat in katastre)
            {
                foreach (var list in kat.StromListovVlastnictvaPodlaCisla)
                {
                    foreach (var VARIABLE in list.NehnutelnostiNaListe)
                    {
                        kat.StromNehnutelnostiPodlaCisla.Insert(VARIABLE);
                        kat.PridajMaxNeh(VARIABLE.Cislo);
                    }
                }

            }
          */
        }

        public void Nacitaj()
        {
            StreamReader srObcan = new StreamReader("Obcan.csv");
            StreamReader srNeh = new StreamReader("nehnutelnost.csv");
            StreamReader srList = new StreamReader("listVlasnictva.csv");
            StreamReader srKat = new StreamReader("katastre.csv");
            StreamReader srVla = new StreamReader("vlasnici.csv");

            while (!srKat.EndOfStream)
            {
                var lineA = srKat.ReadLine().Split(';');
                var kat = new KatUzemie(Int32.Parse(lineA[1]), lineA[0]);
                StromKatUzemiPodlaCisla.Insert(new KatUzemiePodlaCisla(kat));
                StromkatUzemiPodlaNazvu.Insert(new KatUzemiePodlaNazvu(kat));
                for (int i = 2; i < lineA.Length; i++)
                {
                    var list = new ListVlastnictva(kat, Int32.Parse(lineA[i]));
                    kat.StromListovVlastnictvaPodlaCisla.Insert(list);
                    kat.PridajMaxList(list.CisloListu);
                }
            }

            while (!srObcan.EndOfStream)
            {
                var lineA = srObcan.ReadLine().Split(';');
                var datum = lineA[3].Split(' ');
                 
                StromObcanoPodlaRc.Insert(new Obcan(lineA[0], lineA[1], lineA[2],
                    new DateTime(Int32.Parse(datum[2].Replace('.',' ')), Int32.Parse(datum[1].Replace('.', ' ')), (Int32.Parse(datum[0].Replace('.', ' '))))));
            }

            KatUzemie katr = null;
            while (!srNeh.EndOfStream)
            {
                var lineA = srNeh.ReadLine().Split(';');
                if (katr == null)
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                if (katr.Nazov != lineA[0])
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                var neh = new Nehnutelnosti(Int32.Parse(lineA[1]), lineA[2], lineA[3]);
                katr.StromNehnutelnostiPodlaCisla.Insert(neh);
                katr.PridajMaxNeh(neh.Cislo);
                for (int i = 4; i < lineA.Length; i++)
                {
                    var ob = StromObcanoPodlaRc.Find(new Obcan("", "", lineA[i], null));
                    ob.TrvalyPobyt = neh;
                    neh.TrvalýPobyt.Insert(ob);
                }


            }

            while (!srList.EndOfStream)
            {
                var lineA = srList.ReadLine().Split(';');
                if (katr == null)
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                if (katr.Nazov != lineA[0])
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                var list = katr.StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, Int32.Parse(lineA[1])));
                for (int i = 2; i < lineA.Length; i++)
                {
                    var neh = katr.StromNehnutelnostiPodlaCisla.Find(new Nehnutelnosti(Int32.Parse(lineA[i]), "", ""));
                    list.NehnutelnostiNaListe.Insert(neh);
                    neh.ListVlasnictva = list;
                    list.PridajMax(neh.Cislo);
                }
               

            }

            while (!srVla.EndOfStream)
            {
                var lineA = srVla.ReadLine().Split(';');
                if (katr == null)
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                if (katr.Nazov != lineA[0])
                {
                    katr = StromkatUzemiPodlaNazvu.Find(new KatUzemiePodlaNazvu(new KatUzemie(0, lineA[0]))).KatUzemie;
                }

                var list = katr.StromListovVlastnictvaPodlaCisla.Find(new ListVlastnictva(null, Int32.Parse(lineA[1])));
                for (int i = 2; i < lineA.Length; i++)
                {
                    var ob = StromObcanoPodlaRc.Find(new Obcan("", "", lineA[i], null));
                    i++;
                    list.Podiely.Insert(new Vlastnik(Int32.Parse(lineA[i]), ob));
                    ob.ListyVlasnictva.Add(list);
                }


            }
        }

        public void Uloz()
        {
            StringBuilder sbo = new StringBuilder();
            foreach (var obcan in StromObcanoPodlaRc)
            {
                string s = obcan.Meno + ";" + obcan.Priezvisko + ";" + obcan.RodCislo + ";" + obcan.DatNarodenia;

                foreach (var list in obcan.ListyVlasnictva)
                {
                    s +=(";" + list.CisloListu + ";" + list.Uzemie.Nazov);
                }

                sbo.AppendLine(s);
            }
            File.WriteAllText("Obcan.csv", sbo.ToString());
            var i = 0;
            
            StringBuilder sbn = new StringBuilder();
            foreach (var kat in StromKatUzemiPodlaCisla)
            {
                foreach (var neh in kat.KatUzemie.StromNehnutelnostiPodlaCisla)
                {
                    string s = kat.KatUzemie.Nazov;
                    s += ";" + neh.Cislo + ";" + neh.Adresa + ";" + neh.Popis;
                    foreach (var VARIABLE in neh.TrvalýPobyt)
                    {
                        s += ";" + VARIABLE.RodCislo;
                    }

                    sbn.AppendLine(s);
                    i++;
                }
            }
            File.WriteAllText("nehnutelnost.csv", sbn.ToString());

            StringBuilder sbl = new StringBuilder();
            StringBuilder sbv = new StringBuilder();


            foreach (var kat in StromKatUzemiPodlaCisla)
            {
                
                foreach (var list in kat.KatUzemie.StromListovVlastnictvaPodlaCisla)
                {
                    string sl = kat.KatUzemie.Nazov;
                    string sv = kat.KatUzemie.Nazov;
                    sl += ";" + list.CisloListu;
                    sv += ";" + list.CisloListu;
                    foreach (var neh in list.NehnutelnostiNaListe)
                    {
                        sl += ";" + neh.Cislo;
                    }

                    foreach (var vlasnik in list.Podiely)
                    {
                        sv += ";" + vlasnik.Obcan.RodCislo + ";" + vlasnik.Podiel;
                    }
                    sbl.AppendLine(sl);
                    sbv.AppendLine(sv);

                }
                


            }
            
            File.WriteAllText("listVlasnictva.csv", sbl.ToString());
            File.WriteAllText("vlasnici.csv", sbv.ToString());

            StringBuilder sb = new StringBuilder();
            foreach (var kat in StromKatUzemiPodlaCisla)
            {
                string s = kat.KatUzemie.Nazov + ";" + kat.KatUzemie.Cislo;
                foreach (var list in kat.KatUzemie.StromListovVlastnictvaPodlaCisla)
                {
                  s += ";"+list.CisloListu;
                }

                sb.AppendLine(s);
            }
            File.WriteAllText("katastre.csv",sb.ToString());

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
