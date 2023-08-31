using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SampleForm.Models;

namespace SampleForm.DBContext
{

    public class DBConnection

    {
        public SqlConnection getSqlConnection()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(getConfiguration());
            }
            catch (Exception ee)
            {
                throw ee;
            }
            return con;
        }


        public static string getConfiguration()
        {
            string ConnectionString = null;
            try
            {
                ConnectionString = "Server=8NSD6Q3\\SQLEXPRESS;Database=Subhani;TrustServerCertificate = True;User ID=sa;pwd=Rizwana@203";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ConnectionString;
        }
    }

}    
