<a name="title"></a>
# Building a Universal Windows application front end #

---
<a name="Overview"></a>
## Overview ##
This demo demonstrates a Universal Windows application frond end (developed with HTML & JS) that allows users to take the quiz. It tours through already existing code that retrieves data from the REST API and shows the quiz running in a Universal Windows  application.

<a id="goals"></a>
### Goals ###
In this demo, you will see how to:

1. Retrieve data from a REST API from a Universal Windows application.
1. Leverage WinJS data-binding capabilities to automatically update the UI.

<a name="technologies"></a>
### Key Technologies ###

- [HTML](http://www.w3schools.com/html/)
- [WinJS](http://msdn.microsoft.com/en-us/library/windows/apps/br229773.aspx)
- [ASP.NET Core](http://docs.asp.net)


<a name="setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Open Visual Studio 2015.
1. Open the **GeekQuiz.sln** solution located under **source\end**.
1. Collapse the **GeekQuiz.Web** project node in **Solution Explorer**.
1. In Visual Studio, close all open files.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Walkthrough of default.js](#segment1)
1. [Walkthrough of viewModel.js](#segment2)
1. [Walkthrough of default.html](#segment3)
1. [Running the application](#segment4)

<a name="segment1"></a>
### Walkthrough of default.js ###

1. Open the file **default.js** located inside the **js** folder of the **GeekQuiz** project.

1. Select the code highlighted in the following snippet.
	
	<!-- mark:11-16 -->
	````JavaScript
	app.onactivated = function (args) {
		if (args.detail.kind === activation.ActivationKind.launch) {
			if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
				// TODO: This application has been newly launched. Initialize your application here.
			} else {
				// TODO: This application was suspended and then terminated.
				// To create a smooth user experience, restore application state here so that it looks like the app never stopped running.
			}
			args.setPromise(WinJS.UI.processAll());

			var root = document.getElementById("root");
			var questionDiv = document.getElementById("question");
			var nextButton = document.getElementById("next");
			var viewModel = new QuizViewModel(root, questionDiv, nextButton);

			viewModel.nextQuestion();
		}
	};
	````

	> **Speaking point:** Explain that our logic is going to be in a controller object and that the UI elements are going to be updated through data-binding.  We are basically creating the controller and asking for the next questions immediatly.

1. Highlight the following line (line #5 in the file):

	<!-- mark:1 -->
	````JavaScript
	WinJS.Binding.optimizeBindingReferences = true;
	````

	> **Speaking Point:** Explain that this is required for every Universal Windows application that takes advantage of data binding. Source [here](http://msdn.microsoft.com/en-us/library/windows/apps/jj215606.aspx).


<a name="segment2"></a>
### Walkthrough of viewModel.js ###

1. Open the file **viewModel.js** located inside the **js** folder of the **GeekQuiz** project.

1. Highlight the call to the `return WinJS.Class.define` function.

	> **Speaking point:** Explain that this the way that you can create classes with WinJS. Source [here](http://msdn.microsoft.com/en-us/library/windows/apps/br229813.aspx). The class that we are creating is a ViewModel. The set of properties of a ViewModel instance at a particular point in time represent the state of the view.

1. Highlight the `this.apiUrl` assignment, highlighted in the following code snippet:
	
	<!-- mark:6 -->
	````JavaScript
	return WinJS.Class.define(
        function (root, questionDiv, nextButton) {
            var self = this;

            var i;
            this.apiUrl = "http://localhost:50505/api/trivia";

            this.buttons = questionDiv.getElementsByTagName("button");

            this.question = {
                title: "Empty",
                id: 0,
                option1: {},
                option2: {},
                option3: {},
                option4: {},
                correct: false,
            };
	````

	> **Speaking point:** Explain that this is the end point of the REST API.

1. Highlight the `this.buttons` and `this.question` assignments, highlighted in the following code snippet:
	
	<!-- mark:8-18 -->
	````JavaScript
	return WinJS.Class.define(
        function (root, questionDiv, nextButton) {
            var self = this;

            var i;
            this.apiUrl = "http://localhost:50505/api/trivia";

            this.buttons = questionDiv.getElementsByTagName("button");

            this.question = {
                title: "Empty",
                id: 0,
                option1: {},
                option2: {},
                option3: {},
                option4: {},
                correct: false,
            };
	````

	> **Speaking point:** Explain that we are retrieving all the buttons that will be the question options. We are also creating a question with default values. These values will be updated when we retrieve each question from the REST API, and will be automatically updated through data-binding.

1. Highlight the code included in the following snippet:

	````JavaScript
	this.state = this.states.loading;

	this.eventListeners = [];

	for (i = 0; i <= 3; i++) {
		 this.eventListeners[i] = function (num) {
			  return function () {
					var j;
					// we are always the same buttons, need to clear event listeners
					for (j = 0; j < self.buttons.length; j++) {
						 self.buttons[j].removeEventListener("click", self.eventListeners[i]);
					}
					self.sendAnswer(self.question, self.question["option" + num]);
			  };
		 }(i + 1);
	}

	nextButton.addEventListener("click", function () {
		 self.nextQuestion.apply(self, arguments);
	});
	````

	> **Speaking point:** Explain that we are using `states` as an enumerator of the possible view states. We are also creating functions for the event listeners.
	All event listeners need to be removed once an option is clicked, as we are re-using the buttons for all questions.

1. Highlight the code included in the following snippet:

	````JavaScript
	WinJS.Binding.processAll(root, this);

	this.observable = WinJS.Binding.as(this);
	````

	> **Speaking point:** We are setting the ViewModel instance as the binding source for the `root` element. After that, we are creating an observable (proxy) for the ViewModel, so changes to properties are automatically reflected in the UI.

1. Highlight the `nextQuestion` method, which is included in the following code snippet:

	````JavaScript
    nextQuestion: function () {
        var self = this;

        WinJS.xhr({
            url: this.apiUrl,
            headers: {
                "If-Modified-Since": "Mon, 27 Mar 1972 00:00:00 GMT"
            }
        }).then(
            function (response) {
                var j, q = JSON.parse(response.responseText);
                self.observable.question.id = q.id;
                self.observable.question.title = q.title;
                self.observable.question.option1 = q.options[0];
                self.observable.question.option2 = q.options[1];
                self.observable.question.option3 = q.options[2];
                self.observable.question.option4 = q.options[3];

                for (j = 0; j < self.buttons.length; j++) {
                    self.buttons[j].addEventListener("click", self.eventListeners[j]);
                }

                self.observable.state = self.states.showingQuestion;
            }, function (error) {
                console.log(error);
            });
    },
	````

	> **Speaking point:** Explain that it performs the web request and once it completes successfully the properties in the observable are updated, which automatically updates the UI. The `xhr` function returns a promise (conceptually similar to a `Task` in .NET) so it can be returned or chained with other promises. Explain that we are using WinJS facilities, but we could use any library (such as JQuery) for the AJAX calls.

1. Highlight the `sendAnswer` method, which is included in the following code snippet:

	````JavaScript
	sendAnswer: function(question, option) {
		 this.observable.state = this.states.loading;
		 var self = this;
		 console.log("web request");
		 WinJS.xhr({
			  url: self.apiUrl,
			  type: "post",
			  headers: { "Content-type": "application/json" },
			  data: JSON.stringify({ "questionId": question.id, "optionId": option.id })
		 }).then(function (response) {
			  var r = JSON.parse(response.responseText);
			  self.observable.question.correct = r;
			  self.observable.state = self.states.showingAnswer;
		 }, function (error) {
			  console.log(error);
		 })
	}
	````

	> **Speaking point:** Explain that this is similar to the `nextQuestion` method, but the main difference is that we are using an HTTP POST instead of a GET.

<a name="segment3"></a>
### Walkthrough of default.html ###

1. In **Solution Explorer**, double-click **default.html** to open it in the editor.

1. Select the code highlighted in the following code snippet.
	
	<!-- mark:3-19 -->
	````HTML
	<section aria-label="Main content" role="main">
		 <div id="root" class="grid">
			  <div id="question" class="layout" data-win-bind="style.display: state Converters.showingQuestionToVisibilityConverter">
					<div class="title col1 row1">
						 <span data-win-bind="innerText: question.title"></span>
					</div>
					<div class="option col1 row2">
						 <button data-win-bind="innerText: question.option1.title; disabled: question.answered"></button>
					</div>
					<div class="option col2 row2">
						 <button data-win-bind="innerText: question.option2.title; disabled: question.answered"></button>
					</div>
					<div class="option col3 row2">
						 <button data-win-bind="innerText: question.option3.title; disabled: question.answered"></button>
					</div>
					<div class="option col4 row2">
						 <button data-win-bind="innerText: question.option4.title; disabled: question.answered"></button>
					</div>
			  </div>
	````

	> **Speaking point:** Explain that the ViewModel properties are bound to the different properties through the usage of the `data-win-bind` attribute. The visibility of these controls is determined by the binding declared in the `<div id="question" class="layout" data-win-bind="style.display: state Converters.showingQuestionToVisibilityConverter">` element, which determines the visibility based on the ViewModel's state.

1. Select the code included in the following code snippet:

	````HTML
	<div id="answer" class="layout" data-win-bind="style.display: state Converters.showingAnswerToVisibilityConverter">
		 <div class="title col1 row1" data-win-bind="style.display: question.correct Converters.boolToVisibilityConverter">
			  <span>Correct</span>
		 </div>
		 <div class="title col1 row1" data-win-bind="style.display: question.correct Converters.inverseBoolToVisibilityConverter">
			  <span>Incorrect</span>
		 </div>
		 <div class="next col1 row2">
			  <button id="next">Next question</button>
		 </div>
	</div>
	<div id="loading" class="layout" data-win-bind="style.display: state Converters.loadingToVisibilityConverter">
		 <div class="title col1 row1">
			  <span>Loading...</span>
		 </div>
		 <div class="progress col1 row2">
			  <progress></progress>
		 </div>
	</div>
	````

	> **Speaking point:** Explain that these `<div>` elements are also bound to the ViewModel's state (using different converters).

<a name="segment4"></a>
### Running the application ###

1. In **Solution Explorer**, right-click the **GeekQuiz.Web** project, expand the **Start** menu and select **Start new instance**.

	![Starting new web instance](Images/newinstance.png?raw=true "Starting new web instance")

	_Starting new web instance_

1. Once the site is up and running, repeat the previous step to start the **GeekQuiz** Universal Windows project. The application will be launched, and once the **Loading...** message disappears, the first question will be displayed.

	![Starting new instance](Images/newinstance-windows.png?raw=true "Starting new instance")

	_Starting new instance_

1. Answer some questions to show how the application works.

	![app](Images/app.png?raw=true)

	_Showing the App_

---

<a name="summary"></a>
## Summary ##

By completing this demo you should have understood how you can leverage a ASP.NET Core API from a Universal Windows application to quickly build a front end for an existing web application.

---
