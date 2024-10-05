using Lab6_Files.Domain.Entities;
using Lab6_Files.Service.Services;
using Lab6_Files.Service.Services.Interfaces;

namespace Lab6_Files.Controllers;

public class PersonController
{
  private readonly IPersonService _personService;

  public PersonController()
  {
    _personService = new PersonService();
  }

  public void Create()
  {
    Person person = new();
    Console.WriteLine("Enter person name");
    person.Name = Console.ReadLine();
    Console.WriteLine("Enter location");
    person.Location = Console.ReadLine();
    Console.WriteLine("Enter age");
    string strAge = Console.ReadLine();
    if (!int.TryParse(strAge,out int age))
    {
      throw new Exception("Age must be int");
    }

    person.Age = age;
    
    Console.WriteLine("Enter salary");
    string strSalary = Console.ReadLine();
    if (!double.TryParse(strAge,out double salary))
    {
      throw new Exception("Salary must be decimal");
    }

    person.Salary = salary;
    Console.WriteLine("Enter SureName:");
    person.SureName = Console.ReadLine();
    _personService.Create(person);

  }

  public void Delete()
  {
    Console.WriteLine("enter person id for remove");

    string strId = Console.ReadLine();
    if (!int.TryParse(strId,out int id))
    {
      throw new Exception("Id must be int");
    }
    _personService.Delete(id);
  }

  public void GetAll()
  {
    IEnumerable<Person> persons = _personService.GetAll();
    foreach (var person in persons)
    {
      Console.WriteLine("<----------------------->");
      Console.WriteLine($"Id:{person.Id}\nName:{person.Name}\nSureName:{person.SureName}\nAge:{person.Age}\nLocation:{person.Location}\nSalary:{person.Salary}");
      Console.WriteLine("<---------------------->");
    }
  }

  public void GetAllByLocation()
  {
    string location = Console.ReadLine();
    IEnumerable<Person> persons = _personService.GetAll(p => p.Location.Contains(location));
    foreach (var person in persons)
    {
      Console.WriteLine("<----------------------->");
      Console.WriteLine($"Id:{person.Id}\nName:{person.Name}\nSureName:{person.SureName}\nAge:{person.Age}\nLocation:{person.Location}\nSalary:{person.Salary}");
      Console.WriteLine("<---------------------->");
    }
  }

  public void GetById()
  {
    Console.WriteLine("enter person id ");

    string strId = Console.ReadLine();
    if (!int.TryParse(strId,out int id))
    {
      throw new Exception("Id must be int");
    }

    Person person = _personService.Get(p => p.Id == id);
    Console.WriteLine("<----------------------->");
    Console.WriteLine($"Id:{person.Id}\nName:{person.Name}\nSureName:{person.SureName}\nAge:{person.Age}\nLocation:{person.Location}\nSalary:{person.Salary}");
    Console.WriteLine("<---------------------->");
    
  }

  public void GetByName()
  {
    Console.WriteLine("enter person name");

    string name = Console.ReadLine();
    

    Person person = _personService.Get(p => p.Name.ToLower() == name.ToLower());
    Console.WriteLine("<----------------------->");
    Console.WriteLine($"Id:{person.Id}\nName:{person.Name}\nSureName:{person.SureName}\nAge:{person.Age}\nLocation:{person.Location}\nSalary:{person.Salary}");
    Console.WriteLine("<---------------------->");
  }
}