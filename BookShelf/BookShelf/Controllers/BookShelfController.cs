using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.Movflix;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookShelf.Controllers
{
    public class BookShelfController : AppController
    {
        private readonly IBookShelfService _movflixService;

        public BookShelfController(IBookShelfService movflixService)
        {
            _movflixService = movflixService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _movflixService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BookShelfCreateDto movflixCreateDto)
        {
            await _movflixService.CreateAsync(movflixCreateDto);
            return Ok();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookShelfUpdateDto movflixUpdateDto)
        {
            await _movflixService.UpdateAsync(id, movflixUpdateDto);
            return Ok(movflixUpdateDto);
        }
    }
}
