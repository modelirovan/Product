using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL.Entities;
using WebApplication1.DAL.Internal.Implementation;

namespace WebApplication1.DAL.Repositories.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _myDBContext;

        public ProductRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        private List<Product> _productList;

        public ProductRepository()
        {
            _productList = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "product1",
                    Description = "Product1Description"
                },

                new Product()
                {
                    Id = 2,
                    Name = "Product2",
                    Description = "Description2"
                }
            };
        }

        public async Task<Product> AddNewProduct(Product product)
        {
            _myDBContext.Set<Product>().Add(product);

            await _myDBContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetProductById(long ProductId)
        {
            var res = _myDBContext.Products.Where(x => x.Id == ProductId).FirstOrDefault();
            return res;
            //return _productList.Where(x => x.Id == ProductId).FirstOrDefault();
        }
    }
}
