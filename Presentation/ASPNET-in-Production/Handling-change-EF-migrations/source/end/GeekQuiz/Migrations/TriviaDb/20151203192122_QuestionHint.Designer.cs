using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using GeekQuiz.Models;

namespace GeekQuiz.Migrations.TriviaDb
{
    [DbContext(typeof(TriviaDbContext))]
    [Migration("20151203192122_QuestionHint")]
    partial class QuestionHint
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GeekQuiz.Models.TriviaAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("OptionId");

                    b.Property<int>("QuestionId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GeekQuiz.Models.TriviaOption", b =>
                {
                    b.Property<int>("QuestionId");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("QuestionId", "Id");
                });

            modelBuilder.Entity("GeekQuiz.Models.TriviaQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Hint");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("GeekQuiz.Models.TriviaAnswer", b =>
                {
                    b.HasOne("GeekQuiz.Models.TriviaOption")
                        .WithMany()
                        .HasForeignKey("QuestionId", "OptionId");
                });

            modelBuilder.Entity("GeekQuiz.Models.TriviaOption", b =>
                {
                    b.HasOne("GeekQuiz.Models.TriviaQuestion")
                        .WithMany()
                        .HasForeignKey("QuestionId");
                });
        }
    }
}
