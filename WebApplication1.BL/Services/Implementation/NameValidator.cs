using System.Threading.Tasks;

namespace WebApplication1.BL.Services.Implementation
{
    public class NameValidator : INameValidator
    {
        public async Task<bool> ValidateAsync(string name)
        {
            if (name != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
