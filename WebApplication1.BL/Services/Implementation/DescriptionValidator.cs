using System.Threading.Tasks;

namespace WebApplication1.BL.Services.Implementation
{
    public class DescriptionValidator : IDescriptionValidator
    {
        public async Task<bool> ValidateAsync(string description)
        {
            if (description != null)
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
