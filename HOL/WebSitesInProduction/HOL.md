<a name="HOLTop" />
# Web Sites in Production #

---

<a name="Overview" />
## Overview ##

Windows Azure offers secure and flexible development, deployment and scaling options for any size web application. Leverage your existing tools to create and deploy applications without the hassle of managing infrastructure.

Provision a production web application yourself in minutes by easily deploying content created using your favorite development tool. You can deploy an existing site directly from source control with support for **Git**, **GitHub**, **Bitbucket**, **CodePlex**, **TFS**, and even **DropBox**. Deploy directly from your favorite IDE or from scripts using **PowerShell** in Windows or **CLI** tools running on any OS. Once deployed, keep your sites constantly up-to-date with support for continuous deployment.

Windows Azure provides scalable, durable cloud storage, backup, and recovery solutions for any data, big or small. When deploying applications to a production environment, storage services such as Tables, Blobs and SQL Databases, help you scale your application in the cloud. 

With SQL Databases, it is important to keep your productive database up-to-date when deploying new versions of your application. Thanks to **Entity Framework Migrations**, the development and deployment of your data model has been simplified to update your environments in minutes.

This hands-on lab will show you the different topics you could encounter when deploying you Web Site to production environments in Windows Azure.

<a name="Objectives" />
### Objectives ###
In this hands-on lab, you will learn how to:

- Enable Entity Framework Migrations with an existing model
- Update the object model and database accordingly using Entity Framework Migrations
- Deploy to Windows Azure Website using Git
- Rollback to a previous deployment using the Windows Azure Management portal
- Use Windows Azure Storage to scale a website 
- Configure auto-scaling for a website using the Windows Azure Management Portal
- Create and configure a load test project in Visual Studio

<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this hands-on lab:

- [Visual Studio Express 2013 for Web][1] or greater
- [Windows Azure Tools for Microsoft Visual Studio 2.2][2] or later
- [GIT Version Control System][3]
- A Windows Azure subscription
	- Sign up for a [Free Trial](http://aka.ms/watk-freetrial)
	- If you are a Visual Studio Professional, Test Professional, Premium or Ultimate with MSDN or MSDN Platforms subscriber, activate your [MSDN benefit](http://aka.ms/watk-msdn) now to start developing and testing on Windows Azure
	- [BizSpark](http://aka.ms/watk-bizspark) members automatically receive the Windows Azure benefit through their Visual Studio Ultimate with MSDN subscriptions
	- Members of the [Microsoft Partner Network](http://aka.ms/watk-mpn) Cloud Essentials program receive monthly Windows Azure credits at no charge

[1]: http://www.microsoft.com/visualstudio/
[2]: http://www.microsoft.com/windowsazure/sdk/
[3]: http://git-scm.com/download

<a name="Setup" />
### Setup ###
In order to run the exercises in this hands-on lab, you will need to set up your environment first.

1. Open Windows Explorer and browse to the lab's **Source** folder.
1. Right-click on **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this lab.
1. If the User Account Control dialog is shown, confirm the action to proceed.

> **Note:** Make sure you have checked all the dependencies for this lab before running the setup.

<a name="CodeSnippets" />
### Using the Code Snippets ###

Throughout the lab document, you will be instructed to insert code blocks. For your convenience, most of this code is provided as Visual Studio Code Snippets, which you can access from within Visual Studio 2013 to avoid having to add it manually. 

>**Note**: Each exercise is accompanied by a starting solution located in the **Begin** folder of the exercise that allows you to follow each exercise independently of the others. Please be aware that the code snippets that are added during an exercise are missing from these starting solutions and may not work until you have completed the exercise. Inside the source code for an exercise, you will also find an **End** folder containing a Visual Studio solution with the code that results from completing the steps in the corresponding exercise. You can use these solutions as guidance if you need additional help as you work through this hands-on lab.

---

<a name="Exercises" />
## Exercises ##
This hands-on lab includes the following exercises:

1. [Using Entity Framework Migrations](#Exercise1)
1. [Deploying a Web Site to Staging](#Exercise2)
1. [Performing Deployment Rollback in Production](#Exercise3)
1. [Scaling Using Windows Azure Storage](#Exercise4)
1. [Using Autoscale for Web Sites](#Exercise5) (Optional for Visual Studio 2013 Ultimate edition)

Estimated time to complete this lab: **75 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this lab describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1" />
### Exercise 1: Using Entity Framework Migrations ###

When you are developing an application, your data model might change over time. These changes could affect the existing model in your database (if you are creating a new version) and it is important to keep your database up-to-date to prevent errors. 

To simplify the tracking of these changes in your model, **Entity Framework Code First Migrations** automatically detect changes comparing your model with the database schema and generates specific code to update your database, creating new _versions_ of your database. 

This exercise shows you how to enable **Migrations** for your application and how you can easily detect and generate changes to update your databases.

<a name="Ex1Task1" />
#### Task 1 – Enabling Migrations ####

In this task, you will go through the steps of enabling **Entity Framework Code First Migrations** to the **Geek Quiz** database, changing the model and understanding how those changes are reflected in the database. 

1. Open Visual Studio and open the **GeekQuiz.sln** solution file from **Source\Ex1-UsingEntityFrameworkMigrations\Begin**.

1. Build the solution in order to download and install the **NuGet** package dependencies. To do this, right-click the solution and click **Build Solution** or press **Ctrl + Shift + B**.

1. From the **Tools** menu in Visual Studio, select **Library Package Manager**, and then click **Package Manager Console**.

1. In the **Package Manager Console**, enter the following command and then press **Enter**. An initial migration based on the existing model will be created.
	
	````PowerShell
	Enable-Migrations -ContextTypeName GeekQuiz.Models.TriviaContext 
	````
	
	![Enabling Migrations](Images/enabling-migrations.png?raw=true "Enabling Migrations")
	
	_Enabling Migrations_
	
	>**Note:** This command adds a **Migrations** folder to Geek Quiz project that contains a file called **Configuration.cs**. The **Configuration** class allows you to configure how Migrations behaves for your context. 

1. With Migrations enabled, you need to update the **Configuration** class to populate the database with the initial data that **Geek Quiz** requires. Under **Migrations**, replace the **Configuration.cs** file with the one located in the **Source\Assets** folder of this lab.

	> **Note:** Since **Migrations** will call the **Seed** method with every database update, you need to be sure that records are not duplicated in the database. The **AddOrUpdate** method will help to prevent duplicate data.
	
1. To add an initial migration, enter the following command and then press **Enter**.

	> **Note:** Make sure that there is no database named "GeekQuizProd" in your LocalDB instance.

	````PowerShell
	Add-Migration InitialSchema
	````
	
	![Adding base schema migration](Images/adding-base-schema-migration.png?raw=true "Adding base schema migration")
	
	_Adding base schema migration_
	
	>**Note:** **Add-Migration** will scaffold the next migration based on changes you have made to your model since the last migration was created. In this case, as it is the first migration of the project, it will add the scripts to create all the tables defined in the **TriviaContext** class.	
	
1. Execute the migration to update the database by running the following command. For this command you will specify the **Verbose** flag to view the SQL statements being applied to the target database.

	````PowerShell
	Update-Database -Verbose
	````
	
	![Creating initial database](Images/creating-initial-database.png?raw=true "Creating initial database")
	
	_Creating initial database_
	
	>**Note:** **Update-Database** will apply any pending migrations to the database. In this case, it will create the database using the connection string defined in your web.config file.
	
1. Go to **View** menu and open **SQL Server Object Explorer**.

	![Open in SQL Server Object Explorer](Images/open-in-sql-server-object-explorer.png?raw=true "Open in SQL Server Object Explorer")
	
	_Open in SQL Server Object Explorer_

1. In the **SQL Server Object Explorer** window, connect to your LocalDB instance by right-clicking the **SQL Server** node and selecting **Add SQL Server...** option.

	![Adding a SQL Server Instance](Images/adding-sql-server-instance.png?raw=true "Adding a SQL Server Instance")

	_Adding a SQL Server instance to SQL Server Object Explorer_
	
1. Set the **server name** to _(localdb)\v11.0_ and leave **Windows Authentication** as your authentication mode. Click **Connect** to continue.

	![Connecting to LocalDB](Images/connecting-to-localdb.png?raw=true "Connecting to LocalDB")
	
	_Connecting to LocalDB_
	
1. Open the **GeekQuizProd** database and expand the **Tables** node. As you can see, the **Update-Database** command generated all the tables defined in the **TriviaContext** class. Locate the **dbo.TriviaQuestions** table and open the columns node. In the next task, you will add a new column to this table and update the database using **Migrations**. 

	![Trivia Questions Columns](Images/trivia-questions-columns.png?raw=true "Trivia Questions Columns")

	_Trivia Questions Columns_
	
<a name="Ex1Task2" />
#### Task 2 – Updating Database Schema Using Migrations ####
	
In this task, you will use **Entity Framework Code First Migrations** to detect a change in your model and generate the necessary code to update the database. You will update the **TriviaQuestions** entity by adding a new property to it. Then you will run commands to create a new Migration to include the new column in the table.

1. In **Solution Explorer**, double-click the **TriviaQuestion.cs** file located inside the **Models** folder.

1. Add a new property named **Hint**, as shown in the following code snippet.
	
	<!-- mark:10 -->
	````C#
	public class TriviaQuestion
	{
		 public int Id { get; set; }

		 [Required]
		 public string Title { get; set; }

		 public virtual List<TriviaOption> Options { get; set; }

		 public string Hint { get; set; }
	}
	````

1. In the **Package Manager Console**, enter the following command and then press **Enter**. A new migration will be created reflecting the change in our model.

	<!-- mark:1 -->
	````PowerShell
	Add-Migration QuestionHint
	````
	
	![Add-Migration](Images/add-migration.png?raw=true "Add-Migration")
	
	_Add-Migration_
	
	> **Note:** A Migration file is composed of two methods, **Up** and **Down**. 
	
	>* The **Up** method will be used to specify what changes the current version of our application need to apply to the database. 
	>* The **Down** is used to reverse the changes we have added to the **Up** method. 
	
	>When the Database Migration updates the database, it will run all migrations in the timestamp order, and only those that have not been used since the last update (The _MigrationHistory table keeps track of which migrations have been applied). The **Up** method of all migrations will be called and will make the changes we have specified to the database. If we decide to go back to a previous migration, the **Down** method will be called to redo the changes in a reverse order.

1. In the **Package Manager Console**, enter the following command and then press **Enter**.
	
	````PowerShell
	Update-Database -Verbose
	````

1. The output of the **Update-Database** command generated an **Alter Table** SQL statement to add a new column to the **TriviaQuestions** table, as shown in the image below.

	![Add column SQL statement generated](Images/add-column-sql-statement-generated.png?raw=true "Add column SQL statement generated")
	
	_Add column SQL statement generated_

1. In **SQL Server Object Explorer**, refresh the **dbo.TriviaQuestions** table and check that the new **Hint** column is displayed.

	![Showing the new Hint Column](Images/showing-the-new-hint-column.png?raw=true "Showing the new Hint Column")

	_Showing the new Hint Column_

1. Back in the **TriviaQuestion.cs** editor, add a **StringLength** constraint to the _Hint_ property, as shown in the following code snippet.

	<!-- mark:10 -->
	````C#
	public class TriviaQuestion
	{
		 public int Id { get; set; }

		 [Required]
		 public string Title { get; set; }

		 public virtual List<TriviaOption> Options { get; set; }

		 [StringLength(150)]
		 public string Hint { get; set; }
	}
	````

1. In the **Package Manager Console**, enter the following command and then press **Enter**.
	
	````PowerShell
	Add-Migration QuestionHintLength
	````
1. In the **Package Manager Console**, enter the following command and then press **Enter**.

	````PowerShell
	Update-Database -Verbose
	````

1. The output of the **Update-Database** command generated an **Alter Table** SQL statement to update the _hint_ column type of the **TriviaQuestions** table, as shown in the image below.

	![Alter column SQL statement generated](Images/alter-column-sql-statement-generated.png?raw=true "Alter column SQL statement generated")
	
	_Alter column SQL statement generated_

1. In **SQL Server Object Explorer**, refresh the **dbo.TriviaQuestions** table and check that the **Hint** column type is **nvarchar(150)**.

	![Showing the new constraint](Images/showing-the-new-constraint.png?raw=true "Showing the new constraint")

	_Showing the new constraint_

<a name="Exercise2" />
### Exercise 2: Deploying a Web site to Staging ###

**Windows Azure Web Sites** enables you to perform staged publishing. Staged publishing creates a staging site slot for each default production site and enables you to swap these slots with no down time. This is really useful to validate changes before releasing to the public, incrementally integrate site content, and roll back if changes are not working as expected.

In this exercise, you will deploy the **Geek Quiz** application to the staging environment of your Windows Azure Web site using Git source control. To do this, you will create the Web site and provision the required components at the management portal, configure a **Git** repository and push the application source code from your local computer to the staging slot. You will also update your production database with the **Code First Migrations** you created in the previous exercise. You will then execute the application in this test environment to verify its operation. Once you are satisfied that it is working according to your expectations, you will promote the application to production.

> **Note:** To enable staged publishing, the Web site must be in **Standard mode**. Note that additional charges will be incurred if you change your Web site to Standard mode. For more information about pricing, see [Web Site Pricing Details](http://www.windowsazure.com/en-us/pricing/details/web-sites/). 

<a name="Ex2Task1" />
#### Task 1 – Creating a Windows Azure Web Site ####

In this task, you will create a **Windows Azure Web Site** from the management portal. You will also configure a **SQL Database** to persist the application data, and configure a local Git repository for source control.

1. Go to the [Windows Azure management portal](https://manage.windowsazure.com) and sign in using the Microsoft account associated with your subscription.

	![Sign in to the Windows Azure management portal](Images/sign-in-to-windows-azure-management-portal.png?raw=true)

	_Sign in to the Windows Azure management portal_

1. Click **New** in the command bar at the bottom of the page.

	![Creating a new Web Site](Images/creating-a-new-web-site.png?raw=true "Creating a new Web Site")

	_Creating a new Web Site_

1. Click **Compute**, **Web Site** and then **Custom Create**.

	![Creating a new Web Site using Custom Create](Images/creating-a-new-web-site-using-custom-create.png?raw=true "Creating a new Web Site using Custom Create")

	_Creating a new Web Site using Custom Create_

1. In the **New Web Site - Custom Create** dialog box, provide an available **URL** (e.g. _geek-quiz_), select a location in the **Region** drop-down list, and select **Create a new SQL database** in the **Database** drop-down list. Finally, select the **Publish from source control** check box and click **Next**.

	![Customizing the new Web site](Images/customizing-the-new-web-site.png?raw=true)

	_Customizing the new Web site_

1. Specify the following information for the database settings:
	- In the **Name** text box, enter a database name (e.g. _geekquiz_db_)
	- In the Server **drop-down** list, select **New SQL database server**. Alternatively, you can select an existing server.
	- In the **Database username** and **Database password** boxes, enter the administrator username and password for the SQL database server. If you select a server you have already created, you will be prompted for the password.

	![Specifying the database settings](Images/specifying-the-database-settings.png?raw=true)

	_Specifying the database settings_

1. Click **Next** to continue.

1. Select **Local Git repository** for the source control to use and click **Next**.

	> **Note:** You may be prompted for the deployment credentials (a username and password).

	![Creating the Git Repository](Images/creating-git-repository.png?raw=true)

	_Creating the Git repository_

1. Wait until the new web site is created.

	> **Note:** By default, Windows Azure provides domains at _azurewebsites.net_ but also gives you the possibility to set custom domains using the Windows Azure management portal. However, you can only manage custom domains if you are using certain Web site modes.
	
	> Windows Azure offers 3 modes for users to run their Web sites - Free, Shared, and Standard. In Free and Shared mode, all Web sites run in a multi-tenant environment and have quotas for CPU, Memory, and Network usage. You can mix and match which sites are Free (strict quotas) vs. Shared (more flexible quotas). The maximum number of free sites may vary with your plan. In Standard mode, you choose which sites run on dedicated virtual machines that correspond to the standard Azure compute resources. You can find the Web Sites Mode configuration in the **Scale** menu of your Web site.

	> ![Web Site Modes](Images/web-site-modes.png?raw=true "Web Site Modes")

	> If you are using **Shared** or **Standard** mode, you will be able to manage custom domains for your Web site by going to your Web site’s **Configure** menu and clicking **Manage Domains** under _domain names_.

	> ![Manage Domains](Images/manage-domains.png?raw=true "Manage Domains")

	> ![Manage Custom Domains](Images/manage-custom-domains.png?raw=true "Manage Custom Domains")

1. Once the Web site is created, click the link under the **URL** column to check that the new Web site is running.

	![Browsing to the new Web site](Images/browsing-to-the-new-web-site.png?raw=true)

	_Browsing to the new web site_

	![Web site running](Images/web-site-running.png?raw=true)

	_Web site running_

<a name="Ex2Task2" />
#### Task 2 – Creating the Production SQL Database ####

In this task, you will use the **Entity Framework Code First Migrations** to create the database targeting the **Windows Azure SQL Database** instance you created in the previous task.
	
1. In the Management Portal, navigate to the Web site you created in the previous task and go to its **Dashboard**.

1. In the **Dashboard** page, click **View connection strings** link under the **quick glance** section.

	![View connection strings](Images/view-connection-strings.png?raw=true "View connection strings")

	_View connection strings_

1. Copy the **connection string** value and close the dialog box.

	![Connection String in Windows Azure Management Portal](Images/connection-string-in-windows-azure-management.png?raw=true "Connection String in Windows Azure Management Portal")

	_Connection String in Windows Azure Management Portal_

1. Click **SQL Databases** to see the list of SQL databases in Windows Azure

	![SQL Database menu](Images/sql-database-menu.png?raw=true "SQL Database menu")
	
	_SQL Database menu_

1. Locate the database you created in the previous task and click on the Server.

	![SQL Database server](Images/sql-database-server.png?raw=true "SQL Database server")
	
	_SQL Database server_

1. In the **Quick Start** page of the server, click on **Configure**.

	![Configure menu](Images/configure-menu.png?raw=true "Configure menu")
	
	_Configure menu_
	
1. In the **Allowed IP addresses** section, click on **Add to the allowed IP addresses** link to enable your IP to connect to the SQL Database server.

	![Allowed IP addresses](Images/allowed-ip-addresses.png?raw=true "Allowed IP addresses")
	
	_Allowed IP addresses_

1. Click **Save** at the bottom of the page to complete the step.
	
1. Switch back to Visual Studio.

1. In the **Package Manager Console**, execute the following command replacing _[YOUR-CONNECTION-STRING]_ placeholder with the connection string you copied from Windows Azure

	````PowerShell
	Update-Database -Verbose -ConnectionString "[YOUR-CONNECTION-STRING]" -ConnectionProviderName "System.Data.SqlClient"
	````

	![Update database targeting Windows Azure SQL Database](Images/update-database-targeting-windows-azure-sql-d.png?raw=true "Update database targeting Windows Azure SQL Database")
	
	_Update database targeting Windows Azure SQL Database_

<a name="Ex2Task3" />
#### Task 3 – Deploying Geek Quiz to Staging Using Git ####

In this task, you will enable staged publishing in your Web site. Then, you will use Git to publish the Geek Quiz application directly from your local computer to the staging environment of your Web site.

1. Go back to the portal and click the name of the web site under the **Name** column to display the management pages.

	![Opening the Web site management pages](Images/opening-the-web-site-management-pages.png?raw=true)
	
	_Opening the Web site management pages_
	
1. Navigate to the **Scale** page. Under the **general** section, select **Standard** for the **Web Site Mode** configuration and click **Save** in the command bar.

	> **Note:** To run all Web sites in the current region and subscription in **Standard** mode, leave the **Select All** check box selected in the **Choose Sites** configuration. Otherwise, clear the **Select All** check box.

	![Upgrading the Web Site to Standard mode](Images/upgrading-the-web-site-to-standard-mode.png?raw=true "Upgrading the Web Site to Standard mode")

	_Upgrading the Web site to Standard mode_

1. Click **Yes** to confirm the changes.

	![Confirming the change to Standard mode](Images/confirming-change-to-standard-mode.png?raw=true "Continuing with the changing of the Web Site mode")

	_Confirming the change to Standard mode_

1. Go to the **Dashboard** page and click **Enable staged publishing** under the **quick glance** section.

	![Enabling staged publishing](Images/enabling-staged-publishing.png?raw=true "Enabling staged publishing")

	_Enabling staged publishing_

1. Click **Yes** to enable staged publishing.

	![Confirming staged publishing](Images/clicking-yes-to-enable-staged-publishing.png?raw=true "Clicking Yes to enable staged publishing")

	_Confirming staged publishing_

1. In the list of Web sites, expand the mark to the left of your Web site name to display the staging site slot. It has the name of your Web site followed by _**(staging)**_. Click the staging site to go to the management page.

	![Navigating to the staging Web Site](Images/navigating-to-the-staging-web-site.png?raw=true "Navigating to the staging Web Site")

	_Navigating to the staging Web Site_

1. Notice that he management page looks like any other Web site's management page. Navigate to the **Deployments** page and copy the **Git URL** value. You will use it later in this exercise.

	![Copying the Git URL value](Images/coping-the-git-url-value.png?raw=true)

	_Copying the Git URL value_

1. Open a new **Git Bash** console and execute the following commands. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution, located in the **Source\Ex1-DeployingWebSiteToStaging\Begin** folder of this lab. 
	
	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git init
	git config --global user.email "{username@example.com}"
	git config --global user.name "{your-user-name}"
	git add .
	git commit -m "Initial commit"
	````

	![Git initialization and first commit](Images/git-initialization-and-first-commit.png?raw=true)

	_Git initialization and first commit_

1. Run the following command to push your Web site to the remote **Git** repository. Replace the placeholder with the URL you obtained from the management portal. You will be prompted for your deployment password.

	````GitBash
	git remote add azure [GIT-CLONE-URL]
	git push azure master
	````

	![Pushing to Windows Azure](Images/pushing-to-windows-azure.png?raw=true)

	_Pushing to Windows Azure_

	> **Note:** When you deploy content to the FTP host or GIT repository of a Windows Azure Web site you must authenticate using the **deployment credentials** that you created from the Web site’s **Quick Start** or **Dashboard** management pages. If you do not know your deployment credentials you can easily reset them using the management portal. Open the Web site **Dashboard** page and click the **Reset your deployment credentials** link. Provide a new password and click **OK**. Deployment credentials are valid for use with all Windows Azure Web sites associated with your subscription. 

1. In order to verify the Web site was successfully pushed to Windows Azure, go back to the management portal and click **Web Sites**.

1. Locate your Web site and expand the entry to display the staging site slot. Click its **Name** to go to the management page.

1. Click **Deployments** to see the **deployment history**. Verify that there is an **Active Deployment** with your _"Initial Commit"_.

	![Active deployment](Images/active-deployment.png?raw=true)

	_Active deployment_

1. Finally, click **Browse** in the command bar to go to the Web site.

	![Browse web site](Images/browse-web-site.png?raw=true)

	_Browse Web site_

1. If the application is successfully deployed, you will see the Geek Quiz login page.

	> **Note:** The address URL of the deployed application contains the name of your Web site followed by _-staging_.

	![Application running in the staging environment](Images/application-running-in-staging.png?raw=true)

	_Application running in the staging environment_

1. If you wish to explore the application, click **Register** to register a new user. Complete the account details by entering a user name, email address and password. Next, the application shows the first question of the quiz. Answer a few questions to make sure it is working as expected.

	![Application ready to be used](Images/application-ready-to-be-used.png?raw=true)

	_Application ready to be used_

<a name="Ex2Task4" />
#### Task 4 – Promoting the Web Site to Production ####

Now that you have verified that the Web site is working correctly in the staging environment, you are ready to promote it to production. In this task, you will swap the staging site slot with the production site slot.

1. Go back to the management portal and select the staging site slot in the Web sites list. Click **Swap** in the command bar.

	![Swap to production](Images/swap-to-production.png?raw=true)

	_Swap to production_

1. Click **Yes** in the confirmation dialog box to proceed with the swap operation. Azure will immediately swap the content of the production site with the content of the staging site.

	> **Note:** Some settings from the staged version will automatically be copied to the production version (e.g. connection string overrides, handler mappings, etc.) but other settings will not change (e.g. DNS endpoints, SSL bindings, etc.).

	![Confirming swap operation](Images/confirm-swap-operation.png?raw=true)

	_Confirming swap operation_
	
1. Once the swap is complete, select the production slot and click **Browse** in the command bar to open the production site. Notice the URL in the address bar.

	> **Note:** You might need to refresh your browser to clear cache. In Internet Explorer, you can do this by pressing **CTRL+R**.

	![Web site running in the production environment](Images/web-site-running-in-the-production-environmen.png?raw=true)

1. In the **GitBash** console, update the remote URL for the local Git repository to target the production slot. To do this, run the following command replacing the placeholders with your deployment username and the name of your Web site.

	> **Note:** In the following exercises, you will push changes to the production site instead of staging just for the simplicity of the lab. In a real-world scenario, it is recommended to verify the changes in the staging environment before promoting to production.

	````GitBash
	git remote set-url azure https://<your-user>@<your-web-site>.scm.azurewebsites.net:443/<your-web-site>.git
	````

<a name="Exercise3" />
### Exercise 3: Performing Deployment Rollback in Production ###

There are scenarios where you do not have a staging slot to perform hot swap between staging and production, for example, if you are working with **Web Sites** running in **Free** or **Shared** mode. In those scenarios, you should test your application in a testing environment –either locally or in a remote site– before deploying to production. However, it is possible that an issue not detected during the testing phase may arise in the production site. In this case, it is important to have a mechanism to easily switch to a previous and more stable version of the application as quickly as possible.

In **Windows Azure Web Sites**, continuous deployment from source control makes this possible thanks to the **redeploy** action available in the management portal. Windows Azure keeps track of the deployments associated with the commits pushed to the repository and provides an option to redeploy your application using any of your previous deployments, at any time.

In this exercise you will perform a change to the code in the **Geek Quiz** application that intentionally injects a _bug_. You will deploy the application to production to see the error, and then you will take advantage of the redeploy feature to go back to the previous state.

<a name="Ex3Task1" />
#### Task 1 – Updating the Geek Quiz Application ####

In this task, you will refactor a small piece of code of the **TriviaController** class to extract part of the logic that retrieves the selected quiz option from the database into a new method.

1. Switch to the Visual Studio instance with the **GeekQuiz** solution from the previous exercise.

1. In **Solution Explorer**, open the **TriviaController.cs** file inside the **Controllers** folder.

1. Locate the **StoreAsync** method and select the code highlighted in the following figure.

	![Selecting the code](Images/selecting-the-code.png?raw=true)

	_Selecting the code_

1. Right-click the selected code, expand the **Refactor** menu and select **Extract Method...**. 

	![Extracting the code as a new method](Images/extracting-the-code-as-a-new-method.png?raw=true)
	
	_Selecting Extract Method_

1. In the **Extract Method** dialog box, name the new method _MatchesOption_ and click **OK**.

	![Specifying the method name](Images/specifying-the-method-name.png?raw=true)

	_Specifying the name for the extracted method_

1. The selected code is then extracted into the **MatchesOption** method. The resulting code is shown in the following snippet.

	<!-- mark:6,11-15 -->
	````C#
	private async Task<bool> StoreAsync(TriviaAnswer answer)
	{
		this.db.TriviaAnswers.Add(answer);

		await this.db.SaveChangesAsync();
		var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o => MatchesOption(answer, o));

		return selectedOption.IsCorrect;
	}

	private static bool MatchesOption(TriviaAnswer answer, TriviaOption o)
	{
		return o.Id == answer.OptionId
				&& o.QuestionId == answer.QuestionId;
	}
	````

1. Press **CTRL + S** to save the changes.

<a name="Ex3Task2" />
#### Task 2 – Redeploying the Geek Quiz Application ####

You will now push the changes you made in the previous task to the repository, which will trigger a new deployment to the production environment. Then, you will troubleshot an issue using the **F12 development tools** provided by Internet Explorer, and then perform a rollback to the previous deployment from the Windows Azure management portal.

1. Open a new **Git Bash** console to deploy the updated application to Windows Azure Web Sites.

1. Execute the following commands to push the changes to Windows Azure. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution. You will be prompted for your deployment password.

	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git add .
	git commit -m "Refactored answer check"
	git push azure master
	````

	![Pushing refactored code to Windows Azure](Images/pushing-refactored-code-to-windows-azure.png?raw=true)

	_Pushing refactored code to Windows Azure_

1. Open Internet Explorer and navigate to your Web site (e.g. _http://\<your-web-site>\.azurewebsites.net_). Log in using the previously created credentials.

1. Press **F12** to launch the development tools, select the **Network** tab and click the **Play** button to start recording.

	![Starting network recording](Images/starting-the-network-recording.png?raw=true "Starting network recording")

	_Starting network recording_

1. Select any option of the quiz. You will see that nothing happens.

1. In the **F12** window, the entry corresponding to the POST HTTP request shows an HTTP **500** result.

	![HTTP 500 error](Images/showing-the-http-500-error.png?raw=true)

	_HTTP 500 error_

1. Select the **Console** tab. An error is logged with the details of the cause.

	![Logged error](Images/logged-error.png?raw=true)

	_Logged error_

1. Locate the details part of the error. Clearly, this error is caused by the code refactoring you committed in the previous steps.

	`Details: LINQ to Entities does not recognize the method 'Boolean MatchesOption ...`.

1. Do not close the browser.

1. In a new browser instance, navigate to the [Windows Azure management portal](http://manage.windowsazure.com) and sign in using the Microsoft account associated with your subscription.

1. Select **Web Sites** and click the Web site you created in Exercise 2.

1. Navigate to the **Deployments** page. Notice that all the commits performed are listed in the deployment history.

	![List of existing deployments](Images/list-of-existing-deployments.png?raw=true)

	_List of existing deployments_

1. Select the previous commit and click **Redeploy** on the command bar.

	![Redeploying the previous commit](Images/redeploying-previous-commit.png?raw=true)

	_Redeploying the previous commit_

1. When prompted to confirm, click **Yes**.

	![Confirming the redeployment](Images/confirming-the-redeployment.png?raw=true)

1. When the deployment completes, switch back to the browser instance with your Web site and press **CTRL + F5**.
	
1. Click any of the options. The flip animation will now take place and the result (_correct/incorrect_) will be displayed.

1. (Optional) Switch to the **Git Bash** console and execute the following commands to revert to the previous commit.

	> **Note:** These commands create a new commit that undoes all changes in the Git repository that were made in the bad commit. Windows Azure will then redeploy the application using the new commit.

	````GitBash
	git revert HEAD --no-edit
	git push azure master
	````

<a name="Exercise4" />
### Exercise 4: Scaling Using Windows Azure Storage ###

**Blobs** are the simplest way to store large amounts of unstructured text or binary data such as video, audio and images. Moving the static content of your application to Storage, helps to scale your application by serving images or documents directly to the browser.

In this exercise, you will move the static content of your application to a Blob container. Then you will configure your application to add an **ASP.NET URL rewrite rule** in the **Web.config** to redirect your content to the Blob container.

<a name="Ex4Task1" />
#### Task 1 – Creating a Windows Azure Storage Account ####

In this task you will learn how to create a new storage account using the management portal.

1. Navigate to the [Windows Azure management portal](http://manage.windowsazure.com) and sign in using the Microsoft account associated with your subscription.

1. Select **New | Data Services | Storage | Quick Create** to start creating a new storage account. Enter a unique name for the account and select a **Region** from the list. Click **Create Storage Account** to continue.

	![Creating a new Storage Account](Images/creating-a-new-storage-account.png?raw=true "Creating a new Storage Account")

	_Creating a new storage account_

1.  In the **Storage** section, wait until the status of the new storage account changes to _Online_ in order to continue with the following step.

	![Storage Account created](Images/storage-account-created.png?raw=true "Storage Account created")

	_Storage Account created_

1. Click on the storage account name and then click the **Dashboard** link at the top of the page. The **Dashboard** page provides you with information about the status of the account and the service endpoints that can be used within your applications.

	![Displaying the Storage Account Dashboard](Images/displaying-the-storage-account-dashboard.png?raw=true "Displaying the Storage Account Dashboard")

	_Displaying the Storage Account Dashboard_
	
1. Click the **Manage Access Keys** button in the navigation bar.
	
	![Manage Access Keys button](Images/manage-access-keys-button.png?raw=true "Manage Access Keys button")
	
	_Manage Access Keys button_
	
1. In the **Manage Access Keys** dialog box, copy the **Storage Account Name** and **Primary Access Key** as you will need them in the following exercise. Then, close the dialog box.

	![Manage Access Key dialog box](Images/manage-access-key-dialog-box.png?raw=true "Manage Access Key dialog box")
	
	_Manage Access Key dialog box_

<a name="Ex4Task2" />
#### Task 2 – Uploading an Asset to Windows Azure Blob Storage ####

In this task, you will use the Server Explorer window from Visual Studio to connect to your storage account. You will then create a blob container and upload a file with the Geek Quiz logo to the container.

1. Switch to the Visual Studio instance with the **GeekQuiz** solution from the previous exercise.

1. From the menu bar, select **View** and then click **Server Explorer**.

1. In **Server Explorer**, right-click the **Windows Azure** node and select **Connect to Windows Azure...**. Sign in using the Microsoft account associated with your subscription.

	![Connect to Windows Azure](Images/connect-to-windows-azure.png?raw=true)

	_Connect to Windows Azure_

1. Expand the **Windows Azure** node, right-click **Storage** and select **Attach External Storage...**.

1. In the **Add New Storage Account** dialog box, enter the **Account name** and **Account key** you obtained in the previous task and click **OK**.

	![Add New Storage Account dialog box](Images/add-new-storage-account-dialog-box.png?raw=true)
	
	_Add New Storage Account dialog box_

1. Your storage account should appear under the **Storage** node. Expand your storage account, right-click **Blobs** and select **Create Blob Container...**. 

	![Create Blob Container](Images/create-blob-container.png?raw=true "Create Blob Container")
	
	_Create Blob Container_

1. In the **Create Blob Container** dialog box, enter a name for the blob container and click **OK**.

	![Create Blob Container dialog box](Images/create-blob-container-dialog-box.png?raw=true "Create Blob Container dialog box")
	
	_Create Blob Container dialog box_
	
1. The new blob container should be added to the **Blobs** node. Change the access permissions in the container to make the container public. To do this, right-click the **images** container and select **Properties**.

	![images container properties](Images/images-container-properties.png?raw=true "images container properties")
	
	_Images container properties_
	
1. In the **Properties** window, set the **Public Read Access** to **Container**.

	![Changing public read access property](Images/changing-public-read-access-property.png?raw=true "Changing public read access property")
	
	_Changing public read access property_

1. When prompted if you are sure you want to change the public access property, click **Yes**.
	
	![Microsoft Visual Studio warning](Images/microsoft-visual-studio-warning.png?raw=true "Microsoft Visual Studio warning")
	
	_Microsoft Visual Studio warning_
	
1. In **Server Explorer**, right-click in the **images** blob container and select **View Blob Container**.

	![View Blob Container](Images/view-blob-container.png?raw=true "View Blob Container")
	
	_View Blob Container_

1. The images container should open in a new window and a legend with no entries should be shown. Click the **upload** icon to upload a file to the blob container.

	![Images container with no entries](Images/images-container-with-no-entries.png?raw=true "Images container with no entries")

	_Images container with no entries_
	
1. In the **Upload Blob** dialog box, navigate to the **Assets** folder of the lab. Select the **logo-big.png** file and click **Open**.

1. Wait until the file is uploaded. When the upload completes, the file should be listed in the images container. Right-click the file entry and select **Copy URL**.

	![Copy blob URL](Images/copy-blob-file-url.png?raw=true "Copy blob file URL")
	
	_Copy blob URL_
	
1. Open Internet Explorer and paste the URL. The following image should be shown in the browser.

	![logo-big.png image from Windows Azure Blob Storage](Images/logo-bigpng-image-from-storage.png?raw=true "logo-big.png image from storage")
	
	_logo-big.png image from Windows Azure Blob Storage_
	
<a name="Ex4Task3" />
#### Task 3 – Updating the Solution to Consume Static Content from Windows Azure Blob Storage ####

In this task, you will configure the **GeekQuiz** solution to consume the image uploaded to Windows Azure Blob Storage (instead of the image located in the Web site) by adding an ASP.NET URL rewrite rule in the **web.config** file.

1. In Visual Studio, open the **Web.config** file inside the **GeekQuiz** project and locate the **\<system.webServer>** element.

1. Add the following code to add an URL rewrite rule, updating the placeholder with your storage account name.

	(Code Snippet - _WebSitesInProduction - Ex4 - UrlRewriteRule_)
	
	<!--mark:2-9-->
	````XML
	<system.webServer>
		<rewrite>
			<rules>
				<rule name="redirect-images" stopProcessing="true">
					<match url="img/(.*)"/>
					<action type="Redirect" url="http://[YOUR-STORAGE-ACCOUNT].blob.core.windows.net/images/{R:1}"></action>
				</rule>
			</rules>
		</rewrite>
	````

	> **Note:** URL rewriting is the process of intercepting an incoming Web request and redirecting the request to a different resource. The URL rewriting rules tells the rewriting engine when a request needs to be redirected, and where should they be redirected. A rewriting rule is composed of two strings: the pattern to look for in the requested URL (usually, using regular expressions), and the string to replace the pattern with, if found. For more information, see [URL Rewriting in ASP.NET](http://msdn.microsoft.com/en-us/library/ms972974.aspx).

1. Press **CTRL + S** to save the changes.

1. Open a new **Git Bash** console to deploy the updated application to Windows Azure Web Sites.

1. Execute the following commands to push the changes to Windows Azure. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution. You will be prompted for your deployment password.

	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git add .
	git commit -m "Added URL rewrite rule in web.config file"
	git push azure master
	````
	
	![Deploying update to Windows Azure](Images/deploying-update-to-windows-azure.png?raw=true)
	
	_Deploying update to Windows Azure_

<a name="Ex4Task4" />
#### Task 4 – Verification ####

In this task you will use **Internet Explorer** to browse the **Geek Quiz** application and check that the URL rewrite rule for images works and you are redirected to the image hosted on **Windows Azure Blob Storage**.

1. Open Internet Explorer and navigate to your Web site (e.g. _http://\<your-web-site\>.azurewebsites.net_). Log in using the previously created credentials.

	![Showing the Geek Quiz website with the image](Images/showing-the-geek-quiz-website-with-the-image.png?raw=true "Showing the Geek Quiz website with the image")

	_Showing the Geek Quiz website with the image_

1. Press **F12** to launch the development tools, select the **Network** tab and start recording.

	![Starting network recording](Images/starting-the-network-recording.png?raw=true "Starting network recording")

	_Starting network recording_

1. Press **CTRL + F5** to refresh the web page.

1. Once the page has finished loading, you should see an HTTP request for the **/img/logo-big.png** URL with an HTTP **301** result (redirect) and another request for **http://[YOUR-STORAGE-ACCOUNT].blob.core.windows.net/images/logo-big.png** URL with a HTTP **200** result.

	![Verifying the URL redirect](Images/showing-the-redirect-in-dev-tools.png?raw=true "Showing the redirect in Dev Tools")

	_Verifying the URL redirect_

<a name="Exercise5" />
### Exercise 5: Using Autoscale for Web Sites ###

> **Note:** This exercise is optional, since it requires support for Web Load & Performance Testing which is only available for **Visual Studio 2013 Ultimate Edition**. For more information on specific Visual Studio 2013 features, compare versions [here](http://www.microsoft.com/visualstudio/eng/products/compare).

**Windows Azure Web Sites** provides the Autoscale feature for Web sites running in **Standard Mode**. Autoscale lets Windows Azure automatically scale the instance count of your Web site depending on the load. When Autoscale is enabled, Windows Azure checks the CPU of your Web site once every five minutes and adds instances as needed at that point in time. If the CPU usage is low, Windows Azure will remove instances once every two hours to ensure that the performance of your Web site is not degraded.

In this exercise you will go through the steps required to configure the **Autoscale** feature for the **Geek Quiz** Web site. You will verify this feature by running a Visual Studio load test to generate enough CPU load on the application to trigger an instance upgrade.

<a name="Ex5Task1" />
#### Task 1 – Configuring Autoscale Based on the CPU Metric ####

In this task you will use the Windows Azure management portal to enable the Autoscale feature for the Web site you created in Exercise 2.

1. In the [Windows Azure management portal](https://manage.windowsazure.com/), select **Web Sites** and click the Web site you created in Exercise 2.

1. Navigate to the **Scale** page. Under the **capacity** section, select **CPU** for the **Scale by Metric** configuration.

	> **Note:** When scaling by CPU, Windows Azure dynamically adjusts the number of instances that the Web site uses if the CPU usage changes.

	![Selecting to scale by CPU](Images/selecting-the-cpu-metric-for-auto-scaling.png?raw=true "Selecting the CPU metric for auto scaling")

	_Selecting to scale by CPU_

1. Change the **Target CPU** configuration to **20**-**40** percent.

	> **Note:** This range represents the average CPU usage for your Web site. Windows Azure will add or remove instances to keep your Web site in this range. The minimum and maximum number of instances used for scaling is specified in the **Instance Count** configuration. Windows Azure will never go above or beyond that limit.
	> 
	> The default **Target CPU** values are modified just for the purposes of this lab. By configuring the CPU range with small values, you are increasing the chances to trigger Autoscale when a moderate load is placed on the application.

	![Changing the target CPU to be between 20 and 40 percent](Images/changing-the-target-cpu-to-be-between-20-and.png?raw=true "Changing the target CPU to be between 20 and 40 percent")

	_Changing the Target CPU to be between 20 and 40 percent_

1. Click **Save** in the command bar to save the changes.

<a name="Ex5Task2" />
#### Task 2 – Load Testing with Visual Studio ####

Now that **Autoscale** has been configured, you will create a **Web Performance and Load Test Project** in Visual Studio to generate some CPU load on your Web site.

1. Open **Visual Studio Ultimate 2013** and select **File | New | Project...** to start a new solution.

	![Creating a new project](Images/creating-a-new-project.png?raw=true "Creating a new project")

	_Creating a new project_

1. In the **New Project** dialog box, select **Web Performance and Load Test Project** under the **Visual C# | Test** tab. Make sure **.NET Framework 4.5** is selected, name the project _WebAndLoadTestProject_, choose a **Location** and click **OK**.

	![Creating a new Web and Load Test project](Images/creating-a-new-web-and-load-test-project.png?raw=true "Creating a new Web and Load Test project")

	_Creating a new Web and Load Test project_

1. In the **WebTest1.webtest** Right-click the **WebTest1** node and click **Add Request**.

	![Adding a request to WebTest1](Images/adding-a-request-to-webtest1.png?raw=true "Adding a request to WebTest1")
	
	_Adding a request to WebTest1_

1. In the **Properties** window of the new request node, update the **Url** property to point to the URL of your Windows Azure Web site (e.g. _http://geek-quiz.azurewebsites.net/_).

	![Changing the Url property](Images/changing-the-url-property.png?raw=true "Changing the Url property")

	_Changing the Url property_

1. In the **WebTest1.webtest** window, right-click **WebTest1** and click **Add Loop...**.

	![Adding a loop to WebTest1](Images/adding-a-loop-to-webtest1.png?raw=true "Adding a loop to WebTest1")

	_Adding a loop to WebTest1_

1. In the **Add Conditional Rule and Items to Loop** dialog box, select the **For Loop** rule and modify the following properties.

	1. **Terminating value:** 1000
	1. **Context Parameter Name:** Iterator
	1. **Increment Value:** 1

	![Selecting the For Loop rule and updating the properties](Images/selecting-the-for-loop-rule-and-updating-the.png?raw=true "Selecting the For Loop rule and updating the properties")

	_Selecting the For Loop rule and updating the properties_

1. Under the **Items in loop** section, select the request you created previously to be the first and last item for the loop. Click **OK** to continue.

	![Selecting the first and last items for the loop](Images/selecting-the-first-and-last-items-for-the-lo.png?raw=true "Selecting the first and last items for the loop")

	_Selecting the first and last items for the loop_

1. In **Solution Explorer**, right-click the **WebAndLoadTestProject** project, expand the **Add** menu and select **Load Test...**.

	![Adding a Load Test to the WebAndLoadTestProject project](Images/adding-a-load-test-to-the-webandloadtestproje.png?raw=true "Adding a Load Test to the WebAndLoadTestProject project")

	_Adding a Load Test to the WebAndLoadTestProject project_

1. In the **New Load Test Wizard** dialog box, click **Next**.

	![New Load Test Wizard](Images/new-load-test-wizard.png?raw=true "New Load Test Wizard")

	_New Load Test Wizard_

1. In the **Scenario** page, select **Do not use think times** and click **Next**.

	![Selecting not to use think times](Images/selecting-not-to-use-think-times.png?raw=true "Selecting not to use think times")

	_Selecting not to use think times_

1. In the **Load Pattern** page, make sure that the **Constant Load** option is selected. Change the **User Count** setting to **250** users and click **Next**.

	![Changing the user count to 250](Images/changing-the-user-count-to-250.png?raw=true "Changing the user count to 250")

	_Changing the user count to 250_

1. In the **Test Mix Model** page, select **Based on sequential test order** and click **Next**.

	![Selecting the test mix model](Images/selecting-the-test-mix-model.png?raw=true "Selecting the test mix model")

	_Selecting the test mix model_

1. In the **Test Mix Model** page, click **Add...** to add a test to the mix.

	![Adding a test to the test mix](Images/adding-a-test-to-the-test-mix.png?raw=true "Adding a test to the test mix")
	
	_Adding a test to the test mix_

1. In the **Add Tests** dialog box, double-click **WebTest1** to add the test to the **Selected tests** list. Click **OK** to continue.

	![Adding the WebTest1 test](Images/adding-the-webtest1-to-the-test-mix-model.png?raw=true "Adding the WebTest1 test")

	_Adding the WebTest1 test_

1. Back in the **Test Mix** page, click **Next**.

	![Completing the Test Mix page](Images/completing-the-test-mix-page.png?raw=true "Completing the Test Mix page")

	_Completing the Test Mix page_

1. In the **Network Mix** page, click **Next**.

	![Clicking next in the Network Mix page](Images/clicking-next-in-the-network-mix-page.png?raw=true "Clicking next in the Network Mix page")

	_Clicking next in the Network Mix page_

1. In the **Browser Mix** page, select **Internet Explorer 10.0** as the browser type and click **Next**.

	![Selecting the browser type](Images/selecting-the-browser-type.png?raw=true "Selecting the browser type")

	_Selecting the browser type_

1. In the **Counter Sets** page, click **Next**.

	![Clicking Next in the Counter Sets page](Images/clicking-next-in-the-counter-sets-page.png?raw=true "Clicking Next in the Counter Sets page")

	_Clicking Next in the Counter Sets page_

1. In the **Run Settings** page, set the **Load test duration** to **5 minutes** and click **Finish**.

	![Setting the load test duration to 5 minutes](Images/setting-the-load-test-duration-to-5-minutes.png?raw=true "Setting the load test duration to 5 minutes")

	_Setting the load test duration to 5 minutes_

1. In **Solution Explorer**, double-click the **Local.settings** file to explore the test settings. By default, Visual Studio uses your local computer to run the tests.

	> **Note:** Alternatively, you can configure your test project to run the load tests in the cloud using **Visual Studio Online (VSO)**. VSO provides a cloud-based load testing service that simulates a more realistic load, avoiding local environment constraints like CPU capacity, available memory and network bandwidth. For more information about using VSO to run load tests, see [this article](http://www.visualstudio.com/get-started/load-test-your-app-vs).

	![Test settings](Images/test-settings.png?raw=true)

<a name="Ex5Task3" />
#### Task 3 – Autoscale Verification ####

You will now execute the load test you created in the previous task and see how your Web site behaves under load.

1. In **Solution Explorer**, double-click **LoadTest1.loadtest** to open the load test.

	![Opening LoadTest1.loadtest](Images/opening-loadtest1loadtest.png?raw=true "Opening LoadTest1.loadtest")

	_Opening LoadTest1.loadtest_

1. In the **LoadTest1.loadtest** window, click the first button in the toolbox to run the load test.

	![Running the load test](Images/running-the-load-test.png?raw=true "Running the load test")

	_Running the load test_

1. Wait until the load test completes.

	> **Note:** The load test simulates multiple users that send requests to the Web site simultaneously. When the test is running, you can monitor the available counters to detect any errors, warnings or other information related to your load test run.

	![Load test running](Images/waiting-until-the-load-test-completes.png?raw=true "Waiting until the load test completes")

	_Load test running_

1. Once the test completes, go back to the management portal and navigate to the **Scale** page of your Web site. Under the **capacity** section, you should see in the graph that a new instance was automatically deployed.

	![New instance automatically deployed](Images/new-instance-automatically-deployed.png?raw=true)

	_New instance automatically deployed_

	> **Note:** It may take several minutes for the changes to appear in the graph (press **CTRL + F5** periodically to refresh the page). If you do not see any changes, you can try the following:
	>
	> - Increase the duration of the load test (e.g. to **10 minutes**)
	> - Reduce the maximum and minimum values of the **Target CPU** range in the Autoscale configuration of your Web site
	> - Run the load test in the cloud with **Visual Studio Online**. More information [here](http://www.visualstudio.com/en-us/get-started/load-test-your-app-vs.aspx)


---

<a name="Summary" />
## Summary ##

In this hands-on lab, you learned how to set up and deploy your application to production Web Sites in Windows Azure. You started by detecting and updating your databases using **Entity Framework Code First Migrations**, then continued by deploying new versions of your site using **Git** and performing rollbacks to the latest stable version of your site. Additionally, you learned how to scale your app using Storage to move your static content to a Blob container. 
