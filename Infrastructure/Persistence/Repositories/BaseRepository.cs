using System;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Persistence.Context;

using Microsoft.EntityFrameworkCore;

//Essa clase vai ser responsável por realizar as operações de persistência como criação, atualização e exclusão
namespace CleanArchitecture.Persistence.Repositories{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity{ //T significa o tipo de dado no nosso caso T é o tipo BaseEntity
        protected readonly AppDbContext Context; //DbContext e uma classe do tipo de dados do Entity Framework

        public BaseRepository(AppDbContext context){//estanciadndo a conexao com o banco
            Context = context;//passando o contexto para a propriedade
        }
        public void Create(T entity){  //criando uma nova entidade 
           entity.Created = DateTimeOffset.UtcNow; //data de criação
           Context.Add(entity);//adicionando a entidade ao contexto do Entity Framework
        }
        public void Update( T entity){
            entity.Updated = DateTimeOffset.UtcNow;//data de atualização
            Context.Update(entity);
        }
        public void Delete( T entity){
            entity.Deleted = DateTimeOffset.UtcNow; //data de exclusão
            Context.Remove(entity);
        }
        
        public async Task<T> Get(Guid id, CancellationToken cancellationToken){
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
        public async Task<List<T>> GetAll(CancellationToken cancellationToken){
            return await Context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}