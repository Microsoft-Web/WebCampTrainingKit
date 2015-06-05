namespace GeekQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TriviaAnswers",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        OptionId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TriviaOptions", t => new { t.QuestionId, t.OptionId }, cascadeDelete: true)
                .Index(t => new { t.QuestionId, t.OptionId });
            
            CreateTable(
                "dbo.TriviaOptions",
                c => new
                    {
                        QuestionId = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        IsCorrect = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.QuestionId, t.Id })
                .ForeignKey("dbo.TriviaQuestions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.TriviaQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TriviaAnswers", new[] { "QuestionId", "OptionId" }, "dbo.TriviaOptions");
            DropForeignKey("dbo.TriviaOptions", "QuestionId", "dbo.TriviaQuestions");
            DropIndex("dbo.TriviaAnswers", new[] { "QuestionId", "OptionId" });
            DropIndex("dbo.TriviaOptions", new[] { "QuestionId" });
            DropTable("dbo.TriviaQuestions");
            DropTable("dbo.TriviaOptions");
            DropTable("dbo.TriviaAnswers");
        }
    }
}
