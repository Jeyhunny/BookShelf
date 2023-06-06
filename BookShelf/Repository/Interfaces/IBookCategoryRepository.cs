using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBookCategoryRepository : IRepository<MovieCategory>
    {
        Task<List<MovieCategory>> GetAllCategories();
    }
}
