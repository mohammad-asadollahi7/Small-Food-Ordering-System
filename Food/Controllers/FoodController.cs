using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("mypolicy")]
public class FoodController : ControllerBase
{
    
}
