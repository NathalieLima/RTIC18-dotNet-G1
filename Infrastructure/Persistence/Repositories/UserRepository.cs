using System;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Persistence.Context;
namespace CleanArchitecture.Persistence.Repositories;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context){}

        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken) => await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
