using System;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories;

public class UnitOfWord: IUnitOfWork{
    private readonly AppDbContext _context;

    public UnitOfWord(AppDbContext context){
        _context = context;
    }
    //salvar todas as alterações em conjunto de forma atomica;
    public async Task Commit(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);
}