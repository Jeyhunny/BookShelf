using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Book> _entities;
        public BookRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<Book>();
        }

        public async Task<List<Book>> GetAllBooksWithCategories()
        {
            var books = await _entities
                .Where(m => m.SoftDeleted == false)
                .Include(m => m.Category)
                .ToListAsync();
            return books;
        }


        public async Task<Book> GetBookById(int? id)
        {
            if (id == null) throw new ArgumentNullException();

            var Book = await _entities
                .Include(m => m.BookCategoryId)
                .Include(m => m.Comments)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null) throw new NullReferenceException();

            return Book;
        }

        public async Task<List<Book>> GetBooksBySearch(string? searchText)
        {
            var searchBooks = await
                 _entities
                 .Where(m => m.Name.Contains(searchText))
                 .Include(m => m.BookCategoryId)
                 .ToListAsync();

            if (searchBooks is null) throw new NullReferenceException();

            return searchBooks;
        }

        public async Task RateBooks(int id, float rate)
        {
            var movie = await _entities.FirstOrDefaultAsync(m => m.Id == id);

            movie.Rating += rate;

            await _context.SaveChangesAsync();
           
        }

        public async Task<List<Book>> GetBooksByCategory(string category)
        {
            if (category is null) throw new NullReferenceException();

            var result = await _entities
                .Include(m => m.BookCategoryId)
                .Where(m => m.Category.Name == category)
                .Take(10)
                .ToListAsync();

            if (result is null) throw new DllNotFoundException();
            
            return result;                
        }

        public async Task<List<Book>> RelatedBooks(int id)
        {
            var books= await _entities.Include(m => m.BookCategory)
                .Where(m => m.Id == id).FirstOrDefaultAsync();

            var book = await _entities.Include(m => m.BookCategory)
                .Where(m => m.BookCategoryId == books.BookCategoryId)
                .ToListAsync();

            return book;              


        }

        public async Task<List<Book>> GetBooksDescOrder()
        {
            var result = await _entities
                .Include(m => m.BookCategory)
                .OrderByDescending(m => m.Id)
                .Take(8)
                .ToListAsync();

            if (result is null) throw new NullReferenceException();

            return result;
        }

        public async Task<List<Movie>> GetBooksRateDesc()
        {
            var result = await _entities
                .Include(m => m.MovieCategory)
                .OrderByDescending(m => m.Rating)
                .Take(8)
                .ToListAsync();

            return result;
        }
    }
}
