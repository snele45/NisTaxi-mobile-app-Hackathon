using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
	public class TaxiTransaction
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public Driver Driver { get; set; }

		[Required]
		public int FuelId { get; set; }

		[ForeignKey(nameof(FuelId))]
		public Fuel Fuel { get; set; }

		[Required]
		public double Amount { get; set; }

		[Required]
		public double Price { get; set; }

		[Required]
		public DateTime DateTime { get; set; }

		[Required]
		public string PlaceOfTransaction { get; set; }
	}
}
