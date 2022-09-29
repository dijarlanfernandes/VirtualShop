using AutoMapper;
using VirtualShop.ProductApi.DTOs;
using VirtualShop.ProductApi.Models;
using VirtualShop.ProductApi.Repositories.ProductRepository.ProductRepository;

namespace VirtualShop.ProductApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly Mapper _mapper;
        public ProductService(IProductRepository repository, Mapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddProduct(ProductDto product)
        {
             var dto =  _mapper.Map<Product>(product);
             await _repository.CreateProduct(dto);
             product.Id = dto.Id;           
        }

        public async Task DeleteProduct(int id)
        {
            var product = _repository.GetById(id).Result;
            await _repository.DeleteProduct(product.Id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            var products = await _repository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);

        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _repository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProduct(ProductDto product)
        {
            var dto = _mapper.Map<Product>(product);
            await _repository.UpdateProduct(dto);           
        }
    }
}
