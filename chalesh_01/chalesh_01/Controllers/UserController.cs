﻿using AutoMapper;
using chalesh_01.core.CodeFactory;
using chalesh_01.core.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chalesh_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            
            if(Utils.UserList == null) return StatusCode(204);
            return Ok(new { result = Utils.UserList });
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (Utils.UserList == null) return StatusCode(204);
            var user = Utils.UserList.Where(u=>u.id == id).SingleOrDefault();
            var notes = Utils.Notes.Where(x=>x.UserId == id).ToList();
            if (user == null) return Ok(new { result = "User with this ID was not found" });
            return Ok(new { result = user, notes });
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModelIn model)
        {
            var checkDuplicateEmail = Utils.UserList.Where(u=>u.Email == model.Email).Any();
            if (checkDuplicateEmail) return BadRequest(new { message = "There is a user with this email" });
            var user = _mapper.Map<UserModelOut>(model);                
            Utils.UserList.Enqueue(user);
            return Ok(new { result = user });
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModelIn model)
        {
            var user = Utils.UserList.Where(x=>x.id == id).SingleOrDefault();
            if (user == null) return BadRequest(new { message = "User is not exsit" });            
            user.LastName = model.LastName;
            user.FirstName = model.FirstName;
            user.Email = model.Email;
            user.Age = model.Age;
            user.Website = model.Website;
            return Ok(new { result = user });
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Utils.UserList.Where(x => x.id == id).SingleOrDefault();
            if (user == null) return BadRequest(new { message = "User is not exsit" });
            Utils.UserList.TryDequeue(out user);
            var nots = Utils.Notes.Where(x => x.UserId == id).ToList();
            foreach (var item in nots)
            {
                Note? note = item as Note;
                Utils.Notes.TryDequeue(out note);
            }
            return NoContent();
        }
    }
}
