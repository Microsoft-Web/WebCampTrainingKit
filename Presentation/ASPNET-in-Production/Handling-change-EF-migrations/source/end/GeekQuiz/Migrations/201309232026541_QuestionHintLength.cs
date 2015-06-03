namespace GeekQuiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionHintLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TriviaQuestions", "Hint", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TriviaQuestions", "Hint", c => c.String());
        }
    }
}
