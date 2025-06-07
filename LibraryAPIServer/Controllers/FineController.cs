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

        public ActionResult<IEnumerable<FineDto>> GetByUser(int userId)
        {
            return Ok(_service.GetFinesByUser(userId));
        }

        [HttpGet("{id}")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<FineDto> GetById(int id)
        {
            var fine = _service.GetFineById(id);
            if (fine == null) return NotFound();
            return Ok(fine);
        }

        [HttpPut("{id}/pay")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Pay(int id, FinePaymentDto dto)
        {
            bool updated = _service.UpdatePaymentStatus(id, dto.PaymentStatus);
            if (!updated) return NotFound();
            return NoContent();
        }
    }


}
