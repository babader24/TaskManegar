using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class clsCategory
    {
        public static DataTable GetAllCategory()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsSettings.ConnetionString);
            string query = "select * from Category";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                    dt.Load(reader);

                reader.Close();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;

        }

        public static int AddNewCategory(string categoryName)
        {
            int categoryId = -1;

            SqlConnection connection = new SqlConnection(clsSettings.ConnetionString);
            string query = "insert into Category (CategoryName) values(@CategoryName)";

            SqlCommand command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@CategoryName", categoryName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertID))
                    categoryId = insertID;

            }
            catch
            {
                //Write The Exception
            }
            finally
            {
                connection.Close();
            }
            return categoryId;

        }
    }


}
