using AutoMapper;
using System.Runtime.InteropServices;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories.CategoryRepository;

namespace VirtualShop.ProductApi.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository repository;
        private readonly Mapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, Mapper _mapper)
        {
            repository = categoryRepository;
            mapper = _mapper;
        }

        public async Task CreateCategory(CategoryDto categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            await repository.CreateCategory(category);
           categoryDto.CategoryId = category.CategoryId;
        }

        public Task DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var category =await repository.GetAllCategories();
            return mapper.Map<IEnumerable<CategoryDto>>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesProducts()
        {
            var category = await repository.GetCategoryProducts();
            return mapper.Map<IEnumerable<CategoryDto>>(category);
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var category = await repository.GetCategoryById(id);
            return mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateCategory(CategoryDto categoryDto)
        {
            var dto = mapper.Map<Category>(categoryDto);
            await repository.UpdateCategory(dto);             
        }
    }
}
