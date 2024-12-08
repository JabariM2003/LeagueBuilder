using Microsoft.AspNetCore.Mvc;
using TheFinalreset.Services;

namespace TheFinalreset.Controllers
{
	public class ChampionController : Controller
	{
		private IChampionRepository _championRepo;

		public ChampionController(IChampionRepository championRepo)
		{
			_championRepo = championRepo;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _championRepo.ReadAllAsync());
		}

		public async Task<IActionResult> Details(int id)
		{
			var champion = await _championRepo.ReadAsync(id);
			if (champion == null)
			{
				return RedirectToAction("Index");
			}
			return View(champion);
		}
	}
}
