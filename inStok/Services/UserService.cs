using inStok.Models;

namespace inStok.Services
{
    public interface IUserService
    {
        Usuario GetUsuario(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly InStockContext _context;

        public UserService(InStockContext context)
        {
            _context = context;
        }

        public Usuario GetUsuario(string email, string password)
        {
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == password);

                if (usuario == null)
                {
                    return null;
                }

                return usuario;
            }
        }

    }

}
