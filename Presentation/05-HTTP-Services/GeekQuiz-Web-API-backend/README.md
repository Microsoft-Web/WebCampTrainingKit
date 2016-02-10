<a name="title"></a>
# Overview of Web API backend from GeekQuiz #

---
<a name="Overview"></a>
## Overview ##

In this demo you will walk through the process of building GeekQuiz backend. It'll be implemented using ASP.NET Web API to create a controller with two operations; Get, which returns the next question relying on the QuestionService for data access and Post to store the given answer using the AnswerService for data access.

<a id="goals"></a>
### Goals ###

In this demo, you will see how to:

1. Create a new Web API controller
1. Implement a Get operation in the Web API controller
1. Implement a Post operation in the Web API controller

<a name="technologies"></a>
### Key Technologies ###

- [ASP.NET Web API](http://www.asp.net/web-api)

<a name="Setup"></a>
### Setup and Configuration ###

In order to execute this demo you need to set up your environment.

1. Open Visual Studio 2015.
1. Open the **GeekQuiz.sln** solution located under **source\begin**.
1. If you don't have one, create a user account for the application. To do that, press **F5**, click **Register** and provide the information required. After that, close the browser window.

	> **Note:** Remember the information you provided as you will be using it during the demo.

1. In Visual Studio, close all open files.

<a name="Demo"></a>
## Demo ##

This demo is composed of the following segments:

1. [Create the TriviaController](#segment1).
1. [Run the solution](#segment2).

<a name="segment1"></a>
### Create the TriviaController ###

1. Right-click the **Controllers** folder, expand the **Add** menu and click **New Item...** in order to create a new **TriviaController**.

	![Creating a new item](images/creating-a-new-item.png?raw=true "Creating a new item")

	_Creating a new item_

1. In the **Add New Item** dialog box, select **Web API Controller Class** from the list, set the Controller's name to **TriviaController** and click **Add**.

	![Selecting the Web API Controller Class option](images/selecting-the-web-api-controller-class.png?raw=true "Selecting the Web API Controller Class option")

	_Selecting the Web API Controller Class option_

1. Implement the controller using the following code.

	<!-- mark:4-23 -->
	````C#
    [Route("api/[controller]")]
    public class TriviaController : Controller
    {
        private TriviaDbContext context;
        private IQuestionsService questionsService;
        private IAnswersService answersService;

        public TriviaController(TriviaDbContext context, IQuestionsService questionsService, IAnswersService answersService)
        {
            this.context = context;
            this.questionsService = questionsService;
            this.answersService = answersService;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }

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

1. Add the `Produces("application/json")` attribute to the TriviaController.

	<!-- mark:3 -->
	````C#
	namespace GeekQuiz.Controllers
	{
		 [Produces("application/json")]
		 [Route("api/[controller]")]
		 public class TriviaController : Controller
		 {
	````

1. Add the `Authorize` attribute to the TriviaController.

	<!-- mark:5 -->
	````C#
	namespace GeekQuiz.Controllers
	{
		 [Produces("application/json")]
		 [Route("api/[controller]")]
		 [Authorize]
		 public class TriviaController : Controller
		 {
	````

1. Resolve the missing _using_ statements for the `Authorize` attribute.

	<!-- mark:1 -->
	````C#
	using Microsoft.AspNet.Authorization;
	````

1. Add the following code to create a **Get** action in the **TriviaController**.

	<!-- mark:1-16 -->
	````C#
	// GET: api/Trivia
	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var userId = User.Identity.Name;

		TriviaQuestion nextQuestion =
			 await this.questionsService.NextQuestionAsync(userId);

		if (nextQuestion == null)
		{
			 return HttpNotFound();
		}

		return Ok(nextQuestion);
	}
````

1. Add the **Post** method from the following code snippet just after the **Get** method.

	<!-- mark:1-15 -->
	````C#
	// PUT: api/Trivia
	[HttpPost]
	public async Task<IActionResult> Post([FromBody] TriviaAnswer answer)
	{
		if (!ModelState.IsValid)
		{
			 return HttpBadRequest(ModelState);
		}

		answer.UserId = User.Identity.Name;

		var isCorrect = await this.answersService.StoreAsync(answer);
		
		return this.CreatedAtAction("Get", new {}, isCorrect);
	}
````

1. Build the solution.

<a name="segment2"></a>
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

<a name="summary"></a>
## Summary ##

By completing this demo you should have:

1. Created a new Web API controller named "TriviaController".
1. Implemented the Get method to retrieve the next question and wired it to the database using the QuestionsService.
1. Implemented the Post method to store an answer and wired it to the database using the AnswersService.
1. Debug the implemented methods and walk through their implementation to better understand what's going on.

---
