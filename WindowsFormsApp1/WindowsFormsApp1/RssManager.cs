using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WindowsFormsApp1
{
    class Movie
    {
        public string Rating { get; set; }
        public string title { get; }
        public string summary { get; }
        public string price { get; }
        public string category { get; }
        public string artist { get; }

        public Movie(string title, string summary,string price,string category,string artist)
        {
            this.title = title;
            this.summary = summary;
            this.price = price;
            this.category = category;
            this.artist = artist;
            this.Rating = "0";
        }
    }
    class RssManager
    {
        string RssUrl = "https://itunes.apple.com/us/rss/topmovies/limit=25/json";
        public List<Movie> movieList = new List<Movie>();

        public RssManager()
        {
            initRss();
        }
        public void initRss()
        {
            
            var webString = new WebClient().DownloadString(RssUrl);
            //parse to json string
            JObject jsonString = JObject.Parse(webString);
            //create list from json
            IList<JToken> movieListJson = jsonString["feed"]["entry"].Children().ToList();

            foreach(JObject movie in movieListJson)
            {
                string title = movie["title"]["label"].ToString() ;
                string summary = movie["summary"]["label"].ToString();
                string price = movie["im:price"]["label"].ToString();
                string category = movie["category"]["attributes"]["term"].ToString();
                string artist = movie["im:artist"]["label"].ToString();

                movieList.Add(new Movie(title, summary, price, category, artist));
            }

        }
    }
}

