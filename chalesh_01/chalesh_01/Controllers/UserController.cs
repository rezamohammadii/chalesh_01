using chalesh_01.core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chalesh_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<UserModel> UserList = new List<UserModel>();
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            if(UserList == null) return StatusCode(204);
            return Ok(new { result = UserList });
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (UserList == null) return StatusCode(204);
            var user = UserList.Where(u=>u.Age == id).SingleOrDefault();
            if (user == null) return Ok(new { result = "User with this ID was not found" });
            return Ok(new { result = user });
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel model)
        {
            var checkDuplicateEmail = UserList.Where(u=>u.Email == model.Email).Any();
            if (checkDuplicateEmail) return BadRequest(new { message = "There is a user with this email" });
            var user = new UserModel()
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                Email = model.Email,
                Age = model.Age,
                Website = model.Website,
            };            
            UserList.Add(user);
            return Ok(new { result = user });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
