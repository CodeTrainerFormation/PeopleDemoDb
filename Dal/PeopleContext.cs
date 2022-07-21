using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class PeopleContext : DbContext
    {
        #region DbSet
        public DbSet<Person> People { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        #endregion

        #region Constructors
        public PeopleContext()
            : base()
        {
        }

        public PeopleContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion

        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=PeopleDatabase;Integrated Security=true");
            }

            base.OnConfiguring(optionsBuilder);
        }
        #endregion
    }
}