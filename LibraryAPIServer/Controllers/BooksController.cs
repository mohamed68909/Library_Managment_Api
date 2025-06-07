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

        public ActionResult<List<BookDto>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookDto> Get(int id)
        {
            var book = _service.GetById(id);
            return book == null ? NotFound() : Ok(book);
        }

        [HttpPost ("Create")]

        public IActionResult Create(BookCreateDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("Update")]
        
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(BookUpdateDto dto)
        {
            _service.Update(dto);
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }

}
