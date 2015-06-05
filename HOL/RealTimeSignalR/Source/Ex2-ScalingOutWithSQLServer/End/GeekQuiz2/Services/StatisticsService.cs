namespace GeekQuiz.Services
{
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using GeekQuiz.Hubs;
    using GeekQuiz.Models;
    using Microsoft.AspNet.SignalR;
    
    public class StatisticsService
    {
        private TriviaContext db;

        public StatisticsService(TriviaContext db)
        {
            this.db = db;
        }

        public async Task<StatisticsViewModel> GenerateStatistics()
        {
            var correctAnswers = await this.db.TriviaAnswers.CountAsync(a => a.TriviaOption.IsCorrect);
            var totalAnswers = await this.db.TriviaAnswers.CountAsync();
            var totalUsers = (float)await this.db.TriviaAnswers.GroupBy(a => a.UserId).CountAsync();

            var incorrectAnswers = totalAnswers - correctAnswers;

            return new StatisticsViewModel
            {
                CorrectAnswers = correctAnswers,
                IncorrectAnswers = incorrectAnswers,
                TotalAnswers = totalAnswers,
                CorrectAnswersAverage = (totalUsers > 0) ? correctAnswers / totalUsers : 0,
                IncorrectAnswersAverage = (totalUsers > 0) ? incorrectAnswers / totalUsers : 0,
                TotalAnswersAverage = (totalUsers > 0) ? totalAnswers / totalUsers : 0,
            };
        }

        public async Task NotifyUpdates()
        {            
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();
            
            if (hubContext != null)
            {
                try
                {
                    var stats = await this.GenerateStatistics();                                        
                    hubContext.Clients.All.updateStatistics(stats);
                }
                catch (System.Exception e)
                {                    
                    throw e;
                }                
            }
        }
    }
}