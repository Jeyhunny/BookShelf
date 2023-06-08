using Domain.Entities;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class BookShelfRepository : Repository<BookShelf>, IBookShelfRepository
    {
        public BookShelfRepository(AppDbContext context) : base(context) { }

    }
}
