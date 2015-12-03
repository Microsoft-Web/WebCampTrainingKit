using System.Threading.Tasks;
using GeekQuiz.Models;

namespace GeekQuiz.Services
{
    public interface IAnswersService
    {
        Task<bool> StoreAsync(TriviaAnswer answer);
    }
}
