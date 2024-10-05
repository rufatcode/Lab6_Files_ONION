using Lab6_Files.Domain.Entities;

namespace Lab6_Files.Service.Services.Interfaces;

public interface IPersonService
{
  public void Create(Person person);
  public void Delete(int id);
  public Person Get(Func<Person,bool>predicate=null);
  public IEnumerable<Person> GetAll(Func<Person,bool>predicate=null);
}