using MEDEletro.ProductApi.DTOs;
using MEDEletro.ProductApi.Services;
using MEDEletro.ProductApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MEDEletro.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var productsDto = await _productService.GetProducts();
            if(productsDto is null)
            {
                return NotFound("Not Found");
            }
            return Ok(productsDto);
        }
        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var productDto = await _productService.GetById(id);
            if(productDto is null)            
                return NotFound("Not Found");  
            
            return Ok(productDto);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
        {
            if(productDTO is null)
            {
                return BadRequest("Invalid Data");
            }
            await _productService.AddProduct(productDTO);
            return new CreatedAtRouteResult("GetProduct", new { id = productDTO.Id }, productDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] ProductDTO productDTO)
        {
            if (id != productDTO.Id)
                return BadRequest();

            if(productDTO is null)            
                return BadRequest();

            await _productService.UpdateProduct(productDTO);
            return Ok(productDTO);           

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var productDto = await _productService.GetById(id);
            if (productDto is null)
                return NotFound("Product Not Found");
            await _productService.RemoveProduct(id);

            return Ok(productDto);
        }
    }
}
