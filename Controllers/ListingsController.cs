using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auctions.Data;
using Auctions.Models;
using Auctions.Data.Services;
using System.Security.Claims;
using auction.Data;

namespace Auctions.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingsService _listingsService;
        private readonly IBidsService _bidsService;
        private readonly ICommentsService _commentsService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICategoryService _categoryService;

        public ListingsController(IListingsService listingsService, IWebHostEnvironment webHostEnvironment, IBidsService bidsService, ICommentsService commentsService, ICategoryService categoryService)
        {
            _listingsService = listingsService;
            _webHostEnvironment = webHostEnvironment;  
            _bidsService = bidsService;
            _commentsService = commentsService;
            _categoryService = categoryService;
        }

        // GET: Listings
        public async Task<IActionResult> Index(int? pageNumber, string searchString)
        {
            // Вызываем CloseExpiredListings перед загрузкой Index, чтобы закрыть просроченные лоты
            await CloseExpiredListings();

            var applicationDbContext = _listingsService.GetAll();
            int pageSize = 3;
            if (!string.IsNullOrEmpty(searchString))
            {
                applicationDbContext = applicationDbContext.Where(a => a.Title.Contains(searchString));
                return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.Where(l => l.IsSold == false).AsNoTracking(), pageNumber ?? 1, pageSize));

            }

            return View(await PaginatedList<Listing>.CreateAsync(applicationDbContext.Where(l => l.IsSold == false).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // Метод для закрытия лотов, время которых истекло
        public async Task<IActionResult> CloseExpiredListings()
        {
            var expiredListings = await _listingsService.GetExpiredListingsAsync(); // Получить все лоты, время закрытия которых истекло
            foreach (var listing in expiredListings)
            {
                await CloseBidding(listing.Id); // Закрыть лот
            }

            // Добавим отладочное сообщение
            Console.WriteLine("Expired listings closed successfully.");

            return RedirectToAction("Index"); // Перенаправить пользователя на главную страницу или другую подходящую страницу
        }


        public async Task<IActionResult> MyListings(int? pageNumber)
        {
            var applicationDbContext = _listingsService.GetAll();
            int pageSize = 3;          

            return View("Index", await PaginatedList<Listing>.CreateAsync(applicationDbContext.Where(l =>l.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public async Task<IActionResult> MyBids(int? pageNumber)
        {
            var applicationDbContext = _bidsService.GetAll();
            int pageSize = 3;

            return View(await PaginatedList<Bid>.CreateAsync(applicationDbContext.Where(l => l.IdentityUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _listingsService.GetById(id);

            if (listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategory(); // Получите список категорий из сервиса или репозитория
            var listingVM = new ListingVM();
            listingVM.Category = new SelectList(categories, "Id", "Name"); // Добавьте список категорий в модель представления
            return View(listingVM);
        }

        // POST: Listings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingVM listing)
        {
            if (listing.Image != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                string fileName = listing.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await listing.Image.CopyToAsync(fileStream);
                }

                var listObj = new Listing
                {
                    Title = listing.Title,
                    Description = listing.Description,
                    Price = listing.Price,
                    IdentityUserId = listing.IdentityUserId,
                    CategoryId = listing.SelectedCategoryId,
                    ImagePath = fileName,
					TimeOfClosure = listing.TimeOfClosure,
				};
                await _listingsService.Add(listObj);
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        [HttpPost]
        public async Task<ActionResult> AddBid([Bind("Id, Price, ListingId, IdentityUserId")] Bid bid)
        {
            if(ModelState.IsValid) 
            {
                await _bidsService.Add(bid);
            }
            var listing = await _listingsService.GetById(bid.ListingId);
            listing.Price = bid.Price;
            await _listingsService.SaveChanges();

            return View("Details", listing);
        }
        public async Task<ActionResult> CloseBidding(int id)
        {
            var listing = await _listingsService.GetById(id);
            listing.IsSold = true;
            await _listingsService.SaveChanges();
            return View("Details", listing);
        }
        [HttpPost]
        public async Task<ActionResult> AddComment([Bind("Id, Content, ListingId, IdentityUserId")] Comment comment)
        {
            if(ModelState.IsValid) 
            {
                await _commentsService.Add(comment);
            }
            var listing = await _listingsService.GetById(comment.ListingId);
            return View("Details", listing);
        }

        //// GET: Listings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Listings == null)
        //    {
        //        return NotFound();
        //    }

        //    var listing = await _context.Listings.FindAsync(id);
        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", listing.IdentityUserId);
        //    return View(listing);
        //}

        //// POST: Listings/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,ImagePath,IsSold,IdentityUserId")] Listing listing)
        //{
        //    if (id != listing.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(listing);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ListingExists(listing.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", listing.IdentityUserId);
        //    return View(listing);
        //}

        //// GET: Listings/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Listings == null)
        //    {
        //        return NotFound();
        //    }

        //    var listing = await _context.Listings
        //        .Include(l => l.User)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (listing == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(listing);
        //}

        //// POST: Listings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Listings == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Listings'  is null.");
        //    }
        //    var listing = await _context.Listings.FindAsync(id);
        //    if (listing != null)
        //    {
        //        _context.Listings.Remove(listing);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ListingExists(int id)
        //{
        //  return (_context.Listings?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
