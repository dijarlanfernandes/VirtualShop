using VirtualShop.ProductApi.DTOs;

namespace VirtualShop.ProductApi.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct();
        Task<ProductDto> GetProductById(int id);
        Task AddProduct(ProductDto product);    
        Task UpdateProduct(ProductDto product);
        Task DeleteProduct(int id);
        
    }
}
