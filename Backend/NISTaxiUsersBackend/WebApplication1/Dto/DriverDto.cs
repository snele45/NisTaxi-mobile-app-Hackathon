using WebApplication1.Entities;

namespace WebApplication1.Dto
{
	public class DriverDto
	{
		public int Id { get; set; }

		public string PhoneNumber { get; set; }

		public string DriverName { get; set; }

		public string TaxiLicence { get; set; }
		public string TaxiCardNumber { get; set; }

		public double AmountPouredFirst { get; set; }

		public double AmountPouredSecond { get; set; }

		public string FuelNameFirst { get; set; }

		public string FuelNameSecond { get; set; }

		public double FirstFuelLeft { get; set; }

		public double SecondFuelLeft { get; set; }

		public DriverDto(Driver driver)
		{
			Id = driver.Id;
			PhoneNumber = driver.PhoneNumber;
			DriverName = driver.DriverName;
			TaxiLicence = driver.TaxiLicence;
			AmountPouredFirst = driver.AmountPouredFirst;
			AmountPouredSecond = driver.AmountPouredSecond;
			FuelNameFirst = driver.FuelCombination.Fuel1.Name;
			FuelNameSecond = driver.FuelCombination.Fuel2.Name;
			FirstFuelLeft = CalculateFirstFuelAmount(driver);
			SecondFuelLeft = CalculateSecondFuelAmount(driver);
			TaxiCardNumber = driver.TaxiCardNumber;
		}

		private double CalculateFirstFuelAmount(Driver driver)
		{
			return driver.FuelCombination.LimitFirstFuel - driver.AmountPouredFirst;
		}

		private double CalculateSecondFuelAmount(Driver driver)
		{
			if (driver.FuelCombination.LimitFirstFuel == null || driver.AmountPouredFirst == null)
			{
				return -1;
			}
			else
			{
				return driver.FuelCombination.LimitFirstFuel - driver.AmountPouredFirst;
			}
		}
	}
}
