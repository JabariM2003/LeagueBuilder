using System.ComponentModel.DataAnnotations;

namespace TheFinalreset.Models.Entities
{
	public class Build
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; } = string.Empty;
		[StringLength(500)]
		public string Description { get; set; } = string.Empty;

		//Connects build to champion and item
		public int ChampionId { get; set; }
		public Champion? Champion { get; set; }
		public int ItemId { get; set; }
		public Item? Item { get; set; }
	}
}
