# MongoDB Integration Library
MongoDB Integration Library is both .Net Framework and .Net Core library written by using Mongodb drivers for more flexible use. 
# Usage
First you need to configure the default connection settings. If you do not specify a custom link when creating a new object, the default settings that you previously set will be used.  As an example, we can configure settings in the Startup.cs file in an ASP.NET Core MVC project.

```C#
using MongoDBCore;

namespace MyExampleProject
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
                string connectionString = Configuration.GetValue<string>("MongoConnection");
                string databaseName = Configuration.GetValue<string>("MongoDatabase");
                MongoDbConfig.DefaultConnection(string connectionString, string databaseName);
            ...
        }
    }
}
```

Like this you'll configure your settings as default by adding them to the startup file of your project. <br>
If you want to create a new custom link in the object creation stage;
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static List<Person> MyExamplePerson()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>("mongodb://localhost/JAGIndex?safe=true","JAGIndex");
          List<Person> persons = connectPerson.GetAll().ToList();
          return persons;
       }
    }
}
```
Let's add a data as another example in the project. In order to be able to add data, we must first have a data model and this model must have the abstract class called EntityBase.<br>
Sample data model:
```C#
    public class Person : EntityBase
    {
         public string Name { get; set; }
         public string Surname { get; set; }
    }
```
Example of adding data:
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyExampleProject
{
    public static string ExamplePersonAdd()
    {
        Person person = new Person()
        {
            Name = "Fatih",
            Surname = "Kazancı"
        };
        
        MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
        Response response = connectPerson.Add(person);
        if(response.Result)
        {
            return "The insert is successful.";
        }
        else
        {
           return "Insertion failed!";
        }
    }
}
```
The addition process returns us with a class of Response type.
# Methods
**Add(TEntity entity):** Adds a new data to the database in the requested model.
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static Response MyExampleAdd()
       {
          Person person = new Person()
          {
            Name = "Fatih",
            Surname = "Kazancı"
          };
        
        MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
        Response response = connectPerson.Add(person);
        return response;
        }
    }
}
```
**Update(string uniqKey, Expression<Func<TEntity, object>> columnExpression, object newValue):**<br>
**Update(string uniqKey, string columName, object newValue):** <br>
**Update(TEntity entity):** <br>
Updates the requested data.
 <br>
<br>
Example:
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static UpdateResponse MyExampleUpdate()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          UpdateResponse response = connectPerson.Update("aaa-aaa-aaa-aaa", i => i.PersonName, "Emre");
          return response;
       }
       
       public static UpdateResponse MyExampleUpdate2()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          UpdateResponse response = connectPerson.Update("aaa-aaa-aaa-aaa", "PersonName", "Emre");
          return response;
       }
       
       public static UpdateResponse MyExampleUpdate3()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          Person person = connectPerson.GetById("aaa-aaa-aaa-aaa");
          person.PersonName = "Emre";
          UpdateResponse response = connectPerson.Update(person);
          return response;
       }
    }
}
```
**Delete(string uniqKey):** Deletes data according to UniqKey.
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
        public static DeleteResponse MyExampleDelete()
        {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            DeleteResponse response = connectPerson.Delete("aaa-aaa-aaa-aaa");
            return response;
        }
    }
}
```
**SearchFor(Expression<Func<TEntity, bool>> columnExpression):** Searches with LINQ.
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
        public static List<Person> MyExampleList()
        {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            List<Person> persons = connectPerson.SearchFor(i => i.PersonName == "Emre").ToList();
            return persons;
        }
    }
}
```
**GetById (string uniqKey):** Gets data according to UniqKey.
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static Person MyExamplePerson()
       {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            Person person = connectPerson.GetById("aaa-aaa-aaa-aaa");
            return person;
       }
    }
}
```
**GetAll():** Gets all data.
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static List<Person> MyExamplePerson()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          List<Person> persons = connectPerson.GetAll().ToList();
          return persons;
       }
    }
}
```
<br>
<br>
<br>

# MongoDB Integration Library
MongoDB Integration Library, Mongodb driverlarını kullanarak daha esnek kullanım için yazılmış hem .Net Framework hem de .Net Core kütüphanesidir.

# Kullanım
Öncelikle varsayılan bağlantı ayarlarını yapılandırmamız gerekiyor.Eğer kullanım aşamasında özel bir bağlantı ayarı belirtmediğimizde bu varsayılan bağlantı ayarları kullanılacaktır.

Örnek olarak bir ASP.NET Core MVC projesinde Startup.cs dosyasında ayarları yapılandırabiliriz.
```C#
using MongoDBCore;

namespace MyExampleProject
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
                string connectionString = Configuration.GetValue<string>("MongoConnection");
                string databaseName = Configuration.GetValue<string>("MongoDatabase");
                MongoDbConfig.DefaultConnection(string connectionString, string databaseName);
            ...
        }
    }
}
```
Bunun gibi kendi projenizin başlangıç dosyasına ekleyerek varsayılan olarak ayarlarınızı yapılandırmış olursunuz.

Eğer Nesne oluşturma aşamasında yeni bir özel bağlantı oluşturmak istiyorsanız;
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static List<Person> MyExamplePerson()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>("mongodb://localhost/JAGIndex?safe=true","JAGIndex");
          List<Person> persons = connectPerson.GetAll().ToList();
          return persons;
       }
    }
}
```

Proje içerisinde bir diğer örnek kullanım olarak bir veri ekleyelim.
Veri ekleyebilmek için öncelikle bir veri modelimiz olmalı ve bu model _EntityBase_ adlı abstract sınıfını extend almış olması gerekir.

Örnek veri modeli:
```C#
    public class Person : EntityBase
    {
         public string Name { get; set; }
         public string Surname { get; set; }
    }
```
Örnek veri ekleme işlemi:
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyExampleProject
{
    public static string ExamplePersonAdd()
    {
        Person person = new Person()
        {
            Name = "Fatih",
            Surname = "Kazancı"
        };
        
        MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
        Response response = connectPerson.Add(person);
        if(response.Result)
        {
            return "Ekleme işlemi başarılı.";
        }
        else
        {
           return "Ekleme işlemi başarısız!";
        }
    }
}
```
Eklenme işlemi bize Response tipinde bir sınıf döndürür.

# Metotlar
**Add(TEntity entity):** Veritabanına istenilen modelde bir yeni kayıt ekler.<br>
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static Response MyExampleAdd()
       {
          Person person = new Person()
          {
            Name = "Fatih",
            Surname = "Kazancı"
          };
        
        MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
        Response response = connectPerson.Add(person);
        return response;
        }
    }
}
```
**Update(string uniqKey, Expression<Func<TEntity, object>> columnExpression, object newValue):** <br>
**Update(string uniqKey, string columName, object newValue):**<br>
**Update(TEntity entity):**<br>
İstenilen bir veriyi günceller. <br>
<br>
Örnek:
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static UpdateResponse MyExampleUpdate()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          UpdateResponse response = connectPerson.Update("aaa-aaa-aaa-aaa", i => i.PersonName, "Emre");
          return response;
       }
       
       public static UpdateResponse MyExampleUpdate2()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          UpdateResponse response = connectPerson.Update("aaa-aaa-aaa-aaa", "PersonName", "Emre");
          return response;
       }
       
       public static UpdateResponse MyExampleUpdate3()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          Person person = connectPerson.GetById("aaa-aaa-aaa-aaa");
          person.PersonName = "Emre";
          UpdateResponse response = connectPerson.Update(person);
          return response;
       }
    }
}
```
**Delete(string uniqKey):** UniqKey'e göre bir veriyi siler.<br>
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
        public static DeleteResponse MyExampleDelete()
        {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            DeleteResponse response = connectPerson.Delete("aaa-aaa-aaa-aaa");
            return response;
        }
    }
}
```
**SearchFor(Expression<Func<TEntity, bool>> columnExpression):** LINQ ile arama işlemleri gerçekleştirir.<br>
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
        public static List<Person> MyExampleList()
        {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            List<Person> persons = connectPerson.SearchFor(i => i.PersonName == "Emre").ToList();
            return persons;
        }
    }
}
```
**GetById(string uniqKey):** UniqKey'e göre bir veri getirir. <br>
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static Person MyExamplePerson()
       {
            MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
            Person person = connectPerson.GetById("aaa-aaa-aaa-aaa");
            return person;
       }
    }
}
```
**GetAll():** Tüm veriyi getirir.<br>
```C#
using MongoDBCore.Repositories;
using MongoDB.Driver;

namespace MyProject
{
    public class MyProjectClass
    {
       public static List<Person> MyExamplePerson()
       {
          MongoDbRepository<Person> connectPerson = new MongoDbRepository<Person>();
          List<Person> persons = connectPerson.GetAll().ToList();
          return persons;
       }
    }
}
```
