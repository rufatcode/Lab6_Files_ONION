using Lab6_Files.Domain.Common;

namespace Lab6_Files.Domain.Entities;

public class Person:BaseEntity
{
  public string Name { get; set; }
  public string SureName { get; set; }
  public int Age { get; set; }
  public double Salary { get; set; }
  public string Location { get; set; }
}