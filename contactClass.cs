using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Rejestracja_użytkownika.SqlConnect
{
    class contactClass
    {
        public int UżytkownikID { get; set; }
        public string Imię { get; set; }
        public string Nazwisko { get; set; }

        public string Stanowisko { get; set; }

        public string Płeć { get; set; }
        
        public string Email { get; set; }
        
        public string Login { get; set; }

        public string Hasło { get; set; }

        public string Rola { get; set; }

        static string myconnstring = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;

        //Select data from database.
        public DataTable Select()
        {
            //Step 1: Database Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            DataTable dt = new DataTable();
            try
            {
                //Step 2: Writing Sql Query
                string sql = "SELECT * FROM Rejestracja_Uzytkownikow";
                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL dataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        //Inserting Data into DataBase
        public bool Insert (contactClass c)
        {
            //Creating a default return type and setting it's value to false
            bool isSuccess = false;

            //Step 1: Connect DataBase
            SqlConnection conn = new SqlConnection(myconnstring);
            try
            {
                //Step 2: Create a Sql Query to insert data
                string sql = "INSERT INTO Rejestracja_Uzytkownikow (Imię, Nazwisko, Stanowisko, Płeć, Email, Login, Hasło, Rola) VALUES (@Imię, @Nazwisko, @Stanowisko, @Płeć, @Email, @Login, @Hasło, @Rola)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@Imię", c.Imię);
                cmd.Parameters.AddWithValue("@Nazwisko", c.Nazwisko);
                cmd.Parameters.AddWithValue("@Stanowisko", c.Stanowisko);
                cmd.Parameters.AddWithValue("@Płeć", c.Płeć);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@Login", c.Login);
                cmd.Parameters.AddWithValue("@Hasło", c.Hasło);
                cmd.Parameters.AddWithValue("@Rola", c.Rola);

                //Connection Open Here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query runs succesfully then the value of rows will be greater than 0 else it's value will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }


    }
}
        

