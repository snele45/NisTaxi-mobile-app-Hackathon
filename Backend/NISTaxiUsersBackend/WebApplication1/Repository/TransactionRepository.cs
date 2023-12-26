using WebApplication1.DatabaseContext;
using WebApplication1.Entities;
using WebApplication1.RepositoryInterfaces;

namespace WebApplication1.Repository
{
    public class TransactionRepository : ITransactionRepository
	{
		private readonly DataContext context;

		public TransactionRepository(DataContext context)
		{
			this.context = context;
		}

		public TaxiTransaction GetTaxiTransaction(int id)
		{
			return context.Transactions.Where(t => t.Id == id).FirstOrDefault();
		}

		public ICollection<TaxiTransaction> GetTaxiTransactions()
		{
			return context.Transactions.ToList();
		}

		public ICollection<TaxiTransaction> GetAllDriverTransactions(int driverId)
		{
			return context.Transactions.Where(t => t.Driver.Id == driverId).ToList();
		}
	}
}
