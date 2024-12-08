using Microsoft.EntityFrameworkCore;
using TheFinalreset.Data;
using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public class DbBuildRepository : IBuildRepository
	{
		private readonly ApplicationDbContext _db;
		private readonly IChampionRepository _championRepo;
		private readonly IItemRepository _itemRepo;

		public DbBuildRepository(ApplicationDbContext db, IChampionRepository championRepo, IItemRepository itemRepo)
		{
			_db = db;
			_championRepo = championRepo;
			_itemRepo = itemRepo;
		}

		public async Task<Build?> ReadAsync(int id)
		{
			return await _db.Builds
			.Include(c => c.Champion)
			.Include(i => i.Item)
			.FirstOrDefaultAsync(i => i.Id == id);
		}
		public async Task<ICollection<Build>> ReadAllAsync()
		{
			return await _db.Builds
			.Include(c => c.Champion)
			.Include(i => i.Item)
			.ToListAsync();
		}
		public async Task<Build?> CreateAsync(int championId, int itemId)
		{
			var champion = await _championRepo.ReadAsync(championId);
			if (champion == null)
			{
				return null;
			}
			var championBuild = champion.ChampionBuilds
			.FirstOrDefault(i => i.ItemId == itemId);
			if (championBuild != null)
			{
				return null;
			}
			var item = await _itemRepo.ReadAsync(itemId);
			if (item == null)
			{
				return null;
			}
			var build = new Build
			{
				Champion = champion,
				Item = item
			};
			champion.ChampionBuilds.Add(build);
			item.ItemBuilds.Add(build);
			await _db.SaveChangesAsync();
			return build;
		}
	}
}
