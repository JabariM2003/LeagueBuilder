using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheFinalreset.Models.Entities;

namespace TheFinalreset.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Champion> Champions => Set<Champion>();
		public DbSet<Item> Items => Set<Item>();
		public DbSet<Build> Builds => Set<Build>();
	}
}
