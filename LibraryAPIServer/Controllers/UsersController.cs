using LibraryBusinessLayer.Interfaces;
using LiibraryDataAccessLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    public UsersController(IUserService service) => _service = service;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<List<UserDto>>> Get()
    {
        var users = await _service.GetAllAsync();

       return Ok(User);
    }

    [HttpGet("{id}")]
    public  async Task<ActionResult<UserDto>> GetByID(int id)
    {
        var user = await _service.GetByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

  
    [HttpPut]
    public async Task< IActionResult> Update(UserDto dto)
    {
      await  _service.UpdateAsync(dto);
        return Ok("User updated");
    }

    [HttpDelete("{id}")]
    public async Task< IActionResult> Delete(int id)
    {
       await _service.DeleteAsync(id);
        return Ok("User deleted");
    }
}
