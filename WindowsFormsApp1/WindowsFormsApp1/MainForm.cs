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

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        RssManager rssManager = new RssManager();
        public MainForm()
        {
            InitializeComponent();
            initMovie();
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
    }   
}
