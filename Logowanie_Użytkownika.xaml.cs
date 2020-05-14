using Rejestracja_użytkownika.SqlConnect;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Logika interakcji dla klasy Logowanie_Użytkownika.xaml
    /// </summary>
    public partial class Logowanie_Użytkownika : Window
    {
        public Logowanie_Użytkownika()
        {
            InitializeComponent();
        }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        contactClass c = new contactClass();

        int licznikPrób = 0;
        int MaxLiczbaPrób = 3;
        private void Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            if (checkLogin() == false && checkHasło() == false)
            {
                licznikPrób++;
                if (licznikPrób > MaxLiczbaPrób)
                {
                    MessageBox.Show("Osiągnięto maksymalną liczbę prób zalogowania! Wyłącz aplikację i spróbuj zalogować się ponownie.");
                }
            }

            if (checkingAgents() == true)
            {
                Hide();
                new WidokAdministratora().ShowDialog();
                ShowDialog();
            }

            if (checkUser() == true)
            {
                Hide();
                new WidokUżytkownika().ShowDialog();
                ShowDialog();
            }
        }

        bool checkingAgents()
        {
            string Login = TextBox_Loginu.Text;
            string Hasło = txt_Hasło.Password;

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rejestracja_Uzytkownikow where Login = '" + Login + "' and Hasło= '" + Hasło + "' and Rola = 'Admin'" , con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        bool checkUser()
        {
            string Login = TextBox_Loginu.Text;
            string Hasło = txt_Hasło.Password;

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rejestracja_Uzytkownikow where Login = '" + Login + "' and Hasło= '" + Hasło + "' and Rola = 'User'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        bool checkLogin()
        {
            string Login = TextBox_Loginu.Text;

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rejestracja_Uzytkownikow where Login = '" + Login + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        bool checkHasło()
        {
            string Hasło = txt_Hasło.Password;

            bool isSuccess = false;
            SqlConnection con = new SqlConnection(myconnstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Rejestracja_Uzytkownikow where Hasło= '" + Hasło + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                isSuccess = true;
            }
            else
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        private void CofnijDoRejestracji_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
