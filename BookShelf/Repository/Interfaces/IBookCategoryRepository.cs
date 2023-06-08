using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBookCategoryRepository : IRepository<BookCategory>
    {
        Task<List<BookCategory>> GetAllCategories();
    }
}
