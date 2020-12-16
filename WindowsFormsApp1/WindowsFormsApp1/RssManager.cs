﻿using System;
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
        public string Stars { get; set; }
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
            this.Stars = "0";
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
            Newtonsoft.Json.Linq.JObject jsonString = Newtonsoft.Json.Linq.JObject.Parse(webString);
            IList<Newtonsoft.Json.Linq.JToken> movieListJson = jsonString["feed"]["entry"].Children().ToList();

            foreach(Newtonsoft.Json.Linq.JObject movie in movieListJson)
            {
                string title = movie["title"]["label"].ToString() ;
                string summary = movie["summary"]["label"].ToString();
                string price = movie["im:price"]["label"].ToString();
                string category = movie["category"]["attributes"]["term"].ToString();
                string artist = movie["im:artist"]["label"].ToString();
                //string imgPath = movie["im:image"].First["lable"].ToString();

                movieList.Add(new Movie(title, summary, price, category, artist));
            }

        }
    }
}

