using Microsoft.AspNetCore.Mvc;
using WebApplication1.Authentication;
using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.RepositoryInterfaces;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DriverController : Controller
	{
		private readonly IDriverRepository driverRepository;
		private readonly IAuthenticationService authenticationService;

		public DriverController(IDriverRepository driverRepository, IAuthenticationService authenticationService)
		{
			this.driverRepository = driverRepository;
			this.authenticationService = authenticationService;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<Driver>))]
		public IActionResult GetDrivers()
		{
			var drivers = driverRepository.GetDrivers();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(drivers);
		}

		[HttpGet("{driverId}")]
		[ProducesResponseType(200, Type = typeof(Driver))]
		[ProducesResponseType(400)]
		public IActionResult GetDriver(int driverId)
		{
			var driver = driverRepository.GetDriver(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(new DriverDto(driver));
		}

		[HttpGet("{driverId}/taxiLicence")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult GetDriverTaxiLicence(int driverId)
		{
			var taxiLicence = driverRepository.GetDriverTaxiLicence(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(taxiLicence);
		}

		[HttpGet("{driverId}/driverName")]
		[ProducesResponseType(200, Type = typeof(string))]
		[ProducesResponseType(400)]
		public IActionResult GetDriverName(int driverId)
		{
			var taxiLicence = driverRepository.GetDriversName(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(taxiLicence);
		}

		[HttpGet("{driverId}/firstFuelLeft")]
		[ProducesResponseType(200, Type = typeof(double))]
		[ProducesResponseType(400)]
		public IActionResult GetFirstFuelLeft(int driverId)
		{
			var firstAmountLeft = driverRepository.CalculateFirstFuelAmount(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(firstAmountLeft);
		}

		[HttpGet("{driverId}/secondFuelLeft")]
		[ProducesResponseType(200, Type = typeof(double))]
		[ProducesResponseType(400)]
		public IActionResult GetSecondFuelLeft(int driverId)
		{
			var secondAmountLeft = driverRepository.CalculateSecondFuelAmount(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(secondAmountLeft);
		}

		[HttpPost("login")]
		public IActionResult Login([FromBody] DriverLoginDto dto)
		{
			try
			{
				var token = authenticationService.Authenticate(dto.PhoneNumber, dto.TaxiLicence);
				if (token == "")
				{
					return Unauthorized();
				}
				return Ok(token);

			}
			catch (Exception ex)
			{
				return Unauthorized(ex.Message);
			}

		}
	}
}
