using System;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data
{
	public class BuchungDbContext : DbContext
	{
		public BuchungDbContext(DbContextOptions<BuchungDbContext> options) : base(options)
		{
		}

		public DbSet<Buchung> buchung { get; set; }
	}
}

