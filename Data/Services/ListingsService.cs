using auction.Data;
using Auctions.Models;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data.Services
{
    public class ListingsService : IListingsService
    {
        private readonly ApplicationDbContext _context;

        public ListingsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
        }
        public IQueryable<Listing> GetAll()
        {
            var applicationDbContext = _context.Listings.Include(l => l.User);
            return applicationDbContext;
        }
        public async Task<Listing> GetById(int? id)
        {
            var listing = await _context.Listings
                .Include(l => l.User)
                .Include(l => l.Comments)
                .Include(l => l.Bids)
                .ThenInclude(l => l.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            return listing;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Listing> GetByCategory(string category)
        {
            return _context.Listings.Where(l => l.Category.Name == category).ToList();
        }
        public async Task<IEnumerable<Listing>> GetExpiredListingsAsync()
        {
            var currentTime = DateTime.Now;
            return await _context.Listings.Where(l => l.TimeOfClosure < currentTime && !l.IsSold).ToListAsync();
        }

        public async Task CloseBidding(int id)
        {
            var listing = await _context.Listings.FindAsync(id);
            if (listing != null)
            {
                listing.IsSold = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
