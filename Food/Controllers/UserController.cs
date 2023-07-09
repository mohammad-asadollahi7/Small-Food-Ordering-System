using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Services;

namespace FoodApi.Controllers;

[ApiController]
[Route("api/login/[controller]")]
public class UserController : ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Login([FromForm] string username, [FromForm] string password)
    {
        var isValid = _userService.IsValid(username, password);
        if (!isValid)
        {
            return BadRequest();
        }
        return Ok();
    }
}
