using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL.Internal
{
    public interface IDBContext
    {
         DbSet<Product> Products { get; set; }
    }
}
