using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Services.Abstract;
using Repositories.Services.Concreate;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialsService _materialService;

        public MaterialController(IMaterialsService materialService)
        {
            _materialService = materialService;
        }

        // API rotalarını tanımlayın
        [HttpGet]
        public IActionResult GetAllMaterials()
        {
            var materials = _materialService.GetAllMaterials();
            return Ok(materials);
        }
        [HttpGet("{id}")]
        public IActionResult GetMaterialById(int id)
        {
            var material = _materialService.GetMaterialById(id);
            if (material == null)
            {
                return NotFound();
            }
            return Ok(material);
        }

        [HttpPost]
        public IActionResult AddMaterial([FromBody] Material material)
        {
            _materialService.AddMaterial(material);
            return CreatedAtAction(nameof(GetMaterialById), new { id = material.Id }, material);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMaterial(int id, [FromBody] Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _materialService.UpdateMaterial(material);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMaterial(int id)
        {
            _materialService.DeleteMaterial(id);
            return NoContent();
        }
    }
}

