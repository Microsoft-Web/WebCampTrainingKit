using GeekQuiz.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace GeekQuiz.Services
{
    public class AnswersService
    {
        private TriviaContext db;

        public AnswersService(TriviaContext db)
        {
            this.db = db;
        }

        public async Task<bool> StoreAsync(TriviaAnswer answer)
        {
            this.db.TriviaAnswers.Add(answer);

            await this.db.SaveChangesAsync();
            var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o => 
		        o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            return selectedOption.IsCorrect;
        }
    }
}