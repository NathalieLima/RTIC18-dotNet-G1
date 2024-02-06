
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class UserService : IUserService
    {
        public int Create(NewUserInputModel user)
        {
            throw new NotImplementedException();
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