using Microsoft.Data.SqlClient;
namespace UtilLibrary
{
    public class DBConnection
    {
        static string cnstring = "Data Source=.\\sqlexpress;Initial Catalog=CourierMagagementSystem;Integrated Security=True;Trust Server Certificate=True";

        public static SqlConnection GetConnectionString()
        {
            SqlConnection cn = new SqlConnection(cnstring);
            return cn;
        }

    }
}
