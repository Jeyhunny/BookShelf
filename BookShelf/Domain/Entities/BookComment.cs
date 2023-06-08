using Domain.Common;

namespace Domain.Entities
{
    public class BookComment : BaseEntity
    {
        public string By { get; set; }
        public string Context { get; set; }
        public int MovieId { get; set; }
        public Book? Movie { get; set; }
    }
}
