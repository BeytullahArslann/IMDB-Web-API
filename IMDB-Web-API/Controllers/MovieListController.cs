using IMDB_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieListController : ControllerBase
    {
        [HttpGet("lists/{userId}")]
        public List<MovieList> getUserList(int userId)
        {
            using(var context = new IMDBWEBSITEContext())
            {
                return context.MovieLists.Where(x => x.UserId == userId).ToList();
            }
        }
        [HttpPost("addMovie")]
        public void addMovie(MovieList movieList)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                var movieLists = context.Set<MovieList>();
                movieLists.Add(movieList);
                context.SaveChanges();
            }
        }
        [HttpPost("deleteMovie")]
        public void addMovie(int movieId , int userId , int listId)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                var movieList = context.MovieLists.Where(l => l.MovieId == movieId && l.UserId == userId && l.ListId == listId).FirstOrDefault();
                context.MovieLists.Remove(movieList);
                //movieList.IsDeleted = true;
                context.SaveChanges();
            }
        }
        public class ListMovie
        {
            public List List { get; set; }
            public List<MovieList> movies { get; set; }
        }
        [HttpPost("getListsMovie")]
        public List<ListMovie> getListsMovie(int userId)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                List<ListMovie> listMovie = new List<ListMovie>();
                var lists = context.Lists.Where(x => x.UserId == userId).ToList();
                foreach (var list in lists)
                {
                    var movies = context.MovieLists.Where((l) => l.ListId == list.Id).ToList();
                    listMovie.Add(
                        new ListMovie() { List = list, movies = movies });
                }
                //var query = (from list in context.Lists join movieList in context.MovieLists on list.Id equals movieList.ListId select new
                //{
                //    list.Id,
                //    list.Name,
                //    //movieList.Id,
                //    movieList.MovieId,
                //    movieList.MovieName,
                //    movieList.MoviePosterPath,
                //    movieList.Type
                //}).ToList();
                //return query;
                return listMovie;
            }
        }
    }
}
