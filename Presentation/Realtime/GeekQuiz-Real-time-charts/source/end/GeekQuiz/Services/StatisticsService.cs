using GeekQuiz.Models;
using GeekQuiz.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.SignalR;
using GeekQuiz.Hubs;

namespace GeekQuiz.Services
{
    public class StatisticsService
    {
        private TriviaContext db;

        public StatisticsService(TriviaContext db)
        {
            this.db = db;
        }

        public async Task NotifyUpdates()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();
            if (hubContext != null)
            {
                var stats = await this.GenerateStatistics();
                hubContext.Clients.All.updateStatistics(stats);
            }
        }

        public async Task<StatisticsViewModel> GenerateStatistics()
        {
            var correctAnswers = await db.TriviaAnswers.CountAsync(a => a.TriviaOption.IsCorrect);
            var totalAnswers = await db.TriviaAnswers.CountAsync();
            var totalUsers = (float)await db.TriviaAnswers.GroupBy(a => a.UserId).CountAsync();

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
    }
}