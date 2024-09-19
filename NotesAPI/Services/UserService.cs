using NotesAPI.Context;
using NotesAPI.Data;
using NotesAPI.ViewModel;

namespace NotesAPI.Services
{
	public class UserService
	{
		private AppDbContext _context;
		public UserService(AppDbContext context)
		{
			_context = context;
		}

		public void AddUser(UserVM user)
		{
			var newUser = new User()
			{
				UserName = user.UserName,
				UserPassword = user.Password,
				Role = "User"
			};
			_context.User.Add(newUser);
			_context.SaveChanges();
		}

		public bool UserCreated(string username)
		{
			return (_context.User.FirstOrDefault(x => x.UserName == username)) != null ? true : false;
		}

		public User GetUser(string username, string password)
		{
			return _context.User.FirstOrDefault(x => x.UserName == username && x.UserPassword == password);
		}
	}
}
