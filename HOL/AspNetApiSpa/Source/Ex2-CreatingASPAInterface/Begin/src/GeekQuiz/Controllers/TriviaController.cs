using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GeekQuiz.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GeekQuiz.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class TriviaController : Controller
    {
        private TriviaDbContext context;

        public TriviaController(TriviaDbContext context)
        {
            this.context = context;
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = User.Identity.Name;

            TriviaQuestion nextQuestion =
                await this.NextQuestionAsync(userId);

            if (nextQuestion == null)
            {
                return HttpNotFound();
            }

            return Ok(nextQuestion);
        }

        // POST: api/Trivia
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TriviaAnswer answer)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            answer.UserId = User.Identity.Name;

            var isCorrect = await this.StoreAsync(answer);

            return this.CreatedAtAction("Get", new { }, isCorrect);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

            base.Dispose(disposing);
        }

        private async Task<TriviaQuestion> NextQuestionAsync(string userId)
        {
            var lastQuestionId = await this.context.TriviaAnswers
                .Where(a => a.UserId == userId)
                .GroupBy(a => a.QuestionId)
                .Select(g => new { QuestionId = g.Key, Count = g.Count() })
                .OrderByDescending(q => q.Count)
                .ThenByDescending(q => q.QuestionId)
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            var questionsCount = await this.context.TriviaQuestions.CountAsync();

            var nextQuestionId = (lastQuestionId % questionsCount) + 1;
            return await this.context.TriviaQuestions.Include(q => q.Options).FirstOrDefaultAsync(q => q.Id == nextQuestionId);
        }

        private async Task<bool> StoreAsync(TriviaAnswer answer)
        {
            var selectedOption = await this.context.TriviaOptions.FirstOrDefaultAsync(o =>
                o.Id == answer.OptionId
                && o.QuestionId == answer.QuestionId);

            if (selectedOption != null)
            {
                answer.TriviaOption = selectedOption;
                this.context.TriviaAnswers.Add(answer);

                await this.context.SaveChangesAsync();
            }

            return selectedOption.IsCorrect;
        }
    }
}
