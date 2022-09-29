using Microsoft.AspNetCore.Mvc;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Services.CategoryService;

namespace VirtualShop.ProductApi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public async Task<ActionResult<List<CategoryDto>>> GetCategories()
        {
            var categories = await categoryService.GetAllCategories();
            return Ok(categories);
        }
        public async Task<ActionResult<CategoryDto>> GetProductsCategories(int id)
        {
            var getcategories = await categoryService.GetCategoriesProducts();
            return Ok(getcategories);
        }
        [HttpGet(Name ="/{id}")]
        public async Task<ActionResult<CategoryDto>> getCategoriesId(int id)
        {
            var getCateId = await categoryService.GetCategoryById(id);
            if (getCateId == null)
            {   
                return NotFound("data not found");
            }
            return Ok(getCateId);
        }

    }
}
