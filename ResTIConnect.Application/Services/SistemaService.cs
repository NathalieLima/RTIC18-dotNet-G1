
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Exceptions;
using ResTIConnect.Infra.Data.Context;

namespace ResTIConnect.Application.Services
{
    public class SistemaService : ISistemaService
    {
        private readonly ResTIConnectContext _context;

        public SistemaService(ResTIConnectContext context)
        {
            _context = context;
        }

        public int Create(NewSistemaInputModel sistema)
        {
            var _sistema = new Sistemas
            {
                Descricao = sistema.Descricao,
                Tipo = sistema.Tipo
            };

            _context.Sistemas.Add(_sistema);
            _context.SaveChanges();

            return _sistema.SistemaId;
        }

        public List<SistemaViewModel> GetAll()
        {
            var sistemas = _context.Sistemas
                .Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo
                })
                .ToList();

            return sistemas;
        }

        public List<SistemaViewModel> GetByEventoPeriodos(int eventoId, DateTime inicio)
        {
            // Implemente a lógica para recuperar os sistemas por evento e período, se necessário
            throw new NotImplementedException();
        }

        public SistemaViewModel GetById(int id)
        {
            var _sistema = _context.Sistemas
                .Include(s => s.Users)
                .Include(s => s.Eventos)
                .FirstOrDefault(s => s.SistemaId == id);

            if (_sistema is null)
                throw new SistemaNotFoundException();


            var sistemaViewModel = new SistemaViewModel
            {
                SistemaId = _sistema.SistemaId,
                Descricao = _sistema.Descricao,
                Tipo = _sistema.Tipo,
                Users = _sistema.Users!.Select(u => new UserViewModel
                {
                    UserId = u.UserId,
                    Name = u.Name
                }).ToList(),
                Eventos = _sistema.Eventos!.Select(e => new EventoViewModel
                {
                    EventoId = e.EventoId,
                    Descricao = e.Descricao

                }).ToList()
            };
            return sistemaViewModel;

        }

        public List<SistemaViewModel> GetByUserId(int userId)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.UserId == userId);

            if (user != null && user.Sistemas != null)
            {
                var sistemas = user.Sistemas.Select(s => new SistemaViewModel
                {
                    SistemaId = s.SistemaId,
                    Descricao = s.Descricao,
                    Tipo = s.Tipo
                }).ToList();

                return sistemas;
            }
            return new List<SistemaViewModel>();
        }
    }
}