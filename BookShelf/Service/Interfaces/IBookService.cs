using Domain.Entities;
using Service.Services.DTOs.Book;

namespace Service.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(BookCreateDto movieCreateDto);
        Task<List<BookListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookUpdateDto movieUpdateDto);
        Task<BookGetDto> GetByIdAsync(int id);
        Task<List<BookListDto>> SearchAsync(string? searchText);
        Task<List<BookListDto>> GetBooksByCategoryAsync(string? category);
        Task<List<BookListDto>> RelatedBooksAsync(int id);
        Task<List<BookListDto>> GetBooksDesOrderAsync();
        Task<List<BookListDto>> GetBooksRateOrderAsync();
        Task RateAsync(int id, float rate);
    }
}
