using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext Context;
        public CategoryRepository(AppDbContext _Context)
        {
            Context = _Context;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            Context.Categories.Add(category);
            await Context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id); 
            Context.Remove(category);
            await Context.SaveChangesAsync();

            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await Context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await Context.Categories.Where(p => p.CategoryId == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoryProducts()
        {

            return await Context.Categories.Include(c=>c.Products).ToListAsync();

        }

        public async Task<Category> UpdateCategory(Category category)
        {
            Context.Entry(category).State = EntityState.Modified;
            await Context.SaveChangesAsync();

            return category;
        }
    }
}
