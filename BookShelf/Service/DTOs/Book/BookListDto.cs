using Service.Services.DTOs.BookCategory;

namespace Service.Services.DTOs.Book
{
    public class BookListDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        
        public byte[]? Photo { get; set; }
        public int Length { get; set; }
        public string? Country { get; set; }
        public int ReleaseYear { get; set; }
        public int BookCategoryId { get; set; }
        public BookCategoryListDto? BookCategory { get; set; }
    }
  
}
