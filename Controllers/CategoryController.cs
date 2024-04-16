/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Auctions.Models;
using Auctions.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IListingsService _listingsService;

        public CategoryController(IListingsService listingsService)
        {
            _listingsService = listingsService;
        }

        public async Task<IActionResult> Tech(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Техника" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Vintage(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Винтаж" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Music(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Музыка" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Art(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Искусство" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Books(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Книги" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Fashion(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Мода" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Antiques(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Антиквариат" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

    }
}
*/