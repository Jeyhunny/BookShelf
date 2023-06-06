using Domain.Entities;
using Service.Services.DTOs.Movie;

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
        Task<List<BookListDto>> GetMoviesByCategoryAsync(string? category);
        Task<List<BookListDto>> RelatedMoviesAsync(int id);
        Task<List<BookListDto>> GetMoviesDesOrderAsync();
        Task<List<BookListDto>> GetMoviesRateOrderAsync();
        Task RateAsync(int id, float rate);
    }
}
