using Microsoft.EntityFrameworkCore;
using VirtualShop.ProductApi.Context;
using VirtualShop.ProductApi.Repositories.ProductRepository.ProductRepository;

namespace VirtualShop.ProductApi.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext Context;
        public ProductRepository(AppDbContext _context)
        {
            Context = _context;
        }
        public async Task<Models.Product> CreateProduct(Models.Product product)
        {
            Context.Products.Add(product);
            await Context.SaveChangesAsync();
            return product;
        }

        public async Task<Models.Product> DeleteProduct(int id)
        {
            var product = await GetById(id);
            Context.Products.Remove(product);
            await Context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Models.Product>> GetAllProducts()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<Models.Product> GetById(int id)
        {
            var product = await Context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Models.Product> UpdateProduct(Models.Product product)
        {
           Context.Entry(product).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return product;
        }
    }
}
