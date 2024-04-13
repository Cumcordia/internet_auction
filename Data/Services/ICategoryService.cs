using Auctions.Models;
using System.Threading.Tasks; // Импортируйте пространство имен для Task

namespace Auctions.Data.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory(); // Метод для получения всех категорий
        Task<int> GetCategoryIdByNameAsync(string categoryName); // Метод для получения идентификатора категории по имени
        // Другие методы для работы с категориями, например, добавление, удаление и т. д.
    }
}
