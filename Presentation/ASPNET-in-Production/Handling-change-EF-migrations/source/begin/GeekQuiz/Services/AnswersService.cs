using System.Threading.Tasks;
using GeekQuiz.Models;
using Microsoft.Data.Entity;

namespace GeekQuiz.Services
{
    public class AnswersService : IAnswersService
    {
        private TriviaDbContext db;

        public AnswersService(TriviaDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> StoreAsync(TriviaAnswer answer)
        {
            var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o => o.Id == answer.OptionId
                    && o.QuestionId == answer.QuestionId);

            if (selectedOption != null)
            {
                answer.TriviaOption = selectedOption;
                this.db.TriviaAnswers.Add(answer);

                try
                {
                    await this.db.SaveChangesAsync();
                }
                catch (System.Exception)
                {

                    throw;
                }
                
            }

            return selectedOption.IsCorrect;
        }
    }
}
