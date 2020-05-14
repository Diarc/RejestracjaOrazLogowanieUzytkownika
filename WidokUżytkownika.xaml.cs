using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy WidokUżytkownika.xaml
    /// </summary>
    public partial class WidokUżytkownika : Window
    {
        static string myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
        public WidokUżytkownika()
        {
            InitializeComponent();
            ComboboxWydarzenia();
            Agenda();
        }

        string[] comboboxWydarzenia = new string[2];
        string[] agenda = new string[2];

        void ComboboxWydarzenia()
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(myconnstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Wydarzenia", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                comboboxWydarzenia[i] = read.GetString(1);
                i++;
            }
            conn.Close();

            ComboBoxNazwyWydarzenia.Items.Add(comboboxWydarzenia[0]);
            ComboBoxNazwyWydarzenia.Items.Add(comboboxWydarzenia[1]);
        }

        void Agenda()
        {
            int i = 0;
            SqlConnection conn = new SqlConnection(myconnstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Wydarzenia", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                agenda[i] = read.GetString(2);
                i++;
            }
            conn.Close();
        }

        private void lostfocus(object sender, System.Windows.RoutedEventArgs e)
        {
            int indeks = ComboBoxNazwyWydarzenia.SelectedIndex;
            indeks = indeks * indeks;
            if ((ComboBoxNazwyWydarzenia.SelectedItem as string) == comboboxWydarzenia[indeks])
            {
                Tb_Agenda.Text = agenda[indeks];
            }
        }

        private void PowrótDoLogowania_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
