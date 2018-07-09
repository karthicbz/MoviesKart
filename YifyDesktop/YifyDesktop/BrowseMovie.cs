using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace YifyDesktop
{
    class BrowseMovie : Grabber
    {
        //public string[] quality = new string[] { "All", "720", "1080", "3D" };
        public string[] orderBy = new string[] { "ASC", "DSC" };
        public string[] genre = new string[] {"All", "Comedy", "sci-fi", "Horror", "Romance", "Action", "Thriller",
                                                "Drama", "Mystery", "Crime", "Animation", "Adventure", "Fantasy"};
        public string[] rating = new string[] { "9", "8", "7", "6", "5", "4", "3", "2", "1" };

        string ConnectionString = "Data Source=DESKTOP-RSE0AFO;Initial Catalog=MoviesKart;Integrated Security=True";
        public List<string> movieNames = new List<string>();

        private void addTitle(string Genre, string Rating)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            if(connection.State == System.Data.ConnectionState.Open)
            {
                if(Genre == "All")
                {
                    string Titlequery = "Select Title From MovieSource Where Rating > '" + Rating + "' Order By Title ASC";
                    //SqlCommand command = new SqlCommand(Titlequery, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(Titlequery, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    for(int i=0; i<table.Rows.Count; i++)
                    {
                        string name = table.Rows[i]["Title"].ToString();
                        movieNames.Add(name);
                    }
                }
                else
                {
                    string Titlequery = "Select Title From MovieSource Where Genre = '" + Genre + "' And Rating > '" + Rating + "' Order By Title ASC";
                    SqlDataAdapter adapter = new SqlDataAdapter(Titlequery, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        string name = table.Rows[i]["Title"].ToString();
                        movieNames.Add(name);
                    }
                }
                
            }
        }

        private void showBrowsedMovies(string movieName)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            if(connection.State == ConnectionState.Open)
            {
                string CoverQuery = "Select MediumCover From MovieSource Where Title='" + movieName + "'";
                SqlCommand command = new SqlCommand(CoverQuery, connection);
                MPosterLinks.Add(command.ExecuteScalar().ToString());

                string yearQuery = "Select Year From MovieSource Where Title='" + movieName + "'";
                SqlCommand YearCommand = new SqlCommand(yearQuery, connection);
                Year.Add(YearCommand.ExecuteScalar().ToString());

                string RuntimeQuery = "Select RunTime From MovieSource Where Title='" + movieName + "'";
                SqlCommand RuntimeCommand = new SqlCommand(RuntimeQuery, connection);
                Runtime.Add(RuntimeCommand.ExecuteScalar().ToString());

                string SevenQuery = "Select sevenHdMovie From MovieSource Where Title='" + movieName + "'";
                SqlCommand SevenCommand = new SqlCommand(SevenQuery, connection);
                Sevenp.Add(SevenCommand.ExecuteScalar().ToString());

                string TenQuery = "Select TenHdMovie From MovieSource Where Title='" + movieName + "'";
                SqlCommand TenCommand = new SqlCommand(TenQuery, connection);
                Tenp.Add(TenCommand.ExecuteScalar().ToString());

                string ThreedQuery = "Select ThreedMovie From MovieSource Where Title='" + movieName + "'";
                SqlCommand ThreedCommand = new SqlCommand(ThreedQuery, connection);
                Threed.Add(ThreedCommand.ExecuteScalar().ToString());

            }
        }

        public void AddTitle(string genre, string rating)
        {
            addTitle(genre, rating);
        }

        public void ShowBrowsedMovies(string MovieName)
        {
            showBrowsedMovies(MovieName);
        }

    }
}
