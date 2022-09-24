using VirtualShop.ProductApi.Models;

namespace VirtualShop.ProductApi.Repositories.ProductRepository.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Models.Product>> GetAllProducts();
        Task<Models.Product> GetById(int id);
        Task<Models.Product> CreateProduct(Models.Product product);
        Task<Models.Product> UpdateProduct(Models.Product product);
        Task<Models.Product> DeleteProduct(int id);
    }
}
