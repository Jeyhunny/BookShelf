using Domain.Entities;
using Repository.Data;
using Repository.Interfaces;

namespace Repository
{
    public class MovlixRepository : Repository<Movflix>, IBookRepository
    {
        public MovlixRepository(AppDbContext context) : base(context) { }

    }
}
