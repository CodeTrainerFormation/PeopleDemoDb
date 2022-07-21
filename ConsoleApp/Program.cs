using Dal;
using DomainModel;

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
                // TODO : Afficher la moyenne d'age de la liste
                // TODO : Afficher la personne avec l'ID égal à 5
                // TODO : Récuperer un dictionnaire contenant
                //        le firstname en clé et l'age en valeur
                // TODO : Récuperer une liste des personnes
                //        ayant un age supérieur ou égal à 35

                // GROS GROS GROS TODO : VERIFIER LES RESULTATS
                // DANS LA DB A CHAQUE REQUETE !!!!




            } //context.Dispose();

            Console.WriteLine("Hello World!");
        }
    }
}