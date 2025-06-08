using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryAPIServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BookCopiesController : ControllerBase
    {
        private readonly IBookCopyService _service;
        public BookCopiesController(IBookCopyService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<BookCopyDto>>> GetAll()
        {


            var Copy = await _service.GetAllAsync();

           return  Ok(Copy);
        }

        [HttpGet("book/{bookId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BookCopyDto>>> GetByBookId(int bookId) { 
                  var copy = await _service.GetByBookIdAsync(bookId);
         return   Ok(copy);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <ActionResult<BookCopyDto> >Get(int id)
        {
            var copy =await _service.GetByIdAsync(id);
            return copy == null ? NotFound() : Ok(copy);
        }

        [HttpPost("Create")]
        public async Task< IActionResult> Create(BookCopyCreateDto dto)
        {
          await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(BookCopyDto dto)
        {
           await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task <IActionResult> Delete(int id)
        {
           await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
