using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.Comment;
using Service.Services.DTOs.MovieComment;
using Service.Services.Interfaces;

namespace BookShelf.Controllers
{
    public class BookCommentController : AppController
    {
        private readonly IMovieCommentService _commentService;

        public BookCommentController(IMovieCommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieCommentCreateDto commentCreateDto)
        {
            await _commentService.CreateAsync(commentCreateDto);

            return Ok();

        }
    }
}
