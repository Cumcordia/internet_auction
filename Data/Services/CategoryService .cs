using System.Collections.Generic;
using auction.Data;
using Auctions.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<int> GetCategoryIdByNameAsync(string categoryName)
        {
            var category = _context.Category.FirstOrDefaultAsync(c => c.Name == categoryName);
            return category?.Id ?? 0; // Вернуть идентификатор категории или 0, если категория не найдена
        }

    }
}
