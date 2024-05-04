using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Services.Abstract;


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
    }
}
