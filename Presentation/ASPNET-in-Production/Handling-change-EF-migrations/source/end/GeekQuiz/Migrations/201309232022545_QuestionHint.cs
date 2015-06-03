namespace GeekQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionHint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TriviaQuestions", "Hint", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TriviaQuestions", "Hint");
        }
    }
}
