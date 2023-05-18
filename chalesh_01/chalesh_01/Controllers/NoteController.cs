using AutoMapper;
using chalesh_01.core.CodeFactory;
using chalesh_01.core.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace chalesh_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly IMapper _mapper;
        public NoteController(IMapper mapper)
        {
            _mapper = mapper;
        }
        // GET api/<NoteController>/5
        [HttpGet("/GetAllNoteUser/{userId}")]
        public IActionResult GetAllNoteUser(int userId)
        {
            var getAllNote = Utils.Notes.Where(n=>n.UserId == userId).ToList();
            if(getAllNote.Count() == 0) return Ok("No data for userId");
            return Ok(getAllNote);
        }
        [HttpGet("GetNote/{noteId}")]
        public IActionResult GetNote(int noteId)
        {
            if(noteId == 0) return BadRequest();
            var getNote = Utils.Notes.Where(n => n.Id == noteId).SingleOrDefault();
            if (getNote == null) return BadRequest("There are no notes with this ID");
            return Ok(getNote);
        }

        // POST api/<NoteController>
        [HttpPost]
        public IActionResult Post([FromBody] NoteIn note)
        {
            if(note == null) return BadRequest();
            var noteMap = _mapper.Map<Note>(note);
            Utils.Notes.Add(noteMap);
            return Ok("Add note");
        }

        // PUT api/<NoteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] NoteIn noteIn)
        {
            var note = Utils.Notes.Where(n=>n.Id == id).SingleOrDefault();
            if(note == null) return BadRequest("There are no notes with this ID");
            note.Name = noteIn.Name;
            note.Published = noteIn.Published;
            note.View =noteIn.View;
            note.DateModified = DateTime.Now;
            return Ok("The note is updated");
        }

        // DELETE api/<NoteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();
            var note = Utils.Notes.Where(n=>n.Id == id).SingleOrDefault();
            if (note == null) return BadRequest("There are no notes with this ID");
            Utils.Notes.Remove(note);
            return NoContent();

        }
    }
}
