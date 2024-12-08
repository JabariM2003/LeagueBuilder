using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TheFinalreset.Models.Entities
{
	public enum Role { Top, Middle, Jungle, Bottom, Support }
	public enum Difficulty { Low, Medium, High }
	public class Champion
	{
		public int Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; } = string.Empty;
		public Role Role { get; set; }
		public Difficulty Difficulty { get; set; }

		//Connects champion to build
		public ICollection<Build> ChampionBuilds { get; set; } = new List<Build>();
	}
}
