<a name="title"></a>
# Visual Studio and Web Essentials - Web Tooling #

> **Note:** Many of the features in this demo (e.g. Browser Link) **do not work in the ASP.NET 5 RC1 release**. Support is being adding in Visual Studio web tools for ASP.NET Core, but is not available yet. **You can complete this demo using a new ASP.NET MVC 5 application (File / New / ASP.NET 5) until they are supported in ASP.NET Core**.

---
<a name="Overview"></a>
## Overview ##

In this demo you will perform several changes to GeekQuiz in order to showcase top web developer featuers included in the new version of Visual Studio and Web Essentials.  

<a id="goals"></a>
### Goals ###

In this demo, you will see:

1. The new HTML editor features, including HTML 5 snippets and zen coding
1. The new CSS editor features, including Color
1. Browser Link and the extension support for it
1. IDs and classes Intellisense in JavaScript

<a name="technologies"></a>
### Key Technologies ###

* [Web Essentials](http://vswebessentials.com/)
* [Visual Studio 2015](http://www.visualstudio.com/)
* [Browser Link](http://blogs.msdn.com/b/webdev/archive/2013/09/10/what-is-new-in-browser-link-with-visual-studio-2013-rc.aspx)

<a name="setup"></a>
### Setup and Configuration ###

Follow these steps to setup your environment for the demo.

1. Install **[Web Extension Pack](https://visualstudiogallery.msdn.microsoft.com/f3b504c6-0095-42f1-a989-51d5fc2a8459)** (if it is not already installed).

1. Open the **GeekQuiz.sln** solution located under **source/begin**.

1. Dock Visual Studio to the right and set up the layout of Microsoft Edge and Chrome as shown in the following figure.

	![Layout](Images/layout.png?raw=true)

1. In Visual Studio, open Index.cshtml in the editor.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Browser Link and Web Essentials](#segment1)
1. [Snippets and Intellisense](#segment2)

<a name="segment1"></a>
### Browser Link and Web Essentials ###

1. Expand the browser menu in the Visual Studio toolbar and select **Browse With...**.

	![Browse With](Images/browse-with.png?raw=true)

1. Hold down **CTRL** and select **Google Chrome and Microsoft Edge**.

	![Selecting multiple browsers](Images/multiple-browsers.png?raw=true "Selecting multiple browsers")

	_Selecting multiple browsers_

1. Click **Set as Default** and click **Cancel**.

1. Press **CTRL + F5** to start debugging.

1. Replace the `<!-- TODO: add options here-->` comment in the **index.cshtml** file with the following code snippet and press **TAB**.

	<!-- mark:1 -->
	````HTML
	button.btn.btn-info.btn-lg.option{Answer $}*4
	````

1. Click the Browser Link **Refresh** button.

	![Refreshing Linked Browsers](Images/refresh-browser-link.png?raw=true "Refreshing Linked Browsers")

	_Refreshing Linked Browsers_

1. Click **Microsoft Edge** (to set focus on it) and press **CTRL + ALT + I**.

	> **Speaking point:** Let's change the color of the border around the question.

1. Place the mouse over the light blue border and click on it, as shown in the following figure.

	![Inspecting the Border](Images/inspect-border.png?raw=true "Inspecting the Border")

	_Inspecting the Border_

	> **Speaking point:** Note that the element and its children are highlighted in Visual Studio. Now we know which CSS class we need to change.

1. Back in Visual Studio, press **CTRL + ,**,  type _site.css_ and press **ENTER**.

	![Opening the Site.css file](Images/opening-sitecss.png?raw=true "Opening the Site.css file")

	_Opening the Site.css file_

1. Scroll to the bottom of the file.

	![Scrolling to the botton of the file](Images/bottom.png?raw=true "Scrolling to the botton of the file")

	_Scrolling to the botton of the file_

1. Click the light blue square that is part of the border property of the `.flip-container .front` class.

	![Opening the Color Picker](Images/color-picker.png?raw=true "Opening the Color Picker")

	_Opening the Color Picker_

1. Expand the color picker by clicking the button with the chevrons, circled in the following figure.

	![Expanding the Color Picker](Images/expand-color-picker.png?raw=true "Expanding the Color Picker")

	_Expanding the Color Picker_

1. Select a new color, close the color picker and press **CTRL + ALT + ENTER** to update the browsers.

	![Updating the Border color](Images/update-border.png?raw=true "Updating the Border color")

	_Updating the Border color_

1. Open the **Index.cshtml** editor.

1. Click **Google Chrome** (to set focus on it) and press **CTRL + ALT + D**.

1. Place the mouse over the question's title and click on it, as shown in the following figure.

	![Editing the Question](Images/edit-question.png?raw=true "Editing the Question")

	_Editing the Question_

1. Update the original text with _What does it look like when I write a longer question?_.

	![Updating the Question](Images/updated-question.png?raw=true "Updating the Question")

	_Updating the Question_

	> **Speaking point:** Explain that the VS editor is updated and changes are saved automatically.

1. Back in Visual Studio, click the Browser Link **Refresh** button so IE is refreshed.

	![Refreshing Linked Browsers](Images/refresh-browser-link.png?raw=true "Refreshing Linked Browsers")

	_Refreshing Linked Browsers_

1. Expand the **Error List** window and double-click the SEO related warning.

	![Opening the SEO warning](Images/seo-error.png?raw=true "Opening the SEO warning")

	_Opening the SEO warning_

1. When asked if you would like to insert a `<meta>` tag, click **Yes**. 

	![Adding the description meta tag](Images/adding-description-meta-tag.png?raw=true "Adding the description meta tag")

	_Adding the description meta tag_

1. The editor for **\_Layout.cshtml** is opened an the following code is automatically added.

	````HTML
	<meta name="description" content="The description of my page" />
	````

1. Change the value of the `content` attribute to _GeekQuiz_ and save the file.


	````HTML
	<meta name="description" content="GeekQuiz" />
	````

<a name="segment2"></a>
### Snippets and Intellisense ###

1. Switch back to the **Index.cshtml** editor.

1. Add the following code inside the `<section>` element.

	````HTML
	<form>
		 <input type="text" id="name" />
	</form>
	````
1. Type `<label for="` inside the `<form>` element. As shown in the following figure, there is intellisense based on the Id of elements within the same valid scope (the `<form>`).

	![Showing the id Intellisense](Images/id-intellisense.png?raw=true "Showing the id Intellisense")

	_Showing the id Intellisense_

1. Delete the recently added `<form>` element and all its content.

1. Type `<aud` inside the `<section>` element as shown in the following figure.

	![Inserting a audio element](Images/audio-element.png?raw=true "Inserting a audio element")

	_Inserting a audio element_

	> **Note:** This demo segment adds an `<audio>` element to the page to showcase HTML 5 snippet support. This is meant to be a joke and the changes will be deleted, since we don't actually want to add audio to the site.

1. Press **TAB** twice. The following code will be added.

	````HTML
	<audio controls="controls">
		 <source src="file.mp3" type="audio/mp3" />
		 <source src="file.ogg" type="audio/ogg" />
	</audio>
	````

1. Delete the second line and update the source of the first one with the following link to the WebCampsTV Katana show:
http://media.ch9.ms/ch9/11d8/604b8163-fad3-4f12-9607-b404201211d8/KatanaProject.mp3. The resulting code is shown below.

	````HTML
	<audio controls="controls">
		 <source src="http://media.ch9.ms/ch9/11d8/604b8163-fad3-4f12-9607-b404201211d8/KatanaProject.mp3" type="audio/mp3" />
	</audio>
	````

1. Add the following code at the bottom of the file.

	````HTML
	@section Scripts {
		<script src="~/js/init.js"></script>
	}
	````

1. In **Solution Explorer**, right-click the **js** folder located in **wwwroot**, expand the **Add** menu and select **New Item...**.

	![Adding a Javascript File](Images/adding-javascript-file.png?raw=true "Adding a Javascript File]")

	_Adding a Javascript File_

1. In the **Add New Item** dialog box, select **JavaScript File** under the **DNX | Client-Side**, name the file _init.js_ and click **Add**.

	![Adding the init.js file](Images/creating-the-init-js-file.png?raw=true "Adding the init.js file")

	_Adding the init.js file_

1. Add the following code to the new JS file.

	<!-- mark:1-5 -->
	````JavaScript
	(function () {
		 $(document).ready(function () {

		 });
	}());
	````

1. Type `document.getElementsByClassName("")` in the first line of the ready callback, as shown in the following figure.

	![Showing Intellisense for the getElementsByClassName method](Images/byclassname.png?raw=true "Showing Intellisense for the getElementsByClassName method")

	_Showing Intellisense for the getElementsByClassName method_

1. Delete that line.

1. Type `var audioElements = document.getElementsByTagName("au")` in the first link of the ready callback, as shown in the following figure.

	![Showing Intellisense for the GetElementByTagName method](Images/getelementbytagname.png?raw=true "Showing Intellisense for the GetElementByTagName method")

	_Showing Intellisense for the GetElementByTagName method_

1. Select **"audio"** and press **Enter**. The result is shown in the following figure.

	![Retrieving Audio Elements](Images/retrieve-audio-elements.png?raw=true "Retrieving Audio Elements")

	_Retrieving Audio Elements_

1. Add the following code below the line you just typed.

	<!-- mark:1-4 -->
	````JavaScript
	var len = audioElements.length;
	for (var i = 0; i < len; i++) {
		 audioElements[i].play();
	}
	````

1. Click the Browser Link **Refresh** button. Once the pages are refreshed, audio will start playing.

	![Refreshing Linked Browsers](Images/refresh-browser-link.png?raw=true "Refreshing Linked Browsers")

	_Refreshing Linked Browsers_

1. Close both browser windows.

1. Delete the `<audio>` element and the `@section Scripts`.

	> **Speaking point:** We don't really want our site to have audio (it seems a bit 1990s), so let's get rid of these things we have added.


---

<a name="summary"></a>
## Summary ##

By completing this demo you should have showcased the features included in the new version of Visual Studio and Web Essentials while updating GeekQuiz:

1. Zen Coding for creating the buttons
1. CSS Color Picker for updating the color of the container's border
1. Browser Link to refresh changes done in Visual Studio automatically
1. Browser Link Extensions to reflect changes done in the browser in the source code
1. SEO warnings
1. IDs and JavaScript Intellisense
1. HTML 5 code snippets for adding audio

---
