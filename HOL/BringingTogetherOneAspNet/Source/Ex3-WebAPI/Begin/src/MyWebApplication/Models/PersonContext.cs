using Microsoft.Data.Entity;

namespace MyWebApplication.Models
{
    public class PersonContext : DbContext
    {
        private static bool _created = false;

        public PersonContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Person> Person { get; set; }
    }
}
