using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ResTIConnect;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace ResTIConnect.Application.Services;

public class LoginService : ILoginService
{
    private readonly IUserService _userService; //Contrado com os metodos de acesso aos usuarios
    private readonly IConfiguration _configuration; //Contrato com os metodos para acesso ao json da WebApi 

    public LoginService(IUserService userService)
    {
        _userService = userService;
    }
    public LoginViewModel? Authenticate(LoginInputModel login)
    {
        
        string _token = ""; //token inicialmente vazio

        if (_userService.AutenticateUser(login.Email, login.Password))
        {
            var authService = new AuthService(_configuration); // Instancia o serviço de autenticação
            _token = authService.GenerateJwtToken(login.Email, login.Email); //Gera o token e atribui o valor dele
        }
        if (_token != "")//se tudo der certo retorna um novo login com o token
        {
            return new LoginViewModel
            {
                Username = login.Email,
                Token = _token
            };
        }
        return null;
    }
}  
    
