
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class PerfilService : IPerfilService
    {
        public int Create(NewPerfilInputModel perfil)
        {
            throw new NotImplementedException();
        }

        public List<PerfilViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PerfilViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<PerfilViewModel> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}