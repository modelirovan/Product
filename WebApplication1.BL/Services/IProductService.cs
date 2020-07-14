using System.Threading.Tasks;
using WebApplication1.DAL.Entities;

namespace WebApplication1.BL.Services
{
    public interface IProductService
    {
        Task<Product> GetProductForAllUsers(long ProductId);
        Task<Product> AddNewProduct(string Name, string Description);

    }
}
