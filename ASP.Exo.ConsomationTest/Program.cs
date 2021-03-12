using ASP.Model.Global.Models;
using ASP.Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Exo.ConsomationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AspUserRepository repo = new AspUserRepository("SqlServer");
            AspUser userTest = new AspUser()
            {
                Mail = "toto@toto.toto",
                Password = "test1234",
                LastName = "toto",
                FirstName = "titi",
                BirthDate = new DateTime(1987, 12, 25),
                RegNational = "12345678901",
                Bio = "Toto est un personnage fictif pour le test de notre DB"
            };
            int id = repo.Insert(userTest);
            Console.WriteLine(id);
            AspUser test = repo.Get(id);
            Console.WriteLine(test.Password);
            Console.WriteLine(repo.CheckPassword("toto@tata.titi","test1234"));
            Console.WriteLine(repo.CheckPassword("toto@toto.toto","test1235"));
            Console.WriteLine(repo.CheckPassword("toto@toto.toto","test1234"));

        }
    }
}
