using inStok.Controllers;
using inStok.Models;

namespace inStok.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public Usuario ValidateUser(string email, string password)
        {
            // Verifica se o e-mail ou a senha estão vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {

                throw new ArgumentException("E-mail e senha devem ser informados.");
            }

            try
            {
                var user = _userService.GetUsuario(email, password);

                if (user != null && ValidatePassword(password, user.Senha))
                {
                    return user; // Retorna o usuário validado
                }

                return null; // Usuário inválido ou senha incorreta
            }
            catch (Exception ex)
            {
                // Tratamento adicional de exceções, se necessário
                return null;
            }
        }

        private bool ValidatePassword(string inputPassword, string storedPassword)
        {

            return inputPassword == storedPassword;
        }


    }

}
