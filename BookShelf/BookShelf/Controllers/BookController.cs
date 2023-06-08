using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.Blog;
using Service.Services.DTOs.Book;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookShelf.Controllers
{
    public class BookController : AppController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([FromBody] BookCreateDto movieCreateDto)
        {
            await _bookService.CreateAsync(movieCreateDto);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookUpdateDto bookUpdateDto)
        {
            try
            {
                await _bookService.UpdateAsync(id, bookUpdateDto);

                return Ok(bookUpdateDto);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }



        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SoftDelete([Required] int id)
        {
            try
            {
                await _bookService.SoftDeleteAsync(id);
                return Ok();
            }
            catch (NullReferenceException)
            {

                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int id)
        {
            try
            {
                return Ok(await _bookService.GetByIdAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Search(string? search)
        {
            return Ok(await _bookService.SearchAsync(search));
        }

        [HttpPost]        
        public async Task<IActionResult> Rate([Required] int id, [FromQuery]float rate)
        {
           await _bookService.RateAsync(id, rate);         

            return Ok();
        }

        [HttpGet]
   
        public async Task<IActionResult> GetBooksByCategory([FromQuery] string category)
        {       
            return Ok(await _bookService.GetBooksByCategoryAsync(category));
        }

        [HttpGet]
        public async Task<IActionResult> RelatedBooks([FromQuery] int id)
        {
            return Ok(await _bookService.RelatedBooksAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksDescOrder()
        {
            return Ok(await _bookService.GetBooksDesOrderAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksRateOrder()
        {
            return Ok(await _bookService.GetBooksRateOrderAsync());
        }
    }
}
