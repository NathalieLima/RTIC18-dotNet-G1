using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;
    //Implementa a classe concreta UserRepository e vai estender a classe generica BaseRepository onde tem a minha entidade User
    //Isso significa que UserRepository contem todos os metodos definidos em BaseRepository
    //Essa classe vai poder reslizar todas as operações CRUD no objetos do tipo User
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {}

        public async Task<User> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
