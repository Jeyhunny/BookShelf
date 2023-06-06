using Domain.Entities;
using Service.Services.DTOs.MovieCategory;

namespace Service.Services.Interfaces
{
    public interface IBookCategoryService
    {
        Task CreateAsync(BookCategoryCreateDto movieCategoryCreateDto);
        Task<List<BookCategoryListDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
        Task UpdateAsync(int id, BookCategoryUpdateDto movieCategoryUpdateDto);
        Task<MovieCategory> GetByIdAsync(int id);
    }
}
