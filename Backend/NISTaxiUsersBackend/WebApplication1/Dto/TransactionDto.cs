using WebApplication1.Entities;

namespace WebApplication1.Dto
{
	public class TransactionDto
	{
		public int Id { get; set; }

		public DriverDto DriverDto { get; set; }

		public Fuel Fuel { get; set; }

		public double Amount { get; set; }

		public double Price { get; set; }

		public DateTime DateTime { get; set; }

		public string PlaceOfTransaction { get; set; }

        public TransactionDto(TaxiTransaction taxiTransaction)
        {
			Id = taxiTransaction.Id;
			DriverDto = new DriverDto(taxiTransaction.Driver);
			Fuel = taxiTransaction.Fuel;
			Amount = taxiTransaction.Amount;
			Price = taxiTransaction.Price;
			DateTime = taxiTransaction.DateTime;
			PlaceOfTransaction = taxiTransaction.PlaceOfTransaction;
        }
    }
}
