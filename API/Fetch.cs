using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieKnights.API
{
    public class Fetch
    {
        public string cs = "Server=(localdb)\\mssqllocaldb;Database=MovieKnightsDB;Trusted_Connection=true";
        public HttpClient client = new HttpClient();
        public string Search { get; set; }
        public string Data { get; set; }
        public string Videos { get; set; }
        public string Details { get; set; }
        public string Credits { get; set; }

        // constructor
        public Fetch() 
        {}

        public async Task GrabMovieDetails(string movieID)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "applicationException/json"));

            // grab vids
            HttpResponseMessage videos = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID +
                    "/videos?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");
            // grab details
            HttpResponseMessage details = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID +
                    "?api_key=d194eb72915bc79fac2eb1a70a71ddd3&language=en-US");
            // grab credits
            HttpResponseMessage credits = await client.GetAsync(
                "https://api.themoviedb.org/3/movie/" + movieID +
                "/credits?api_key=d194eb72915bc79fac2eb1a70a71ddd3");

            if (videos.IsSuccessStatusCode || details.IsSuccessStatusCode 
                || credits.IsSuccessStatusCode)
            {
                Videos = await videos.Content.ReadAsStringAsync();
                Details = await details.Content.ReadAsStringAsync();
                Credits = await credits.Content.ReadAsStringAsync();
            }
        }
        public async Task GrabMovieInfo(string search)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "applicationException/json"));

            // grab 20 vids
            HttpResponseMessage response = await client.GetAsync(
                "https://api.themoviedb.org/3/search/movie?api_key=d194eb72915bc79fac2eb1a70a71ddd3&query="
                    + search);

            if(response.IsSuccessStatusCode)
            {
                Search = search;
                Data = await response.Content.ReadAsStringAsync();
            }
            else 
            {
                Data = null;
            }
        } // GrabMovieInfo()
    } // class
} // namespace