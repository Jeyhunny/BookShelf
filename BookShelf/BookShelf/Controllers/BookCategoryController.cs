using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services.DTOs.Book;
using Service.Services.DTOs.BookCategory;
using Service.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BookShelf.Controllers
{
    public class BookCategoryController : AppController
    {
        private readonly IBookCategoryService _categoryService;

        public BookCategoryController(IBookCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create([FromBody] BookCategoryCreateDto bookCategoryCreateDto)
        {
            await _categoryService.CreateAsync(movieCategoryCreateDto);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromRoute][Required] int id, BookCategoryUpdateDto movieCategoryUpdateDto)
        {
            try
            {
                await _categoryService.UpdateAsync(id, movieCategoryUpdateDto);

                return Ok(movieCategoryUpdateDto);
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
                await _categoryService.DeleteAsync(id);
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
                await _categoryService.SoftDeleteAsync(id);
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
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([Required] int id)
        {
            try
            {
                return Ok(await _categoryService.GetByIdAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

    }
}
