using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Abstract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
       private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var foods = _foodService.GetAllFoods();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public IActionResult GetFoodById(int id)
        {
            var food = _foodService.GetFoodById(id);
            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        [HttpPost]
        public IActionResult AddFood([FromBody] Food food)
        {
            _foodService.AddFood(food);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFood(int id, [FromBody] Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            _foodService.UpdateFood(food);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFood(int id)
        {
            _foodService.DeleteFood(id);
            return NoContent();
        }
    }
}
