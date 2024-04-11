using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Auctions.Models;
using Auctions.Data.Services;

namespace Auctions.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IListingsService _listingsService;

        public CategoryController(IListingsService listingsService)
        {
            _listingsService = listingsService;
        }

        public IActionResult Tech()
        {
            var techListings = _listingsService.GetByCategory("Tech"); // Получаем список лотов категории "Tech"
            return View(techListings); // Передаем список лотов в представление
        }

        public IActionResult Vintage()
        {
            return View();
        }
        public IActionResult Music()
        {
            return View();
        }
        public IActionResult Art()
        {
            return View();
        }
        public IActionResult Books()
        {
            return View();
        }
        public IActionResult Fashion()
        {
            return View();
        }
        public IActionResult Antiques()
        {
            return View();
        }

    }
}
