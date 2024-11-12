using System.Collections.Generic;
using System.Threading.Tasks;
using KoiOrderingSystem.Repositories.Entities;
using KoiOrderingSystem.Repositories.Interfaces;
using KoiOrderingSystem.Services.Interfaces;

namespace KoiOrderingSystem.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int productId)
        {
            return await _productRepository.GetProductByIdAsync(productId);
        }

        public async Task<bool> AddProductAsync(Product product)
        {
            return await _productRepository.AddProductAsync(product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            return await _productRepository.DeleteProductAsync(productId);
        }

        public async Task SaveChangesAsync()
        {
            await _productRepository.SaveChangesAsync();
        }
    }
}
