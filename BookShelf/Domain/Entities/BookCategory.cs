using Domain.Common;

namespace Domain.Entities
{
    public class BookCategory : BaseEntity
    {
        public string? Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
