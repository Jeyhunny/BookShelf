using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.Comment;
using Service.Services.DTOs.MovieComment;
using Service.Services.Interfaces;

namespace BookShelf.Controllers
{
    public class BookCommentController : AppController
    {
        private readonly IBookCommentService _commentService;

        public BookCommentController(IBookCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookCommentCreateDto commentCreateDto)
        {
            await _commentService.CreateAsync(commentCreateDto);

            return Ok();

        }
    }
}
