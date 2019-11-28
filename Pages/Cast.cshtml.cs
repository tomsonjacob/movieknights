using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace MovieKnights.Pages
{
    public class CastModel : PageModel
    {
        public string castID ="";
        public void OnGet()
        {
            castID = Program.History.GetCastID();
            
        }
    }//class
}//namespace