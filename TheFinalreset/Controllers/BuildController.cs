using Microsoft.AspNetCore.Mvc;
using TheFinalreset.Models.ViewModels;
using TheFinalreset.Services;

namespace TheFinalreset.Controllers
{
	public class BuildController : Controller
	{
		private readonly IChampionRepository _championRepo;
		private readonly IItemRepository _itemRepo;
		private readonly IBuildRepository _buildRepo;

		public BuildController(IChampionRepository championRepo, IItemRepository itemRepo, IBuildRepository buildRepo)
		{
			_championRepo = championRepo;
			_itemRepo = itemRepo;
			_buildRepo = buildRepo;
		}

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Create([Bind(Prefix = "id")] int championId, int itemId)
		{
			var champion = await _championRepo.ReadAsync(championId);
			if (champion == null)
			{
				return RedirectToAction("Index", "Champion");
			}

			var item = await _itemRepo.ReadAsync(itemId);
			if (item == null)
			{
				return RedirectToAction("Details", "Champion", new { id = championId });
			}

			var build = champion.ChampionBuilds.SingleOrDefault(i => i.ItemId == itemId);
			if (build != null)
			{
				return RedirectToAction("Details", "Champion", new { id = championId });
			}

			var buildVM = new BuildVM
			{
				Champion = champion,
				Item = item
			};
			return View(buildVM);
		}

		[HttpPost, ValidateAntiForgeryToken, ActionName("Create")]
		public async Task<IActionResult> CreateConfirmed(int championId, int itemId)
		{
			await _buildRepo.CreateAsync(championId, itemId);
			return RedirectToAction("Details", "Champion", new { id = championId });
		}
	}
}
