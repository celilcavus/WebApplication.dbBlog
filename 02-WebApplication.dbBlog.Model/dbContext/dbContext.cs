using System.Data.SqlClient;

namespace _02_WebApplication.dbBlog.Model.dbContext
{
    public static class dbContext
    {
         const  string ConnectString = @"Data Source=.;Initial Catalog=DbBlog;Integrated Security=True";
        static  public SqlConnection conn = new SqlConnection(ConnectString);
    
    }
}
