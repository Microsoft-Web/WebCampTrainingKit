using System.Threading.Tasks;
using GeekQuiz.Models;

namespace GeekQuiz.Services
{
    public interface IQuestionsService
    {
        Task<TriviaQuestion> NextQuestionAsync(string userId);
    }
}
