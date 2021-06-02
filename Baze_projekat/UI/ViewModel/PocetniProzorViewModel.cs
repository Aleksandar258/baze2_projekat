using Servis2.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UI.ViewModel
{
    public class PocetniProzorViewModel : BindableBase
    {
        public MyICommand AddCommand { get; set; }
        public MyICommand DeleteCommand { get; set; }

        public PocetniProzorViewModel()
        {
            AddCommand = new MyICommand(onProcedura);
            DeleteCommand = new MyICommand(onFunkcija);
        }


        public void onProcedura()
        {
            SqlConnection myConn = new SqlConnection("data source=DESKTOP-K47RKQJ;initial catalog=ModelFirstDb;integrated security=True;");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("TrazenjeRadnika", myConn);
            SqlParameter param = new SqlParameter();

            myCmd.CommandType = CommandType.StoredProcedure;

            myCmd.Parameters.AddWithValue("@Mesto", "Novi sadd");
            myCmd.Parameters.AddWithValue("@Ime", "aaa");
            myCmd.Parameters.Add("@Plt", SqlDbType.Int);
            myCmd.Parameters["@Plt"].Direction = ParameterDirection.Output;



            myCmd.ExecuteNonQuery();
            string plata = myCmd.Parameters["@Plt"].Value.ToString();

            MessageBox.Show(string.Format("Plata radnika je {0}", plata), "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

            myConn.Close();
        }

        public void onFunkcija()
        {
           /* SqlConnection myConn = new SqlConnection("data source=DESKTOP-K47RKQJ;initial catalog=ModelFirstDb;integrated security=True;");
            myConn.Open();
            SqlCommand myCmd = new SqlCommand("SELECT * FROM [dbo].[BrojObuceMaterijala](@Mat)", myConn);
            SqlParameter param = new SqlParameter();

            myCmd.CommandType = CommandType.StoredProcedure;

            myCmd.Parameters.AddWithValue("@Mat", "koza");

            SqlDataAdapter da = new SqlDataAdapter(myCmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string str = dt.Rows[0][0].ToString();

            //int br = myCmd.ExecuteNonQuery();
            //string plata = myCmd.Parameters["@Plt"].Value.ToString();

            MessageBox.Show(string.Format("Plata radnika je {0}", str), "Success!", MessageBoxButton.OK, MessageBoxImage.Information);

            myConn.Close();*/

            string connString = "data source=DESKTOP-F0GE8QS\\SQLEXPRESS; Integrated Security=SSPI; Initial Catalog=BolnicaDB";


            try
            {
                //sql connection object
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    //define the query text
                    // string query = @"SELECT [dbo].[fnGetTotalEmployees](@empID) AS TotalEmployees;";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand("select dbo.PronadjiLekara(@Mat)", conn);

                    //parameter value will be set from command line
                    SqlParameter param1 = new SqlParameter();
                    //cmd.Parameters.AddWithValue("Jmbg", 53);
                    param1.ParameterName = "@Mat";
                    param1.SqlDbType = SqlDbType.VarChar;
                    param1.Value = "koza";

                    //pass parameter to the SQL Command
                    cmd.Parameters.Add(param1);

                    //open connection


                    //execute the SQLCommand
                    string ime = cmd.ExecuteScalar().ToString();

                    if (!string.IsNullOrWhiteSpace(ime))
                    {
                        MessageBox.Show(string.Format("Uspesno ste izvrsili funkciju.\nBroj je: {0}", ime), "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Nema trazenog lekara.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
