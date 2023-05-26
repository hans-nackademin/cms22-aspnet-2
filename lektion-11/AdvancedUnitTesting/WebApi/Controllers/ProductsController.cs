using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;
using WebApi.Models.Schemas;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region constructors and private fields

        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productManager.GetAllAsync();
            if (products != null)
                return Ok(products);

            return NotFound();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productManager.GetAsync(x => x.Id == id);
            if (product != null)
                return Ok(product);

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductSchema schema)
        {
            if (ModelState.IsValid)
            {
                var product = await _productManager.GetAsync(x => x.Name == schema.Name);
                if (product != null)
                    return Conflict();

                return Created("", await _productManager.CreateAsync(schema));
            }

            return BadRequest(schema);
        }





    }
}
