using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace OMDBProject.Models
{
    public class MovieDAL
    {
        public static MovieModel getMovie(string moviename)
        {
            string apiKey = "f858d2fb";
            string url = $"http://www.omdbapi.com/?t={moviename}&apikey={apiKey}&plot=full";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);

            return result;
        }
    }
}
