using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        RssManager rssManager = new RssManager();
        public MainForm()
        {
            InitializeComponent();
            initMovie();
            initStarRating();            
        }


        public void initMovie()
        {
            //create data binding from movie list to dataGridView
            var bindingList = rssManager.movieList;
            var source = new BindingSource(bindingList, null);
            dataGridViewMovie.AutoGenerateColumns = true;
            dataGridViewMovie.DataSource = source;


        }

        private void dataGridViewMovie_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!checkedListBoxWishBox.Items.Contains(rssManager.movieList[e.RowIndex].title))
            {
                checkedListBoxWishBox.Items.Add(rssManager.movieList[e.RowIndex].title); //add related movie to wish list
            }
            else
            {
                MessageBox.Show("The movie " + rssManager.movieList[e.RowIndex].title + " already in your wish list");
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            while (checkedListBoxWishBox.CheckedItems.Count > 0)
            {
                checkedListBoxWishBox.Items.RemoveAt(checkedListBoxWishBox.CheckedIndices[0]);
            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            //get the substring that represent the movie's rating
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return "";
        }

        private void initStarRating()
        {
            //create new tread for make program faster, rating will update on the go.
            new Thread(TreadForStarRating).Start();            
        }

        public void TreadForStarRating()
        {
            try
            {
                foreach (Movie movie in rssManager.movieList)
                {

                    using (WebClient client = new WebClient())
                    {
                            string htmlCode = client.DownloadString(movie.link);
                            string data = getBetween(htmlCode, "ratingValue", "ratingCount");
                            if (!data.Equals(""))
                            {
                                data = Regex.Replace(data, "[^0-9.]", "");//remove unrelevant chars and purify the rate.
                                movie.Rating = data;

                            }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
