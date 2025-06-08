using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service) => _service = service;

        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<List<BookDto>>> GetAll() { 
         var books = await _service.GetAllAsync();
            return books.Count == 0 ? NotFound() : Ok(books);

        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< ActionResult<BookDto>> Get(int id)
        {
            var book = await _service.GetByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost ("Create")]

        public async Task< IActionResult> Create(BookCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("Update")]
        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task< IActionResult> Update(BookUpdateDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task< IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }

}
