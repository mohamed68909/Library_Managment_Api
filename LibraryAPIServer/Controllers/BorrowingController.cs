using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingService _service;

        public BorrowingController(IBorrowingService service)
        {
            _service = service;
        }

        [HttpPost("borrow")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Borrow(BorrowRequestDto dto)
        {
            try
            {
                await _service.BorrowAsync(dto);
                return Ok("Borrowed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("return/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Return(int id)
        {
            try
            {
                await _service.ReturnAsync(id);
                return Ok("Return completed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<BorrowingRecordDto>> >GetByUser(int userId)
        {
            var Borrow = await _service.GetByUserAsync(userId);
            return Ok(Borrow);
        }
    }

}
