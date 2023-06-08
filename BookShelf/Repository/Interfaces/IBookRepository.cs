using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetAllBooksWithCategories();
        Task<Book> GetBookById(int? id);
        Task<List<Book>> GetBooksBySearch(string? searchText);
        Task<List<Book>> GetBooksByCategory(string? category);
        Task<List<Book>> RelatedBooks(int id);
        Task<List<Book>> GetBooksDescOrder();
        Task<List<Book>> GetBooksRateDesc();
        Task RateMovie(int id, float rate);
    }
}
