using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository.Services;

namespace FoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("mypolicy")]
public class FoodController : ControllerBase
{
    private IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var foods = _foodService.GetAll();
        if (foods.Count() == 0)
        {
            return NoContent();
        }
        return Ok(foods);
    }
}
