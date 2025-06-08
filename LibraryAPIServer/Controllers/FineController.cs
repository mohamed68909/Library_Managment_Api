using LibraryBusinessLayer.Interfaces;
using LibraryBusinessLayer.Services;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinesController : ControllerBase
    {
        private readonly IFineService _service;

        public FinesController(IFineService service)
        {
            _service = service;
        }

        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task< ActionResult<IEnumerable<FineDto>>> GetByUser(int userId)
        {
           var fines = await _service.GetFinesByUserAsync(userId);
            if (fines == null || !fines.Any()) return NotFound();
            return Ok(fines);
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task <ActionResult<FineDto>> GetById(int id)
        {
            var fine = await _service.GetFineByIdAsync(id);
            if (fine == null) return NotFound();
            return Ok(fine);
        }

        [HttpPut("{id}/pay")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Pay(int id, FinePaymentDto dto)
        {
            bool updated = await _service.UpdatePaymentStatusAsync(id, dto.PaymentStatus);
            if (!updated) return NotFound();
            return NoContent();
        }
    }


}
