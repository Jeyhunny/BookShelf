using Service.Services.DTOs.Comment;
using Service.Services.DTOs.BookCategory;
using Service.Services.DTOs.BookComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.Book
{
    public class BookGetDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        //public string? Poster { get; set; }
        public byte[]? Photo { get; set; }

        public int Length { get; set; }
        public string? Country { get; set; }
        public int ReleaseYear { get; set; }
        public BookCategoryListDto? BookCategory { get; set; }
        public List<BookCommentListDto>? Comments { get; set; }


    }
}
