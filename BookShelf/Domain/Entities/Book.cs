using Domain.Common;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
       
        public byte[]? Photo { get; set; }
        public int Length { get; set; }
        public int ReleaseYear { get; set; }
        public string? Country { get; set; }
        public float Rating { get; set; }
        public BookCategory? Category { get; set; }
        public int BookCategoryId { get; set; }
        public List<BookComment>? Comments { get; set; }

    }
}
