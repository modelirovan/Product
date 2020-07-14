using System.Threading.Tasks;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(long ProductId);
        Task<Product> AddNewProduct(Product product);
    }
}
