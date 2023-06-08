using AutoMapper;
using Domain.Entities;
using Repository.Interfaces;
using Service.Services.DTOs.BookShelf;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class BookShelfService : IBookShelfService
    {
        private readonly IBookShelfRepository _repo;
        private readonly IMapper _mapper;

        public BookShelfService(IBookShelfRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookShelfCreateDto movflixCreateDto)
        {
            var mappedData = _mapper.Map<BookShelf>(movflixCreateDto);
            await _repo.CreateAsync(mappedData);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repo.GetAsync(id);

            await _repo.DeleteAsync(product);
        }

        public async Task<List<BookShelfListDto>> GetAllAsync()
        {

            return _mapper.Map<List<BookShelfListDto>>(await _repo.GetAllAsync());
        }

        public async Task<BookShelf> GetByIdAsync(int id)
        {
            return (await _repo.GetAsync(id));
        }

        public async Task SoftDeleteAsync(int id)
        {
            var bookShelf = await _repo.GetAsync(id);

            await _repo.SoftDeleteAsync(bookShelf);


        }

        public async Task UpdateAsync(int id, BookShelfUpdateDto bookShelfUpdateDto)
        {
            var dbBookShelf = await _repo.GetAsync(id);

            _mapper.Map(dbBookShelf, bookShelfUpdateDto);

            await _repo.UpdateAsync(dbBookShelf);
        }
    }
}
