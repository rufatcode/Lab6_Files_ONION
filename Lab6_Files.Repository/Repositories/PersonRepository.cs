using Lab6_Files.Domain.Entities;
using Lab6_Files.Repository.Repositories.Interfaces;

namespace Lab6_Files.Repository.Repositories;

public class PersonRepository:BaseRepository<Person>,IPersonRepository
{
  
}