using Lab6_Files.Domain.Common;

namespace Lab6_Files.Repository.Repositories.Interfaces;

public interface IBaseRepository<T> where T:BaseEntity
{
  public void Create(T entity);
  public void Delete(T entity);
  public void Update(T entity);
  public T Get(Func<T,bool>predicate=null);
  public IEnumerable<T> GetAll(Func<T,bool>predicate=null);
}