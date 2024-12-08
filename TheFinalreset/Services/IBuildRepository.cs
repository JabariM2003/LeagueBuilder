using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public interface IBuildRepository
	{
		Task<Build?> ReadAsync(int id);
		Task<ICollection<Build>> ReadAllAsync();
		Task<Build?> CreateAsync(int championId, int itemId);
	}
}
