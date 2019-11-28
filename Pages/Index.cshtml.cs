using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MovieKnights.Pages
{
    public class IndexModel : PageModel
    {
        public List<string> id = new List<string>();
        public List<string> posterPath = new List<string>();
        public List<string> VidClips = new List<string>();
        public List<string> Filter = new List<string>();

        public List<string> CastIDs = new List<string>();
        public List<string> CastNames = new List<string>();
        public List<string> CastImages = new List<string>();

        public string description = "";
        public string movieTitle = "";
        
        public int UserID = Program.History.GetUserID();
        //get methods
        public async Task OnGet()//automaticall load prev search done
        {
            string prevSearch = Program.History.GetSearch();
            if(prevSearch != "")
            {
                await OnPostFindMovies(prevSearch);
            }
            UserID = Program.History.GetUserID();
        }
///post  method

//OnPostlogin

        public void OnPostLogin(string email, string password)
        {
            using(SqlConnection myConn = new SqlConnection(Program.Fetch.cs))
            {
                SqlCommand login = new SqlCommand();
                login.Connection = myConn;
                myConn.Open();

                login.Parameters.AddWithValue("@email", email);
                login.Parameters.AddWithValue("@password", password);

                login.CommandText = ("[spLoginReturnID]");
                login.CommandType = System.Data.CommandType.StoredProcedure;

               var result = login.ExecuteScalar(); // need return value
               if(result != null)
               {
                    Program.History.SetUserID(Convert.ToInt32(result)); 
               }
               Response.Redirect("/Index");
            }//using
        }//on post login

        //on post logout
        public void OnPostLogout()
        {
            Program.History.Logout();
             Response.Redirect("/Index");
        }

        public void OnPostCast(string castID)
        {

            Program.History.SetCastID(castID);
            Response.Redirect("/cast");
        }

        public async Task OnPostDetails(string movieID)
        {
            await Program.Fetch.GrabMovieDetails(movieID);

            //==========>>
            // Videos
            Program.JsonNinja = new JsonNinja(Program.Fetch.Videos);
            Filter = Program.JsonNinja.GetDetails("\"results\"");
            Program.JsonNinja = new JsonNinja(Filter[0]);

            List<string> vidNames = Program.JsonNinja.GetNames();
            List<string> vidVals = Program.JsonNinja.GetVals();

            VidClips = Program.JsonNinja.GetDetails("\"key\"");

            //===========>>
            // Details
            Program.JsonNinja = new JsonNinja(Program.Fetch.Details);

            List<string> detailNames = Program.JsonNinja.GetNames();
            List<string> detailVals = Program.JsonNinja.GetVals();

            List<string> descs = Program.JsonNinja.GetDetails("\"overview\"");
            description = descs[0];
        
            //===========>>
            // Cast

            Program.JsonNinja = new JsonNinja(Program.Fetch.Credits);
            List<string> creditNames = Program.JsonNinja.GetNames();
            List<string> creditVals = Program.JsonNinja.GetVals();

            Filter = Program.JsonNinja.GetDetails("\"cast\"");
            Program.JsonNinja = new JsonNinja(Filter[0]);
            CastIDs = Program.JsonNinja.GetIds("\"id\"");
            CastNames = Program.JsonNinja.GetDetails("\"name\"");
            CastImages = Program.JsonNinja.GetDetails("\"profile_path\"");

           
        }
        public async Task OnPostFindMovies(string search)
        {
            Program.History.SetSearch(search);
            await Program.Fetch.GrabMovieInfo(search);

            if(Program.Fetch.Data == null)
            {
                // oops no data to display
            }
            else
            {
                Program.JsonNinja = new JsonNinja(Program.Fetch.Data);
                Program.JsonNinja = new JsonNinja(Program.JsonNinja.filter[0]);
                posterPath = Program.JsonNinja.GetPosters();

                // hack to fix the last poster path with missing 'g'
                // there has to a better way ;)
                posterPath[posterPath.Count() - 1] += "g";

                id = Program.JsonNinja.GetIds("\"id\"");

            }
        } // OnPostFindMovies()
    } // class
} // namespace