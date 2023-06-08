using Domain.Entities;
using Service.Services.DTOs.BookShelf;

namespace Service.Services.Interfaces
{
    public interface IBookShelfService
    {
        Task CreateAsync(BookShelfCreateDto movflixCreateDto);
        Task<List<BookShelfListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookShelfUpdateDto movflixUpdateDto);
        Task<BookShelf> GetByIdAsync(int id);
    }
}
