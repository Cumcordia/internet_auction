using System.Collections.Generic;
using auction.Data;
using Auctions.Models;

namespace Auctions.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategory()
        {
            return _context.Category.ToList(); // Получаем все категории из базы данных
        }

        // Реализация других методов для работы с категориями
    }
}
