using AutoMapper;
using Domain.Entities;
using Repository.Interfaces;
using Service.Services.DTOs.Book;
using Service.Services.Interfaces;
using System.Runtime.InteropServices;

namespace Service.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(BookCreateDto bookCreateDto)
        {
            var mappedData = _mapper.Map<Book>(bookCreateDto);
            await _repo.CreateAsync(mappedData);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _repo.GetAsync(id);

            await _repo.DeleteAsync(book);
        }

        public async Task<List<BookListDto>> GetAllAsync()
        {
            var bookList = await _repo.GetAllBooksWithCategories();
            return _mapper.Map<List<BookListDto>>(bookList);
        }

        public async Task<BookGetDto> GetByIdAsync(int id)
        {
            var mappedBook = _mapper.Map<BookGetDto>(await _repo.GetBookById(id));
            
           
            return mappedBook;
        }

        public async Task<List<BookListDto>> SearchAsync(string? searchText)
        {
            List<Book> searchDatas = new();

            if (searchText != null)
            {
                searchDatas = await _repo.GetBooksBySearch(searchText);
            }
            else
            {
                searchDatas = await _repo.GetAllBooksWithCategories();
            }

            return _mapper.Map<List<BookListDto>>(searchDatas);
        }

        public async Task SoftDeleteAsync(int id)
        {
            var book = await _repo.GetAsync(id);

            await _repo.SoftDeleteAsync(book);
        }

        public async Task UpdateAsync(int id, BookUpdateDto bookUpdateDto)
        {
            var dbBook = await _repo.GetAsync(id);

            _mapper.Map(bookUpdateDto, dbBook);

            await _repo.UpdateAsync(dbBook);
        }

    

        public async Task RateAsync(int id, float rate)
        {
            await _repo.RateMovie(id, rate);  
            
        }

        public async Task<List<BookListDto>> GetBooksByCategoryAsync(string? category)
        {
            var dbMovies = await _repo.GetBooksByCategory(category);

            var mappedMovies = _mapper.Map<List<BookListDto>>(dbMovies);

            return mappedMovies;
        }

        public async Task<List<BookListDto>> GetBooksDesOrderAsync()
        {
            var dbMovies = await _repo.GetBooksDescOrder();

            var mappedMovies = _mapper.Map<List<BookListDto>>(dbMovies);

            return mappedMovies;
        }

        public async Task<List<BookListDto>> GetBooksRateOrderAsync()
        {
            var dbMovies = await _repo.GetBooksRateDesc();

            var mappedMovies = _mapper.Map<List<BookListDto>>(dbMovies);

            return mappedMovies;
        }

        public async Task<List<BookListDto>> RelatedBooksAsync(int id)
        {
            var dbMovies = await _repo.RelatedBooks(id);

            var mappedMovies = _mapper.Map<List<BookListDto>>(dbMovies);

            return mappedMovies;
        }
    }
}
