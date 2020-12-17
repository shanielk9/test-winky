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
        public string Place { get; }
        public string Rating { get; set; }
        public string title { get; }
        public string summary { get; }
        public string price { get; }
        public string category { get; }
        public string artist { get; }
        public string link { get; }

        public Movie(int place, string title, string summary,string price,string category,string artist, string link)
        {
            this.Place = place.ToString() + ".";
            this.title = title;
            this.summary = summary;
            this.price = price;
            this.category = category;
            this.artist = artist;
            this.Rating = "0";
            this.link = link;
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

            int i = 1;
            foreach(JObject movie in movieListJson)
            {
                string title = movie["title"]["label"].ToString() ;
                string summary = movie["summary"]["label"].ToString();
                string price = movie["im:price"]["label"].ToString();
                string category = movie["category"]["attributes"]["term"].ToString();
                string artist = movie["im:artist"]["label"].ToString();
                string link = movie["link"][0]["attributes"]["href"].ToString();

                movieList.Add(new Movie(i,title, summary, price, category, artist,link));
                i++;
            }

        }
    }
}

