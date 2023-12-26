

using WebApplication1.RepositoryInterfaces;

namespace WebApplication1.Authentication
{
	public sealed class AuthenticationService : IAuthenticationService
	{
		private readonly IJwtProvider _jwtProvider;
		private readonly IDriverRepository _driverRepository;

		public AuthenticationService(IJwtProvider jwtProvider, IDriverRepository driverRepository)
		{
			_jwtProvider = jwtProvider;
			_driverRepository = driverRepository;
		}

		public string Authenticate(string phoneNumber, string taxiLicence)
		{
			var driver = _driverRepository.GetDriverByPhoneNumber(phoneNumber);

			if (driver is null)
			{
				return "";
			}

			if (driver.TaxiLicence != taxiLicence)
			{
				return "";
			}

			return _jwtProvider.Generate(driver);
		}
	}
}
