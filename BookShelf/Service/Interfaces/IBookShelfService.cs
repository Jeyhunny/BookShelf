using Domain.Entities;
using Service.Services.DTOs.Movflix;

namespace Service.Services.Interfaces
{
    public interface IBookShelfService
    {
        Task CreateAsync(BookShelfCreateDto movflixCreateDto);
        Task<List<BookShelfListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookShelfUpdateDto movflixUpdateDto);
        Task<Movflix> GetByIdAsync(int id);
    }
}
