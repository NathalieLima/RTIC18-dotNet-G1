
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Data.Context;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;


namespace ResTIConnect.Application.Services
{
    public class UserService : IUserService
    {

        private readonly ResTIConnectContext _context;
        public UserService(ResTIConnectContext context)
        {
            _context = context;
        }
        public int Create(NewUserInputModel user)
        {
            var _user = new User
            {
                Name = user.Name
            };
            _context.Users.Add(_user);

            _context.SaveChanges();

            return _user.UserId;
        }

        public void Delete(int id)
        {
            _context.Users.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public List<UserViewModel> GetAll()
        {
            var users = _context.Users
                 .Select(u => new UserViewModel
                 {
                     UserId = u.UserId,
                     Name = u.Name,
                     Endereco = new EnderecoViewModel
                     {
                         EnderecoId = u.Endereco!.EnderecoId,
                         Logradouro = u.Endereco.Logradouro,
                         Numero = u.Endereco.Numero,
                         Cidade = u.Endereco.Cidade,
                         Complemento = u.Endereco.Complemento,
                         Bairro = u.Endereco.Bairro,
                         Estado = u.Endereco.Estado,
                         Cep = u.Endereco.Cep,
                         Pais = u.Endereco.Pais

                     },
                     Perfis = u.Perfis!.Select(p => new PerfilViewModel
                    {
                        PerfilId = p.PerfilId,
                        Descricao = p.Descricao,
                        Permissoes = p.Permissoes
                    }).ToList(),
                    Sistemas = u.Sistemas!.Select(s => new SistemaViewModel
                     {

                        SistemaId = s.SistemaId,
                        Descricao = s.Descricao,
                        Tipo = s.Tipo
                     }).ToList()
                 })
                 .ToList();

            return users;
        }
        public UserViewModel? GetById(int id)
        {
            var _user = _context.Users
                .Include(u => u.Endereco)
                .Include(u => u.Perfis)
                .Include(u => u.Sistemas)
                .FirstOrDefault(u => u.UserId == id);
                
            if (_user is null)
                throw new UserNotFoundException();

            var userViewModel = new UserViewModel
                 {
                     UserId = _user.UserId,
                     Name = _user.Name,
                     Endereco = new EnderecoViewModel
                     {
                         EnderecoId = _user.Endereco!.EnderecoId,
                         Logradouro = _user.Endereco.Logradouro,
                         Numero = _user.Endereco.Numero,
                         Cidade = _user.Endereco.Cidade,
                         Complemento = _user.Endereco.Complemento,
                         Bairro = _user.Endereco.Bairro,
                         Estado = _user.Endereco.Estado,
                         Cep = _user.Endereco.Cep,
                         Pais = _user.Endereco.Pais

                     },
                     Perfis = _user.Perfis!.Select(p => new PerfilViewModel
                    {
                        PerfilId = p.PerfilId,
                        Descricao = p.Descricao,
                        Permissoes = p.Permissoes
                    }).ToList(),
                    Sistemas = _user.Sistemas!.Select(s => new SistemaViewModel
                     {

                        SistemaId = s.SistemaId,
                        Descricao = s.Descricao,
                        Tipo = s.Tipo
                     }).ToList()
                 };

                 return userViewModel;

        }

        private User GetByDbId(int id)
        {
            var _user = _context.Users.Find(id);

            if (_user is null)
                throw new UserNotFoundException();
            
            return _user;
        }
        public void Update(int id, NewUserInputModel user)
        {
             var _user = GetByDbId(id);
            _user.Name = user.Name!;
            _context.Users.Update(_user);
            _context.SaveChanges();
        }
    }
}