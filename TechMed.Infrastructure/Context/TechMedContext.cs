using Microsoft.EntityFrameworkCore;

namespace TechMed.Infrastructure.Context;

using TechMed.Core.Entities;
public class TechMedContext : DbContext
{
    public TechMedContext(DbContextOptions<TechMedContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechMedContext).Assembly);
    }
}