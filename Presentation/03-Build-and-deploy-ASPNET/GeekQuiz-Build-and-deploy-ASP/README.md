<a name="title"></a>
# Building and Deploying an ASP.NET Application #

---
<a name="Overview"></a>
## Overview ##

In this demo you will create a new ASP.NET MVC application using the Web Application ASP.NET template, explain how routing works in MVC and show the default HomeController and Views. Then you will walk through the process of creating part of the GeekQuiz object model (TriviaQuestion and TriviaOption) and leverage MVC scaffolding to create the controllers and views. Finally, you'll deploy the site to a new Microsoft Azure Web App created from within Visual Studio using the new tooling.

<a id="goals"></a>
### Goals ###
In this demo, you will see how to:

1. Create a new MVC application using the ASP.NET tooling
1. Create GeekQuiz object model
1. Use MVC Scaffolding to create controllers and views for your model
1. Create a new Web App in Microsoft Azure and deploy

<a name="technologies"></a>
### Key Technologies ###

- [Visual Studio 2015][1]
- [ASP.NET MVC][2]
- [Microsoft Azure][3]

[1]: https://www.visualstudio.com/
[2]: http://www.asp.net/mvc
[3]: http://azure.microsoft.com/

<a name="Setup"></a>
### Setup and Configuration ###
In order to execute this demo you need to set up your environment.

1. Azure SDK for Visual Studio 2015 from [here](http://azure.microsoft.com/en-us/downloads/).

1. Azure Subscription.

1. Visual Studio 2015 running.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Creating the project](#Segment1).
1. [Creating the Controllers using Scaffolding](#Segment2)
1. [Running the site locally](#Segment3)
1. [Deploying to Microsoft Azure Web Apps](#Segment4).

<a name="Segment1"></a>
### Creating the project ###

1. Open the **File / New / Project** dialog and show the options in the **Visual C# / Web** section.

	![Creating a new ASP.NET Web application](images/creating-a-new-asp-net-web-app.png?raw=true "Creating a new ASP.NET Web application")

	_Creating a new ASP.NET Web application_

1. Name the application _GeekQuiz_ and click **OK**.

	> 	**Note:** Make sure that the **Add to source control** checkbox is not selected.

1. Select Web Application project.

	![New ASP.NET template options for other project types](images/new-aspnet-template-options-for-other-project-types.png?raw=true "New ASP.NET template options for other project types")

	_New ASP.NET templates_

	> 	**Speaking Point:**
	>
	Explain the templates in the new ASP.NET Project dialog.

1. Click **OK** to create the project.

	> 	**Speaking Point:**
	>
	As the project is loading, talk about changes to the project template, including the new application anatomy, services, prebuilt middlewares and client-side development.

1. Explore the generated solution in the **Solution Explorer**.

	![Exploring the solution](images/exploring-the-solution.png?raw=true "Exploring the solution")

	_Exploring the solution_

1. Open the **Controllers/HomeController.cs** file and show the generated code.

	![Exploring the controllers](images/exploring-the-controllers.png?raw=true "Exploring the controllers")

	_Exploring the controllers_

1. Expand to the **Views/Home** folder and show the generated files.

	![Exploring the views](images/exploring-the-views.png?raw=true "Exploring the views")

	_Exploring the views_

1. Open the **Index.cshtml** file located in the **Views/Home** folder.

1. Open the **Startup.cs** file, go to the Configure method and explain the [Middleware](https://docs.asp.net/en/latest/fundamentals/middleware.html) concept and talk about the built-in routing middleware.

	> 	**Speaking Point:**
	>
	Note that when accessing to the url ending with /home/index you will be calling the home controller and the index action of that controller. Additionally, the index action is mapped to the cshtml file with the same name inside the home folder.

1. Create the GeekQuiz model classes. To do that, right-click the **Model** folder and expand the **Add** menu and select **Class**.

	![Creating a new model class](images/creating-a-new-model-class.png?raw=true "Creating a new model class")

	_Creating a new model class_

1. Name the file _TriviaQuestion.cs_ and click **Add**.

	![Creating the TriaviaQuestion class](images/creating-the-trivia-question-class.png?raw=true "Creating the TriaviaQuestion class")

	_Creating the TriaviaQuestion class_

1. Add the following code to the **TriviaQuestion** class.

	<!-- mark:3-8 -->
	````C#
    public class TriviaQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TriviaOption> Options { get; set; }
    }
````

1. Add the following using statement to the **TriviaQuestion.cs** file.

	````C#
	using System.ComponentModel.DataAnnotations;
````

	![Adding the missing using statement](images/adding-the-missing-using-statement.png?raw=true "Adding the missing using statement")

	_Adding the missing using statement_

1. Repeat steps 10 and 11 to add a new class named _TriviaOption_.

1. Add the following code to the **TriviaOption** class.

	<!-- mark:3-14 -->
	````C#
    public class TriviaOption
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TriviaQuestion")]
        public int QuestionId { get; set; }

        public virtual TriviaQuestion TriviaQuestion { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsCorrect { get; set; }
    }
````

1. Include all the missing using statements.

1. Build the solution.

<a name="Segment2"></a>
### Creating the Controllers using Scaffolding ###

1. Create the controller to manage the model's CRUD operations. To do that, right-click the **Controllers** folder and expand the **Add** menu and select **Controller...**

	![Creating a new Controller](images/creating-a-new-controller.png?raw=true "Creating a new Controller")

	_Creating a new Controller_

	> 	**Speaking Point:**
	>
	Let's create the controllers and views using scaffolding for each model class.

1. Select the **MVC 6 Controller with views, using Entity Framework** option in the **Add Scaffold** dialog and click **Add**.

	![Selecting the MVC 6 Controller with views and Entity Framework](images/selecting-mvc6-controller-with-views.png?raw=true "Selecting the MVC 6 Controller with views and Entity Framework")

	_Selecting the MVC 6 Controller with views and Entity Framework_

1. Select **TriviaQuestion** from the **Model class** list.

	![Selecting the TriviaQuestion model](images/selecting-the-triviaquestion-model.png?raw=true "Selecting the TriviaQuestion model")

	_Selecting the TriviaQuestion model_

1. Create a new data context named **TriviaContext**.

	![Creating the new TriviaContext](images/creating-the-new-triviacontext.png?raw=true "Creating the new TriviaContext")

	_Creating the new TriviaContext_

1. Check the **Use async controller actions** checkbox.

	![Checking the use async controller actions checkbox](images/checking-the-async-option.png?raw=true "Checking the use async controller actions checkbox")

	_Checking the use async controller actions checkbox_

1. Change the name of the controller to **QuestionController**.

	![Changing the controller name](images/changing-the-controller-name.png?raw=true "Changing the controller name")

	_Changing the controller name_

1. Finally, click **Add** to create the views and the controller with the default actions.

	![Creating the QuestionController](images/creating-the-questioncontroller.png?raw=true "Creating the QuestionController")

	_Creating the QuestionController_

1. Expand to the **Controller** folder and show the **QuestionController.cs** file, which was just created.

1. Open the **QuestionController.cs** file to show the generated content.

	![Showing the QuestionController](images/showing-the-questioncontroller.png?raw=true "Showing the QuestionController")

	_Showing the QuestionController_

1. Expand the **Views** folder and show the new views under the **Question** folder.

	![Showing the Question Views](images/showing-the-question-views.png?raw=true "Showing the Question Views")

	_Showing the Question Views_

1. Build the solution. Then, repeat steps 1 through 7 to create the **OptionController** for the **TriviaOption** class using the already existing **TriviaContext**.

<a name="Segment3"></a>
### Running the site locally ###

1. Press **F5** to run the web site.

1. Navigate to **/question**.

	![Navigating to question](images/navigating-to-question.png?raw=true "Navigating to question")

	_Navigating to question_

1. Add a new question.

	![Adding a new question](images/adding-a-new-question.png?raw=true "Adding a new question")

	_Adding a new question_

1. Close the browser to stop the solution.

<a name="Segment4"></a>
### Deploying to Microsoft Azure Web Apps ###

1. Right-click the **GeekQuiz** project and select **Publish...**

	![Publishing the Website](images/publishing-the-site.png?raw=true "Publishing the Website")

	_Publishing the Website_

1. In the **Publish Web** dialog, click **Microsoft Azure App Service**.

	![Selecting Microsoft Azure App Service](images/selecting-azure-app-service.png?raw=true "Microsoft Azure App Service")

	_Microsoft Azure App Service_

1. Click **Add an account...**. to sign in to Visual Studio with your Azure account.

	![Adding an account](images/adding-an-account.png?raw=true "Adding an account")

	_Adding an account_

1. Then, click **New...** to open the _Create App Service_ dialog box.

	![Creating a new App Service](images/create-new-web-app.png?raw=true "Creating a new App Service")

	_Creating a new App Service_

1. The _Create App Service_ dialog box will appear. Fill the Web App name field, the Resource Group and the App Service plan. Then, click **Services** to add the SQL Database.

	![Creating Web App on Microsoft Azure dialog](images/create-app-service-dialog-box.png?raw=true "Creating Web App on Microsoft Azure dialog")

	_Creating Web App on Microsoft Azure dialog_

	> 	**Speaking Point:**
	>
	You can create a new Web App without a database, or a new Web App with a new database on an existing database server, or a new Web App with a new database on a new database server. Fill in all the required information and voila... your new Microsoft Azure Web App is ready and you can deploy your website project there.

1. In the **Services** tab, click the add buton next to **SQL Database** in **Resource Type** list.

	![Adding a new SQL Database](images/adding-a-new-sql-database.png?raw=true "Adding a new SQL Database")

	_Adding a new SQL Database_

1. In the **Configure SQL Database** dialog box, create a new SQL Server by clicking the **New...** button.

	![Creating a new SQL Server](images/creating-a-new-sql-server.png?raw=true "Creating a new SQL Server")

	_Creating a new SQL Server_

1. In the **Configure SQL Server** dialog box, fill the server name, the administrator username and password and then click **OK**.

	![Configuring the SQL Server](images/configuring-the-sql-server.png?raw=true "Configuring the SQL Server")

	_Configuring the SQL Server_

1. Back in the **Configure SQL Database** dialog box, click **OK**.

	![Configuring the SQL Database](images/configuring-the-sql-database.png?raw=true "Configuring the SQL Database")

	_Configuring the SQL Database_

1. In the **Create App Service** dialog box, click **Create** and wait until the Web App is created.

	![Creating the app Service](images/creating-the-app-service.png?raw=true "Creating the app Service")

	_Creating the app Service_

1. Back in the **Publish Web** dialog, click **Next >**.

	![Reviewing the connection settings to deploy](images/reviewing-the-connection-settings-to-deploy.png?raw=true "Reviewing the connection settings to deploy")

	_Reviewing the connection settings to deploy_

1. In the settings tab, show that you can select to target differents DNX versions.

	![Showing the different DNX versions](images/showing-the-dnx-versions.png?raw=true "Showing the different DNX versions")

	_Showing the different DNX versions_

1. Finally, click **Publish** to publish the site.

	![Publishing the site to the new Microsoft Azure Web Appp](images/publishing-the-site-to-azure.png?raw=true "Publishing the site to the new Microsoft Azure Web Appp")

	_Publishing the site to the new Microsoft Azure Web Appp_

---

<a name="summary"></a>
## Summary ##

By completing this demo you should have:

* Created a new MVC application using the Web Application ASP.NET template
* Learned how MVC routing, views and controllers work
* Created GeekQuiz object model (TriviaQuestion and TriviaOption)
* Scaffolded the views and controllers for your model
* Created a new Web App in Azure and deployed to it from within Visual Studio

---
