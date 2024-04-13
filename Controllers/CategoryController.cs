using Microsoft.AspNetCore.Mvc;
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
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Tech" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> Vintage(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Vintage" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Music(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Music" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Art(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Art" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Books(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Books" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Fashion(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Fashion" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> Antiques(int? pageNumber, string searchString)
        {
            var applicationDbContext = _listingsService.GetAll().Where(l => l.Category.Name == "Antique" && !l.IsSold); // Filter by category and active listings

            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(l => l.Title.Contains(searchString));
            }

            int pageSize = 3;
            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

    }
}
