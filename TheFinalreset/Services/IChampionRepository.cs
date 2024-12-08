using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public interface IChampionRepository
	{
		Task<Champion?> ReadAsync(int id);
		Task<ICollection<Champion>> ReadAllAsync();
	}
}
