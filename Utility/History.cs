using System;

namespace MovieKnights.Utility
{
    public class History
    {
        public string CastID { get; set; }
        public string Search { get; set; }
        
        public int UserID { get; set; }
        public History()
        {}
        public void SetUserID(int userID)
        {
            UserID = userID;
        } 
        public int GetUserID()
        {
            return UserID;
        }   
        public void Logout()//check user is login or not
        {
            UserID = 0;
        }
        public void SetSearch(string search)
        {
            Search = search;
        }

        public string GetSearch()
        {
            return Search;
        }

        public void SetCastID(string castID)
        {
            CastID = castID;
        }

        public string GetCastID()
        {
            return CastID;
        }
    } // class
} // namepace