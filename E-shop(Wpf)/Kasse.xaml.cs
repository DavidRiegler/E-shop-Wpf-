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

namespace Wpf_E_shop
{
    /// <summary>
    /// Interaktionslogik für Kasse.xaml
    /// </summary>
    public partial class Kasse : Window
    {
        public Kasse()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Vielen Dank für ihre Bestellung! \nAuf Wiedersehen");
            Close();
        }
    }
}
