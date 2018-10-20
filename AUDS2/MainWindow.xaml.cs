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



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            //samo.Content = pr.test2();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Uloha1 win = new Uloha1(pr);
            win.ShowDialog();
        }
    }
}
