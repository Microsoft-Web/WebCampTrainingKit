function updateLeftChart(correctAnswers, incorrectAnswers) {
    var chartContainer = document.getElementById('leftChartContainer');
    var correctCount = [[0, correctAnswers]],
        incorrectCount = [[0, incorrectAnswers]];

    Flotr.draw(
      chartContainer, [
        { data: correctCount, label: 'Correct', color: '#4DA74D' },
        { data: incorrectCount, label: 'Incorrect', color: '#CB4B4B' },
      ], {
          HtmlText: false,
          grid: { verticalLines: false, horizontalLines: false, outlineWidth: 0 },
          xaxis: { showLabels: false },
          yaxis: { showLabels: false },
          pie: { show: true },
          legend: { show: true, position: 'se' }
      });
}

function updateRightChart(correctAnswersAverage, incorrectAnswersAverage, totalAnswersAverage) {
    var chartContainer = document.getElementById('rightChartContainer');

    var correctAverage = [[0, correctAnswersAverage]];
    var incorrectAverage = [[1, incorrectAnswersAverage]];
    var totalAverage = [[2, totalAnswersAverage]];

    Flotr.draw(
      chartContainer, [
        { data: correctAverage, label: 'Correct', color : '#4DA74D' },
        { data: incorrectAverage, label: 'Incorrect', color: '#CB4B4B' },
        { data: totalAverage, label: 'Total', color: '#00A8F0' }
      ], {
          bars: {
              show: true,
              horizontal: false,
              shadowSize: 0.1,
              barWidth: 0.7
          },
          markers: {
              show: true,
              position: 'ct',
              fontSize: 9
          },
          HtmlText: false,
          grid: { verticalLines: false, horizontalLines: true, outlineWidth: 0 },
          xaxis: { showLabels: false },
          yaxis: {
              min: 0,
              autoscale: true,
              autoscaleMargin: 1
          },
          legend: { show: true, position: 'se' }
      });
}

function showCharts(statistics) {
    if (statistics.CorrectAnswers > 0 || statistics.IncorrectAnswers > 0 ||
        statistics.CorrectAnswersAverage > 0 || statistics.IncorrectAnswersAverage > 0 || statistics.TotalAnswersAverage > 0) {
        $("#noDataMessage").hide();
        $("#charts").show();
        $("#answersHeader").show();

        updateLeftChart(statistics.CorrectAnswers, statistics.IncorrectAnswers);
        updateRightChart(statistics.CorrectAnswersAverage, statistics.IncorrectAnswersAverage, statistics.TotalAnswersAverage);
    } else {
        $("#noDataMessage").show();
        $("#charts").hide();
        $("#answersHeader").hide();
    }
}