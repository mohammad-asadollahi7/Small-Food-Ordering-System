using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Repository.Services;

namespace FoodApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableCors("mypolicy")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IHttpContextAccessor _context;

    public OrderController(IOrderService orderService, IHttpContextAccessor context)
    {
        _orderService = orderService;
        _context = context;
    }

    [HttpPost]
    public IActionResult Add([FromBody] Food food)
    {
        int userId = _context.HttpContext.Session.GetInt32("userId") ?? 1;
        var isAdded = _orderService.CreateOrUpdate(food, userId);
        if (isAdded)
            return Ok();
        else
            return BadRequest();
    }
}
