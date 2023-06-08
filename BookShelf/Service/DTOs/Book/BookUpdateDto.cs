namespace Service.Services.DTOs.Book
{
    public class BookUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }       
        public byte[] Photo { get; set; }
        public int Length { get; set; }
        public int ReleaseYear { get; set; }
        public string Country { get; set; }
        public int BookCategoryId { get; set; }
    }
}
