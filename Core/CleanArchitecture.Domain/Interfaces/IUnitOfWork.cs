namespace CleanArchitecture.Domain;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
