using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Entities;
using WebApplication1.RepositoryInterfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class TransactionController : Controller
	{
		private readonly ITransactionRepository transactionRepository;

		public TransactionController(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<TaxiTransaction>))]
		public IActionResult GetTransactions()
		{
			var transactions = transactionRepository.GetTaxiTransactions();

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(transactions);
		}

		[HttpGet("{transactionId}")]
		[ProducesResponseType(200, Type = typeof(TaxiTransaction))]
		[ProducesResponseType(400)]
		public IActionResult GetTransaction(int transactionId)
		{
			var transaction = transactionRepository.GetTaxiTransaction(transactionId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(new TransactionDto(transaction));
		}

		[HttpGet("{driverId}/driverTransactions")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<TaxiTransaction>))]
		[ProducesResponseType(400)]
		public IActionResult GetDriverTransactions(int driverId)
		{
			var driverTransactions = transactionRepository.GetAllDriverTransactions(driverId);

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			return Ok(driverTransactions);
		}
	}
}
