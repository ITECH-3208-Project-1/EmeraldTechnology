using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Desktop_app.Models
{
    class Customer
    {
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public string user_firstname { get; set; }
        public string user_address { get; set; }
        public string user_contact { get; set; }
        public int user_ID { get; set; }


        static string dbconnectString = ConfigurationManager.ConnectionStrings["connectstring"].ConnectionString;  


        //Selcting data from the database.

        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(dbconnectString);
            DataTable datatable = new DataTable();
            try
            {
                //Writing the SQL query
                string sql_query = "SELECT * FROM CustomerTable";
                // Initialising connection string and sql query
                SqlCommand command = new SqlCommand(sql_query, connection);
                // Creating SQL data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(datatable);
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }
            return datatable;
        }
        //Creating Customer in the database
        public bool CreateCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(dbconnectString);
            DataTable datatable = new DataTable();
            bool dataInserted = false;
            try
            {

                //Writing the SQL query
                string sql_query = "insert into CustomerDatabaseTable (user_firstname, user_lastname, user_email, user_contact, user_address ) VALUES(@user_firstname, @user_lastname, @user_email, @user_contact, @user_address)";
                // Initialising connection string and sql query
                SqlCommand command = new SqlCommand(sql_query, connection);

                command.Parameters.AddWithValue("@user_firstname", customer.user_firstname);
                command.Parameters.AddWithValue("@user_lastname", customer.user_lastname);
                command.Parameters.AddWithValue("@user_email", customer.user_email);
                command.Parameters.AddWithValue("@user_contact", customer.user_contact);
                command.Parameters.AddWithValue("@user_address", customer.user_address);
                connection.Open();
                int tableRows = command.ExecuteNonQuery();
                if (tableRows > 0) { dataInserted = true; }
                else { dataInserted = false; }
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
            }
            
            return dataInserted;
        }
    }

}
