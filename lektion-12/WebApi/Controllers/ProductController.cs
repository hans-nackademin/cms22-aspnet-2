using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if(ModelState.IsValid)
            {
                if (await _service.ProductExistsAsync(x => x.Name == schema.Name))
                    return Conflict("A product with the same name already exists.");

                var result = await _service.CreateAsync(schema);
                if (result != null)
                    return Created("", result);
                else
                    return Problem();
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _service.GetAsync(x => x.Id == id);
            if (result != null)
                return Ok(result);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result != null)
                return Ok(result);

            return NotFound();
        }
    }
}
