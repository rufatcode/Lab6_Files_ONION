using Lab6_Files.Domain.Common;
using Lab6_Files.Repository.Data;
using Lab6_Files.Repository.Repositories.Interfaces;

namespace Lab6_Files.Repository.Repositories;

public class BaseRepository<T> :IBaseRepository<T> where T:BaseEntity
{
  public void Create(T entity)
  {
    AppDbContext<T>.Add(entity);
  }

  public void Delete(T entity)
  {
    AppDbContext<T>.Remove(entity);
  }

  public void Update(T entity)
  {
    AppDbContext<T>.Update(entity);
  }

  public T Get(Func<T, bool> predicate=null)
  {
    return predicate!=null? AppDbContext<T>.Get().First(predicate):AppDbContext<T>.Get().FirstOrDefault();
  }

  public IEnumerable<T> GetAll(Func<T, bool> predicate=null)
  {
    return predicate!=null? AppDbContext<T>.Get().Where(predicate):AppDbContext<T>.Get();
  }
}