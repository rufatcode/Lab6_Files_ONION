using Lab6_Files.Domain.Entities;
using Lab6_Files.Repository.Repositories;
using Lab6_Files.Repository.Repositories.Interfaces;
using Lab6_Files.Service.Services.Interfaces;

namespace Lab6_Files.Service.Services;

public class PersonService:IPersonService
{
  private readonly IPersonRepository _personRepository;

  public PersonService()
  {
    _personRepository = new PersonRepository();
  }
  public void Create(Person person)
  {
    if (person.Age<0)
    {
      throw new Exception("Age must be greater than 0");
    }
    _personRepository.Create(person);
  }

  public void Delete(int id)
  {
    Person existPerson = Get(p => p.Id == id);
    
    _personRepository.Delete(existPerson);
  }

  public Person Get(Func<Person, bool> predicate=null)
  {
    return _personRepository.Get(predicate);
  }

  public IEnumerable<Person> GetAll(Func<Person, bool> predicate=null)
  {
    return _personRepository.GetAll(predicate);
  }
}