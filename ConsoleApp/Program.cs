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
                //context.Database.EnsureDeleted();

                //context.Database.EnsureCreated();

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
                // TODO : Supprimer "Lily"
                // TODO : Ré-ajouter la personne supprimée (Lily)
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