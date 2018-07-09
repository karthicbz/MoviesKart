using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace YifyDesktop
{
    public partial class Form1 : Form
    {
        Grabber grabber;
        BrowseMovie browseMovie = new BrowseMovie();
        public Form1()
        {
            InitializeComponent();
            grabber = new Grabber();
            grabber.Start = 1;
            grabber.Stop = 8;
            MediumPictureboxPosters();
            dynamicSearch();

            grabber.ShowMovieDetails();
            comboBoxAdder();
        }

        private void MediumPictureboxPosters()
        {
            grabber.ShowMoviePosters();
            LoadPictureBoxes();
        }

        private void LoadPictureBoxes()
        {
            pictureBox1.Load(grabber.MPosterLinks[0]);
            pictureBox2.Load(grabber.MPosterLinks[1]);
            pictureBox3.Load(grabber.MPosterLinks[2]);
            pictureBox4.Load(grabber.MPosterLinks[3]);
            pictureBox5.Load(grabber.MPosterLinks[4]);
            pictureBox6.Load(grabber.MPosterLinks[5]);
            pictureBox7.Load(grabber.MPosterLinks[6]);
            pictureBox8.Load(grabber.MPosterLinks[7]);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            //This for showing Movie Posters
            grabber.MPosterLinks.Clear();
            buttonPrevious.Enabled = true;
            grabber.Start += 8;
            grabber.Stop += 8;
            grabber.ShowMoviePosters();
            LoadPictureBoxes();
            pageNumber.Text = (int.Parse(pageNumber.Text) + 1).ToString();

            //This for showing Movie Title
            flushMovieDetailsText();
            grabber.ShowMovieDetails();

            resizePicturebox();

            flushLabelText();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if(grabber.Start > 1)
            {
                grabber.MPosterLinks.Clear();
                grabber.Start -= 8;
                grabber.Stop -= 8;
                grabber.ShowMoviePosters();
                LoadPictureBoxes();
                pageNumber.Text = (int.Parse(pageNumber.Text) - 1).ToString();
            }
            else
            {
                grabber.Start = 1;
                grabber.Stop = 8;
                buttonPrevious.Enabled = false;
            }

            flushMovieDetailsText();
            grabber.ShowMovieDetails();

            resizePicturebox();

            flushLabelText();
        }

        private void dynamicSearch()
        {
            grabber.SearchBoxUpdater();
            MovieSearchBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MovieSearchBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            MovieSearchBox.AutoCompleteCustomSource = grabber.collection; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox1.Size = new Size(120, 150);
            movieDetailsText(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox2.Size = new Size(120, 150);
            movieDetailsText(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox3.Size = new Size(120, 150);
            movieDetailsText(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox4.Size = new Size(120, 150);
            movieDetailsText(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox5.Size = new Size(120, 150);
            movieDetailsText(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox6.Size = new Size(120, 150);
            movieDetailsText(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox7.Size = new Size(120, 150);
            movieDetailsText(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            resizePicturebox();
            pictureBox8.Size = new Size(120, 150);
            movieDetailsText(7);
        }

        private void movieDetailsText(int i)
        {
            labelTitle.Text = grabber.Title[i];
            labelYear.Text = grabber.Year[i];
            labelRating.Text = grabber.Rating[i];
            labelRuntime.Text = (float.Parse(grabber.Runtime[i])/60).ToString("0.00") + " hrs";
            labelGenre.Text = grabber.Genre[i];
            labelSevenp.Text = grabber.Sevenp[i];
            labelTenp.Text = grabber.Tenp[i];
            labelThreed.Text = grabber.Threed[i];
        }

        private void flushMovieDetailsText()
        {
            grabber.Title.Clear();
            grabber.Year.Clear();
            grabber.Rating.Clear();
            grabber.Runtime.Clear();
            grabber.Genre.Clear();
            grabber.Sevenp.Clear();
            grabber.Tenp.Clear();
            grabber.Threed.Clear();
        }

        private void flushLabelText()
        {
            labelTitle.Text = " ";
            labelYear.Text = " ";
            labelRating.Text = " ";
            labelRuntime.Text = " ";
            labelGenre.Text = " ";
            labelSevenp.Text = " ";
            labelTenp.Text = " ";
            labelThreed.Text = " ";
        }

        private void resizePicturebox()
        {
            pictureBox1.Size = new Size(100, 134);
            pictureBox2.Size = new Size(100, 134);
            pictureBox3.Size = new Size(100, 134);
            pictureBox4.Size = new Size(100, 134);
            pictureBox5.Size = new Size(100, 134);
            pictureBox6.Size = new Size(100, 134);
            pictureBox7.Size = new Size(100, 134);
            pictureBox8.Size = new Size(100, 134);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            grabber.BigMovie.Clear();
            grabber.ShowSingleMovie(MovieSearchBox.Text);
            hidePictureBox(false);
            pictureboxSearch.Visible = true;
            buttonExit.Visible = true;
            pictureboxSearch.Load(grabber.BigMovie[0]);
            labelTitle.Text = grabber.BigMovie[1];
            labelYear.Text = grabber.BigMovie[2];
            labelRating.Text = grabber.BigMovie[3];
            labelRuntime.Text = grabber.BigMovie[4];
            labelGenre.Text = grabber.BigMovie[5];
            labelSevenp.Text = grabber.BigMovie[6];
            labelTenp.Text = grabber.BigMovie[7];
            labelThreed.Text = grabber.BigMovie[8];

        }

        private void hidePictureBox(bool value)
        {
            pictureBox1.Visible = value;
            pictureBox2.Visible = value;
            pictureBox3.Visible = value;
            pictureBox4.Visible = value;
            pictureBox5.Visible = value;
            pictureBox6.Visible = value;
            pictureBox7.Visible = value;
            pictureBox8.Visible = value;
            buttonNext.Visible = value;
            buttonPrevious.Visible = value;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            pictureboxSearch.Visible = false;
            buttonExit.Visible = false;
            hidePictureBox(true);
            flushLabelText();
            MovieSearchBox.Clear();
        }

        private void comboBoxAdder()
        {
            for(int j=0; j<browseMovie.genre.Length; j++)
            {
                comboBoxGenre.Items.Add(browseMovie.genre[j]);
            }

            for(int k=0;k<browseMovie.rating.Length; k++)
            {
                comboBoxRating.Items.Add(browseMovie.rating[k]);
            }
        }

        private void addMoviesList()
        {
            browseMovie.AddTitle(comboBoxGenre.SelectedItem.ToString(), comboBoxRating.SelectedItem.ToString());
            foreach(string names in browseMovie.movieNames)
            {
                MoviesListView.Items.Add(names);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            browseMovie.movieNames.Clear();
            MoviesListView.Items.Clear();
            addMoviesList();
        }

        private void MoviesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            browseMovie.MPosterLinks.Clear();
            browseMovie.Year.Clear();
            browseMovie.Runtime.Clear();
            browseMovie.Sevenp.Clear();
            browseMovie.Tenp.Clear();
            browseMovie.Threed.Clear();

            browseMovie.ShowBrowsedMovies(MoviesListView.SelectedItem.ToString());
            browsePictureBox.Load(browseMovie.MPosterLinks[0]);
            byearLabel.Text = browseMovie.Year[0];
            bRuntimeLabel.Text = (float.Parse(browseMovie.Runtime[0]) / 60).ToString("0.00")+" hrs";
            BrowseSeven.Text = browseMovie.Sevenp[0];
            BrowseTen.Text = browseMovie.Tenp[0];
            BrowseThree.Text = browseMovie.Threed[0];
        }

        private void BrowseSeven_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(BrowseSeven.Text);
        }

        private void BrowseTen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(BrowseTen.Text);
        }

        private void BrowseThree_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(BrowseThree.Text);
        }
    }
}
