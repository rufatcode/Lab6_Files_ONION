using System.Text.Json;
using Lab6_Files.Domain.Common;
using StreamWriter = System.IO.StreamWriter;

namespace Lab6_Files.Repository.Data;

public static class AppDbContext<T> where T:BaseEntity
{
   static List<T> Datas { get; set; } = new();
   static string DbPath { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "DB");
   static string ObjectPath { get; set; } = Path.Combine(DbPath, typeof(T).Name+".txt");

  static AppDbContext()
  {
    if (!Directory.Exists(DbPath))
    {
      Directory.CreateDirectory(DbPath);
    }
    if (!File.Exists(ObjectPath))
    {
      File.CreateText(ObjectPath);
    }

    BindDatas();
  }
  public static void Add(T entity)
  {
    

    entity.Id = Datas.Count == 0 ? 1 : Datas[Datas.Count - 1].Id+1;
    Datas.Add(entity);
    using ( StreamWriter streamWriter = new(ObjectPath))
    {
      string strDatas = JsonSerializer.Serialize(Datas);
      streamWriter.Write(strDatas);

    }

   
  
    
  }
  
  public static void Remove(T entity)
  {
    Datas.Remove(entity);
    using (StreamWriter streamWriter = new(ObjectPath))
    {
      string strDatas = JsonSerializer.Serialize(Datas);
      streamWriter.Write(strDatas);
    }
    
   
  }

  public static void Update(T entity)
  {
    T data = Datas.FirstOrDefault(e => e.Id == entity.Id);
    data = entity;
    using (  StreamWriter streamWriter = new(ObjectPath))
    {
      string strDatas = JsonSerializer.Serialize(Datas);
      streamWriter.Write(strDatas);
    }
  
   
  }

  public static List<T> Get()
  {

    return Datas;
  }

  private static void BindDatas()
  {
    StreamReader streamReader = new(ObjectPath);
    string strDatas =  streamReader.ReadToEnd();

    Datas = JsonSerializer.Deserialize<List<T>>(strDatas);
  }
  
  
  
  
  
   
}