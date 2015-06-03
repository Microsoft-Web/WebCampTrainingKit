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
    public class TriviaController : ApiController
    {
        private TriviaContext db;
        private QuestionsService questionsService;
        private AnswersService answersService;

        const string UserId = "test";

        public TriviaController()
        {
            this.db = new TriviaContext();
            this.questionsService = new QuestionsService(db);
            this.answersService = new AnswersService(db);
        }

        public async Task<TriviaQuestion> Get()
        {
            TriviaQuestion nextQuestion =
                await this.questionsService.NextQuestionAsync(UserId);

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
                answer.UserId = UserId;
                bool isCorrect =false;
                try
                {
                    isCorrect = await this.answersService.StoreAsync(answer);
                }
                catch (Exception e)
                {

                }
                

                return Request.CreateResponse(HttpStatusCode.Created, isCorrect);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}