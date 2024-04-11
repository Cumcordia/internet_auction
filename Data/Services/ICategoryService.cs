using Auctions.Models; // Подключите пространство имен с моделью Category

namespace Auctions.Data.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategory(); // Метод для получения всех категорий
        // Другие методы для работы с категориями, например, добавление, удаление и т. д.
    }
}
