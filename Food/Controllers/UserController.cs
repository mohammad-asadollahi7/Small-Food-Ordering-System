﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Services;

namespace FoodApi.Controllers;

[ApiController]
[Route("api/login/[controller]")]
[EnableCors("mypolicy")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IHttpContextAccessor _context;
    public UserController(IUserService userService, IHttpContextAccessor context)
    {
        _userService = userService;
        _context = context;
    }
    
    [HttpPost]
    public IActionResult Login([FromForm] string username, [FromForm] string password)
    {
        var user = _userService.CheckUser(username, password);
        if (user == null)
            return NotFound();
        
        else
        {
            _context.HttpContext.Session.SetInt32("userId", user.Id);
            return Ok();
        }
       
    }
}
