using Microsoft.AspNetCore.Mvc;
using TheFinalreset.Services;

namespace TheFinalreset.Controllers
{
	public class ItemController : Controller
	{
		private IChampionRepository _championRepo;
		private readonly IItemRepository _itemRepo;

		public ItemController(IChampionRepository championRepo, IItemRepository itemRepo)
		{
			_championRepo = championRepo;
			_itemRepo = itemRepo;
		}

		public async Task<IActionResult> Index()
		{
			var allItems = await _itemRepo.ReadAllAsync();
			return View(allItems);
		}

		public async Task<IActionResult> AddItem([Bind(Prefix = "id")] int championId)
		{
			var champion = await _championRepo.ReadAsync(championId);
			if (champion == null)
			{
				return RedirectToAction("Index", "Champion");
			}
			var allItems = await _itemRepo.ReadAllAsync();
			var itemsAdded = champion.ChampionBuilds
			.Select(i => i.Item).ToList();
			var itemsNotAdded = allItems.Except(itemsAdded);
			ViewData["Champion"] = champion;
			return View(itemsNotAdded);
		}
	}
}
