using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories.ProductRepository.ProductRepository;

namespace VirtualShop.ProductApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly Mapper mapper;
        public ProductService(IProductRepository repository, Mapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task AddProduct(ProductDto product)
        {
             var dto =  mapper.Map<Product>(product);
             await repository.CreateProduct(dto);
             product.Id = dto.Id;           
        }

        public async Task DeleteProduct(int id)
        {
            var product = repository.GetById(id).Result;
            await repository.DeleteProduct(product.Id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await repository.GetAllProducts();
            return mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await repository.GetById(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductDto product)
        {
            var dto = mapper.Map<Product>(product);
            await repository.UpdateProduct(dto);           
        }
    }
}
