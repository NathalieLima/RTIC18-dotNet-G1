
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services
{
    public class PerfilService : IPerfilService
    {
        private readonly ResTIConnectContext _context;

        public PerfilService(ResTIConnectContext context)
        {
            _context = context;
        }
        public int Create(NewPerfilInputModel perfil)
        {
            var _perfil = new Perfis
            {
                Descricao = perfil.Descricao,
                Permissoes = perfil.Permissoes
            };

            _context.Perfis.Add(_perfil);
            _context.SaveChanges();

            return _perfil.PerfilId;
        }

        public List<PerfilViewModel> GetAll()
        {
            var perfis = _context.Perfis
                .Select(p => new PerfilViewModel
                {
                    PerfilId = p.PerfilId,
                    Descricao = p.Descricao,
                    Permissoes = p.Permissoes
                })
                .ToList();

            return perfis;
        }

        public PerfilViewModel? GetById(int id)
        {
            var perfil = _context.Perfis.Find(id);
            if (perfil != null)
            {
                var perfilViewModel = new PerfilViewModel
                {
                    PerfilId = perfil.PerfilId,
                    Descricao = perfil.Descricao,
                    Permissoes = perfil.Permissoes
                };
                return perfilViewModel;
            }
            return null;
        }

        public List<PerfilViewModel> GetByUserId(int userId)
        {
            var perfis = _context.Perfis
               .Where(p => p.Users.Any(u => u.UserId == userId))
               .Select(p => new PerfilViewModel
               {
                   PerfilId = p.PerfilId,
                   Descricao = p.Descricao,
                   Permissoes = p.Permissoes,
                   Users = p.Users.Select(u => new UserViewModel
                   {
                       UserId = u.UserId,
                       Name = u.Name,
                   }).ToList()
                })
               .ToList();

            return perfis;
        }
    }
}