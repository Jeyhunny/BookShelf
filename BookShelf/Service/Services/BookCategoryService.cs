using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Services.DTOs.MovieCategory;
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

        public async Task CreateAsync(BookCategoryCreateDto movieCategoryCreateDto)
        {
            var mappedData = _mapper.Map<MovieCategory>(movieCategoryCreateDto);
            await _repo.CreateAsync(mappedData);
           
        }

        public async Task DeleteAsync(int id)
        {
            var movieCategory = await _repo.GetAsync(id);

            await _repo.DeleteAsync(movieCategory);
        }

        public async Task<List<BookCategoryListDto>> GetAllAsync()
        {

            var categories = await _repo.GetAllCategories();
            var result = _mapper.Map<List<BookCategoryListDto>>(categories);
            return result;
        }

        public async Task<MovieCategory> GetByIdAsync(int id)
        {
            return (await _repo.GetAsync(id));
        }

        public async Task SoftDeleteAsync(int id)
        {
            var movieCategory = await _repo.GetAsync(id);

            await _repo.SoftDeleteAsync(movieCategory);


        }

        public async Task UpdateAsync(int id, BookCategoryUpdateDto movieCategoryUpdateDto)
        {
            var dbMovieCategory = await _repo.GetAsync(id);

            _mapper.Map(movieCategoryUpdateDto, dbMovieCategory);

            await _repo.UpdateAsync(dbMovieCategory);
        }
    }
}
