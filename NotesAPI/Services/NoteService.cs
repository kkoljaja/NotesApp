using NotesAPI.Context;
using NotesAPI.Data;

namespace NotesAPI.Services
{
	public class NoteService
	{
		private AppDbContext _context;
		public NoteService(AppDbContext context)
		{
			_context = context;
		}

		public void AddNote(Note note)
		{
            Note newNote = new Note
            {
                UserName = note.UserName,
                NoteContext = note.NoteContext,
                IsDone = false
            };

            _context.Note.Add(newNote);
			_context.SaveChanges();
		}

		public List<Note> GetUserNotes(string username)
		{
			var userNotes = _context.Note.ToList();
			var userNotesFiltered = new List<Note>();
			foreach (var note in userNotes)
			{
                if (note.UserName == username)
                {
                    userNotesFiltered.Add(note);
                }
			}
			return userNotesFiltered;
		}

		public Note UpdateNote(int id, Note newNote)
		{
			var note = _context.Note.FirstOrDefault(x => x.Id == id);
			if (note == null) return null;
			note.NoteContext = newNote.NoteContext;
			note.IsDone = newNote.IsDone;
			_context.Note.Update(note);
			_context.SaveChanges();
			return note;
		}

		public void RemoveNote(int id)
		{
			var noteDB = _context.Note.FirstOrDefault(x => x.Id == id);
			if (noteDB != null)
			{
				_context.Note.Remove(noteDB);
				_context.SaveChanges();
			}
		}
    }
}
