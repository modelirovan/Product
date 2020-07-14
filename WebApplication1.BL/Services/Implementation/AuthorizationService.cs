using System;
using System.Threading.Tasks;
using WebApplication1.BL.Models;

namespace WebApplication1.BL.Services.Implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        public async Task<AuthModel> CheckAuthorizationAsync(string ClientId)
        {
            string[] words = ClientId.Split(' ');

            var correctClient = Convert.ToInt32(words[1]) % 2 == 0;

            if (correctClient)
            {
                return new AuthModel()
                {
                    Authorized = true,
                    ClientId = ClientId
                };
            }
            else
            {
                return new AuthModel
                {
                    Authorized = false,
                    ClientId = ClientId
                };
            }
        }
    }
}
