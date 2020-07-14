using System.Threading.Tasks;

namespace WebApplication1.BL.Services
{
    public interface IDescriptionValidator
    {
        Task<bool> ValidateAsync(string name);
    }
}
