using Rejestracja_użytkownika.SqlConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Rejestracja_użytkownika
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        contactClass c = new contactClass();

        private void Tb_imienia_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_imienia.Text.Length > 0)
            {
                string firstLetter = Tb_imienia.Text[0].ToString();

                if (firstLetter == firstLetter.ToUpper() && (String.IsNullOrEmpty(firstLetter) == false))
                {
                    if (Tb_imienia.Text.Length >= 2)
                    {
                        var sum = 0;
                        for (int i = 0; i < Tb_imienia.Text.Length; i++)
                        {
                            string lowerLetters = Tb_imienia.Text[i].ToString();

                            if (lowerLetters == lowerLetters.ToLower())
                            {
                                sum = sum + 1;
                            }
                        }

                        if (sum + 1 == Tb_imienia.Text.Length)
                        {
                            var sumS = 0;
                            for (int i = 0; i < Tb_imienia.Text.Length; i++)
                            {
                                string whiteSpace = Tb_imienia.Text[i].ToString();
                                bool isWhiteSpace = String.IsNullOrWhiteSpace(whiteSpace);
                                if (isWhiteSpace == true)
                                {
                                    sumS = sumS + 1;
                                }
                            }
                            if (sumS > 0)
                            {
                                tBlock_imienia.Text = "W imieniu nie może być spacji. Popraw imię.";
                                tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
                            }
                            else
                            {
                                string input = Tb_imienia.Text.ToString();
                                bool containsInt = input.Any(char.IsDigit);
                                if (containsInt == true)
                                {
                                    tBlock_imienia.Text = "Imię musi składać się z samych liter.";
                                    tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
                                }
                                else
                                {
                                    tBlock_imienia.Text = "Imię zostało podane prawidłowo.";
                                    tBlock_imienia.Foreground = new SolidColorBrush(Colors.Green);
                                }
                            }
                        }
                        else
                        {
                            tBlock_imienia.Text = "Prócz pierwszej litery, pozostałe muszą być małe. Popraw imię.";
                            tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        tBlock_imienia.Text = "Imię jest zbyt krótkie. Musi być długie na conajmniej 2 litery.";
                        tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_imienia.Text = "Pierwsza litera imienia musi być duża. Popraw imię.";
                    tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
                }
            }   
            else
            {
                tBlock_imienia.Text = "Imię musi być uzupełnione.";
                tBlock_imienia.Foreground = new SolidColorBrush(Colors.Red);
            }
            
        }

        private void Tb_nazwiska_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_nazwiska.Text.Length > 0)
            {
                string firstLetter = Tb_nazwiska.Text[0].ToString();

                if (firstLetter == firstLetter.ToUpper() && (String.IsNullOrEmpty(firstLetter) == false))
                {
                    if (Tb_nazwiska.Text.Length >= 2)
                    {
                        var sum = 0;
                        for (int i = 0; i < Tb_nazwiska.Text.Length; i++)
                        {
                            string lowerLetters = Tb_nazwiska.Text[i].ToString();

                            if (lowerLetters == lowerLetters.ToLower())
                            {
                                sum = sum + 1;
                            }
                        }
                        if (sum + 1 == Tb_nazwiska.Text.Length)
                        {
                            var sumS = 0;
                            for (int i = 0; i < Tb_nazwiska.Text.Length; i++)
                            {
                                string whiteSpace = Tb_nazwiska.Text[i].ToString();
                                bool isWhiteSpace = String.IsNullOrWhiteSpace(whiteSpace);
                                if (isWhiteSpace == true)
                                {
                                    sumS = sumS + 1;
                                }
                            }
                            if (sumS > 0)
                            {
                                tBlock_nazwiska.Text = "W nazwisku nie może być spacji. Popraw nazwisko.";
                                tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
                            }
                            else
                            {
                                string input = Tb_nazwiska.Text.ToString();
                                bool containsInt = input.Any(char.IsDigit);
                                if (containsInt == true)
                                {
                                    tBlock_nazwiska.Text = "Nazwisko musi składać się z samych liter.";
                                    tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
                                }
                                else
                                {
                                    tBlock_nazwiska.Text = "Nazwisko zostało podane prawidłowo.";
                                    tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Green);
                                }
                            }
                        }
                        else
                        {
                            tBlock_nazwiska.Text = "Prócz pierwszej litery, pozostałe muszą być małe. Popraw nazwisko.";
                            tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        tBlock_nazwiska.Text = "Nazwisko jest zbyt krótkie. Musi być długie na conajmniej 2 litery.";
                        tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_nazwiska.Text = "Pierwsza litera nazwiska musi być duża. Popraw nazwisko.";
                    tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                tBlock_nazwiska.Text = "Nazwisko musi być uzupełnione.";
                tBlock_nazwiska.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Tb_stanowiska_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_stanowiska.Text.Length > 0)
            {
                string firstLetter = Tb_stanowiska.Text[0].ToString();

                if (firstLetter == firstLetter.ToUpper() && (String.IsNullOrEmpty(firstLetter) == false))
                {
                    if (Tb_stanowiska.Text.Length >= 2)
                    {
                        var sum = 0;
                        for (int i = 0; i < Tb_stanowiska.Text.Length; i++)
                        {
                            string lowerLetters = Tb_stanowiska.Text[i].ToString();

                            if (lowerLetters == lowerLetters.ToLower())
                            {
                                sum = sum + 1;
                            }
                        }
                        if (sum + 1 == Tb_stanowiska.Text.Length)
                        {
                            string input = Tb_stanowiska.Text.ToString();
                            bool containsInt = input.Any(char.IsDigit);
                            if (containsInt == true)
                            {
                                tBlock_stanowiska.Text = "Stanowisko musi składać się z samych liter.";
                                tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Red);
                            }
                            else
                            {
                                tBlock_stanowiska.Text = "Stanowisko zostało podane prawidłowo.";
                                tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Green);
                            }
                        }
                        else
                        {
                            tBlock_stanowiska.Text = "Prócz pierwszej litery, pozostałe muszą być małe. Popraw nazwę stanowiska.";
                            tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        tBlock_stanowiska.Text = "Stanowisko jest zbyt krótkie. Musi być długie na conajmniej 2 litery.";
                        tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_stanowiska.Text = "Pierwsza litera stanowiska musi być duża. Popraw stanowisko.";
                    tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                tBlock_stanowiska.Text = "Stanowisko musi być uzupełnione.";
                tBlock_stanowiska.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Tb_emaila_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_emaila.Text.Length > 0)
            {
                if (Tb_emaila.Text.Length >= 2)
                {
                    string longWord = Tb_emaila.Text.ToString();
                    if (longWord.Contains("@wp.pl") == true || longWord.Contains("@gmail.com") == true)
                    {
                        var sum = 0;
                        for (int i = 0; i < Tb_emaila.Text.Length; i++)
                        {
                            string whiteSpace = Tb_emaila.Text[i].ToString();
                            bool isWhiteSpace = String.IsNullOrWhiteSpace(whiteSpace);
                            if (isWhiteSpace == true)
                            {
                                sum = sum + 1;
                            }
                        }
                        if(sum > 0)
                        {
                            tBlock_emailu.Text = "W Emailu nie może być spacji. Popraw email.";
                            tBlock_emailu.Foreground = new SolidColorBrush(Colors.Red);
                        }
                        else if(sum == 0)
                        {
                            tBlock_emailu.Text = "Email jest poprawny.";
                            tBlock_emailu.Foreground = new SolidColorBrush(Colors.Green);
                        }
                    }
                    else
                    {
                        tBlock_emailu.Text = "Email jest niepoprawny. Potrzebny jest email @wp.pl bądź @gmail.com";
                        tBlock_emailu.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_emailu.Text = "Email jest zbyt krótki. Musi być długi na conajmniej 2 litery.";
                    tBlock_emailu.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                tBlock_emailu.Text = "Email musi składać się z samych liter.";
                tBlock_emailu.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Tb_Loginu_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tb_Loginu.Text.Length > 0)
            {
                string firstLetter = Tb_Loginu.Text[0].ToString();

                if (firstLetter == firstLetter.ToUpper() && (String.IsNullOrEmpty(firstLetter) == false))
                {
                    if (Tb_Loginu.Text.Length >= 2)
                    {
                        var sum = 0;
                        for (int i = 0; i < Tb_Loginu.Text.Length; i++)
                        {
                            string whiteSpace = Tb_Loginu.Text[i].ToString();
                            bool isWhiteSpace = String.IsNullOrWhiteSpace(whiteSpace);
                            if (isWhiteSpace == true)
                            {
                                sum = sum + 1;
                            }
                        }
                        if (sum > 0)
                        {
                            tBlock_Loginu.Text = "W loginie nie może być spacji. Popraw login.";
                            tBlock_Loginu.Foreground = new SolidColorBrush(Colors.Red);
                        }
                        else if (sum == 0)
                        {
                            tBlock_Loginu.Text = "Login jest poprawny.";
                            tBlock_Loginu.Foreground = new SolidColorBrush(Colors.Green);
                        }
                    }
                    else
                    {
                        tBlock_Loginu.Text = "Login jest zbyt krótki. Musi być długi na conajmniej 2 litery.";
                        tBlock_Loginu.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_Loginu.Text = "Pierwsza litera loginu musi być duża. Popraw login.";
                    tBlock_Loginu.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                tBlock_Loginu.Text = "Login musi być uzupełniony.";
                tBlock_Loginu.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Tb_hasła_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Tb_hasła.Text.Length > 0)
            {
                if (Tb_hasła.Text.Length >= 2)
                {
                    var sum = 0;
                    for (int i = 0; i < Tb_hasła.Text.Length; i++)
                    {
                        string oneBigLetter = Tb_hasła.Text[i].ToString();

                        if (oneBigLetter == oneBigLetter.ToUpper())
                        {
                            sum = sum + 1;
                        }
                    }
                    if (sum > 0)
                    {
                        string input = Tb_hasła.Text.ToString();
                        bool containsInt = input.Any(char.IsDigit);
                        if (containsInt == true)
                        {
                            tBlock_hasła.Text = "Hasło jest poprawne.";
                            tBlock_hasła.Foreground = new SolidColorBrush(Colors.Green);
                        }
                        else
                        {
                            tBlock_hasła.Text = "Hasło musi zawierać przynajmniej 1 cyfrę.";
                            tBlock_hasła.Foreground = new SolidColorBrush(Colors.Red);
                        }
                    }
                    else
                    {
                        tBlock_hasła.Text = "Hasło musi zawierać przynajmniej 1 duża literę.";
                        tBlock_hasła.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    tBlock_hasła.Text = "Login jest zbyt krótki. Musi być długie na conajmniej 2 litery.";
                    tBlock_hasła.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                tBlock_hasła.Text = "Hasło musi być uzupełnione.";
                tBlock_hasła.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Tb_potwierdzenia_hasła_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Tb_potwierdzenia_hasła.Text == Tb_hasła.Text)
            {
                tBlock_potwierdzenia_hasła.Text = "Hasło zostało zatwierdzone.";
                tBlock_potwierdzenia_hasła.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tBlock_potwierdzenia_hasła.Text = "Hasła różnią się między Sobą! Trzeba je poprawić.";
                tBlock_potwierdzenia_hasła.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tBlock_imienia.Text == "Imię zostało podane prawidłowo." && tBlock_nazwiska.Text == "Nazwisko zostało podane prawidłowo."
                && tBlock_stanowiska.Text == "Stanowisko zostało podane prawidłowo." && tBlock_emailu.Text == "Email jest poprawny."
                && tBlock_Loginu.Text == "Login jest poprawny." && tBlock_hasła.Text == "Hasło jest poprawne."
                && tBlock_potwierdzenia_hasła.Text == "Hasło zostało zatwierdzone." && (ComboBox_Płeć.SelectedIndex == 0 || ComboBox_Płeć.SelectedIndex == 1)
                && (ComboBox_Roli.SelectedIndex == 0 || ComboBox_Roli.SelectedIndex == 1))
            {
                c.Imię = Tb_imienia.Text;
                c.Nazwisko = Tb_nazwiska.Text;
                c.Stanowisko = Tb_stanowiska.Text;
                c.Płeć = ComboBox_Płeć.Text;
                c.Email = Tb_emaila.Text;
                c.Login = Tb_Loginu.Text;
                c.Hasło = Tb_hasła.Text;
                c.Rola = ComboBox_Roli.Text;

                bool success = c.Insert(c);

                if (success == true)
                {
                    MessageBox.Show("Dane zostały poprawnie wprowadzone. Teraz możesz przejść do opcji logowania.");
                    emailSending(Tb_emaila.Text);
                }
                else
                {
                    MessageBox.Show("Coś poszło nie tak. Spróbuj ponownie.");
                }
            }
            else
            {
                MessageBox.Show("Pewne dany zostały błędnie uzupełnione. Aby zarejestrować użytkownika, należy wprowadzić wszystkie dane. Wprowadź ponownie dane.");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox_Roli.SelectedIndex == 0 || ComboBox_Roli.SelectedIndex == 1)
            {
                TextBlock_rodzajuKonta.Text = "Rodzaj konta został poprawnie wybrany.";
                TextBlock_rodzajuKonta.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                TextBlock_rodzajuKonta.Text = "Aby kontynuować rejestrację należy wybrać rodzaj konta!";
                TextBlock_rodzajuKonta.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void ComboBox_Płeć_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox_Płeć.SelectedIndex == 0 || ComboBox_Płeć.SelectedIndex == 1)
            {
                tBlock_płci.Text = "Płeć została poprawnie wybrana.";
                tBlock_płci.Foreground = new SolidColorBrush(Colors.Green);
            }
            else
            {
                tBlock_płci.Text = "Płeć musi zostać wybrana!";
                tBlock_płci.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void Przejscie_do_Logowania_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new Logowanie_Użytkownika().ShowDialog();
            ShowDialog();
        }

        //Należy podać swój email w miejsce "automatycznywarczakkamil@gmail.com" oraz swoje hasło, aby wysyłanie poprawnie działało.
        public static void emailSending(string mail)
        {
            string to = mail;
            string from = "automatycznywarczakkamil@gmail.com";
            MailMessage wiadomosc = new MailMessage(from, to);
            wiadomosc.Subject = "Potwierdzenie rejestracji";
            wiadomosc.Body = "Dziękujemy za dokonanie rejestracji.";

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("automatycznywarczakkamil@gmail.com", "autmaipaw");
            client.Host = "smtp.gmail.com";
            client.UseDefaultCredentials = false;
            client.Port = 587;
            client.EnableSsl = true;
            client.Send(wiadomosc);
        }
    }
}
