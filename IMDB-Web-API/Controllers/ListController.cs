using IMDB_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        // GET: api/<ListController>
        [HttpGet]
        public List<List> Get()
        {
            using (var context = new IMDBWEBSITEContext())
            {
                return context.Lists.ToList();
            }
        }

        // GET api/<ListController>/5
        [HttpGet("{id}")]
        public List<List> Get(int id)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                return context.Lists.Where(x => x.UserId == id).ToList();
            }
        }

        [HttpPost("createList")]
        public List createList(List list)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                var lists = context.Set<List>();
                lists.Add(list);
                context.SaveChanges();
                //  context.Users.AddObject(value);
                return list;
            }
        }
        [HttpDelete("deleteList/{id}")]
        public void deleteList(int id)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                var list = context.Lists.Where(l => l.Id == id).FirstOrDefault();
                list.IsDeleted = true;
                context.SaveChanges();
                //  context.Users.AddObject(value);
            }
        }
        [HttpPost("updateList/{id}")]
        public void deleteList(int id, [FromBody] String name)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                var list = context.Lists.Where(l => l.Id == id).FirstOrDefault();
                list.Name = name;
                context.SaveChanges();
                //  context.Users.AddObject(value);
            }
        }
    }
}
