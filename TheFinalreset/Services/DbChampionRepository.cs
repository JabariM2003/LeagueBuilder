using Microsoft.EntityFrameworkCore;
using TheFinalreset.Data;
using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public class DbChampionRepository : IChampionRepository
	{
		private readonly ApplicationDbContext _db;
		public DbChampionRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Champion?> ReadAsync(int id)
		{
			return await _db.Champions
			.Include(cb => cb.ChampionBuilds)
			.ThenInclude(i => i.Item)
			.FirstOrDefaultAsync(c => c.Id == id);
		}
		public async Task<ICollection<Champion>> ReadAllAsync()
		{
			return await _db.Champions
			.Include(cb => cb.ChampionBuilds)
			.ThenInclude(i => i.Item)
			.ToListAsync();
		}
	}
}
