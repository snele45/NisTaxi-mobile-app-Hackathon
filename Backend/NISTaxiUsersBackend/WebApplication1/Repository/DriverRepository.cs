using WebApplication1.DatabaseContext;
using WebApplication1.Entities;
using WebApplication1.RepositoryInterfaces;

namespace WebApplication1.Repository
{
	public class DriverRepository : IDriverRepository
	{
		private readonly DataContext _context;

		public DriverRepository(DataContext context)
		{
			_context = context;
		}

		public Driver GetDriver(int id)
		{
			var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
			var fuelCombination = _context.FuelCombinations.FirstOrDefault(f => f.Id == driver.FuelCombinationId);
			_context.Entry(fuelCombination).Reference(d => d.Fuel1).Load();
			_context.Entry(fuelCombination).Reference(d => d.Fuel2).Load();
			return driver;
		}

		public Driver GetDriverByPhoneNumber(string phoneNumber)
		{
			return _context.Drivers.FirstOrDefault(d => d.PhoneNumber == phoneNumber);
		}

		public string GetDriversName(int id)
		{
			return _context.Drivers.Where(d => d.Id == id).FirstOrDefault().DriverName;
		}

		public double GetDriverAmountPouredFirst(int id)
		{
			return _context.Drivers.Where(d => d.Id == id).FirstOrDefault().AmountPouredFirst;
		}

		public double GetDriverAmountPouredSecond(int id)
		{
			return _context.Drivers.Where(d => d.Id == id).FirstOrDefault().AmountPouredSecond;
		}

		public ICollection<Driver> GetDrivers()
		{
			return _context.Drivers.ToList();
		}

		public string GetDriverTaxiLicence(int id)
		{
			return _context.Drivers.Where(d => d.Id == id).FirstOrDefault().TaxiLicence;
		}

		public FuelCombination GetFuelCombination(int id)
		{
			return _context.Drivers.Where(d => d.Id == id).FirstOrDefault().FuelCombination;
		}

		public double CalculateFirstFuelAmount(int id)
		{
			return GetDriver(id).FuelCombination.LimitFirstFuel - GetDriver(id).AmountPouredFirst;
		}

		public double CalculateSecondFuelAmount(int id)
		{
			if (GetDriver(id).FuelCombination.LimitLastFuel == null || GetDriver(id).AmountPouredSecond == null)
			{
				return -1;
			}
			else
			{
				return (double)(GetDriver(id).FuelCombination.LimitLastFuel - GetDriver(id).AmountPouredSecond);
			}
		}
	}
}
