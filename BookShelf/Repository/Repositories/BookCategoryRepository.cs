using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<BookCategory> _entities;
        public BookCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<BookCategory>();
        }

        public async Task<List<BookCategory>> GetAllCategories()
        {
            var result = await _entities
                .Where(m => m.SoftDeleted == false)
                .Include(m => m.Books)
                .ToListAsync();
            return result;
        }
    }
}
