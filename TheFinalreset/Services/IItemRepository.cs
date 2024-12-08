
using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public interface IItemRepository
	{
		Task<Item?> ReadAsync(int id);
		Task<ICollection<Item>> ReadAllAsync();
	}
}
