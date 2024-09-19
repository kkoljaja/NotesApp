using Microsoft.AspNetCore.Mvc;
using NotesAPI.Data;
using NotesAPI.Services;
using NotesAPI.ViewModel;

namespace NotesAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public UserService UserService { get; set; }
		public UserController(UserService userService)
		{
			UserService = userService;
		}

		[HttpPost]
		public IActionResult AddUser([FromBody] UserVM user)
		{
			UserService.AddUser(user);
			return Ok();
		}

		[HttpGet]
		public IActionResult UserExist(string username)
		{
			var exist = UserService.UserCreated(username);
			return Ok(exist);
		}

		[HttpGet("ValidateUser")]
		public IActionResult GetUser(string username, string password)
		{
			var user = UserService.GetUser(username, password);
			if (user == null) return Ok("null");
			var validatedUser = new ValidatedUser
			{
				UserName = user.UserName,
				Role = user.Role
			};
			return Ok(validatedUser);
		}
	}
}
