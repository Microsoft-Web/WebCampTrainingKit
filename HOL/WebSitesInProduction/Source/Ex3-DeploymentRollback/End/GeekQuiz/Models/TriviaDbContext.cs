using Microsoft.Data.Entity;

namespace GeekQuiz.Models
{
    public class TriviaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TriviaOption>()
                .HasKey(o => new { o.QuestionId, o.Id });

            builder.Entity<TriviaAnswer>()
                .HasOne(a => a.TriviaOption)
                .WithMany()
                .HasForeignKey(a => new { a.QuestionId, a.OptionId });

            builder.Entity<TriviaQuestion>()
                .HasMany(q => q.Options)
                .WithOne(o => o.TriviaQuestion);
        }
        
        public DbSet<TriviaQuestion> TriviaQuestions { get; set; }

        public DbSet<TriviaOption> TriviaOptions { get; set; }

        public DbSet<TriviaAnswer> TriviaAnswers { get; set; }
    }
}
