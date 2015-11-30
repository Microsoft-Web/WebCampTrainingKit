<a name="title" />
# Building an Excel front end (using apps for Office) #

---
<a name="Overview" />
## Overview ##

This demo demonstrates how an Excel app can pull statistics from GeekQuiz through Web API.

<a id="goals" />
### Goals ###
In this demo, you will see how to:

1. Expose statistics through Web API
1. Invoke a Web API from an Excel app
1. Display data in a worksheet containing graphs

<a name="technologies" />
### Key Technologies ###

- [Apps for Office (Excel)][1]
- [Excel][2]
- [ASP.NET Web API][3]

[1]: https://msdn.microsoft.com/en-us/library/office/jj220060.aspx
[2]: http://office.microsoft.com/en-us/excel/
[3]: http://www.asp.net/web-api

<a name="Setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Install the [Office Developer Tools for Visual Studio 2015](http://aka.ms/officedevtoolsforvs2015)
1. Open Visual Studio 2015.
1. Open the **GeekQuiz.sln** solution located under **source\end**.
1. Press **F5** to start the application.
1. If you don't have one, create a user account for the application. To do that, click **Register** and provide the information required.

	> **Note:** Remember the information you provided as you will use it during the demo.

1. Answer a few questions and then close the browser window.
1. Make sure that the **GeekQuiz Website** project has **Current Page** configured as the **Start Action**. To do this, open the project properties, open the Web tab and select the **Current Page** option.

	![Configuring the start action for the web site](images/configuring-the-start-action-of-the-website.png?raw=true "Configuring the start action for the web site")

	_Configuring the start action for the web site_

1. Save the settings.
1. Click the **GeekQuiz.Office** project, open the properties window and set the **Start Document** to **StatisticsDev.xlsx**.

	![_Setting Start Document](images/start-action.png?raw=true "_Setting Start Document")

	_Setting Start Document_

1. In Visual Studio, close all open files.
1. Install **Microsoft Excel 2013** or higher (if it is not already installed).

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Exploring the App for Office](#segment1).
1. [Running the solution](#segment2).

<a name="segment1" />
### Exploring the App for Office ###

1. Expand the **Controllers** folder, open the  **StatisticsController** file and show the **Get** method.

	<!-- mark:1-13 -->
	````C#
	// GET api/statistics
	[ResponseType(typeof(StatisticsViewModel))]
	public async Task<IHttpActionResult> Get()
	{
		StatisticsViewModel statistics =
			 await this.statisticsService.GenerateStatistics();
		if (statistics == null)
		{
			 return NotFound();
		}

		return Ok(statistics);
	}
````

1. Open the **OfficeAppController** file (located in the **Controllers** folder) and show that the **Index** action returns a view.

	<!-- mark:5-8 -->
	````C#
	public class OfficeAppController : Controller
	{
		//
		// GET: /Office/
		public ActionResult Index()
		{
			return View();
		}
	}
	````

1. Double-click the **GeekQuiz.OfficeManifest** file, located in the **GeekQuiz.Office** project and show that the **Source location** is defined as **GeekQuiz/OfficeApp/**.

	![Showing the Office Manifest](images/showing-the-office-manifest.png?raw=true "Showing the Office Manifest")

	_Showing the Office Manifest_

1. Back in the **GeekQuiz** project, open the **Index.cshtml** file located in the **Views/OfficeApp** folder.

1. Highlight the `<button>` element that is shown in the following snippet.

	````HTML
	<button id="update-statistics" disabled >Update Statistics</button>
	````

1. Show the **Scripts** section at the end of the file.

	````HTML
	@section Scripts {
		 <script src="@Url.Content("~/Scripts/OfficeApp.js")"></script>
	}
	````

1. Open the **OfficeApp.js** file located in the **Scripts** folder.

1. Show the `Office.initialize` callback assignment.

	````JavaScript
	// The initialize function must be run each time a new page is loaded
    Office.initialize = function (reason) {
        $(document).ready(function () {
            $('#update-statistics').click(updateStatisticsTable);

            initializeBindings();
        });
    };
	````

1. Show the **initializeBindings** function.

	````JavaScript
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
	````

1. Show the **updateStatisticsTable** function.

	````JavaScript
	function updateStatisticsTable() {
        $.getJSON("/api/statistics", function (data) {
            var headers = [['Total', 'Correct', 'Incorrect', 'Correct p/user', 'Incorrect p/user', 'Total p/user']];
            var rows = [[data.totalAnswers, data.correctAnswers, data.incorrectAnswers,
                          data.correctAnswersAverage, data.incorrectAnswersAverage, data.totalAnswersAverage]];
            var newValuesTable = new Office.TableData(rows, headers);

            Office.select("bindings#" + bindingID).setDataAsync(newValuesTable, { coercionType: Office.CoercionType.Table });
        });
    }
	````

<a name="segment2" />
### Running the solution ###

1. Start running the application by pressing **CTRL + F5**.

	![Running the solution](images/running-the-solution.png?raw=true "Running the solution")
	
	_Running the solution_

1. Once the Excel document is open, show the app for Office.

	![Showing the app for office](images/showing-the-app-for-office.png?raw=true "Showing the app for office")
	
	_Showing the app for office_

1. Select to the **DESIGN** tab and show that the **Table Name** is **StatisticsTable**.

	![Showing the table name](images/showing-the-table-name.png?raw=true "Showing the table name")
	
	_Showing the table name_

1. Click **Update Statistics**.

	![Updating the statistics](images/updating-the-statistics.png?raw=true "Updating the statistics")
	
	_Updating the statistics_

	> **Note:** It takes some time for the excel file to be updated the first time the button is clicked.

1. Show the new data in the statistics table.

	![Showing the updated statistics](images/updated-statistics.png?raw=true "Showing the updated statistics")
	
	_Showing the updated statistics_

1. Switch to the **GeekQuiz** web site, which was opened in a web browser when you pressed **CTRL + F5**.

	> **Note:** If the Log in page is displayed, provide the credentials you created during the setup steps.
	
	> ![Logging in the site](images/logging-in-the-app.png?raw=true "Logging in the site")	


1. Answer a few questions.

1. Go back to **Excel** and click **Update statistics** again.

1. Show that the data has changed again with the latest answers.

---

<a name="summary" />
## Summary ##

By completing this demo you should have walked through the code required for pulling data from GeekQuiz Web API from an Excel App

---
