<a name="title" />
# Building a SPA interface using Ember.js #

---
<a name="Overview" />
## Overview ##

In this demo you will go through the steps required to build the web front end portion of GeekQuiz, focusing on the single page application interaction using Ember.js and Handlebars, and the CSS3 flip animation. 

<a id="goals" />
### Goals ###

In this demo, you will see how to:

1. Create a single page application using Ember and ASP.NET Web API
1. Use CSS3 to perform rich animations
1. Use Handlebars to generate HTML based on predefined templates, and integrate that with your Ember controllers

<a name="technologies" />
### Key Technologies ###

- [Ember](http://emberjs.com/)
- [Handlebars](http://handlebarsjs.com/)
- [CSS3](http://www.w3schools.com/css3/)

<a name="setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Follow the steps detailed in [this link](http://docs.nuget.org/docs/creating-packages/hosting-your-own-nuget-feeds) to setup local sources for the following directories:

	1. **C:\Program Files (x86)\Microsoft Web Tools\Packages**
	1. **C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Stack 5\Packages**

	![NuGet Sources](images/nuget-sources.png?raw=true)

1. Open Visual Studio 2013.
1. Open the **GeekQuiz.sln** solution located under **source\begin**.
1. If you don't have one, create a user account for the application. To do that, press **F5**, click **Register** and provide the information required. After that, close the browser window.

	> **Note:** Remember the information you provided as you will be using it during the demo.

1. In Visual Studio, close all open files.
1. Make sure that you have an Internet connection, as this demo requires it to the download NuGet packages.

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Consuming data from a Web API in an Ember.js app](#segment1)
1. [Creating a flip animation using CSS3](#segment2)

<a name="segment1" />
### Consuming data from a Web API in an Ember.js app ###

1. Right-click the **GeekQuiz** project and select **Manage NuGet Packages...**.

	![Manage NuGet Packages](images/managenugetpackages.png?raw=true)

1. Select **Online** on the left panel.
1. Search for "ember" (without the quotes). A list of results similar to the one shown below will be displayed.

	![Search Ember](images/searchember.png?raw=true)

1. Install the package with Id **Ember**.

	![Install Ember](images/installember.png?raw=true)

1. Click **Close** to close the dialog.
1. Press **CTRL + ,** and search for "index.cs" (without the quotes).

	![index.cshtml](images/indexcshtml.png?raw=true)

1. Press **Enter**. The Index.cshtml file is opened in the editor.
1. Add the following code at the bottom of the file. This code will be used as the root of the SPA application.

	<!-- mark:1 -->
	````HTML
	<div id="bodyContainer"></div>
	````

1. Add the following code snippet at the bottom of the file:

	<!-- mark:1-41 -->
	````JavaScript
	@section Scripts {
    <script src="@Url.Content("~/Scripts/handlebars.js")"></script>
    <script src="@Url.Content("~/Scripts/ember-1.0.0.js")"></script>
    <script>
        var App = Ember.Application.create({ rootElement: '#bodyContainer' });

        App.Question = Ember.Object.extend({ title: "loading question...", options: [], answered: false });

        App.IndexController = Ember.ObjectController.extend({
            question: null,
            answer: null,

            init: function () {
                this._super();
                this.nextQuestion();
            },

            nextQuestion: function () {
                var controller = this;
                var question = App.Question.create();
                this.set('question', question);

                jQuery.getJSON("/api/trivia", function (response) {
                    question.setProperties(response);
                }).fail(function () { question.set('title', "Oops... something went wrong") });
            },

            sendAnswer: function (question, option) {
                var controller = this;

                // prevent multiple posts for the same question
                jQuery('.front button').attr('disabled', 'disabled');

                jQuery.post('/api/trivia', { 'questionId': question.id, 'optionId': option.id }, function (response) {
                    controller.set('answer', response ? 'correct' : 'incorrect');
                    controller.set('question.answered', true);
                });
            }
        });
    </script>
}
	````
1. Add the following code snippet between the `<div id=bodyContainer"></div>` element and the `Scripts` section:

	<!-- mark:1-20 -->
	````HTML
	<script type="text/x-handlebars" id="index">
		 <section id="content">
			  <div class="container">
					<div class="row">
						 <div class="flip-container text-center col-md-12">
							  <div {{bindAttr class=":front question.answered:flip" }}>
									<p class="lead">
										 {{question.title}}
									</p>
									<div class="row text-center">
										 {{#each option in question.options}}
											  <button class="btn btn-info btn-lg option">{{option.title}}</button>
										 {{/each}}
									</div>
							  </div>
						 </div>
					</div>
			  </div>
		 </section>
	</script>
	````
	> **Important:** Visual Studio's autocorrect feature sometimes changes bindAttr to bind**a**ttr. If that happens, you will need to correct that manually.

1. Press **F5**.

	> **Note:** If the Log in page is displayed, provide the credentials you created during the setup steps.
	
	> ![Log in](images/login.png?raw=true)
	
1. As shown in the following figure, the buttons will be displayed. Click any of the buttons. Nothing will happen.

	![question](images/question.png?raw=true)


<a name="segment2" />
### Creating a flip animation using CSS3###

1. Dock the Visual Studio window to the left, and the browser window to the right.

	![dock](images/dock.png?raw=true)

1. In Visual Studio, add the `{{action "sendAnswer" question option}}` to the `<button>` element inside the for each. The resulting `<button>` element is the one from the following code snippet:

	<!-- mark:1 -->
	````HTML
	<button class="btn btn-info btn-lg option" {{action "sendAnswer" question option}}>{{option.title}}</button>
	````

1. Add the following code snippet as the first child of `<div class="flip-container text-center col-md-12">`:

	<!-- mark:1-8 -->
	````HTML
	<div {{bindAttr class=":back question.answered:flip answer" }}>
		 <p class="lead">
			  {{answer}}
		 </p>
		 <p>
			  <button class="btn btn-info btn-lg next option" {{action "nextQuestion" option}}>Next Question</button>
		 </p>
	</div>
````
	> **Important:** Visual Studio's autocorrect feature sometimes changes bindAttr to bind**a**ttr. If that happens, you will need to correct that manually.

1. Click **Refresh Browser Link**.

	![Refresh Browser](images/refreshbrowser.png?raw=true)

1. In the web browser, click any of the buttons. The flip animation will take place and the result (correct/incorrect) will be displayed.

	![Result](images/result.png?raw=true)

---

<a name="summary" />
## Summary ##

By completing this demo you should have:

1. Included Ember.js and Handlebars.js via NuGet
1. Added handlebars bindings to show question and run the application
1. Added Ember code to call sendAnswer
1. Set up the CSS3 flip animation

---
