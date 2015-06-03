(function () {
    "use strict";

    var bindingID = "statisticsTableId";
    var tableName = "StatisticsTable";

    // The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            $('#update-statistics').click(updateStatisticsTable);

            initializeBindings();
        });
    };

    function initializeBindings() {
        Office.context.document.bindings.addFromNamedItemAsync(
          tableName,
          Office.BindingType.Table,
          { id: bindingID },
          function (asyncResult) {
              if (asyncResult.status == Office.AsyncResultStatus.Succeeded) {
                  $('#update-statistics').prop("disabled", false);
              }
          });
    }

    // Update the TableData object referenced by the binding 
    // and then update the data in the table on the worksheet. 
    function updateStatisticsTable() {
        $.getJSON("/api/statistics", function (data) {
            var headers = [['Total', 'Correct', 'Incorrect', 'Correct p/user', 'Incorrect p/user', 'Total p/user']];
            var rows = [[data.totalAnswers, data.correctAnswers, data.incorrectAnswers,
                          data.correctAnswersAverage, data.incorrectAnswersAverage, data.totalAnswersAverage]];
            var newValuesTable = new Office.TableData(rows, headers);

            Office.select("bindings#" + bindingID).setDataAsync(newValuesTable, { coercionType: Office.CoercionType.Table });
        });
    }
})();