<a name="title"></a>
# Building a SPA interface using Angular 2 #

---
<a name="Overview"></a>
## Overview ##

In this demo you will go through the steps required to build the web front end portion of GeekQuiz, focusing on the single page application interaction using Angular 2, and the CSS3 flip animation. 

<a id="goals"></a>
### Goals ###

In this demo, you will see how to:

1. Create a single page application using Angular 2 and ASP.NET Web API
1. Use CSS3 to perform rich animations

<a name="technologies"></a>
### Key Technologies ###

- [Angular 2](https://angular.io/)
- [TypeScript](http://www.typescriptlang.org/)
- [CSS3](http://www.w3schools.com/css/css3_intro.asp)

<a name="setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Open Visual Studio 2015.
1. Open the **GeekQuiz.sln** solution located under **source\begin**.
1. If you don't have one, create a user account for the application. To do that, press **F5**, click **Register** and provide the information required. After that, close the browser window.

	> **Note:** Remember the information you provided as you will be using it during the demo.

1. In Visual Studio, close all open files.
1. Make sure that you have an Internet connection, as this demo requires it to download the npm packages.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Consuming data from a Web API in an Angular 2 app](#segment1)
1. [Creating a flip animation using CSS3](#segment2)

<a name="segment1"></a>
### Consuming data from a Web API in an Angular 2 app ###

1. Press **CTRL + ,** and search for "_Layout.cshtml" (without the quotes).

	![Opening the layout file](images/opening-the-layout.png?raw=true "Opening the layout file")

	_Opening the layout file_

1. Press **Enter**. The "_Layout.cshtml" file is opened in the editor.

1. Add the following code inside the `<environment names="Development">` tag located inside the `head` tag.

	<!-- mark:1-3 -->
	````HTML
	<script src="https://code.angularjs.org/tools/system.js"></script>
	<script src="https://code.angularjs.org/2.0.0-alpha.46/angular2.dev.js"></script>
	<script src="https://code.angularjs.org/2.0.0-alpha.46/http.dev.js"></script>
	````

1. Add the following code inside the `<environment names="Staging,Production">` tag located inside the `head` tag.

	<!-- mark:1-3 -->
	````HTML
	<script src="https://code.angularjs.org/tools/system.js"></script>
	<script src="https://code.angularjs.org/2.0.0-alpha.46/angular2.min.js"></script>
	<script src="https://code.angularjs.org/2.0.0-alpha.46/http.min.js"></script>
	````

	![Updating the layout file to include the new dependencies](images/updating-the-layout.png?raw=true "Updating the layout file to include the new dependencies")

	_Updating the layout file to include the new dependencies_

1. Now, press **CTRL + ,** again and search for "index.cshtml" (without the quotes).

	![Opening the index view](images/opening-the-index-view.png?raw=true "Opening the index view")

	_Opening the index view_

1. Press **Enter**. The Index.cshtml file is opened in the editor.

1. Add the following code at the bottom of the file. This code will be used as the root of the SPA application.

	<!-- mark:1-7 -->
	````HTML
	<section id="content">
		 <div class="container">
			  <div class="row">
					<geekquiz-app>Loading...</geekquiz-app>
			  </div>
		 </div>
	</section>
	````

1. Add the following code snippet at the bottom of the file. This code will include the app.js file that will be created during the next steps.

	<!-- mark:1-9 -->
	````JavaScript
	@section Scripts {
		 <script>
			  System.config({
					packages: { 'js': { defaultExtension: 'js' } }
			  });

			  System.import('js/app');
		 </script>
	}
	````

1. Right-click the **js** folder located under **wwwroot** and select **New Item...** under **Add**.

	![Creating a new item](images/creating-a-new-item.png?raw=true "Creating a new item")

	_Creating a new item_

1.	Select **TypeScript File** under the **DNX | Client-Side** menu, change the name to **app.ts** and click **Add**.

	![Adding a new TypeScript file](images/adding-a-new-typescript-file.png?raw=true "Adding a new TypeScript file")

	_Adding a new TypeScript file_

1. Add the following code in the **app.ts** file you just created.

	<!-- mark:1-73 -->
	````JavaScript
    import {bootstrap, Component, View, NgFor, NgClass, AfterViewInit, Inject} from 'angular2/angular2';
    import {Http, HTTP_BINDINGS, Headers} from 'angular2/http';

    @Component({
        selector: 'geekquiz-app',
        viewBindings: [HTTP_BINDINGS]
    })
    class AppComponent implements AfterViewInit {
        public answered = false;
        public title = "loading question...";
        public options = [];
        public correctAnswer = false;
        public working = false;

        constructor( @Inject(Http) private http: Http) {
        }

        answer() {
            return this.correctAnswer ? 'correct' : 'incorrect';
        }

        nextQuestion() {
            this.working = true;

            this.answered = false;
            this.title = "loading question...";
            this.options = [];

            var headers = new Headers();
            headers.append('If-Modified-Since', 'Mon, 27 Mar 1972 00:00:00 GMT');

            this.http.get("/api/trivia", { headers: headers })
                .map(res => res.json())
                .subscribe(
                    question => {
                        this.options = question.options;
                        this.title = question.title;
                        this.answered = false;
                        this.working = false;
                    },
                    err => {
                        this.title = "Oops... something went wrong";
                        this.working = false;
                    });
        }

        sendAnswer(option) {
            this.working = true;
            var answer = { 'questionId': option.questionId, 'optionId': option.id };

            var headers = new Headers();
            headers.append('Content-Type', 'application/json');

            this.http.post('/api/trivia', JSON.stringify(answer), { headers: headers })
                .map(res => res.json())
                .subscribe(
                    answerIsCorrect => {
                        this.answered = true;
                        this.correctAnswer = (answerIsCorrect === true);
                        this.working = false;
                    },
                    err => {
                        this.title = "Oops... something went wrong";
                        this.working = false;
                    });
        }

        afterViewInit() {
            this.nextQuestion();
        }
    }

    bootstrap(AppComponent);
    ````

1. Add the following View decorator to the **AppComponent** class below the **Component** decorator.

	<!-- mark:1-19 -->
	````JavaScript
	@View({
		 directives: [NgFor, NgClass],
		 template: `
			  <div class="flip-container text-center col-md-12">
					<div class="front" [ng-class]="{flip: answered}">
						 <p class="lead">{{title}}</p>
						 <div class="row text-center">
							  <button class="btn btn-info btn-lg option" *ng-for="#option of options" [disabled]="working">{{option.title}}</button>
						 </div>
					</div>
			  </div>
		 `
	})
	````

1. Save the changes and show that Visual Studio compiles the TypeScript files generating JavaScript code.


	![Showing the generated code](images/showing-the-generated-code.png?raw=true "Showing the generated code")

	_Showing the generated code_

1. Press **F5**.

	> **Note:** If the Log in page is displayed, provide the credentials you created during the setup steps.
	
	> ![Logging in the site](images/logging-in-the-app.png?raw=true "Logging in the site")
	
1. As shown in the following figure, the buttons will be displayed. Click any of the buttons. Nothing will happen.

	![Showing the app running](images/showing-the-app-running.png?raw=true "Showing the app running")

	_Showing the app running_

<a name="segment2"></a>
### Creating a flip animation using CSS3###

1. Dock the Visual Studio window to the left, and the browser window to the right.

	![Docking the windows](images/docking-the-windows.png?raw=true "Docking the windows")

	_Docking the windows_

1. In Visual Studio, press **CTRL + ,** again and search for "flip.css" (without the quotes).

	![Opening the flip.css file](images/opening-the-flip-css-file.png?raw=true "Opening the flip.css file")

	_Opening the flip.css file_

1. Press **Enter**. The flip.css file is opened in the editor.

1. Show the flip.css file.

1. Go back to the **app.ts** file, add the `(click)="sendAnswer(option)"` to the `<button>` element inside the *each* loop. The resulting `<button>` element is the one from the following code snippet.

	<!-- mark:1 -->
	````HTML
	<button class="btn btn-info btn-lg option" *ng-for="#option of options" (click)="sendAnswer(option)" [disabled]="working">{{option.title}}</button>
	````

1. Add the following code snippet as the first child of `<div class="flip-container text-center col-md-12">` and save the changes.

	<!-- mark:1-8 -->
	````HTML
	<div class="back" [ng-class]="{flip: answered, correct: correctAnswer, incorrect:!correctAnswer}">
		<p class="lead">{{answer()}}</p>
		<p>
			  <button class="btn btn-info btn-lg next option" (click)="nextQuestion()" [disabled]="working">Next Question</button>
		</p>
	</div>
````

1. Click **Refresh Browser Link**.

	![Refreshing the Browser using Browser Link](images/refreshing-using-browser-link.png?raw=true "Refreshing the Browser using Browser Link")

	_Refreshing the Browser using Browser Link_

1. In the web browser, click any of the buttons. The flip animation will take place and the result (correct/incorrect) will be displayed.

	![Showing the flip animation](images/showing-the-flip-animation.png?raw=true "Showing the flip animation")

	_Showing the flip animation_

---

<a name="summary"></a>
## Summary ##

By completing this demo you should have:

1. Create a single page application using Angular 2 and ASP.NET Web API
1. Set up the CSS3 flip animation

---
