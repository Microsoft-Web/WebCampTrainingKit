<a name="title" />
# Overview of Web API backend from GeekQuiz #

---
<a name="Overview" />
## Overview ##

In this demo you will walk through the process of building GeekQuiz backend. It'll be implemented using ASP.NET Web API to create a controller with two operations; Get, which returns the next question relying on the QuestionService for data access and Post to store the given answer using the AnswerService for data access.

<a id="goals" />
### Goals ###

In this demo, you will see how to:

1. Create a new Web API controller
1. Implement a Get operation in the Web API controller
1. Implement a Post operation in the Web API controller

<a name="technologies" />
### Key Technologies ###

- [ASP.NET Web API][1]

[1]: www.asp.net/web-api

<a name="Setup" />
### Setup and Configuration ###

In order to execute this demo you need to set up your environment.

1. Follow the steps detailed in [this link](http://docs.nuget.org/docs/creating-packages/hosting-your-own-nuget-feeds) to setup local sources for the following directories:

	1. **C:\Program Files (x86)\Microsoft Web Tools\Packages**
	1. **C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Stack 5\Packages**

	![Nuget Sources](images/nuget-sources.png?raw=true)

1. Open Visual Studio 2013.
1. Open the **GeekQuiz.sln** solution located under **source\begin**.
1. If you don't have one, create a user account for the application. To do that, press **F5**, click **Register** and provide the information required. After that, close the browser window.

	> **Note:** Remember the information you provided as you will be using it during the demo.

1. In Visual Studio, close all open files.

<a name="Demo" />
## Demo ##

This demo is composed of the following segments:

1. [Create the TriviaController](#segment1).
1. [Run the solution](#segment2).

<a name="segment1" />
### Create the TriviaController ###

1. Right-click the **Controllers** folder, expand the **Add** menu and click **Controller...** in order to create a new **TriviaController**.

	![Creating a new Controller](images/creating-a-new-controller.png?raw=true "Creating a new Controller")

	_Creating a new Controller_

1. In the **Add Scaffold** dialog, select **Web API 2 Controller - Empty** from the list and click **Add**.

	![Selecting the Web API 2 Controller - Empty option](images/selecting-the-web-api-controller-scaffold.png?raw=true "Selecting the Web API 2 Controller - Empty option")

	_Selecting the Web API 2 Controller - Empty option_

1. In the **Add Controller** dialog, set the Controller's name to **TriviaController**.

	![Setting the name to the TriviaController](images/setting-the-name-to-the-triviacontroller.png?raw=true "Setting the name to the TriviaController")

	_Setting the name to the TriviaController_

1. Implement the controller using the following code.

	<!-- mark:3-18 -->
	````C#
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
    }
````

1. Add the following using statements.

	<!-- mark:1-2 -->
	````C#
	using GeekQuiz.Models;
	using GeekQuiz.Services;
	````

1. Add the `Authorize` attribute to the TriviaController.

	<!-- mark:3 -->
	````C#
	namespace GeekQuiz.Controllers
	{
		 [Authorize]
		 public class TriviaController : ApiController
		 {
	````

1. Add the following code to create a **Get** action in the **TriviaController**.

	<!-- mark:1-14 -->
	````C#
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
````

1. Resolve the missing _using_ statements for **Task**.

1. Add the **Post** method from the following code snippet just after the **Get** method.

	<!-- mark:1-15 -->
	````C#
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
````

1. Build the solution.

<a name="segment2" />
### Run the solution ###

1. Set breakpoints on the first line of the **Get** and **Post** methods.

	![Setting the debug breakpoints to the methods](images/setting-the-debug-breakpoints.png?raw=true "Setting the debug breakpoints to the methods")

	_Setting the debug breakpoints to the methods_

1. Press **F5** to start debugging the application.

	> **Note:** If the Log in page is displayed, provide the credentials you created during the setup steps.
	
	> ![Logging in the site](images/logging-in-the-app.png?raw=true "Logging in the site")

1. In Visual Studio, the breakpoint on the first line of the **Get** method will be hit. Step over (**F10**) until the method's last line.

	![Stopping at the first line of the Get method](images/stopping-at-the-first-line-of-get.png?raw=true "Stopping at the first line of the Get method")

	_Stopping at the first line of the Get method_

1. Once you have reached the end of the method, press **F5** and go back to the browser.

	![Retrieving  the question](images/retriving-the-questions.png?raw=true "Retrieving the question")

	_Retrieving the question_

1. Click any of the buttons.

1. In Visual Studio, the breakpoint on the first line of the **Post** method will be hit. Step over (**F10**) until the method's last line.

	![Stopping at the first line of the Post method](images/stopping-at-the-first-line-of-post.png?raw=true "Stopping at the first line of the Post method")

	_Stopping at the first line of the Post method_

---

<a name="summary" />
## Summary ##

By completing this demo you should have:

1. Created a new Web API controller named "TriviaController".
1. Implemented the Get method to retrieve the next question and wired it to the database using the QuestionsService.
1. Implemented the Post method to store an answer and wired it to the database using the AnswersService.
1. Debug the implemented methods and walk through their implementation to better understand what's going on.

---
