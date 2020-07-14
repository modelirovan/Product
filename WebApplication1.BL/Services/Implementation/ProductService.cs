using System;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;
using WebApplication1.DAL.Repositories;

namespace WebApplication1.BL.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> AddNewProduct(string name, string description)
        {
            var product = await _productRepository.AddNewProduct(new Product { Name = name, Description = description });

            return product;
        }

        public Task<Product> GetProductForAllUsers(long ProductId)
        {
            var result = _productRepository.GetProductById(ProductId);

            return result;
        }
    }
}
