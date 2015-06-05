namespace GeekQuiz.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using GeekQuiz.Models;
    using GeekQuiz.Services;

    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public async Task<ActionResult> Statistics()
        {
            var db = new TriviaContext();
            var statisticsService = new StatisticsService(db);

            return this.View(await statisticsService.GenerateStatistics());
        }
    }
}