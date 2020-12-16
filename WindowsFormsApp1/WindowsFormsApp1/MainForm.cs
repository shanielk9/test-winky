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
        public Dictionary<string, string> paths = new Dictionary<string, string>();
        public MainForm()
        {
            InitializeComponent();
            initMovie();

            paths.Add("Tenet - Christopher Nolan", "https://itunes.apple.com/us/movie/tenet/id1538251548?ign-mpt=uo%3D2");
            paths.Add("Illumination Presents: Dr. Seuss' The Grinch - Scott Mosier & Yarrow Cheney", "https://itunes.apple.com/us/movie/illumination-presents-dr-seuss-the-grinch/id1440401528?ign-mpt=uo%3D2");
            paths.Add("Elf (2003) - Jon Favreau", "https://itunes.apple.com/us/movie/elf-2003/id287917512?ign-mpt=uo%3D2");
            paths.Add("The War with Grandpa - Tim Hill", "https://itunes.apple.com/us/movie/the-war-with-grandpa/id1535892760?ign-mpt=uo%3D2");
            paths.Add("Honest Thief - Mark Williams", "https://itunes.apple.com/us/movie/honest-thief/id1540396639?ign-mpt=uo%3D2");
            paths.Add("National Lampoon's Christmas Vacation - Jeremiah S. Chechik", "https://itunes.apple.com/us/movie/national-lampoons-christmas-vacation/id296929739?ign-mpt=uo%3D2");
            paths.Add("The New Mutants - Josh Boone", "https://itunes.apple.com/us/movie/the-new-mutants/id1503451893?ign-mpt=uo%3D2");
            paths.Add("The Polar Express - Robert Zemeckis", "https://itunes.apple.com/us/movie/the-polar-express/id297817627?ign-mpt=uo%3D2");
            paths.Add("Love Actually - Richard Curtis", "https://itunes.apple.com/us/movie/love-actually/id292606147?ign-mpt=uo%3D2");
            paths.Add("Love and Monsters - Michael Matthews", "https://itunes.apple.com/us/movie/love-and-monsters/id1533484086?ign-mpt=uo%3D2");
            paths.Add("Monsters of Man - Mark Toia", "https://itunes.apple.com/us/movie/monsters-of-man/id1543029645?ign-mpt=uo%3D2");
            paths.Add("Fatman - Ian Nelms & Eshom Nelms", "https://itunes.apple.com/us/movie/fatman/id1534680901?ign-mpt=uo%3D2");
            paths.Add("Parallel - Isaac Ezban", "https://itunes.apple.com/us/movie/parallel/id1539473283?ign-mpt=uo%3D2");
            paths.Add("The Holiday - Nancy Meyers", "https://itunes.apple.com/us/movie/the-holiday/id271282883?ign-mpt=uo%3D2");
            paths.Add("A Christmas Story - Bob Clark", "https://itunes.apple.com/us/movie/a-christmas-story/id297444171?ign-mpt=uo%3D2");
            paths.Add("Four Christmases - Seth Gordon", "https://itunes.apple.com/us/movie/four-christmases/id306735662?ign-mpt=uo%3D2");
            paths.Add("The Last Champion - Glenn Withrow", "https://itunes.apple.com/us/movie/the-last-champion/id1540027664?ign-mpt=uo%3D2");
            paths.Add("Christmas With the Kranks - Joe Roth", "https://itunes.apple.com/us/movie/christmas-with-the-kranks/id535809175?ign-mpt=uo%3D2");
            paths.Add("After We Collided - Roger Kumble", "https://itunes.apple.com/us/movie/after-we-collided/id1526853610?ign-mpt=uo%3D2");
            paths.Add("How the Grinch Stole Christmas: The Ultimate Edition - Chuck Jones", "https://itunes.apple.com/us/movie/how-the-grinch-stole-christmas-the-ultimate-edition/id1428414879?ign-mpt=uo%3D2");
            paths.Add("Home Alone - Chris Columbus", "https://itunes.apple.com/us/movie/home-alone/id344796733?ign-mpt=uo%3D2");
            paths.Add("Mario Puzo's The Godfather, Coda: The Death of Michael Corleone - Francis Ford Coppola", "https://itunes.apple.com/us/movie/mario-puzos-godfather-coda-death-michael-corleone/id1535782003?ign-mpt=uo%3D2");
            paths.Add("Archenemy - Adam Egypt Mortimer", "https://itunes.apple.com/us/movie/archenemy/id1540395134?ign-mpt=uo%3D2");
            paths.Add("Ava (2020) - Tate Taylor", "https://itunes.apple.com/us/movie/ava-2020/id1525636290?ign-mpt=uo%3D2");
            paths.Add("The Phenomenon - James Fox", "https://itunes.apple.com/us/movie/the-phenomenon/id1528219444?ign-mpt=uo%3D2");

            webBrowser.ScriptErrorsSuppressed = true;

            initStarRating();
            
        }

        public void initMovie()
        {
            var bindingList = rssManager.movieList;
            var source = new BindingSource(bindingList, null);
            dataGridViewMovie.AutoGenerateColumns = true;
            dataGridViewMovie.DataSource = source;


        }

        private void dataGridViewMovie_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!checkedListBoxWishBox.Items.Contains(rssManager.movieList[e.RowIndex].title))
            {
                checkedListBoxWishBox.Items.Add(rssManager.movieList[e.RowIndex].title);
            }
            else
            {
                MessageBox.Show("The movie " + rssManager.movieList[e.RowIndex].title + " already in your wish list");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (checkedListBoxWishBox.CheckedItems.Count > 0)
            {
                checkedListBoxWishBox.Items.RemoveAt(checkedListBoxWishBox.CheckedIndices[0]);
            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
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
                        if (paths.ContainsKey(movie.title))
                        {
                            string p;
                            paths.TryGetValue(movie.title, out p);
                            string htmlCode = client.DownloadString(p);
                            string data = getBetween(htmlCode, "ratingValue", "ratingCount");
                            if (!data.Equals(""))
                            {
                                data = Regex.Replace(data, "[^0-9.]", "");
                                movie.Stars = data;

                            }

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
