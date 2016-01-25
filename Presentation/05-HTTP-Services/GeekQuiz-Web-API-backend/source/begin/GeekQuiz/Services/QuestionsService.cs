using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeekQuiz.Models;
using Microsoft.Data.Entity;

namespace GeekQuiz.Services
{
    public class QuestionsService : IQuestionsService
    {
        private TriviaDbContext db;

        public QuestionsService(TriviaDbContext db)
        {
            this.db = db;
        }

        public async Task<TriviaQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await db.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => q.Count)
                .ThenByDescending(q => q.QuestionId)
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await db.TriviaQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await db.TriviaQuestions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == nextQuestionId);
        }
    }
}
