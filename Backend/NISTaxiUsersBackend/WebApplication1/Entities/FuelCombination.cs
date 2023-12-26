using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
	public class FuelCombination
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public Fuel Fuel1 { get; set; }

		public Fuel? Fuel2 { get; set; }

		[Required]
		public double LimitFirstFuel { get; set; }

		public double? LimitLastFuel { get; set; }
	}
}
