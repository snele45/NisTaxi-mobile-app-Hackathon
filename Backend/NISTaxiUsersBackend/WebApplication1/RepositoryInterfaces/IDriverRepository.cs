using WebApplication1.Entities;

namespace WebApplication1.RepositoryInterfaces
{
	public interface IDriverRepository
	{
		Driver GetDriverByPhoneNumber(string phoneNumber);
		ICollection<Driver> GetDrivers();

		Driver GetDriver(int id);

		string GetDriverTaxiLicence(int id);

		double GetDriverAmountPouredFirst(int id);

		double GetDriverAmountPouredSecond(int id);

		FuelCombination GetFuelCombination(int id);

		double CalculateFirstFuelAmount(int id);

		double CalculateSecondFuelAmount(int id);

		string GetDriversName(int id);


	}
}
