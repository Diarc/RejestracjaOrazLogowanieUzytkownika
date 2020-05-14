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

namespace Rejestracja_użytkownika
{
    /// <summary>
    /// Logika interakcji dla klasy WidokAdministratora.xaml
    /// </summary>
    public partial class WidokAdministratora : Window
    {
        public WidokAdministratora()
        {
            InitializeComponent();
        }

        private void PowrótDoLogowania_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
