using inStok.Controllers;
using inStok.Models;
using inStok.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly JwtService _jwtService;

    public AuthController(IAuthService authService, JwtService jwtService)
    {
        _authService = authService;
        _jwtService = jwtService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public ActionResult Login([FromBody] Login loginModel)
    {
        try
        {
            var user = _authService.ValidateUser(loginModel.Email, loginModel.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }
        catch (ArgumentException ex)
        {
            // Retorna uma resposta com a mensagem de erro
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Outro tratamento de exceções
            return StatusCode(500, "Erro interno no servidor.");
        }
    }


    private string GenerateJwtToken(Usuario user) // User é a classe do seu modelo de usuário
    {
        return _jwtService.GenerateToken(user.UsuarioId);

    }

}
