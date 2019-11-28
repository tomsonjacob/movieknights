using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MovieKnights.Pages
{
    public class CreateUserModel : PageModel
    
    {
        public int UserID = Program.History.GetUserID();
        public void OnGet()
        {}

        public void OnPostCreateUser(string email, string password)
        {
            using(SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand createUser = new SqlCommand();
                createUser.Connection = myConn;
                myConn.Open();

                createUser.Parameters.AddWithValue("@email", email);
                createUser.Parameters.AddWithValue("@password", password);

                createUser.CommandText = ("[spCreateUser]");
                createUser.CommandType = System.Data.CommandType.StoredProcedure;

                createUser.ExecuteNonQuery();
            }
        }
    }//class
}//namespace