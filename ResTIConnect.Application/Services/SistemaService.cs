
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class SistemaService : ISistemaService
    {
        public int Create(NewSistemaInputModel sistema)
        {
            throw new NotImplementedException();
        }

        public List<SistemaViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<SistemaViewModel> GetByEventoPeriodos(int eventoId, DateTime inicio)
        {
            throw new NotImplementedException();
        }

        public SistemaViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SistemaViewModel> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}