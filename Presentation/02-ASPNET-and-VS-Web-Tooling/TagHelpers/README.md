<a name="title"></a>
# Tag Helpers #

---
<a name="Overview"></a>
## Overview ##

This demo introduces Tag Helpers and how they can be used as an alternative to HTML Helpers. Additionally, it shows how to create custom Tag Helpers.

Tag Helpers are a new feature introduced in ASP.NET Core 1.0. They combine the power of the Razor view engine and the expressiveness of HTML by allowing you to write HTML tags in your views rather than inline C# - all this with IntelliSense support.

<a id="goals"></a>
### Goals ###
In this demo, you will see how to:

1. Identify Tag Helpers
1. Create custom Tag Helpers

<a name="technologies"></a>
### Key Technologies ###

- [ASP.NET Core][1]

[1]: http://docs.asp.net

<a name="Setup"></a>
### Setup and Configuration ###
Follow these steps to set up your environment for the demo.

1. Install [Visual Studio 2015](https://www.visualstudio.com/).
1. Open Visual Studio.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Tag Helpers in the project template](#segment1)
1. [Create a custom Tag Helper](#segment2)

<a name="segment1"></a>
### Tag Helpers in the project template ###

1. In Visual Studio, go to **File | New | Project**.

1. In the **Templates | Visual C# | Web** tab, select the **ASP.NET Web Application** project. Name it **TagHelpersDemo**.

	![Creating a web project](images/creating-a-web-project.png?raw=true "Creating a web project")

	_Creating a web project_

1. From the **ASP.NET 5 Templates** list, select the **Web Application** template and click **OK**.

	![Selecting the Web Site template](images/selecting-the-web-site-template.png?raw=true "Selecting the Web Site template")

	_Selecting the Web Site template_

1. Open **Views/Account/Register.cshtml**.

1. Look at the Tag Helpers being used in this view (purple and bold) and play around with setting their attributes and exploring the IntelliSense offered for the different attribute types.

	![Showing the Register view](images/register-view.png?raw=true "Showing the register view")

	_Showing the Register view_

1. Run the application and go to the **Register** page. Using the Microsoft Edge development tools, look at the HTML output of the Tag Helpers.

	![Showing the register view](images/register-view-html-output.png?raw=true "Showing the register view")

	_Showing the Register View's HTML output_

1. Switch back to Visual Studio. You can take a look at the other views in the **Views/Account** folder to see how they use Tag Helpers.

1. Now, open the **Views/Shared/_Layout.cshtml** file.

1. Look at the Tag Helpers being used in the **<head>** element to render CSS stylesheets and at the end of the page to render JavaScript files.

	![Showing layouts head heplers](images/head-layouts-helpers.png?raw=true "Showing layouts head heplers")

	_Showing Tag Helpers in the Layout_

1. In Microsoft Edge, look at the HTML output of the CSS files.

	![Showing head helpers HTML output](images/head-helpers-html-output.png?raw=true "Showing head helpers html output")

	_Showing the HTML output of the Layout_

<a name="segment2"></a>
### Create a custom Tag Helper ###

1. Create a new **RepeatTagHelper** class in the root of the application you created in the previous segment by adding a new item to the project and selecting **Razor Tag Helper**.

	![Creating the Tag Helper class](images/creating-the-tag-helper-class.png?raw=true "Creating the Tag Helper class")

	_Creating the Tag Helper class_

1. Show the content of the generated file and update the _HtmlTargetElement_
 parameter to `repeat`.

	![Showing the content of the generated file](images/showing-the-generated-tag-helper.png?raw=true "Showing the content of the generated file")

	_Showing the content of the generated file_

1. Replace the content of the RepeatTagHelper class with the following code snippet.

	````C#
    public int Count { get; set; }

    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
    }
	````

1. Add the following code to the body of the **ProcessAsync** method that repeats the content via the **output** parameter in a loop of **Count** iterations.

	````C#
    for (int i = 0; i < Count; i++)
    {
        output.Content.Append(await output.GetChildContentAsync());
    }
	````

1. Open the **Views/_ViewImports.cshtml** file and add a line at the end to register the assembly that contains your Tag Helper.

	````C#
	@addTagHelper "*, TagHelpersDemo"
	````

1. Open the **Views/Home/Index.cshtml** file and use your Tag Helper by adding the following code directly above the `<div id="myCarousel" ...>` HTML element.

	````HTML
	<repeat count="5">
		<h3>I'll be repeated!!</h3>
	</repeat>
	````

	![Using the custom tag helper](images/using-custom-tag-helper.png?raw=true "Using custom tag helper")

	_Using the custom tag helper_

1. Run the application again and ensure your Tag Helper is working.

1. Note that the Tag Helper is rendering itself as a **<repeat>** tag. We'll fix that now so that only the contents of the tag are rendered.

	![Showing the custom tag helper](images/custom-tag-helper.png?raw=true "Showing the custom tag helper")

	_Showing the custom tag helper_

1. Open the **RepeatTagHelper** class, and at the end of the **ProcessAsync** method add a line to null the tag name.

	````C#
	output.TagName = null;
	````

1. Run the application again and notice that the outer tag is no longer being rendered.

	![The custom tag is no longer rendered](images/custom-tag-is-no-longer-rendered.png?raw=true "The custom tag is no longer rendered")

	_The custom tag is no longer rendered_

---

<a name="summary"></a>
## Summary ##

In this demo you have walked through the use and creation of ASP.NET Core Tag Helpers and seen how IntelliSense provides support for them.

---
