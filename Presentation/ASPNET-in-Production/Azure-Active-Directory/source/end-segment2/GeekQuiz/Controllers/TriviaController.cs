using GeekQuiz.Models;
using GeekQuiz.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GeekQuiz.Controllers
{
    [Authorize]
    public class TriviaController : ApiController
    {
        private TriviaContext db;
        private QuestionsService questionsService;
        private AnswersService answersService;

        public TriviaController()
        {
            this.db = new TriviaContext();
            this.questionsService = new QuestionsService(db);
            this.answersService = new AnswersService(db);
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }

        public async Task<TriviaQuestion> Get()
        {
            var userId = User.Identity.Name;

            TriviaQuestion nextQuestion =
                await this.questionsService.NextQuestionAsync(userId);

            if (nextQuestion == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return nextQuestion;
        }

        public async Task<HttpResponseMessage> Post(TriviaAnswer answer)
        {
            if (ModelState.IsValid)
            {
                answer.UserId = User.Identity.Name;

                var isCorrect = await this.answersService.StoreAsync(answer);

                return Request.CreateResponse(HttpStatusCode.Created, isCorrect);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}