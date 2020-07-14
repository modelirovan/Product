using System.Threading.Tasks;

namespace WebApplication1.BL.Services
{
    public interface INameValidator
    {
        Task<bool> ValidateAsync(string desription);
    }
}
