using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.DTOs.BookComment
{
    public class BookCommentCreateDto
    {
        public string By { get; set; }
        public string Context { get; set; }
        public int BookId { get; set; }
    }
}
