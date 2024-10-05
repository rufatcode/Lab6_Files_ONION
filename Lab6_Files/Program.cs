


using System.Collections;
using Lab6_Files.Controllers;


PersonController personController = new();

while (true)
{
  TopProses:Console.WriteLine(@"
      0.End
      1.Create Person
      2.Delete Person by Id
      3.Get By Id
      4.Get By Name
      5.Get ALl
      6.Get All By Location

");

  Console.WriteLine("Enter proses ");
  string strProses = Console.ReadLine();
  if (!int.TryParse(strProses,out int proses))
  {
   goto TopProses;
  }

  if (proses==0)
  {
    Console.WriteLine("Proses has finshed");
    break;
  }

  switch (proses)
  {
   case 1:
     personController.Create();
     break;
   case 2:
     personController.Delete();
     break;
   case 3:
     personController.GetById();
     break;
   case 4:
        personController.GetByName();
        break;
   case 5:
     personController.GetAll();
     break;
   case 6:
     personController.GetAllByLocation();
     break;
      
  }
}


