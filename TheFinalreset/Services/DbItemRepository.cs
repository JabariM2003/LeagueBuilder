using TheFinalreset.Data;
using TheFinalreset.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace TheFinalreset.Services
{
	public class DbItemRepository : IItemRepository
	{
		private readonly ApplicationDbContext _db;
		public DbItemRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Item?> ReadAsync(int id)
		{
			return await _db.Items
			.Include(ib => ib.ItemBuilds)
			.ThenInclude(c => c.Champion)
			.FirstOrDefaultAsync(i => i.Id == id);
		}
		public async Task<ICollection<Item>> ReadAllAsync()
		{
			return await _db.Items
			.Include(ib => ib.ItemBuilds)
			.ThenInclude(c => c.Champion)
			.ToListAsync();
		}
	}
}
