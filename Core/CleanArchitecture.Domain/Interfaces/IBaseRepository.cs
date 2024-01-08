namespace CleanArchitecture.Domain;

public interface IBaseRepository<T> where T : BaseEntite
{
    void Create(T Entity);
    void Update(T Entity);
    void Delete(T Entity);
    Task<T> Get(Guid id,CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken); 
}
