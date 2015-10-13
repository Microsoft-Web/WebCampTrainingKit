<a name="title" />
# One ASP.NET / Hybrid Site #

---
<a name="Overview" />
## Overview ##

In this demo you will walk through the process of creating a new site using the new One ASP.NET tooling in Visual Sudio. You will start with a Web Forms application, create a simple model "Person" and use the new tooling to scaffold an MVC and a Web Api controller for it.

<a id="goals" />
### Goals ###
In this demo, you will see how to:

1. Create a new site using the new One ASP.NET tooling
1. Create a simple model "Person"
1. Scaffold an MVC controller for Person
1. Scaffold a Web API controller for Person

<a name="technologies" />
### Key Technologies ###

- [Visual Studio 2013][1]
- [ASP.NET][2]

[1]: http://www.visualstudio.com/
[2]: http://www.asp.net

<a name="Setup" />
### Setup and Configuration ###
In order to execute this demo you need to set up your environment.

1. Open Visual Studio 2013.

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Creating a new site](#segment1).
1. [Creating an MVC Controller using Scaffolding](#segment2).
1. [Creating a Web API using Scaffolding](#segment3).
1. [Running the site](#segment4).

<a name="segment1" />
### Creating a new site ###

1. Open the **File / New Project** dialog and show the options in the **Visual C# / Web** section.

1. Name the application _MyHybridSite_ and click **OK**.

	![Creating a new ASP.NET Web Application project](images/creating-a-new-project.png?raw=true "Creating a new ASP.NET Web Application project")

	_Creating a new ASP.NET Web Application project_

1. Select the **Web Forms** template and check the **MVC** and **Web API** options.

1. Click **OK** to create the project.

	![Selecting the Web Forms template](images/selecting-web-forms-template.png?raw=true "Selecting the Web Forms template")

	_Creating a new project with the WebForms template, including Web API and MVC libraries._


1. Explore the generated solution in the **Solution Explorer**.

	![Exploring the generated solution](images/exploring-the-generated-solution.png?raw=true "Exploring the generated solution")

	_Exploring the generated solution_

1. Open the **Default.aspx** file and show the generated code.

1. Press **F5** to run the web site.

1. Navigate to **/default.aspx**.

	![Navigating to the default webform](images/navigating-to-default-aspx.png?raw=true "Navigating to the default webform")

	_Navigating to the default webform_

	> **Note:** Even if we are on that page, specifying .aspx in the URL emphasizes the fact that this is WebForms.

1. Close the browser.

1. Create a new model class named _Person_. To do that, right-click the **Models** folder, expand the **Add** menu and select **Class...**.

	![Adding a new model class](images/adding-a-new-class.png?raw=true "Adding a new model class")

	_Adding a new model class_

1. Name the file _Person.cs_ and click **Add**.

	![Creating the Person model class](images/creating-the-person-model-class.png?raw=true "Creating the Person model class")

	_Creating the Person model class_

1. Add the highlighted code in the following code snippet to the **Person** class.

	<!-- mark:3-7 -->
	````C#
	public class Person
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int Age { get; set; }
	}
````

1. Build the solution.

<a name="segment2" />
### Creating an MVC Controller using Scaffolding ###

1. Create the controller and views for the _Person_ model class using scaffolding. To do that, right-click the **Controllers** folder, expand the **Add** menu and select **New Scaffolded Item...**

	![Creating a new scaffolded Controller](images/adding-scaffolding-controller.png?raw=true "Creating a new Controller")

	_Creating a new scaffolded Controller_

1. Select the **MVC 5 Controller with views, using Entity Framework** option in the **Add Scaffold** dialog and click **Add**.

	![Selecting the MVC 5 Controller with views and Entity Framework](images/selecting-mvc5-controller.png?raw=true "Selecting the MVC 5 Controller with views and Entity Framework")

	_Selecting the MVC 5 Controller with views and Entity Framework_

1. Change the name of the controller to **MvcPersonController**.

	![Changing the controller name](images/changing-the-controller-name.png?raw=true "Changing the controller name")

	_Changing the controller name_

1. Check the **Use async controller actions** checkbox.

	![Checking the use async controller actions checkbox](images/checking-the-async-option.png?raw=true "Checking the use async controller actions checkbox")

	_Checking the use async controller actions checkbox_

1. Select **Person** from the **Model class** list.

	![Selecting the Person  model](images/selecting-the-model.png?raw=true "Selecting the Person  model")

	_Selecting the Person model_

1. Create a new data context named **PersonContext**.

	![Creating the new PersonContext](images/creating-a-new-context.png?raw=true "Creating the new PersonContext")

	_Creating the new PersonContext_

1. Finally, click **Add** to create the views and the controller with the default actions.

	![Creating the MvcPerson Controller](images/creating-the-mvcperson-controller.png?raw=true "Creating the MvcPerson Controller")

	_Creating the MvcPerson Controller_

1. In the **Solution Explorer**, expand the **Controllers** folder and show the **MvcPersonController.cs** file, which was just created.

1. Open the **MvcPersonController.cs** file to show the generated code.

1. Expand the **Views** folder and show the new views under the **MvcPerson** folder.

1. Build the solution.

<a name="segment3" />
### Creating a Web API using Scaffolding ###

1. Create the Web API controller for the _Person_ Model class using scaffolding. To do that, right-click the **Controllers** folder, expand the **Add** menu and select **New Scaffolded Item...**

	![Creating a new scaffolded Controller](images/adding-scaffolding-controller.png?raw=true "Creating a new Controller")

	_Creating a new scaffolded Controller_

1. Select the **Web API 2 Controller with actions, using Entity Framework** option in the **Add Scaffold** dialog and click **Add**.

	![Selecting the Web API 2 Controller with actions, using Entity Framework](images/creating-a-new-webapi.png?raw=true "Selecting the Web API 2 Controller with actions, using Entity Framework")

	_Selecting the Web API 2 Controller with actions, using Entity Framework_

1. Change the name of the Web API to **ApiPersonController**.

1. Select **Person** from the **Model class** list.

	![Selecting the Person  model](images/selecting-the-person-model-for-webapi.png?raw=true "Selecting the Person model")

	_Selecting the Person model_

1. If not selected, select the **Use async controller actions** option.

1. Finally, click **Add** to create the API controller with the default actions.

	![Creating the ApiPerson Web API](images/creating-the-person-webapi.png?raw=true "Creating the ApiPerson Web API")

	_Creating the ApiPerson Web API_

1. In **Solution Explorer** expand the **Controller** folder and show the **ApiPersonController.cs** file, which was just created.

1. Open the **ApiPersonController.cs** file to show the generated code.

<a name="segment4" />
### Running the site ###

1. Press **F5** to run the web site.

1. Navigate to **/MvcPerson** to show the scaffolded view.

1. Start creting a new person by clicking **Create New**.

	![Navigating to the scaffolded MVC views](images/running-mvc-index.png?raw=true "Navigating to the scaffolded MVC views")

	_Navigating to the scaffolded MVC views_

1. Provide values for the fields and click **Create**.

	![Creating a new person](images/running-mvc-creating.png?raw=true "Creating a new person")

	_Creating a new person_

1. Show the new element in the list.

	![Showing the new element in the index view](images/running-mvc-listing.png?raw=true "Showing the new element in the index view")

	_Showing the new element in the index view_

1. Click **Details** and show the person's details.

	![Showing the new element details](images/running-mvc-details.png?raw=true "Showing the new element details")

	_Showing the new element details_

1. Go back to the index page by clicking **Back  to List**.

1. Finally, click on **Delete** to delete the person.

	![Deleting the element](images/running-mvc-deleting.png?raw=true "Deleting the element")

	_Deleting the element_

---

<a name="summary" />
## Summary ##

By completing this demo you should have:

 * Created a new Web Forms site using the new One ASP.NET template.
 * Created a simple model "Person"
 * Scaffolded a new MVC controller for Person
 * Scaffolded a new Web API controller for Person

---
