using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.BookShelf;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Controllers
{
    public class BookShelfController : AppController
    {
        private readonly IBookShelfService _bookShelfService;

        public BookShelfController(IBookShelfService bookShelfService)
        {
            _bookShelfService = bookShelfService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookShelfService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookShelfCreateDto bookShelfCreateDto)
        {
            await _bookShelfService.CreateAsync(bookShelfCreateDto);
            return Ok();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookShelfUpdateDto bookShelfUpdateDto)
        {
            await _bookShelfService.UpdateAsync(id, bookShelfUpdateDto);
            return Ok(bookShelfUpdateDto);
        }
    }
}
