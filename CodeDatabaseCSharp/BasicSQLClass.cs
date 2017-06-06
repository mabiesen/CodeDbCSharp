using System;
using System.Collections.Generic;
using System.Data;					//used for datatable
using System.Data.SqlClient;		//used for sql connection
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDatabaseCSharp
{
    public class BasicSQLClass
    {
        //Whitelists help to protect against SQL injection
        //Connection string created at instantiation is stored for reuse
        public List<string> tableNameWhitelist = new List<string>();
        public List<string> fieldNameWhitelist = new List<string>();
        public String myConnectionString = "";

        //Instantiate the server object, setting all variables
        public BasicSQLClass(string connString, List<string> tableNames, List<string> fieldNames)
        {
            this.myConnectionString = connString;
            this.tableNameWhitelist = tableNames.ToList();
            this.fieldNameWhitelist = fieldNames.ToList();
        }

        // Query a database for data. Returns a table of data
        public DataTable GetTableData(string query)
        {
            using (SqlConnection conn = new SqlConnection(this.myConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable myDataTable = new DataTable();

                    try
                    {
                        conn.Open();
                        // create data adapter
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        // this will query your database and return the result to your datatable
                        da.Fill(myDataTable);
                        conn.Close();
                        da.Dispose();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Fail to connect for get table data");
                        Console.WriteLine(ex);
                    }

                    return myDataTable;
                }
            }
        }

        // Delete all selected based on a criteria
        public void DelAllSelectedOneCriteria(string table, string myvalue, string field)
        {
            if (this.tableNameWhitelist.Contains(table))
            {
                if (this.fieldNameWhitelist.Contains(field))
                {
                    using (SqlConnection connection = new SqlConnection(this.myConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand("DELETE from " + table + " WHERE " + field + " = @myvalue", connection))
                        {
                            command.Parameters.AddWithValue("@myvalue", myvalue);

                            try
                            {
                                connection.Open();
                                int recordsAffected = command.ExecuteNonQuery();
                            }
                            catch (SqlException)
                            {
                                Console.WriteLine("Connection failed for singles delete");
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
            }
        }

        public void GenericQuery(string suppliedQuery)
        {
            using (SqlConnection connection = new SqlConnection(this.myConnectionString))
            {
                using (SqlCommand command = new SqlCommand(suppliedQuery,connection))
                {


                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        Console.WriteLine("Connection failed for generic connection");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}
