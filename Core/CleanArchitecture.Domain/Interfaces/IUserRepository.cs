namespace CleanArchitecture.Domain;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string Email,CancellationToken cancellationToken);
}
