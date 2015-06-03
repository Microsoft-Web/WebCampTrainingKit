using GeekQuiz.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace GeekQuiz.Services
{
    public class QuestionsService
    {
        private TriviaContext db;

        public QuestionsService(TriviaContext db)
        {
            this.db = db;
        }

        public async Task<TriviaQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await db.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => new { q.Count, QuestionId = q.QuestionId })
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await db.TriviaQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await db.TriviaQuestions.FindAsync(CancellationToken.None, nextQuestionId);
        }
    }
}