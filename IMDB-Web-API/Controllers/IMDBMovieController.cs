using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.Reviews;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.Trending;



namespace IMDB_Web_API.Controllers
{
    [Route("api/movies")]
    //[ApiController]
    public class IMDBMovieController : ControllerBase
    {
        private String apiKey = "dbf838417cf64de0dbe2a81c2318610e";

        // Get Revievs
        [HttpGet("reviews/{id}")]
        public async Task<Review> GetReviews(int id)
        {
            using TMDbClient client = new TMDbClient(apiKey);
            Review reviews = await client.GetReviewAsync(id.ToString());
            return reviews;
        }


        // GET Trending 
        [HttpGet("trendMovie/{page}")]
        public async Task<IEnumerable<SearchMovie>> GetTrendMovie(int page)
        {
            using TMDbClient client = new TMDbClient(apiKey);
            SearchContainer<SearchMovie> movies = await client.GetTrendingMoviesAsync(TimeWindow.Week,page);
            return movies.Results;
        }

        // GET Movies by Id
        [HttpGet("getMovieById/{id}")]
        public async Task<Movie> GetMoviesById(int id)
        {
            using TMDbClient client = new TMDbClient(apiKey);
            Movie results = await client.GetMovieAsync(id);
            return results;
        }


        // GET Movies by Name
        [HttpGet("getByName/{name}")]
        public async Task<IEnumerable<SearchMovie>> GetMoviesByName(string name)
        {
            using TMDbClient client = new TMDbClient(apiKey);

            // This example shows the fetching of a movie.
            // Say the user searches for "Thor" in order to find "Thor: The Dark World" or "Thor"
            SearchContainer <SearchMovie> results = await client.SearchMovieAsync(name);
            return results.Results;
        }

        
    }
}
