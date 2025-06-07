using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookCopiesController : ControllerBase
    {
        private readonly IBookCopyService _service;
        public BookCopiesController(IBookCopyService service) => _service = service;

        [HttpGet]
        public ActionResult<List<BookCopyDto>> GetAll() => Ok(_service.GetAll());

        [HttpGet("book/{bookId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookCopyDto>> GetByBookId(int bookId) =>
            Ok(_service.GetByBookId(bookId));

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookCopyDto> Get(int id)
        {
            var copy = _service.GetById(id);
            return copy == null ? NotFound() : Ok(copy);
        }

        [HttpPost("Create")]
        public IActionResult Create(BookCopyCreateDto dto)
        {
            _service.Create(dto);
            return Ok();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(BookCopyDto dto)
        {
            _service.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
