using Microsoft.EntityFrameworkCore;
using NotesAPI.Data;

namespace NotesAPI.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<User> User { get; set; }
		public DbSet<Note> Note { get; set; }
	}
}
