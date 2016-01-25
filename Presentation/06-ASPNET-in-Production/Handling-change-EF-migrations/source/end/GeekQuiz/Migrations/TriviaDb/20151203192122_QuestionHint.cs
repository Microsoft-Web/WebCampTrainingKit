using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace GeekQuiz.Migrations.TriviaDb
{
    public partial class QuestionHint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_TriviaAnswer_TriviaOption_QuestionId_OptionId", table: "TriviaAnswer");
            migrationBuilder.DropForeignKey(name: "FK_TriviaOption_TriviaQuestion_QuestionId", table: "TriviaOption");
            migrationBuilder.AddColumn<string>(
                name: "Hint",
                table: "TriviaQuestion",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_TriviaAnswer_TriviaOption_QuestionId_OptionId",
                table: "TriviaAnswer",
                columns: new[] { "QuestionId", "OptionId" },
                principalTable: "TriviaOption",
                principalColumns: new[] { "QuestionId", "Id" },
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TriviaOption_TriviaQuestion_QuestionId",
                table: "TriviaOption",
                column: "QuestionId",
                principalTable: "TriviaQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_TriviaAnswer_TriviaOption_QuestionId_OptionId", table: "TriviaAnswer");
            migrationBuilder.DropForeignKey(name: "FK_TriviaOption_TriviaQuestion_QuestionId", table: "TriviaOption");
            migrationBuilder.DropColumn(name: "Hint", table: "TriviaQuestion");
            migrationBuilder.AddForeignKey(
                name: "FK_TriviaAnswer_TriviaOption_QuestionId_OptionId",
                table: "TriviaAnswer",
                columns: new[] { "QuestionId", "OptionId" },
                principalTable: "TriviaOption",
                principalColumns: new[] { "QuestionId", "Id" },
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TriviaOption_TriviaQuestion_QuestionId",
                table: "TriviaOption",
                column: "QuestionId",
                principalTable: "TriviaQuestion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
