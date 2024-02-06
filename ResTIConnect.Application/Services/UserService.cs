
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Infra.Data.Context;

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
                Name = user.Name,

            };
        _context.Pacientes.Add(_paciente);

        _context.SaveChanges();

        return _paciente.PacienteId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, NewUserInputModel user)
        {
            throw new NotImplementedException();
        }
    }
}