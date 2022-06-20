using IMDB_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public List<User> Get()
        {
            using (var context = new IMDBWEBSITEContext())
            {
                return context.Users.ToList();
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
                // return (from x in context.Users where x.Id == id select x).FirstOrDefault();
            }

        }

        public class login
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        // POST api/<UserController>
        [HttpPost("/login")]
        public User Post([FromBody] login login)
        {

            using (var context = new IMDBWEBSITEContext())
            {
                var user = context.Users.Where(x => x.Email == login.email && x.Password == login.password && x.IsDeleted == false).FirstOrDefault();
                if (user != null)
                {
                    return (User)user;
                }
                else
                {
                    return null;
                }
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {

            using (var context = new IMDBWEBSITEContext())
            {
                var users = context.Set<User>();
                users.Add(value);
                context.SaveChanges();
                //  context.Users.AddObject(value);
            }
        }

        // POST api/<UserController>
        [HttpPost("emailControl")]
        public bool EmailTest(String value)
        {

            using (var context = new IMDBWEBSITEContext())
            {
                string Email = (from x in context.Users where x.Email == value select x.Email).FirstOrDefault();
                if (Email != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // POST api/<UserController>
        [HttpPost("nicknameControl")]
        public bool NicknameTest(string value)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                string Nickname = (from x in context.Users where x.NickName == value select x.NickName).FirstOrDefault();
                if (Nickname != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public User updateUser(int id, [FromBody] User value)
        {
            using (var context = new IMDBWEBSITEContext())
            {
                User user = context.Users.Where(x => x.Id == id).FirstOrDefault();
                user.Name = value.Name;
                user.Surname = value.Surname;
                user.NickName = value.NickName;
                user.Email = value.Email;
                user.Password = value.Password;
                user.Birthday = value.Birthday;
                user.IdentificationNo = value.IdentificationNo;
                user.Sex = value.Sex;
                
                
                context.SaveChanges();
                return context.Users.Where(x => x.Id == id).FirstOrDefault();
            }
            
        }
        
        //[FromQuery(Name = "url")] 
        // https://localhost:7084/api/User/Img/Storage%5C url head

        [HttpGet("Img/{url}")]
        public IActionResult getImg(string url)
        {
            var image = System.IO.File.OpenRead(url);
            return File(image, "image/jpeg");

        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var context = new IMDBWEBSITEContext();
            var user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            user.IsDeleted = true;
            context.SaveChanges();
        }


        [HttpPost("updateImg")]
        public async Task<string> updateImg(int userId , bool type, IFormFile file)
        {
            var path = await FileUpload(file);
            if (path != null)
            {
                using(var context = new IMDBWEBSITEContext())
                {
                    var user = context.Users.Where(x => x.Id == userId).FirstOrDefault();
                    if(type)
                    {
                        user.Img = path;
                    }
                    else
                    {
                        user.BackgroundImg = path;
                    }
                    context.SaveChanges();
                }
                return path;
            }
            return null;
        }

        [HttpPost("uploadimg")]
        public async Task<string> FileUpload( IFormFile formFile)
        {
            if (formFile != null)
            {
                var extent = Path.GetExtension(formFile.FileName);
                var randomName = ($"{Guid.NewGuid()}{extent}");
                var path = Path.Combine("Storage", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                return randomName;
            }
            return null;
        }

        

        


    }
}
