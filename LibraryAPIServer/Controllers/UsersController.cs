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

    public ActionResult<List<UserDto>> Get() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public ActionResult<UserDto> Get(int id)
    {
        var user = _service.GetById(id);
        return user == null ? NotFound() : Ok(user);
    }

  
    [HttpPut]
    public IActionResult Update(UserDto dto)
    {
        _service.Update(dto);
        return Ok("User updated");
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok("User deleted");
    }
}
