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
    class Products
    {
        public string product_name { get; set; }
        public int product_quantity { get; set; }
        public string product_expiry_date { get; set; }

        public int product_id { get; set; }

        static string dbconnectString = ConfigurationManager.ConnectionStrings["connectstring"].ConnectionString;


        //Selcting data from the database.

        public DataTable Select()
        {
            SqlConnection connection = new SqlConnection(dbconnectString);
            DataTable datatable = new DataTable();
            try
            {
                //Writing the SQL query
                string sql_query = "SELECT * FROM ProductTable";
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
        public bool CreateCustomer(Products product)
        {
            SqlConnection connection = new SqlConnection(dbconnectString);
            DataTable datatable = new DataTable();
            bool dataInserted = false;
            try
            {
                //String query = "insert into data (E.id,name,surname,age) values ('" + this.eid_txt.text + "','" + this.nametxt.text + "','" + this.surname_txt.text + "','" +this.age_txt.text + "')";
                //Writing the SQL query
                string sql_query = "insert into ProductTable (product_name, product_expiry_date, product_quantity) VALUES(@product_name, @product_expiry_date, @product_quantity)";
                // Initialising connection string and sql query
                SqlCommand command = new SqlCommand(sql_query, connection);

                command.Parameters.AddWithValue("@product_name", product.product_name);
                command.Parameters.AddWithValue("@product_expiry_date", product.product_expiry_date);
                command.Parameters.AddWithValue("@product_quantity", product.product_quantity);
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
