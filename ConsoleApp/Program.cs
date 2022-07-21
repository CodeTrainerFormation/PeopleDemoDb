using Dal;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (PeopleContext context = new PeopleContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                var persons = new List<Person>()
                {
                    new Person() { FirstName = "Ted", LastName = "Mosby", Age = 35},
                    new Person() { FirstName = "Barney", LastName = "Stinson", Age = 34},
                    new Person() { FirstName = "Marshall", LastName = "Eriksen", Age = 35},
                    new Person() { FirstName = "Lily", LastName = "Aldrin", Age = 32},
                    new Person() { FirstName = "Robin", LastName = "Scherbatsky", Age = 38},
                };
                context.People.AddRange(persons);
                context.SaveChanges();


                // TODO : Modifier le nom de "Robin" en "Stinson"

                //-- 1ere solution --
                var robin = context.People.First(p => p.FirstName == "Robin");

                robin.LastName = "Stinson";

                context.People.Update(robin);
                context.SaveChanges();

                //-- 2eme solution --
                //persons[4].LastName = "Stinson";

                //context.People.Update(persons[4]);
                //context.SaveChanges();


                //-- 3eme solution --
                //var robin = new Person()
                //{
                //    Id = 5,
                //    FirstName = "Robin",
                //    LastName = "Stinson",
                //    Age = 38
                //};

                //context.People.Update(robin);
                //context.SaveChanges();


                // TODO : Supprimer "Lily"

                var lily = context.People.First(p => p.FirstName == "Lily");

                context.People.Remove(lily);
                context.SaveChanges();

                // TODO : Ré-ajouter la personne supprimée (Lily)

                //-- 1ere solution --
                //persons[3].Id = 0;

                //context.People.Add(persons[3]);
                //context.SaveChanges();

                //-- 2eme solution --

                var lilyAgain = new Person() { FirstName = "Lily", LastName = "Aldrin", Age = 32 };
                
                context.People.Add(lilyAgain);
                context.SaveChanges();

                // TODO : Afficher toutes les personnes en les triant par Age,
                //        puis par LastName, puis par FirstName

                var people = context.People
                                    .OrderBy(p => p.Age)
                                    .ThenBy(p => p.LastName)
                                    .ThenBy(p => p.FirstName);

                foreach (var item in people)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

                // TODO : Afficher la moyenne d'age de la liste

                // -- very bad solution --
                //var peopleList = context.People.ToList();
                //int sum = 0;

                //foreach (var item in peopleList)
                //{
                //    sum += item.Age;
                //}

                //int average = sum / peopleList.Count;

                // -- also very bad solution --

                //List<int> ageList = context.People.Select(p => p.Age).ToList();
                //int sum = 0;

                //foreach (var item in ageList)
                //{
                //    sum += item;
                //}

                //int average = sum / ageList.Count;

                // -- also very bad solution --

                //int sum = context.People.Select(p => p.Age).Sum();

                //int average = sum / context.People.Count();

                // -- good solution --

                double average = context.People.Average(p => p.Age ?? 0);

                // TODO : Afficher la personne avec l'ID égal à 5

                //List<Person> myPersonList = context.People.Where(p => p.Id == 5).ToList();

                //Person p1 = context.People.FirstOrDefault(p => p.Id == 5);

                //Person p2 = context.People.SingleOrDefault(p => p.Id == 5);

                Person p3 = context.People.Find(5);

                // TODO : Récupérer un dictionnaire contenant
                //        le firstname en clé et l'age en valeur

                //// -- 1ere solution --
                //Dictionary<string, int> myDict1 = new Dictionary<string, int>();

                //foreach (Person item in context.People)
                //{
                //    myDict1.Add(item.FirstName, item.Age);
                //}

                // -- 2eme solution --
                var myDict2 = context.People.ToDictionary(p => p.FirstName, p => p.Age);

                // TODO : Récupérer une liste des personnes
                //        ayant un age supérieur ou égal à 35

                List<Person> personList = context.People.Where(p => p.Age >= 35).ToList();

                // TODO : Vérifier s'il existe une personne dans la table

                //// -- 1ere solution --
                //var count = context.People.Count();
                //if(count == 0)
                //    Console.WriteLine("0 personne !");
                //else
                //    Console.WriteLine("Quelqu'un ou quelques un");

                // -- 2eme solution --

                if(context.People.Any())
                    Console.WriteLine("0 personne !");
                else
                    Console.WriteLine("Quelqu'un ou quelques un");

                // TODO : Vérifier s'il existe une personne dans la table
                //        qui a un age supérieur à 35

                if (context.People.Any(p => p.Age > 35))
                    Console.WriteLine("0 personne !");
                else
                    Console.WriteLine("Quelqu'un ou quelques un");

                // TODO : Vérifier si toutes les personnes ont plus de 35 ans

                if (context.People.All(p => p.Age > 35))
                    Console.WriteLine("tout le monde a plus de 35 ans");
                else
                    Console.WriteLine("ya trop de jeunes içi !!!");

                // (TODO : Exécuter une requête en sql text depuis le contexte)

                List<Person> pList = context.People
                                            .FromSqlRaw("SELECT * FROM people")
                                            .ToList();

                //List<Person> pList2 = context.People
                //                             .FromSqlRaw("MyProcStockForTest", 25)
                //                             .ToList();

                // -- BONUS --

                //using (context.Database.BeginTransaction())
                //{
                //    context.SaveChanges();

                //    context.SaveChanges();

                //    context.SaveChanges();

                //    context.Database.CommitTransaction();
                //}


                // -- recap C# --

                //string? str = null;

                //if (str != null)
                //{
                //    str = str;
                //}
                //else
                //{
                //    str = "hello";
                //}

                //str = str != null ? str : "hello";

                //str = str ?? "hello";

                //str ??= "hello";

                //string? s = str?.ToUpper();

            } //context.Dispose();

            Console.WriteLine("Hello World!");
        }
    }
}