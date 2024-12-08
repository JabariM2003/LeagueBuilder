using TheFinalreset.Data;
using TheFinalreset.Models.Entities;

namespace TheFinalreset.Services
{
	public class Initializer
	{
		private readonly ApplicationDbContext _db;
		public Initializer(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task SeedDatabaseAsync()
		{
			_db.Database.EnsureCreated();

			if (_db.Champions.Any()) return;
			var champions = new List<Champion>
			{
				new() { Name = "Ambessa", Role = Role.Jungle, Difficulty = Difficulty.High},
				new() { Name = "Darius", Role = Role.Top, Difficulty = Difficulty.Low},
				new() { Name = "Draven", Role = Role.Bottom, Difficulty = Difficulty.High},
				new() { Name = "K'Sante", Role = Role.Top, Difficulty = Difficulty.High},
				new() { Name = "Nunu & Willump", Role = Role.Support, Difficulty = Difficulty.Medium},
				new() { Name = "Sett", Role = Role.Top, Difficulty = Difficulty.Low},
				new() { Name = "Sylas", Role = Role.Middle, Difficulty = Difficulty.Medium}
			};
			await _db.Champions.AddRangeAsync(champions);
			await _db.SaveChangesAsync();

			var items = new List<Item>
			{
				new() { Name = "Heartsteel", Description = "Extra HP", AttackDamage = 0, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000},
				new() { Name = "Plated Steelcaps", Description = "Damage Reduction", AttackDamage = 0, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000},
				new() { Name = "Overlord's Bloodmail", Description = "Bonus attack damage", AttackDamage = 30, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000 },
				new() { Name = "Titanic Hydra", Description = "Bonus attack damage", AttackDamage = 40, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000},
				new() { Name = "Sterak's Gage", Description = "Bonus attack damage", AttackDamage = 0, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000},
				new() { Name = "Hullbreaker", Description = "Bonus damage to structures", AttackDamage = 40, AttackSpeed = 0, CriticalStrikeChance = 0, LifeSteal = 0, ArmorPenetration = 0, Lethality = 0, Cost = 3000}
			};
			await _db.Items.AddRangeAsync(items);
			await _db.SaveChangesAsync();
		}
	}
}
