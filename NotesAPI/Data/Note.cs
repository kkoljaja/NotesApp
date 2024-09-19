using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Data
{
	public class Note
	{
		[Key] public int Id { get; set; }
		public string UserName { get; set; }
		public string NoteContext { get; set; }
		public bool IsDone { get; set; }
	}
}
