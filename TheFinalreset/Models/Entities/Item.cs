namespace TheFinalreset.Models.Entities
{
	public class Item
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public int AttackDamage { get; set; }
		public double AttackSpeed { get; set; }
		public double CriticalStrikeChance { get; set; }
		public double LifeSteal { get; set; }
		public double ArmorPenetration { get; set; }
		public int Lethality { get; set; }
		public int Cost { get; set; }

		//Connects item to build
		public ICollection<Build> ItemBuilds { get; set; } = new List<Build>();
	}
}
