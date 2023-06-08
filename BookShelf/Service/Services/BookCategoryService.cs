using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Services.DTOs.BookCategory;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly IBookCategoryRepository _repo;
        private readonly IMapper _mapper;
       

        public BookCategoryService(IBookCategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
           
        }

        public async Task CreateAsync(BookCategoryCreateDto bookCategoryCreateDto)
        {
            var mappedData = _mapper.Map<BookCategory>(bookCategoryCreateDto);
            await _repo.CreateAsync(mappedData);
           
        }

        public async Task DeleteAsync(int id)
        {
            var bookCategory = await _repo.GetAsync(id);

            await _repo.DeleteAsync(bookCategory);
        }

        public async Task<List<BookCategoryListDto>> GetAllAsync()
        {

            var categories = await _repo.GetAllCategories();
            var result = _mapper.Map<List<BookCategoryListDto>>(categories);
            return result;
        }

        public async Task<BookCategory> GetByIdAsync(int id)
        {
            return (await _repo.GetAsync(id));
        }

        public async Task SoftDeleteAsync(int id)
        {
            var bookCategory = await _repo.GetAsync(id);

            await _repo.SoftDeleteAsync(bookCategory);


        }

        public async Task UpdateAsync(int id, BookCategoryUpdateDto bookCategoryUpdateDto)
        {
            var dbBookCategory = await _repo.GetAsync(id);

            _mapper.Map(bookCategoryUpdateDto, dbBookCategory);

            await _repo.UpdateAsync(dbBookCategory);
        }
    }
}
