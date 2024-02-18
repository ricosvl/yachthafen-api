using System;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
	public class UserDbContext : DbContext
	{
		public UserDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<User> users { get; set; }
	}
}

