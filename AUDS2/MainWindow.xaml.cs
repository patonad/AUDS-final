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

        public MainWindow()
        {
            InitializeComponent();
            pr = new Program();
            DataContext = pr;

        }
        private void schovaj()
        {
            MenuVyhladaj.Visibility = Visibility.Collapsed;
            MenuPridaj.Visibility = Visibility.Collapsed;
            MenuZmen.Visibility = Visibility.Collapsed;
            MenuOdstran.Visibility = Visibility.Collapsed;
            uloha7.Visibility = Visibility.Collapsed;
            uloha8.Visibility = Visibility.Collapsed;
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

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            uloha7.Visibility = Visibility.Visible;
            
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            hlaska7.Content = "";
            List<NehnutelnostiPodlaC> neh;
            if (TextBox7.Text == "")
            {
                hlaska7.Content = "Nezadal si žiadny kataster";return;
                
            }

            try
            {
                neh = pr.VypisNehnutelPodlaKat(TextBox7.Text);
                lvUloha7.ItemsSource = neh;
                

            }
            catch (Exception exception)
            {
                hlaska7.Content = "Nenašiel sa zadaný kataster";
                neh  = new List<NehnutelnostiPodlaC>();
                lvUloha7.ItemsSource = neh;
                return;
            }

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            uloha8.Visibility = Visibility.Visible;
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Hlaska8.Content = "";
           
            if (TBCUloha8.Text == "")
            {
                Hlaska8.Content = "Nezadal si žiadny číslo katastra"; return;

            }
            if (TBRCUloha8.Text == "")
            {
                Hlaska8.Content = "Nezadal si žiadny rodné číslo"; return;

            }
            try
            {
            }
            catch (Exception exception)
            {
            }
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
            catch (Exception exception)
            {
                Hlaska16.Content = "Uzivatel exzistuje";
            }

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
                pr.PridajListVlasnictva(TBKatUloha17.Text,list);
                Hlaska17.Content = "Ból pridaný záznam";
            }
            catch (Exception exception)
            {
                Hlaska17.Content = "Kataster neexzistuje alebo uz obsahuje takýto list";
                

            }

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha18.Visibility = Visibility.Visible;
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
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
                //pr.Uloha01(sup,kat);
            }
            catch (Exception exception)
            {
                Hlaska1.Content = "Kataster neexzistuje alebosúpisne číslo neexzistuje"; ;
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            schovaj();
            Uloha21.Visibility = Visibility.Visible;

        }

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
            if(!pr.ContainsToUzemiaPodlaCisla(cislo) && !pr.ContainsToUzemiaPodlaNazvu(TBNazUzUloha21.Text)){
                pr.pridajUzemie(TBNazUzUloha21.Text,cislo);
                Hlaska21.Content = "Kataster ból pridaný";
            }
            else
            {
                Hlaska21.Content = "Kataster už exzistuje";
            }
           

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


            }
            else
            {
                Hlaska18.Content = "Nazadal si dáku hodnotu";
            }
        }
    }
}
