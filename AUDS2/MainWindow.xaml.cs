using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AUDS2.KatUzemie;
using AUDS2.Nehnutelnost;
using AVL;

namespace AUDS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Program pr;
        public List<string> podiely { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            pr = new Program();
            DataContext = pr;
            podiely = new List<string>();

        }
        private void schovaj()
        {
            MenuVyhladaj.Visibility = Visibility.Collapsed;
            MenuPridaj.Visibility = Visibility.Collapsed;
            MenuZmen.Visibility = Visibility.Collapsed;
            MenuOdstran.Visibility = Visibility.Collapsed;
            uloha1.Visibility = Visibility.Collapsed;
            uloha2.Visibility = Visibility.Collapsed;
            uloha3.Visibility = Visibility.Collapsed;
            uloha4.Visibility = Visibility.Collapsed;
            uloha5.Visibility = Visibility.Collapsed;
            uloha6.Visibility = Visibility.Collapsed;
            uloha7.Visibility = Visibility.Collapsed;
            uloha8.Visibility = Visibility.Collapsed;
            uloha9.Visibility = Visibility.Collapsed;
            Uloha12.Visibility = Visibility.Collapsed;
            Uloha12p.Visibility = Visibility.Collapsed;
            Uloha16.Visibility = Visibility.Collapsed;
            Uloha17.Visibility = Visibility.Collapsed;
            Uloha18.Visibility = Visibility.Collapsed;
            Uloha21.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            schovaj();
            MenuVyhladaj.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            schovaj();
            MenuPridaj.Visibility = Visibility.Visible;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            schovaj();
            MenuZmen.Visibility = Visibility.Visible;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            schovaj();
            MenuOdstran.Visibility = Visibility.Visible;
        }
      
    
       
      

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha16.Visibility = Visibility.Visible;
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Hlaska16.Content = "";
            Hlaska16.Content = "Nezadal si meno";
            if (TBMenoUloha16.Text == "")
            {
                Hlaska16.Content = "Nezadal si meno";
                return;
            }
            if (TBPriezUloha16.Text == "")
            {
                Hlaska16.Content = "Nezadal si priezvisko";
                return;
            }
            if (TBRCUloha16.Text == "")
            {
                Hlaska16.Content = "Nezadal si rodné číslo";
                return;
            }

            var date = DatumUloha16.SelectedDate;
            if (date == null)
            {
                Hlaska16.Content = "Nezadal si dátum";
                return;
            }

            try
            {
                pr.pridajObcana(TBMenoUloha16.Text,TBPriezUloha16.Text,TBRCUloha16.Text,date);
                Hlaska16.Content = "Užívaťeľ pridaný";
            }
            catch (Exception )
            {
                Hlaska16.Content = "Uzivatel exzistuje";
            }

            Uloha16LW.ItemsSource = pr.getObcania();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha17.Visibility = Visibility.Visible;
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Hlaska17.Content = "";
            if (TBCListuUloha17.Text == "")
            {
                Hlaska17.Content = "Nezadal si čislo listu";
                return;
            }
            if (TBKatUloha17.Text == "")
            {
                Hlaska17.Content = "Nezadal si názov katastra";
                return;
            }
            
            int list;
            
            if (!int.TryParse(TBCListuUloha17.Text, out list))
            {
                Hlaska17.Content = "Zle zadané čislo listu";
                return;
            }

            try
            {
                pr.Uloha17(TBKatUloha17.Text,list);
                Hlaska17.Content = "Ból pridaný záznam";
            }
            catch (Exception )
            {
                Hlaska17.Content = "Kataster neexzistuje alebo uz obsahuje takýto list";
                

            }

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha18.Visibility = Visibility.Visible;
        }
        //Uloha1
        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha1.Visibility = Visibility.Visible;
        }
        //Uloha1
        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            Uloha1LLV.Content = "";
            Uloha1LSC.Content = "";
            Uloha1LA.Content = "";
            Uloha1TB.Text = "";
            Hlaska1.Content = "";
            if (TBSupCIsloUloha1.Text == "")
            {
                Hlaska1.Content = "Nezadal si  súpisné čislo ";
                return;
            }
            if (TBCisloKatUloha1.Text == "")
            {
                Hlaska1.Content = "Nezadal si číslo katastra";
                return;
            }

            int sup, kat;
            if (!int.TryParse(TBSupCIsloUloha1.Text, out sup))
            {
                Hlaska1.Content = "Zle zadané súpisné čislo ";
                return;
            }
            if (!int.TryParse(TBCisloKatUloha1.Text, out kat))
            {
                Hlaska1.Content = "Zle zadané katasrálne čislo ";
                return;
            }
            try
            {
                var pole = pr.Uloha01(sup,kat);
                Uloha1LLV.Content = pole[3];
                Uloha1LSC.Content = pole[0];
                Uloha1LA.Content = pole[1];
                Uloha1TB.Text = pole[2];


            }
            catch (Exception )
            {
                Hlaska1.Content = "Kataster neexzistuje alebosúpisne číslo neexzistuje"; ;
            }
        }
        //Uloha2
        private void Button_Click_26(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha2.Visibility = Visibility.Visible;
        }
        //Uloha2
        private void Button_Click_27(object sender, RoutedEventArgs e)
        {
            Hlaska2.Content = "";
            Uloha2LSC.Content = "";
            Uloha2LA.Content = "";
            Uloha2TBP.Text = "";
            if (Uloha2TBRC.Text == "")
            {
                Hlaska2.Content = "Nezadal si  rodne cislo ";
                return;
            }
            try
            {

                var pole = pr.Uloha02(Uloha2TBRC.Text);
                if (pole[0] == "nic")
                {
                    Hlaska2.Content = "Osoba nema trvaly pobyt";
                   
                    return;
                }
                Uloha2LSC.Content = pole[0];
                Uloha2LA.Content = pole[1];
                Uloha2TBP.Text = pole[2];


            }
            catch (Exception)
            {
                Hlaska2.Content = "Osoba neexzistuje"; ;
            }
        }
        //Uloha03
        private void Button_Click_28(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha3.Visibility = Visibility.Visible;
        }
        //Uloha03
        private void Button_Click_29(object sender, RoutedEventArgs e)
        {
            Hlaska3.Content = "";
            Uloha3LW.ItemsSource = new List<string>();
            if (Uloha3TBK.Text == "")
            {
                Hlaska3.Content = "Nezadal si číslo katastra";
                return;
            }
            if (Uloha3TLV.Text == "")
            {
                Hlaska3.Content = "Nezadal si cislo listu vlasnictva ";
                return;
            }
            if (Uloha3TSC.Text == "")
            {
                Hlaska3.Content = "Nezadal si supisne cislo ";
                return;
            }
            int kat,sup,list;
            if (!int.TryParse(Uloha3TBK.Text, out kat))
            {
                Hlaska3.Content = "Zle zadané čislo katastra";
                return;
            }
            if (!int.TryParse(Uloha3TLV.Text, out list))
            {
                Hlaska3.Content = "Zle zadané čislo listu";
                return;
            }
            if (!int.TryParse(Uloha3TSC.Text, out sup))
            {
                Hlaska3.Content = "Zle zadané supistne čislo ";
                return;
            }

            try
            {
                Uloha3LW.ItemsSource = pr.Uloha3(kat, list, sup);
            }
            catch (Exception )
            {
                Hlaska3.Content = "Zaznam nebol najdeny";
            }



        }
        //Uloha4
        private void Button_Click_30(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha4.Visibility = Visibility.Visible;
        }
        //Uloha4
        private void Button_Click_31(object sender, RoutedEventArgs e)
        {
            Hlaska4.Content = "";
            Uloha4LW.ItemsSource = new List<string>();
            if (Uloha4TBK.Text == "")
            {
                Hlaska4.Content = "Nezadal si číslo katastra";
                return;
            }
            if (Uloha4TLV.Text == "")
            {
                Hlaska4.Content = "Nezadal si cislo listu vlasnictva ";
                return;
            }
           
            int kat,list;
            if (!int.TryParse(Uloha4TBK.Text, out kat))
            {
                Hlaska4.Content = "Zle zadané čislo katastra";
                return;
            }
            if (!int.TryParse(Uloha4TLV.Text, out list))
            {
                Hlaska4.Content = "Zle zadané čislo listu";
                return;
            }
           

            try
            {
                Uloha4LW.ItemsSource = pr.Uloha4(kat, list);
            }
            catch (Exception)
            {
                Hlaska4.Content = "Zaznam nebol najdeny";
            }

        }
        //Uloha5
        private void Button_Click_32(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha5.Visibility = Visibility.Visible;
        }
        //Uloha5
        private void Button_Click_33(object sender, RoutedEventArgs e)
        {
            Uloha5LLV.Content = "";
            Uloha5LSC.Content = "";
            Uloha5LA.Content = "";
            Uloha5TB.Text = "";
            Hlaska5.Content = "";
            if (TBSupCIsloUloha5.Text == "")
            {
                Hlaska5.Content = "Nezadal si  súpisné čislo ";
                return;
            }
            if (TBCisloKatUloha5.Text == "")
            {
                Hlaska5.Content = "Nezadal si nazov katastra";
                return;
            }

            int sup;
            if (!int.TryParse(TBSupCIsloUloha5.Text, out sup))
            {
                Hlaska5.Content = "Zle zadané súpisné čislo ";
                return;
            }
            try
            {
                var pole = pr.Uloha05(sup, TBCisloKatUloha5.Text);
                Uloha5LLV.Content = pole[3];
                Uloha5LSC.Content = pole[0];
                Uloha5LA.Content = pole[1];
                Uloha5TB.Text = pole[2];


            }
            catch (Exception)
            {
                Hlaska5.Content = "Nenajdeny zaznam"; ;
            }
        }
        //Uloha6
        private void Button_Click_35(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha6.Visibility = Visibility.Visible;
        }
        //uloha6
        private void Button_Click_34(object sender, RoutedEventArgs e)
        {
            Hlaska6.Content = "";
            Uloha6LW.ItemsSource = new List<string>();
            if (Uloha6TBK.Text == "")
            {
                Hlaska6.Content = "Nezadal si nazov katastra";
                return;
            }
            if (Uloha6TLV.Text == "")
            {
                Hlaska6.Content = "Nezadal si cislo listu vlasnictva ";
                return;
            }

            int list;
            if (!int.TryParse(Uloha6TLV.Text, out list))
            {
                Hlaska6.Content = "Zle zadané čislo listu";
                return;
            }


            try
            {
                Uloha6LW.ItemsSource = pr.Uloha6(Uloha6TBK.Text, list);
            }
            catch (Exception)
            {
                Hlaska6.Content = "Zaznam nebol najdeny";
            }
        }
        //uloha7
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha7.Visibility = Visibility.Visible;

        }
        //Uloha7
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            hlaska7.Content = "";
            
            if (TextBox7.Text == "")
            {
                hlaska7.Content = "Nezadal si žiadny kataster"; return;

            }

            try
            {
                List<string> list;
                list = pr.Uloha7(TextBox7.Text);
                Uloha7LW.ItemsSource = list;


            }
            catch (Exception)
            {
                hlaska7.Content = "Nenašiel sa zadaný kataster";
                List<string> list = new List<string>();
                Uloha7LW.ItemsSource = list;
                return;
            }

        }
        //uloha8
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha8.Visibility = Visibility.Visible;
        }
        //Uloha8
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Hlaska8.Content = "";

            if (Uloha8TBkat.Text == "")
            {
                Hlaska8.Content = "Nezadal si žiadny číslo katastra"; return;

            }
            if (Uloha8TBRC.Text == "")
            {
                Hlaska8.Content = "Nezadal si žiadny rodné číslo"; return;

            }

            int kat;

            if (!int.TryParse(Uloha8TBkat.Text, out kat))
            {
                Hlaska17.Content = "Zle zadané čislo katastra";
                return;
            }

            try
            {
                Uloha8LW.ItemsSource = pr.Uloha8(Uloha8TBRC.Text, kat);
            }
            catch (Exception)
            {
                Hlaska8.Content = "Nehnutelnosť nebola najdená";
            }
        }
        //Uloha9
        private void Button_Click_36(object sender, RoutedEventArgs e)
        {
            schovaj();
            uloha9.Visibility = Visibility.Visible;
        }
        //Uloha9
        private void Button_Click_37(object sender, RoutedEventArgs e)
        {
            Hlaska9.Content = "";
            
            if (Uloha9TBRC.Text == "")
            {
                Hlaska9.Content = "Nezadal si žiadny rodné číslo"; return;

            }

            try
            {
                Uloha9LW.ItemsSource = pr.Uloha9(Uloha9TBRC.Text);
            }
            catch (Exception)
            {
                Hlaska9.Content = "Nehnutelnosť nebola najdená";
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)


        {
            schovaj();
            Uloha21.Visibility = Visibility.Visible;
            Uloha21LW.ItemsSource = pr.getKatUzemia();

        }
        //uloha 21
        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            
            if (TBCisUzUloha21.Text == "")
            {
                Hlaska21.Content = "Nezadal si číslo katastra";
                return;
            }
            Hlaska21.Content = "";
            if (TBNazUzUloha21.Text == "")
            {
                Hlaska21.Content = "Nezadal si názov katastra ";
                return;
            }
            int cislo;
            if (!int.TryParse(TBCisUzUloha21.Text, out cislo))
            {
                Hlaska21.Content = "Zle zadané čislo katastra";
                return;
            }
            Hlaska21.Content = pr.Uloha21(TBNazUzUloha21.Text, cislo);
            Uloha21LW.ItemsSource = pr.getKatUzemia();
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (Uloha18TBAdresa.Text != "" && Uloha18TBCisloKatastra.Text != "" && Uloha18TBCisloListu.Text != "" &&
                Uloha18TBPopis.Text != "" && Uloha18TBSupCislo.Text != "")
            {
                int list, kat, sup;
                if (!int.TryParse(Uloha18TBCisloListu.Text, out list))
                {
                    Hlaska18.Content = "Zle zadané čislo listu";
                    return;
                }
                if (!int.TryParse(Uloha18TBCisloKatastra.Text, out kat))
                {
                    Hlaska18.Content = "Zle zadané čislo katastra";
                    return;
                }
                if (!int.TryParse(Uloha18TBSupCislo.Text, out sup))
                {
                    Hlaska18.Content = "Zle zadané súpistné čislo";
                    return;
                }

                try
                {
                    pr.Uloha18(sup, Uloha18TBAdresa.Text, Uloha18TBPopis.Text, list, kat);
                    Hlaska18.Content = "Nehnutelnosť bola pridaná";
                }
                catch (Exception )
                {
                    Hlaska18.Content = "Nehnutelnosť nebola pridaná";
                }
           
            }
            else
            {
                Hlaska18.Content = "Nazadal si dáku hodnotu";
            }
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha12.Visibility = Visibility.Visible;
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            if (Uloha12TBCK.Text == "")
            {
                Hlaska12.Content = "Nezadal si číslo katastra";
                return;
            }
            Hlaska12.Content = "";
            if (Uloha12TBCL.Text == "")
            {
                Hlaska12.Content = "Nezadal si číslo listu";
                return;
            }
            int kat,list;
            if (!int.TryParse(Uloha12TBCK.Text, out kat))
            {
                Hlaska12.Content = "Zle zadané čislo katastra";
                return;
            }
            if (!int.TryParse(Uloha12TBCL.Text, out list))
            {
                Hlaska12.Content = "Zle zadané čislo listu";
                return;
            }

            try
            {
                Uloha12LW.ItemsSource = pr.Uloha12VratPodiely(kat, list);
            }
            catch (Exception )
            {
               
            }

        }

        

        private void Button_Click_20(object sender, RoutedEventArgs e)
        {
            if (Uloha12TBPR.Text == "")
            {
                Hlaska12.Content = "Nezadal si Podiel";
                return;
            }
            int kat, list,pod;
            if (!int.TryParse(Uloha12TBCK.Text, out kat))
            {
                Hlaska12.Content = "Zle zadané čislo katastra";
                return;
            }
            if (!int.TryParse(Uloha12TBCL.Text, out list))
            {
                Hlaska12.Content = "Zle zadané čislo listu";
                return;
            }
            if (!int.TryParse(Uloha12TBPR.Text, out pod))
            {
                Hlaska12.Content = "Zle zadané čislo listu";
                return;
            }

            try
            {
                 pr.Uloha12ZmenPodiel(kat, list, Uloha12TBRC.Text, pod);
                 Uloha12LW.ItemsSource = pr.Uloha12VratPodiely(kat, list);

               // podiely.Add(Uloha12TBRC.Text + "/"+ pod);
                //Uloha12LWN.ItemsSource = podiely;
                
            }
            catch (Exception)
            {
                
            }
           

        }

        private void Button_Click_21(object sender, RoutedEventArgs e)
        {
            int sum = 0;
            foreach (var str in podiely)
            {
                var a = str.Split('/');
                sum += Int32.Parse(a[1]);
            }

            if (sum == 100)
            {

            }
            else
            {
                podiely.Clear();
                Uloha12LWN.ItemsSource = podiely;
            }
        }

        private void Button_Click_22(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha12p.Visibility = Visibility.Visible;
        }

        private void Button_Click_23(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_24(object sender, RoutedEventArgs e)
        {
            if (Uloha12pTBCK.Text == "")
            {
                Hlaska12p.Content = "Nezadal si číslo katastra";
                return;
            }
            Hlaska12p.Content = "";
            if (Uloha12pTBCL.Text == "")
            {
                Hlaska12p.Content = "Nezadal si číslo listu";
                return;
            }
            int kat, list;
            if (!int.TryParse(Uloha12pTBCK.Text, out kat))
            {
                Hlaska12p.Content = "Zle zadané čislo katastra";
                return;
            }
            if (!int.TryParse(Uloha12pTBCL.Text, out list))
            {
                Hlaska12p.Content = "Zle zadané čislo listu";
                return;
            }

            try
            {
                Uloha12pLW.ItemsSource = pr.Uloha12VratPodiely(kat, list);
            }
            catch (Exception )
            {

            }
        }

        private void Button_Click_25(object sender, RoutedEventArgs e)
        {
            if (Uloha12pTBPR.Text == "")
            {
                Hlaska12p.Content = "Nezadal si Podiel";
                return;
            }

            int kat, list, pod;
            if (!int.TryParse(Uloha12pTBCK.Text, out kat))
            {
                Hlaska12p.Content = "Zle zadané čislo katastra";
                return;
            }

            if (!int.TryParse(Uloha12pTBCL.Text, out list))
            {
                Hlaska12p.Content = "Zle zadané čislo listu";
                return;
            }

            if (!int.TryParse(Uloha12pTBPR.Text, out pod))
            {
                Hlaska12p.Content = "Zle zadané čislo listu";
                return;
            }

            try
            {
                pr.Uloha12PridajPodiel(kat, list, Uloha12pTBRC.Text, pod);
            }
            catch (Exception )
            {

            }

            Uloha12pLW.ItemsSource = pr.Uloha12VratPodiely(kat, list);

        }
       
    }
}
