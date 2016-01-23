using Microsoft.Data.Entity;
using GeekQuiz.Models;

namespace GeekQuiz.Models
{
    public class TriviaContext : DbContext
    {
        private static bool _created = false;

        public TriviaContext()
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

        public DbSet<TriviaQuestion> TriviaQuestion { get; set; }

        public DbSet<TriviaOption> TriviaOption { get; set; }
    }
}
