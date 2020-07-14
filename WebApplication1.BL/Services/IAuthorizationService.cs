
using System.Threading.Tasks;
using WebApplication1.BL.Models;

namespace WebApplication1.BL.Services
{
    public interface IAuthorizationService
    {
        Task<AuthModel> CheckAuthorizationAsync(string ClientId);
    }
}
