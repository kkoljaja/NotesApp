using System.ComponentModel.DataAnnotations;

namespace NotesAPI.Data
{
	public class User
	{
		[Key] public int Id { get; set; }
		[Required] public string UserName { get; set; }
		[Required] public string UserPassword { get; set; }
		public string Role { get; set; }
	}
}
