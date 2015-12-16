using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace GeekQuiz.Migrations.TriviaDb
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TriviaQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriviaQuestion", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "TriviaOption",
                columns: table => new
                {
                    QuestionId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCorrect = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriviaOption", x => new { x.QuestionId, x.Id });
                    table.ForeignKey(
                        name: "FK_TriviaOption_TriviaQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "TriviaQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TriviaAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriviaAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TriviaAnswer_TriviaOption_QuestionId_OptionId",
                        columns: x => new { x.QuestionId, x.OptionId },
                        principalTable: "TriviaOption",
                        principalColumns: new[] { "QuestionId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("TriviaAnswer");
            migrationBuilder.DropTable("TriviaOption");
            migrationBuilder.DropTable("TriviaQuestion");
        }
    }
}
