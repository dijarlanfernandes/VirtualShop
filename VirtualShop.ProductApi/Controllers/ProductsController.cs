using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Roles;
using VirtualShop.ProductApi.Services.ProductService;

namespace VirtualShop.ProductApi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService Service;

        public ProductsController(IProductService service)
        {
            Service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProdutos()
        {
            var prodDto = await Service.GetAllProduct();

            if (prodDto ==null)
            {
                return NotFound();
            }
            return Ok(prodDto);
        }


        [HttpGet("{id}", Name = "getProductById")]
        public async Task<ActionResult<ProductDto>> getProductById(int id)
        {
            var productDto = await Service.GetProductById(id);
            if (productDto == null)
            {
                return NotFound();

            }
            return Ok(productDto);
        }


        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductDto>> CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Data invalid");
            }
            await Service.AddProduct(productDto);

            return new CreatedAtRouteResult("getProductById",
                new { id = productDto.Id }, productDto);
        }

        [HttpPut]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Data invalid");
            }
            await Service.UpdateProduct(productDto);

            return Ok(productDto);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)] 
        public async Task<ActionResult<ProductDto>> DeleteProduct(int id)
        {
            var productid = await Service.GetProductById(id);
            if (productid == null)
            {
                return NotFound("product not found");
            }
            await Service.DeleteProduct(id);
            return Ok(productid);
        }

    }
}
