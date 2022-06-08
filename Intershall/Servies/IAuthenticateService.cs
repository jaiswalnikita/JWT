using Intershall.Models;

namespace Intershall.Servies
{
    public interface IAuthenticateService
    {
        User Authenticate(string Email, string Password);
        
    }
}
