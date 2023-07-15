using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Project.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnimalRequest : ControllerBase
    {
        private readonly ProjectDbContext _projectDbContext;

        public AnimalRequest(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var values = _projectDbContext.AnimalRequests.Include(x => x.AppUser).Include(x => x.Animal).ToList();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(values, options);
            return Ok(json);
        }
        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            var value = _projectDbContext.AnimalRequests.Where(x=>x.AnimalRequestId==id).Include(x => x.AppUser).Include(x => x.Animal).FirstOrDefault();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var json = JsonSerializer.Serialize(value, options);

            return Ok(json);
        }
    }
}
