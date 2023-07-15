using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControlController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public ApiControlController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _animalService.GetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var value = _animalService.GetById(id);
            

            return Ok(value);
        }
    }
}
