using WebApplication1.Entities;

namespace WebApplication1.RepositoryInterfaces
{
    public interface ITransactionRepository
    {
        ICollection<TaxiTransaction> GetAllDriverTransactions(int driverId);
        TaxiTransaction GetTaxiTransaction(int id);
        ICollection<TaxiTransaction> GetTaxiTransactions();
    }
}