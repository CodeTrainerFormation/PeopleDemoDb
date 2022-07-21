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


                Person p = context.People.FirstOrDefault();


            } //context.Dispose();

            Console.WriteLine("Hello World!");
        }
    }
}