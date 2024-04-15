using Auctions.Models;

namespace Auctions.Data.Services
{
    public interface IListingsService
    {
        IQueryable<Listing> GetAll();
        Task Add(Listing listing);
        Task<Listing> GetById(int? id);
        Task SaveChanges();
        IEnumerable<Listing> GetByCategory(string category); // Получение лотов по категории
        Task<IEnumerable<Listing>> GetExpiredListingsAsync();
        Task CloseBidding(int id);
    }
}
