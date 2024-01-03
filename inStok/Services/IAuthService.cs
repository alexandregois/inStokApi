using inStok.Models;

namespace inStok.Services
{
    public interface IAuthService
    {
        Usuario ValidateUser(string email, string password);
    }

}
