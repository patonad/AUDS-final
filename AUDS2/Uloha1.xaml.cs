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
using System.Windows.Shapes;
using AVL;

namespace AUDS2
{
    /// <summary>
    /// Interaction logic for Uloha1.xaml
    /// </summary>
    public partial class Uloha1 : Window
    {
        private Program prog;
        public Uloha1(Program pr)
        {
            InitializeComponent();
            prog = pr;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (supCislo.Text == "" && cisUzemia.Text == "")
            {
                hlaska.Content = "Nezadali ste ";
            }


            cislo.Text = "1234";
            adresa.Text = "adr";
            popis.Text ="123cssssssssssssshnhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss4";
        }
    }
}
