using System.Threading.Tasks;
using GeekQuiz.Models;
using GeekQuiz.Services;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace GeekQuiz.Controllers
{
    [Produces("application/json")]
    [Route("api/Trivia")]
    [Authorize]
    public class TriviaController : Controller
    {
        private TriviaDbContext context;
        private IQuestionsService questionsService;
        private IAnswersService answersService;

        public TriviaController(TriviaDbContext context, IQuestionsService questionsService, IAnswersService answersService)
        {
            this.context = context;
            this.questionsService = questionsService;
            this.answersService = answersService;
        }
        
        // GET: api/Trivia
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.Identity.Name;

            TriviaQuestion nextQuestion =
                await this.questionsService.NextQuestionAsync(userId);

            if (nextQuestion == null)
            {
                return HttpNotFound();
            }

            return Ok(nextQuestion);
        }

        // PUT: api/Trivia
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TriviaAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = await this.answersService.StoreAsync(answer);
            
            return this.CreatedAtAction("Get", new {}, isCorrect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}