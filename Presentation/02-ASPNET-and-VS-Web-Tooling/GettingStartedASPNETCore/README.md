<a name="title"></a>
# Getting started with ASP.NET Core #

---
<a name="Overview"></a>
## Overview ##

This demo demonstrates how to create a simple ASP.NET Core project using Visual Studio 2015.

ASP.NET Core is an open source web framework for building modern web applications that can be developed and run on Windows, Linux and Mac. It includes the MVC 6 framework, which now combines the features of MVC and Web API into a single web programming framework.


<a id="goals"></a>
### Goals ###
In this demo, you will see how to:

1. Create and run a simple website using ASP.NET Core.

1. Take advantage of Visual Studio's support for NPM and Bower.

<a name="technologies"></a>
### Key Technologies ###

- [ASP.NET Core][1]
- [ASP.NET Web API][2]
- [Visual Studio 2015][3]

[1]: http://docs.asp.net
[2]: http://www.asp.net/web-api
[3]: https://www.visualstudio.com/

<a name="Setup"></a>
### Setup and Configuration ###
Follow these steps to set up your environment for the demo.

1. Install [Visual Studio 2015](https://www.visualstudio.com/).
1. Open Visual Studio 2015.


> **Note:** Inside the source code you will find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the demo. You can use this solution as guidance if you need additional help as you work through this demo.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Creating a new web site with Visual Studio 2015](#segment1).

<a name="segment1"></a>
### Creating a new web site with Visual Studio 2015###

1. Go to **File | New | Project**.

1. In the **Templates | Visual C# | Web** tab, select the **ASP.NET Web Application** project. Name it **MyWebApplication**.

	![Creating a new Web Application](images/create-new-web-application.png?raw=true "Creating a new Web Application")

	_Creating a new ASP.NET Web Application_

1. From the **ASP.NET 5 Templates** list, select the **Web Application** template.

	![Selecting the Web Application template](images/selecting-web-site-template.png?raw=true "Selecting the Web Application template")

	_Selecting the ASP.NET 5 Web Application template_

1. In the **Solution Explorer**, show the dependencies in the **project.json** file.

	>	**Speaking Point:** In ASP.NET Core, Visual Studio uses the **project.json** file for reference and package dependencies, version definitions, framework configurations, compile options, build events, package creation metadata, and run commands, as well as other details. The advantage of this is that the project can be edited and run in Linux and Mac machines that do not have Visual Studio.

	![Showing the project.json file](images/project-json-file.png?raw=true "Showing the project.json")

	_Showing the project.json file_

1. Show the **package.json** and **bower.json** files.

	>	**Speaking Point:** Both NPM and Bower are now integrated in Visual Studio, as well as the Grunt and Gulp task runners. The Solution Explorer for ASP.NET Core Web Applications has a Dependencies node showing Bower and NPM dependencies. The Bower dependencies are from **bower.json** in the project folder. The NPM dependencies are from **package.json** in the project folder.

	![Showing integrated NPM and Bower](images/Showing-NPM-and-Bower-integrated.png?raw=true "Showing NPM and Bower integrated")

	_Showing integrated NPM and Bower_

1. In the **Dependencies** node, note that it is possible to uninstall or update a package through the context menu. This will automatically remove or update the package from the corresponding JSON file.

	![Showing the Dependencies context menu](images/dependencies-context-command.png?raw=true "Showing Dependencies context command")

	_Showing the Dependencies context menu_

1. Click **Manage Bower Packages...** in the Bower dependencies context menu in order to show the Bower Package Manager UI.

	![Showing the Bower package manager UI](images/showing-bower-package-manager-ui.png?raw=true "Showing the Bower package manager UI")

	_Showing the Bower package manager UI_

1. Show the **ConfigureServices** method in the **Startup.cs** class.

	>	**Speaking Point:** ASP.NET Core supports Dependency Injection natively, and as such this method is adding services to the DI container.

	![Showing ConfigureServices method](images/configureservices-method.png?raw=true "Showing ConfigureServices method")

	_Showing the ConfigureServices method_

1. Show the **Configure** method in **Startup.cs** class.

	>	**Speaking Point:** ASP.NET Core assumes that no frameworks are being used unless you explicitly tell it that they are, and that is why the **Configure** method exists. You use this method to tell ASP.NET what frameworks you would like to use for this app. This enables you to have full control over the HTTP pipeline.

	![Showing Configure method](images/configure-method.png?raw=true "Showing Configure method")

	_Showing the Configure method_

1. Show the **HomeController.cs** file in the **Controllers** folder.

	>	**Speaking Point:** ASP.NET Core supports regular controllers (inheriting from the **Controller** base type) and POCO controllers.

	![Showing the HomeController](images/homecontroller.png?raw=true "Showing the HomeController")

	_Showing the HomeController_

1. Show the Home view **Index.cshtml** in the **Views\Home** folder.

	![Showing the Home View](images/homeview.png?raw=true "Showing the Home View")

	_Showing the Home view_

1. Press **F5** to build and run the solution.

	![Running the web site](images/running-the-web-site.png?raw=true "Running the web site")

	_Running the web site_

---

<a name="summary"></a>
## Summary ##

By completing this demo, you have walked through Visual Studio 2015 and ASP.NET Core. You have seen the overall structure of the solution and the use of the **project.json**, **bower.json** and **package.json** files to manage the project dependencies. You have also seen how ASP.NET Core added support for native dependency injection.

---
