using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserService _userService;
        public LoginService(IUserService userService)
        {
            _userService = userService;
        }
        public LoginViewModel? Authenticate(LoginInputModel login)
        {

            string _token = "";

            if (_userService.AutenticateUser(login.Email, login.Password))
            {
                _token = "usuario logado com sucesso.";//TODO gerar o token JWT aqui
            }
            
            if (_token != "")
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
}