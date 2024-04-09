using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Auctions.Models;

namespace Auctions.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Tech()
        {
            return View();
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
