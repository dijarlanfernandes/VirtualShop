using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<IEnumerable<CategoryDto>> GetCategoriesProducts();
        Task<CategoryDto> GetCategoryById(int id);
        Task CreateCategory(CategoryDto categoryDto);
        Task UpdateCategory(CategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}
