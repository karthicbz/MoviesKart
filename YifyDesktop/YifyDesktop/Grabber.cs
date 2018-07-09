using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace YifyDesktop
{
    class Grabber
    {
        //PictureBox[] MoviePosterMedium = new PictureBox[8];
        public List<string> MPosterLinks = new List<string>();
        public List<string> Title = new List<string>();
        public List<string> Year = new List<string>();
        public List<string> Rating = new List<string>();
        public List<string> Runtime = new List<string>();
        public List<string> Genre = new List<string>();
        public List<string> Sevenp = new List<string>();
        public List<string> Tenp = new List<string>();
        public List<string> Threed = new List<string>();
        public List<string> BigMovie = new List<string>();

        string connectionString = "Data Source=DESKTOP-RSE0AFO;Initial Catalog=MoviesKart;Integrated Security=True";
        public int Start { get; set; }
        public int Stop { get; set; }
        public AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

        private void showMoviePosters()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if(connection.State == System.Data.ConnectionState.Open)
            {
                for (int i = Start; i <= Stop; i++)
                {
                    string query = "Select MediumCover From MovieSource Where Id = '" + i + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    MPosterLinks.Add(command.ExecuteScalar().ToString());
                }

            }
        }

        private void searchBoxUpdater()
        {
            //AutoCompleteStringCollection collection = new AutoCompleteStringCollection();

            string autoCompleteQuery = "SELECT * FROM MovieSource";
            SqlDataAdapter adapter = new SqlDataAdapter(autoCompleteQuery, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);

            for(int i=0; i<table.Rows.Count; i++)
            {
                string name = table.Rows[i]["Title"].ToString();
                collection.Add(name);
            }
        }

        private void showMovieDetails()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if(connection.State == ConnectionState.Open)
            {
                for (int i = Start; i <= Stop; i++)
                {
                    string titleQuery = "Select Title From MovieSource Where Id = '" + i + "'";
                    SqlCommand command = new SqlCommand(titleQuery, connection);
                    Title.Add(command.ExecuteScalar().ToString());

                    string yearQuery = "Select Year From MovieSource Where Id = '" + i + "'";
                    SqlCommand yearcommand = new SqlCommand(yearQuery, connection);
                    Year.Add(yearcommand.ExecuteScalar().ToString());

                    string ratingQuery = "Select Rating From MovieSource Where Id = '" + i + "'";
                    SqlCommand ratingcommand = new SqlCommand(ratingQuery, connection);
                    Rating.Add(ratingcommand.ExecuteScalar().ToString());

                    string runtimeQuery = "Select RunTime From MovieSource Where Id = '" + i + "'";
                    SqlCommand runtimecommand = new SqlCommand(runtimeQuery, connection);
                    Runtime.Add(runtimecommand.ExecuteScalar().ToString());

                    string genreQuery = "Select Genre From MovieSource Where Id = '" + i + "'";
                    SqlCommand genrecommand = new SqlCommand(genreQuery, connection);
                    Genre.Add(genrecommand.ExecuteScalar().ToString());

                    string sevenQuery = "Select sevenHdMovie From MovieSource Where Id = '" + i + "'";
                    SqlCommand sevencommand = new SqlCommand(sevenQuery, connection);
                    Sevenp.Add(sevencommand.ExecuteScalar().ToString());

                    string tenQuery = "Select TenHdMovie From MovieSource Where Id = '" + i + "'";
                    SqlCommand tenCommand = new SqlCommand(tenQuery, connection);
                    Tenp.Add(tenCommand.ExecuteScalar().ToString());

                    string threedQuery = "Select ThreedMovie From MovieSource Where Id = '" + i + "'";
                    SqlCommand threedCommand = new SqlCommand(threedQuery, connection);
                    Threed.Add(threedCommand.ExecuteScalar().ToString());
                }
            }
        }

        private void showSingleMovie(string movieName)
        {
            //string[] names = new string[] {"MediumCover", "Title", "Year", "Rating", "RunTime", "Genre", "sevenHdMovie",
                                           // "TenHdMovie", "ThreedMovie"};
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            if(connection.State == ConnectionState.Open)
            {
                string bigPosterQuery = "Select MediumCover From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigPosterCommand = new SqlCommand(bigPosterQuery, connection);
                BigMovie.Add(bigPosterCommand.ExecuteScalar().ToString());

                string bigTitleQuery = "Select Title From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigTitleCommand = new SqlCommand(bigTitleQuery, connection);
                BigMovie.Add(bigTitleCommand.ExecuteScalar().ToString());

                string bigYearQuery = "Select Year From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigYearCommand = new SqlCommand(bigYearQuery, connection);
                BigMovie.Add(bigYearCommand.ExecuteScalar().ToString());

                string bigRatingQuery = "Select Rating From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigRatingCommand = new SqlCommand(bigRatingQuery, connection);
                BigMovie.Add(bigRatingCommand.ExecuteScalar().ToString());

                string bigRuntimeQuery = "Select RunTime From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigRuntimeCommand = new SqlCommand(bigRuntimeQuery, connection);
                BigMovie.Add(bigRuntimeCommand.ExecuteScalar().ToString());

                string bigGenreQuery = "Select Genre From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigGenreCommand = new SqlCommand(bigGenreQuery, connection);
                BigMovie.Add(bigGenreCommand.ExecuteScalar().ToString());

                string bigSevenQuery = "Select sevenHdMovie From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigSevenCommand = new SqlCommand(bigSevenQuery, connection);
                BigMovie.Add(bigSevenCommand.ExecuteScalar().ToString());

                string bigTenQuery = "Select TenHdMovie From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigTenCommand = new SqlCommand(bigTenQuery, connection);
                BigMovie.Add(bigTenCommand.ExecuteScalar().ToString());

                string bigThreedQuery = "Select ThreedMovie From MovieSource Where Title = '" + movieName + "'";
                SqlCommand bigThreedCommand = new SqlCommand(bigThreedQuery, connection);
                BigMovie.Add(bigThreedCommand.ExecuteScalar().ToString());

            }
        }

        public void ShowMoviePosters()
        {
            showMoviePosters();
        }

        public void SearchBoxUpdater()
        {
            searchBoxUpdater();
        }

        public void ShowMovieDetails()
        {
            showMovieDetails();
        }

        public void ShowSingleMovie(string movie)
        {
            showSingleMovie(movie);
        }
    }

    public class Rootobject
    {
        public string status { get; set; }
        public string status_message { get; set; }
        public Data data { get; set; }
        public Meta meta { get; set; }
    }

    public class Data
    {
        public int movie_count { get; set; }
        public int limit { get; set; }
        public int page_number { get; set; }
        public Movie[] movies { get; set; }
    }

    public class Movie
    {
        public int id { get; set; }
        public string url { get; set; }
        public string imdb_code { get; set; }
        public string title { get; set; }
        public string title_english { get; set; }
        public string title_long { get; set; }
        public string slug { get; set; }
        public int year { get; set; }
        public float rating { get; set; }
        public int runtime { get; set; }
        public string[] genres { get; set; }
        public string summary { get; set; }
        public string description_full { get; set; }
        public string synopsis { get; set; }
        public string yt_trailer_code { get; set; }
        public string language { get; set; }
        public string mpa_rating { get; set; }
        public string background_image { get; set; }
        public string background_image_original { get; set; }
        public string small_cover_image { get; set; }
        public string medium_cover_image { get; set; }
        public string large_cover_image { get; set; }
        public string state { get; set; }
        public Torrent[] torrents { get; set; }
        public string date_uploaded { get; set; }
        public int date_uploaded_unix { get; set; }
    }

    public class Torrent
    {
        public string url { get; set; }
        public string hash { get; set; }
        public string quality { get; set; }
        public int seeds { get; set; }
        public int peers { get; set; }
        public string size { get; set; }
        public long size_bytes { get; set; }
        public string date_uploaded { get; set; }
        public int date_uploaded_unix { get; set; }
    }

    public class Meta
    {
        public int server_time { get; set; }
        public string server_timezone { get; set; }
        public int api_version { get; set; }
        public string execution_time { get; set; }
    }


}
