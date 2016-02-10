<a name="HOLTop"></a>
# Visual Studio 2015 Web Tooling #

---

> **Note:** Many of the features in this lab (e.g. Browser Link) **do not work in the ASP.NET 5 RC1 release**. Support is being adding in Visual Studio web tools for ASP.NET Core, but is not available yet. **You can complete this lab using a new ASP.NET MVC 5 application (File / New / ASP.NET 5) until they are supported in ASP.NET Core**.

<a name="Overview"></a>
## Overview ##

Visual Studio is an excellent development environment for .NET-based Windows and web projects. It includes a powerful text editor that can easily be used to edit standalone files without a project.

Visual Studio maintains a full-featured parse tree as you edit each file. This allows Visual Studio to provide unparalleled auto-completion and document-based actions while making the development experience much faster and more pleasant. These features are especially powerful in HTML and CSS documents.

All of this power is also available for extensions, making it simple to extend the editors with powerful new features to suit your needs. Web Essentials is a collection of (mostly) web-related enhancements to Visual Studio. It includes lots of new IntelliSense completions (especially for CSS), new Browser Link features, automatic JSHint for JavaScript files, new warnings for HTML and CSS, and many other features that are essential to modern web development.

<a name="Objectives"></a>
### Objectives ###
In this hands-on lab, you will learn how to:

- Use new HTML editor features included in Web Essentials such as rich HTML5 code snippets and Zen coding 
- Use new CSS editor features included in Web Essentials such as the Color picker and Browser matrix tooltip
- Use new JavaScript editor features included in Web Essentials such as Extract to File and IntelliSense for all HTML elements
- Exchange data between your browser and Visual Studio using Browser Link


<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this hands-on lab:

- [Visual Studio Community 2015 or greater][1]
- [Web Extension Pack][2]
- [Google Chrome][3]

[1]: https://www.visualstudio.com/en-us/products/visual-studio-community-vs.aspx
[2]: https://visualstudiogallery.msdn.microsoft.com/f3b504c6-0095-42f1-a989-51d5fc2a8459
[3]: http://www.google.com/chrome/


> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.

<a name="Setup"></a>
### Setup ###
In order to run the exercises in this hands-on lab, you will need to set up your environment first.

1. Open a Windows Explorer window and browse to the lab's **Source** folder.
1. Right-click **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this lab.
1. If the User Account Control dialog box is shown, confirm the action to proceed.

> **Note:** Make sure you have checked all the dependencies for this lab before running the setup.

<a name="CodeSnippets"></a>
### Using the Code Snippets ###

Throughout the lab document, you will be instructed to insert code blocks. For your convenience, most of this code is provided as Visual Studio Code Snippets, which you can access from within Visual Studio 2015 to avoid having to add it manually. 

>**Note**: Each exercise is accompanied by a starting solution located in the **Begin** folder of the exercise that allows you to follow each exercise independently of the others. Please be aware that the code snippets that are added during an exercise are missing from these starting solutions and may not work until you have completed the exercise. Inside the source code for an exercise, you will also find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the corresponding exercise. You can use these solutions as guidance if you need additional help as you work through this hands-on lab.

---

<a name="Exercises"></a>
## Exercises ##
This hands-on lab includes the following exercises:

1. [Working with Browser Link and Web Essentials](#Exercise1)
1. [Taking Advantage of Code Snippets and IntelliSense](#Exercise2)


Estimated time to complete this lab: **45 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this lab describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1"></a>
### Exercise 1: Working with Browser Link and Web Essentials ###

**Web Essentials** is a Visual Studio extension that adds a variety of useful features for modern web development, mostly focused on making the web development experience much faster and more pleasant. You can install Web Essentials from the Extension Gallery in Visual Studio.

**Browser Link** is a new feature included in Visual Studio 2013 and 2015 that provides a channel between the Visual Studio IDE and any open browser to exchange data between your web application and Visual Studio. Web Essentials extends Browser Link with tools to manipulate the DOM object model and the CSS styles of your web pages directly from the browser.

In this exercise, you will explore some of the features supported by **Web Essentials** and **Browser Link** to enhance a simple quiz page. 

<a name="Ex1Task1"></a>
#### Task 1 - Running the Project in Multiple Browsers ####

In this task, you will configure your web application to run in multiple browsers at once, which is useful for cross-browser testing.

1. Open **Microsoft Visual Studio**. 

1. In the **File** menu, select **Open | Project/Solution...** and browse to **Ex1-WorkingwithBrowserLinkandWebEssentials\Begin** in the **Source** folder of the lab. Select **GeekQuiz.sln** and click **Open**.

1. In the Visual Studio toolbar, expand the browser menu and select **Browse With...**.

	![Browse With menu option](Images/browse-with-in-browser-menu.png?raw=true "Browse with in browser menu")

	_Browse With menu option_

1. In the **Browse With** dialog box, select both **Google Chrome** and **Microsoft Edge** by holding down the **CTRL** key and click **Set as Default**.

	![Browse with dialog box](Images/browse-with-dialog-box.png?raw=true "Browse with dialog box")

	_Selecting multiple default browsers_

1. Both Google Chrome and Microsoft Edge should now appear as the default browsers. Click **Cancel** to close the dialog box.

	![Google Chrome and Microsoft Edge as default browsers](Images/default-browsers.png?raw=true "Google Chrome and Microsoft Edge default browsers")

	_Google Chrome and Microsoft Edge as default browsers_

	>**Note:** After configuring the default browsers, the **Multiple Browsers** option is selected in the browser menu.
	>
	> ![Multiple browsers](Images/multiple-browsers.png?raw=true "Multiple browsers")
	>
	> _Multiple browsers_

1. Press **CTRL** + **F5** to run the application without debugging.

1. When both browser windows open, place one of them above the other in order to see the updates on both browsers simultaneously. The browsers should display a web page with a light-blue rectangle.

	![Placing one browser above the other](Images/placing-one-browser-above-the-other.png?raw=true "Placing one browser above the other")

	_Placing one browser above the other_

1. Do not close the browsers. You will use them in the next task. 

<a name="Ex1Task2"></a>
#### Task 2 - Using Zen Coding to Create HTML Elements ####

**Zen Coding** is an editor plugin for high-speed HTML, XML, XSL (or any other structured code format) coding and editing. The core of this plugin is a powerful abbreviation engine which allows you to expand expressions -similar to CSS selectors- into HTML code. Zen Coding is a fast way to write HTML using a CSS style selector syntax.

In this exercise, you will use the Zen Coding feature provided by Web Essentials to generate the HTML buttons that represent the options of the question.

1. Switch back to Visual Studio.

1. Open the **Index.cshtml** file located in the **Views** | **Home** folder.

1. Replace the **\<!-- TODO: add options here-->** comment with the following code, and press **TAB**.

	<!-- mark:1 -->
	````HTML
	button.btn.btn-info.btn-lg.option{Answer $}*4 
	````

1. The code should be expanded to HTML.

	![Expanded HTML](Images/expanded-html.png?raw=true "Expanded HTML")

	_Expanded HTML_

	> **Note:** To learn more about Zen Coding syntax, see the following [article](http://www.johnpapa.net/zen-coding-in-visual-studio-2012/).

1. Click the **Refresh linked browsers** button to update both browsers.

	![Refresh linked browsers](Images/refresh-linked-browsers.png?raw=true "Refresh linked browsers")

	_Refresh linked browsers_

	![Microsoft Edge - Page updated with four buttons](Images/microsoft-edge-updated-with-4-buttons.png?raw=true "Microsoft Edge - Page updated with four buttons")

	_Microsoft Edge - Page updated with four buttons_

	![Google Chrome - Page updated with four buttons](Images/google-chrome-updated-with-4-buttons.png?raw=true "Google Chrome - Page updated with four buttons")
	
	_Google Chrome - Page updated with four buttons_

1. Switch back to Visual Studio.

1. You have added the buttons to the page, but you still need to add a template question. To do so, you will use a new feature in Web Essentials called **Lorem Ipsum generator**. Locate the **div** element with the **class** attribute **front**.

1. Add the following code as the first child element of the **div**, and press **TAB**.

	````HTML
	p.lead>lorem5
	````

1. The code should be expanded to HTML.

	![Lorem Ipsum autogenerated](Images/lorem-ipsum-autogenerated.png?raw=true "Lorem Ipsum autogenerated")

	_Lorem Ipsum autogenerated_

	>**Note:** As part of Zen Coding, you can now generate Lorem Ipsum code directly in the HTML editor. Simply type **lorem** and hit **TAB** and a 30 word Lorem Ipsum text will be inserted. E.g. _lorem10_ inserts 10 Lorem Ipsum words.

1. You will add a logo at the top of the question by using another new feature in Web Essentials called **Lorem Pixel generator**. Add the following code as the first child element of the **div** element with **container** as **class** value, and press **TAB**.

	````HTML
	div.row.header>pix-436x185-abstract
	````

1. The code should expand to HTML.

	![Lorem Pixel autogenerated](Images/lorem-pixel-autogenerated.png?raw=true "Lorem Pixel autogenerated")

	_Lorem Pixel autogenerated_

	>**Note:** As part of Zen Coding, you can also generate Lorem Pixel code directly in the HTML editor. Simply type **pix-200x200-animals** and hit **TAB** and an **img** tag with a 200x200 image of an animal will be inserted. For more information, refer to [Lorem Pixel](http://www.lorempixel.com).

1. Click the **Refresh linked browsers** button to update both browsers.

	![Microsoft Edge - Autogenerated image and text](Images/microsoft-edge-autogenerated-image-and-text.png?raw=true "Microsoft Edge - Autogenerated image and text")

	_Microsoft Edge - Autogenerated image and text_

	![Google Chrome - Autogenerated image and text](Images/google-chrome-autogenerated-image-and-text.png?raw=true "Google Chrome - Autogenerated image and text")

	_Google Chrome - Autogenerated image and text_

	>**Note:** Because the image is selected randomly when adding the code snippet, the image shown in the browsers may differ.

1. Do not close the browsers. You will use them in the next task.

<a name="Ex1Task3"></a>
#### Task 3 - Updating a Style Property ####

In this task, you will use the Browser Link's **Inspect Mode** feature to detect the exact location where the specific DOM element is generated and then update the color property of that element using a color picker provided by Web Essentials.

1. In the Internet Explorer browser, press **CTRL** + **ALT** + **I** to enable Inspect Mode.

1. Move the pointer over the light blue border and click.

	![Moving the pointer over the light blue border](Images/mouse-over-the-light-blue-border.png?raw=true "Moving the pointer over the light blue border")

	_Moving the pointer over the light blue border_

1. Switch back to Visual Studio. Notice how the HTML element that you selected in the browser is also selected in the Visual Studio HTML editor.

	![HTML element selected in the Visual Studio HTML editor](Images/html-element-highlighted.png?raw=true "HTML element selected in the Visual Studio HTML editor")

	_HTML element selected in the Visual Studio HTML editor_

1. You will now update the **front** CSS class in order to change the styling of the selected element. To do so, press **CTRL** + **,** to open the **Navigate To** search box. Type **site.css** and press **ENTER** to open the file.

	![Opening file Site.css](Images/sitecss-file-found.png?raw=true "Opening file Site.css")

	_Opening file Site.css_

1. Press **CTRL** + **F** and type **.flip-container .front** to find the CSS selector. 

1. Click the light blue square in the border property of the class to open the Color Picker.

	![Opening the Color Picker](Images/opening-the-color-picker.png?raw=true "Opening the Color Picker")

	_Opening the Color Picker_

1. Expand the Color Picker by clicking the chevron button and select a new color.

	![Expanding the Color Picker](Images/expanding-the-color-picker.png?raw=true "Expanding the Color Picker")

	_Expanding the Color Picker_

1. Press **CTRL** + **ALT** + **ENTER** to refresh linked browsers. 

1. Switch to Microsoft Edge and notice how the color of the border has changed.

	![Microsoft Edge - Border color updated](Images/microsoft-edge-border-color-updated.png?raw=true "Microsoft Edge - Border color updated")

	_Microsoft Edge - Border color updated_

1. Switch to Google Chrome and notice how the color of the border has changed.

	![Google Chrome - Border color updated](Images/google-chrome-border-color-updated.png?raw=true "Google Chrome - Border color updated")

	_Google Chrome - Border color updated_

1. Switch back to Visual Studio.

1. Go to the end of the **Site.css** file and press **CTRL** + **F** to locate the **.btn** selector.

1. Notice that the **-webkit-border-radius** property is underlined in green.

	![-webkit-border-radius property of the btn selector](Images/-webkit-border-radius-property-of-the-btn-sel.png?raw=true "-webkit-border-radius property of the btn selector")

	_-webkit-border-radius property of the btn selector_

1. Place the caret in the **-webkit-border-radius** property. A blue line should appear under the first letter of the first word of the property. This is the **smart tag**.

1. Open the suggestions menu and click **Add missing standard property (border-radius)**.

	![Add missing standard property suggestion](Images/add-missing-standard-properties-suggestion.png?raw=true "Add missing standard property suggestion")

	_Add missing standard property suggestion_

1. The **border-radius** property is automatically added to the CSS rule.
	
	![Missing standard property added](Images/missing-standard-property-added.png?raw=true "Missing standard property added")

	_Missing standard property added_

1. Move the pointer over the **border-radius** property to display the **Browser matrix tooltip**. The **Browser matrix tooltip** shows the availability of the property in each browser.

	![Browser matrix tooltip](Images/browser-matrix-tooltip.png?raw=true "Browser matrix tooltip")

	_Browser matrix tooltip_

1. Notice that the value of the **border-radius** property is still underlined. Move the pointer over the value to see the warning message.

	![Border-radius property value warning](Images/border-radius-property-value-warning.png?raw=true "Border-radius property value warning")

	_Border-radius property value warning_

1. Remove the unit of the **border-radius** property value as suggested by the tooltip.

1. Place the caret in the **word-wrap** property and notice that the smart tag also appears below.

1. Open the menu and click **Add missing vendor specifics**.

	![Add missing vendor specifics suggestion](Images/add-missing-vendor-specifics-suggestion.png?raw=true "Add missing vendor specifics suggestion")

	_Add missing vendor specifics suggestion_

1. The  **-ms-word-wrap** property is automatically added to the CSS rule.

	![Vendor specific property added](Images/vendor-specific-property-added.png?raw=true "Vendor specific property added")

	_Vendor specific property added_


<a name="Ex1Task4"></a>
#### Task 4 - Updating the HTML Code from the Browser ####

In this task, you will use the Browser Link's **Design Mode** feature to edit the DOM object from the browser and transfer the changes to the HTML source file in Visual Studio.

1. In Google Chrome, press **CTRL** + **ALT** + **D** to enable Design Mode.

1. Move the pointer over the **Lorem Ipsum dolor sit amet** label and click.

	![Editing the question](Images/editing-the-question.png?raw=true "Editing the question")

	_Editing the question_
	
1. A cursor should appear. Replace the original text with _What does it look like when I write a longer question?_, and then press **ESC** to exit Design Mode.

	![Question edited](Images/question-edited.png?raw=true "Question edited")

	_Question edited_

1. Switch back to Visual Studio and open **Index.cshtml**, if not already opened. Notice that the inner text of the **\<p\>** element has been updated.

	![Updated question in the HTML page](Images/updated-question-in-the-html-page.png?raw=true "Updated question in the HTML page")

	_Updated question in the HTML page_

<a name="Ex1Task5"></a>
#### Task 5 - Reviewing SEO Related Warnings ####

**Search Engine Optimization** (SEO) is the process of making a website rank higher on a search engine's list of results. The higher the site ranks and the more consistently it is listed, the more visitors the site will get from that search engine. Web Essentials incorporates an analytical tool that examines HTML, reports the issues found and provides assistance to fix them.

1. Go to the **View** menu and click **Error List** to open the **Error List** window.

	![Error List in View menu](Images/error-list-in-view-menu.png?raw=true "Error List in View menu")

	_Error List in View menu_

1. Notice that there is an SEO warning notifying that a **\<meta\>** tag for the page description is missing. Double-click the SEO warning entry to fix it.

	![Error List window](Images/error-list-window.png?raw=true "Error List window")

	_Error List window_

1. In the **Web Essentials** dialog box, click **Yes** to insert a description \<meta\> tag.

	![Web Essentials dialog box](Images/web-essentials-dialog-box.png?raw=true "Web Essentials dialog box")

	_Web Essentials dialog box_

1. The editor for **_Layout.cshtml** opens and the **\<meta\>** tag is automatically added to the **head** section of the HTML file.

	![Meta tag automatically added in _Layout page](Images/meta-tag-automatically-added-in-layout-page.png?raw=true "Meta tag automatically added in _Layout page")

	_Meta tag automatically added to _Layout page_

1. Change the value of the **content** attribute to _GeekQuiz_ and save the file.

<a name="Exercise2"></a>
### Exercise 2: Taking Advantage of Code Snippets and IntelliSense ###

With Web Essentials, the HTML editor has been extended with extra functionality. In this exercise, you will see some new features that are helpful when developing web applications.

<a name="Ex2Task1"></a>
#### Task 1 - Using IntelliSense in HTML Documents ####

The first new feature you will see in this task is called **Dynamic IntelliSense**. Dynamic IntelliSense reads other tags and attributes to infer the possible ids you will use. 

In this task, you will create a new HTML form element which contains a label and an input field. Then you will add a **for** attribute to the label to bind it to the input, and you will see IntelliSense suggestions based on the ids of the inputs in scope.

1. Open **Visual Studio** and the **GeekQuiz.sln** solution located in the **Source/Ex2-TakingAdvantageofCodeSnippetsandIntelliSense/Begin** folder. Alternatively, you can continue with the solution that you obtained in the previous exercise.

1. In **Solution Explorer**, open the **Index.cshtml** file located in the **Views** | **Home** folder.

1. Add the following form inside the **div element with container as class value**.

	(Code Snippet - _VSWebTooling_ - _Ex2_ - _Form_)

	<!-- mark:1-3 -->
	````HTML
	<form>
		 <input type="text" id="name" />
	</form>
	````

1. The input tag should be preceded by a label with some description of the field. Add the following label before the input tag.

	<!-- mark:2 -->
	````HTML
	<form>
		<label id="name">Name</label>		
		<input type="text" id="name" />
	</form>
	````

1. The **for** attribute of a **\<label\>** specifies which form element a label is bound to. The attribute's value should be equal to the id of the related element. Add the **for** attribute to the **\<label\>** element. As shown in the following figure, the "name" value pops up in the IntelliSense box, based on the id of the elements within the same scope (the enclosing **\<form\>**).

	![Showing the id in IntelliSense](Images/showing-the-id-in-intellisense.png?raw=true "Showing the id in IntelliSense")

	_Showing the id in IntelliSense_

1. Delete the recently added **\<form\>** element and its content.

<a name="Ex2Task2"></a>
#### Task 2 - Using HTML Code Snippets ####

HTML5 introduced more than 25 new semantic tags. Visual Studio already had IntelliSense support for these tags, but Visual Studio 2015 makes it faster and easier to write markup by adding new code snippets. Though these tags are not complicated, they come with a few small subtleties, such as adding the correct codec fallbacks for the _audio_ tag. In this task, you will see the HTML code snippets for the audio tag.

1. In the **Index.cshtml** file, type **\<aud** inside the **\<section>** element as shown in the following figure.

	![Inserting an audio element](Images/inserting-an-audio-element.png?raw=true "Inserting an audio element")

	_Inserting an audio element_

1. Press **TAB** twice and notice how the following code is added on the page and the cursor is placed on the **src** attribute of the first source.

	````HTML
	<audio controls="controls">
		 <source src="file.mp3" type="audio/mp3" />
		 <source src="file.ogg" type="audio/ogg" />
	</audio>
	````

	>**Note:** By pressing the **TAB** key twice, the code snippet is inserted. The audio snippet shows the standard usage of the _audio_ tag, with two source files for improved support.

1. Delete the second line and update the source of the first line with the following link to the WebCampsTV Katana show:
http://media.ch9.ms/ch9/11d8/604b8163-fad3-4f12-9607-b404201211d8/KatanaProject.mp3. The resulting code is shown below.

	<!-- mark:2 -->
	````HTML
	<audio controls="controls">
		 <source src="http://media.ch9.ms/ch9/11d8/604b8163-fad3-4f12-9607-b404201211d8/KatanaProject.mp3" type="audio/mp3" />
	</audio>
	````

	>**Note:** The source file *KatanaProject.mp3* is used as an example. You can use another source if you prefer.

1. Press **CTRL** + **S** to save the file.

1. Press **CTRL** + **F5** to start the application.

1. Notice that an audio player was added to the application.

	![Audio player in Microsoft Edge](Images/audio-player-in-microsoft-edge.png?raw=true "Audio player in Microsoft Edge")
	
	_Audio player in Microsoft Edge_

	![Audio player in Google Chrome](Images/audio-player-in-google-chrome.png?raw=true "Audio player in Google Chrome")

	_Audio player in Google Chrome_

1. Do not close the browsers. You will use them in the next task.

<a name="Ex2Task3"></a>
#### Task 3 - Using IntelliSense in JavaScript Documents ####

With Web Essentials, style sheets and HTML pages produce a list of IDs and class names. In this task, you will learn how those lists improve JavaScript IntelliSense support in Web Essentials. 

1. In the **Index.cshtml** file, add the following code to define a **script** tag for JavaScript code.

	<!-- mark:3-7 -->
	````HTML
		...
	</section>
	@section scripts{
		<script type="text/javascript">

		</script>
	}
	````

1. Add the following code inside the **script** tag to define the ready callback function.
	
	(Code Snippet - _VSWebTooling_ - _Ex2_ - _ReadyFunction_)

	<!-- mark:1-5 -->
	````JavaScript
	(function () {
		$(document).ready(function () {
			
		});
	}());
	````

1. Place the caret in the **script** tag and press **CTRL** + **.** to open the suggestion menu.

1. Click **Extract To File**.

	![JavaScript extract to file suggestion](Images/javascript-extract-to-file.png?raw=true "JavaScript extract to file suggestion")

	_JavaScript extract to file suggestion_

1. In the **Save As** window, select the **wwwroot | js** folder, name the file **init.js** and click **Save**.

	![Save As window](Images/save-as-window.png?raw=true "Save As window")

	_Save As window_

	>**Note:** The **init.js** file is created and the content of the script is moved to the file.
	>
	>	![Init.js file created with the content included](Images/initjs-file-created-with-the-content-included.png?raw=true "Init.js file created with the content included")
	>
	>	_Init.js file created with the content included_

1. Open the **Index.cshtml** file and check that the script tag was replaced with a reference to the **init.js** file. Remove the **wwwroot** section from the source url.

	![Init.js html reference](Images/initjs-html-reference.png?raw=true "Init.js html reference")

	_Init.js html reference_

1. Go to the **Solution Explorer** and notice that the **init.js** file was included automatically in the solution.

	![Init.js file included in solution](Images/initjs-file-included-in-solution.png?raw=true "Init.js file included in solution")

	_Init.js file included in solution_

1. Switch back to the **init.js** file to update the **ready** function callback.

1. Inside the function callback definition that is passed to _ready_, add the following code to get all the elements by a specific class attribute.

	<!-- mark:3 -->
	````JavaScript
	(function () {
		 $(document).ready(function () {
			  document.getElementsByClassName("")
		 });
	}());
	````

1. Press **CTRL** + **Space** between the quotes inside the **getElementsByClassName** function call.

	![Showing IntelliSense for the getElementsByClassName function](Images/byclassname.png?raw=true "Showing IntelliSense for the getElementsByClassName function")

	_Showing IntelliSense for the getElementsByClassName function_

	>**Note:** Notice that IntelliSense shows the classes defined in the project style sheets.

1. Replace the line that you have created with the following code.

	<!-- mark:3 -->
	````JavaScript
	(function () {
		 $(document).ready(function () {
			  var audioElements = document.getElementsByTagName("au");
		 });
	}());
	````

1.  Position the cursor after **au** inside the quotes in the **getElementsByTagName** function and press **CTRL** + **Space**.

	![Showing IntelliSense for the getElementByTagName method](Images/getelementbytagname.png?raw=true "Showing IntelliSense for the getElementByTagName method")

	_Showing IntelliSense for the getElementsByTagName method_

1. Select **"audio"** from the list and press **ENTER**. The result is shown in the following figure.

	![Retrieving Audio Elements](Images/retrieve-audio-elements.png?raw=true "Retrieving Audio Elements")

	_Retrieving Audio Elements_

1. In **Solution Explorer**, right-click the **init.js** file in the **wwwroot | js** folder and select **Minify File** from the menu.

	![Minify JavaScript file(s)](Images/minify-javascript-files.png?raw=true "Minify JavaScript files")

	_Minify JavaScript file(s)_

	>**Note:** The **init.min.js** is created and is added as a dependency of the **init.js** file.
	>
	>	![Init.min.js file created](Images/initminjs-file-created.png?raw=true "Init.min.js file created")
	>
	>	_Init.min.js file created_

1. Open the **init.min.js** file and notice that the file is minified.

	![Init.min.js file content](Images/initminjs-file-content.png?raw=true "Init.min.js file content")

	_Init.min.js file content_

1. In the **init.js** file, add the following code below the **getElementsByTagName** function call to play all the audio elements.
	
	(Code Snippet - _VSWebTooling_ - _Ex2_ - _PlayAudioElements_)

	<!-- mark:1-4 -->
	````JavaScript
	var len = audioElements.length;
	for (var i = 0; i < len; i++) {
		 audioElements[i].play();
	}	
	````

1. Click **CTRL** + **S** to save the file. Since the minified file is already opened, you will see a dialog box saying that the file was modified outside of the source editor. Click **Yes**.

	![Microsoft Visual Studio warning](Images/microsoft-visual-studio-warning.png?raw=true "Microsoft Visual Studio warning")

	_Microsoft Visual Studio warning_

1. Switch back to the **init.min.js** file to verify that the file was updated with the new code.

	![Init.min.js file updated](Images/initminjs-file-updated.png?raw=true "Init.min.js file updated")

	_Init.min.js file updated_

1. Click the **Browser Link Refresh** button. 

1. Once both browsers are refreshed the audio players you saw in the previous task will start playing automatically.

	![Audio player included in view](Images/audio-player-included-in-view.png?raw=true "Audio player included in view")

	_Audio player included in view_

---

<a name="Summary"></a>
## Summary ##

By completing this hands-on lab you have learned how to:

- Use new HTML editor features included in Web Essentials such as rich HTML5 code snippets and Zen coding 
- Use new CSS editor features included in Web Essentials such as the Color picker and Browser matrix tooltip 
- Use new JavaScript editor features included in Web Essentials such as Extract to File and IntelliSense for all HTML elements 
- Exchange data between your browser and Visual Studio using Browser Link


> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.
