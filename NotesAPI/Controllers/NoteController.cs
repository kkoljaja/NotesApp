using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using NotesAPI.Services;

namespace NotesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NoteController : ControllerBase
	{
		public NoteService NoteService { get; set; }
		public NoteController(NoteService noteService)
		{
			NoteService = noteService;
		}

		[HttpPost]
		public IActionResult AddNote(Note note)
		{
			NoteService.AddNote(note);
			return Ok();
		}

		[HttpGet]
		public IActionResult GetUserNotes(string username)
		{
			var userNotes = NoteService.GetUserNotes(username);
			return Ok(userNotes);
		}

		[HttpPut]
		public IActionResult UpdateNote(int id, Note newNote)
		{
			var note = NoteService.UpdateNote(id, newNote);
			return Ok(note);
		}

		[HttpDelete]
		public IActionResult RemoveNote(int id)
		{
			NoteService.RemoveNote(id);
			return Ok();
		}
	}
}
