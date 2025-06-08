using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPIServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService _service;

        public SettingsController(ISettingsService service)
        {
            _service = service;
        }

        [HttpGet("GetSetting")]
        public async Task<ActionResult<SettingsDto>> GetSettings()
        {
            var Setting = _service.GetAsync();
            return Ok(Setting);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public  async Task <IActionResult> UpdateSettings(SettingsDto dto)
        {
           await _service.UpdateAsync(dto);
            return Ok("Settings have been updated");
        }
    }
}
