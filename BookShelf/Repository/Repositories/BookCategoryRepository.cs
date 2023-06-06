using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class BookCategoryRepository : Repository<MovieCategory>, IBookCategoryRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<MovieCategory> _entities;
        public BookCategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _entities = _context.Set<MovieCategory>();
        }

        public async Task<List<MovieCategory>> GetAllCategories()
        {
            var result = await _entities
                .Where(m => m.SoftDeleted == false)
                .Include(m => m.Movies)
                .ToListAsync();
            return result;
        }
    }
}
