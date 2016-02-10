<a name="HOLTop"></a>
# Web Sites in Production #

---

<a name="Overview"></a>
## Overview ##

Microsoft Azure offers secure and flexible development, deployment and scaling options for any size web application. Leverage your existing tools to create and deploy applications without the hassle of managing infrastructure.

Provision a production web application on your own in minutes by easily deploying content created using your favorite development tool. You can deploy an existing site directly from source control with support for **Git**, **GitHub**, **Bitbucket**, **CodePlex**, **TFS**, and even **DropBox**. Deploy directly from your favorite IDE or from scripts using **PowerShell** in Windows or **CLI** tools running on any OS. Once deployed, keep your sites constantly up-to-date with support for continuous deployment.

Microsoft Azure provides scalable, durable cloud storage, backup, and recovery solutions for any data, big or small. When deploying applications to a production environment, storage services such as Tables, Blobs and SQL Databases help you scale your application in the cloud. 

With SQL Databases, it is important to keep your productive database up-to-date when deploying new versions of your application. Thanks to **Entity Framework Migrations**, the development and deployment of your data model has been simplified to update your environments in minutes.

This hands-on lab will show you the different topics you could encounter when deploying your site to production environments in Microsoft Azure.

<a name="Objectives"></a>
### Objectives ###
In this hands-on lab, you will learn how to:

- Enable Entity Framework Migrations with an existing model
- Update the object model and database accordingly using Entity Framework Migrations
- Deploy to a Microsoft Azure Web App using Git
- Rollback to a previous deployment using the Azure Portal
- Use Azure Storage to scale a Web App
- Configure auto-scaling for a Web App using the Azure Portal
- Create and configure a load test project in Visual Studio

<a name="Prerequisites"></a>
### Prerequisites ###

The following is required to complete this hands-on lab:

- [Visual Studio Community 2015][1] or greater
- [Azure SDK for Visual Studio 2015][2] or later
- [GIT Version Control System][3]
- Enable the ASP.NET Core command-line tools. Open a command-prompt and run:

	````
	dnvm upgrade
	````

- A Microsoft Azure subscription
	- Sign up for a [Free Trial][4]
	- If you are a Visual Studio Professional, Test Professional, Premium or Ultimate with MSDN or MSDN Platforms subscriber, activate your [MSDN benefit][5] now to start developing and testing on Microsoft Azure
	- [BizSpark][6] members automatically receive the Microsoft Azure benefit through their Visual Studio Ultimate with MSDN subscriptions
	- Members of the [Microsoft Partner Network][7] Cloud Essentials program receive monthly Microsoft Azure credits at no charge

[1]: https://www.visualstudio.com/products/visual-studio-community-vs
[2]: http://azure.microsoft.com/en-us/downloads/
[3]: http://git-scm.com/download
[4]: http://aka.ms/watk-freetrial
[5]: http://aka.ms/watk-msdn
[6]: http://aka.ms/watk-bizspark
[7]: http://azure.microsoft.com/en-us/offers/ms-azr-0025p/


> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.

<a name="Setup"></a>
### Setup ###
In order to run the exercises in this hands-on lab, you will need to set up your environment first.

1. Open Windows Explorer and browse to the lab's **Source** folder.
1. Right-click on **Setup.cmd** and select **Run as administrator** to launch the setup process that will configure your environment and install the Visual Studio code snippets for this lab.
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

1. [Using Entity Framework Migrations](#Exercise1)
1. [Deploying a Web Site to Staging](#Exercise2)
1. [Performing Deployment Rollback in Production](#Exercise3)
1. [Scaling Using Azure Storage](#Exercise4)
1. [Using Autoscale for Web Sites](#Exercise5) (Optional for Visual Studio 2015 Ultimate edition)

Estimated time to complete this lab: **75 minutes**

>**Note:** When you first start Visual Studio, you must select one of the predefined settings collections. Each predefined collection is designed to match a particular development style and determines window layouts, editor behavior, IntelliSense code snippets, and dialog box options. The procedures in this lab describe the actions necessary to accomplish a given task in Visual Studio when using the **General Development Settings** collection. If you choose a different settings collection for your development environment, there may be differences in the steps that you should take into account.

<a name="Exercise1"></a>
### Exercise 1: Using Entity Framework Migrations ###

When you are developing an application, your data model might change over time. These changes could affect the existing model in your database (if you are creating a new version) and it is important to keep your database up-to-date to prevent errors. 

To simplify the tracking of these changes in your model, **Entity Framework Code First Migrations** automatically detect changes comparing your model with the database schema and generates specific code to update your database, creating new _versions_ of your database. 

This exercise shows you how to enable **Migrations** for your application and how you can easily detect and generate changes to update your databases.

<a name="Ex1Task1"></a>
#### Task 1 - Enabling Migrations ####

In this task, you will go through the steps of enabling **Entity Framework Code First Migrations** to the **Geek Quiz** database, changing the model and understanding how those changes are reflected in the database. 

1. Open the **GeekQuiz.sln** solution file from **Source\Ex1-UsingEntityFrameworkMigrations\Begin** in Visual Studio.

1. Build the solution in order to download and install the **NuGet** package dependencies. To do this, right-click the solution and click **Build Solution** or press **Ctrl + Shift + B**.

1. In the **Solution Explorer**, select the GeekQuiz project and press **Shift + Alt + ,** to open a Command Prompt in the folder where the project is located.

1. In the **Command Prompt** you just opened, enter the following command and then press **Enter**. An initial migration based on the existing model will be created.

	<!-- mark:1 -->
	````PowerShell
	dnx ef migrations add InitialMigration --context TriviaDbContext
	````
	
	![Creating the initial migration](Images/creating-the-initial-migration.png?raw=true "Creating the initial migration")

	_Creating the initial migration_

	>**Note:** Make sure that there is no database named "GeekQuizProd" in your LocalDB instance.
	>
	>**Note:** `dnx ef migrations add` will scaffold the next migration based on changes you have made to your model since the last migration was created. In this case, being the first migration of the project, it will add the scripts to create all the tables defined in the **TriviaDbContext** class.	

1. Back in Visual Studio, verify that the new migration was created inside the **TriviaDb** folder located under the **Migrations** folder.

	![Verifying the initial migration](Images/verifying-the-initial-migration.png?raw=true "Verifying the initial migration")

	_Verifying the initial migration_

1. Execute the migration to update the database by running the following command in the **Command Prompt**.

	>**Note:** `dnx ef database update` will apply any pending migrations to the database. In this case, it will create the database using the connection string defined in your appsettings.json file.

	<!-- mark:1 -->
	````PowerShell
	dnx ef database update --context TriviaDbContext
	````

	![Applying the initial migration](Images/applying-the-initial-migration.png?raw=true "Applying the initial migration")
	
1. Go to the **View** menu and open **SQL Server Object Explorer**.

	![Open in SQL Server Object Explorer](Images/open-in-sql-server-object-explorer.png?raw=true "Open in SQL Server Object Explorer")
	
	_Open in SQL Server Object Explorer_

1. In the **SQL Server Object Explorer** window, verify that you have the **(localdb)\MSSQLLocalDB** database in the list. If the database is not in the list, connect to your LocalDB instance by right-clicking the **SQL Server** node and selecting **Add SQL Server...**.

	![Adding a SQL Server Instance](Images/adding-sql-server-instance.png?raw=true "Adding a SQL Server Instance")

	_Adding a SQL Server instance to SQL Server Object Explorer_
	
1. Open the **GeekQuizProd** database and expand the **Tables** node. As you can see, the `dnx ef database update` command generated all the tables defined in the **TriviaDbContext** class. Locate the **dbo.TriviaQuestion** table and open the columns node. In the next task, you will add a new column to this table and update the database using **Migrations**. 

	![Trivia Questions Columns](Images/trivia-questions-columns.png?raw=true "Trivia Questions Columns")

	_Trivia Questions Columns_
	
<a name="Ex1Task2"></a>
#### Task 2 - Updating Database Schema Using Migrations ####
	
In this task, you will use **Entity Framework Code First Migrations** to detect a change in your model and generate the necessary code to update the database. You will update the **TriviaQuestion** entity by adding a new property to it. Then you will run commands to create a new Migration to include the new column in the table.

1. In **Solution Explorer**, double-click the **TriviaQuestion.cs** file located in the **Models** folder.

1. Add a new property named **Hint**, as shown in the following code snippet.
	
	<!-- mark:11 -->
	````C#
    public class TriviaQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<TriviaOption> Options { get; set; }

        public string Hint { get; set; }
    }
	````

1. Switch back to the **Command Prompt**, enter the following command and then press **Enter**. A new migration will be created reflecting the change in our model.

	<!-- mark:1 -->
	````PowerShell
	dnx ef migrations add QuestionHint --context TriviaDbContext
	````

	![Adding the QuestionHint migration](Images/adding-questionhint-migration.png?raw=true "Adding the QuestionHint migration")

	_Adding the QuestionHint migration_
	
	> **Note:** A Migration file is composed of two methods, **Up** and **Down**. 
	
	> * The **Up** method will be used to specify the changes the current version of our application needs to apply to the database. 
	> * The **Down** method is used to reverse the changes we have added to the **Up** method. 
	
	> When the Database Migration updates the database, it will run all migrations that have not been used since the last update in the timestamp (The _EFMigrationsHistory table keeps track of which migrations have been applied). The **Up** method of all migrations will be called and will make the changes we have specified to the database. If we decide to go back to a previous migration, the **Down** method will be called to redo the changes in reverse order.

1. In the **Command Prompt**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	dnx ef database update --context TriviaDbContext
	````

	![Applying the QuestionHint migration](Images/applying-questionhint-migration.png?raw=true "Applying the QuestionHint migration")

	_Applying the QuestionHint migration_

1. In **SQL Server Object Explorer**, refresh the **dbo.TriviaQuestion** table and check that the new **Hint** column is displayed.

	![Checking the new Hint Column](Images/checking-the-new-hint-column.png?raw=true "Checking the new Hint Column")

	_Checking the new Hint Column_

<a name="Exercise2"></a>
### Exercise 2: Deploying a Web Site to Staging ###

**Azure Web Apps** enables you to perform staged publishing. When you deploy your site to an **Azure Web App**, you can choose to deploy it to a separate deployment slot instead of the default production slot. And then swap the deployments in these two slots with no down time. This is really useful for validating changes before releasing to the public, incrementally integrating site content, and rolling back if changes are not working as expected.

In this exercise, you will deploy the **Geek Quiz** application to the staging environment of your Azure Web App using Git source control. To do this, you will create the Web App and provision the required components at the management portal, configure a **Git** repository and push the application source code from your local computer to a deployment slot. You will also update your production database with the **Code First Migrations** you created in the previous exercise. You will then execute the application in this staging environment to verify its operation. Once you are satisfied that it is working according to your expectations, you will promote the application to production.

> **Note:** To enable staged publishing, the Web App must be on one of the Standard plans. Note that additional charges will be incurred if you upgrade your Web App to a Standard plan. For more information about pricing, see [App Service Pricing](http://azure.microsoft.com/en-us/pricing/details/app-service/). 

<a name="Ex2Task1"></a>
#### Task 1 - Creating a Microsoft Azure Web App ####

In this task, you will create a **Microsoft Azure Web App** from the management portal. You will also configure a **SQL Database** to persist the application data, and configure a local Git repository for source control.

1. Go to the [Azure Portal](https://portal.azure.com) and sign in using the Microsoft account associated with your subscription.

	![Sign in to the Azure Portal](Images/sign-in-to-windows-azure-management-portal.png?raw=true)

	_Sign in to the Azure Portal_

1. Click **New** in the left command bar and then search for **Web App + SQL**.

	![Searching for Web App + SQL](Images/searching-for-webapp-sql.png?raw=true "Searching for Web App + SQL")

	_Searching for Web App + SQL_

1. Select **Web App + SQL** from the list.

	![Selecting Web App + SQL](Images/selecting-webapp-sql.png?raw=true "Selecting Web App + SQL")

	_Selecting Web App + SQL_

1. In the **Web App + SQL** blade, click **Create** in order to continue to the configuration of the site.

	![Creating the Web App + SQL](Images/creating-webapp-sql.png?raw=true "Creating the Web App + SQL")

	_Creating the Web App + SQL_

1. In the new **Web App + SQL** blade, select a **Resource Group** or create a new one. Then, click **App Service Name**, provide an available **URL** (e.g. _geekquiz-site_), create a new **AppService Plan**, then choose the pricing tier and location. Finally, click **OK**.

	![Configure the new Web App](Images/configure-the-new-web-app.png?raw=true)

	_Configure the new Web App_

1. Next, select **Database** and create a new database, specifying the required information for the new server. Then, click **OK** in both **New server** and **New database** blades.

	![Configure a new SQL Database](Images/configure-the-new-sql-database.png?raw=true)

	_Configure a new SQL Database_

1. Finally, in the **Web App + SQL** blade, click **Create** and wait until the Web App is created.

	> **Note:** By default, Microsoft Azure provides domains at _azurewebsites.net_ but also gives you the possibility to set custom domains using the Azure Portal. However, you cannot use custom domains with a free Web App.
	
	> Microsoft Azure offers 5 plans for users to run their Web Apps - Free, Shared, Basic, Standard and Premium. In Free and Shared, all Web Apps run in a multi-tenant environment and have quotas for CPU, Memory, and Network usage. You can mix and match which sites are Free (strict quotas) vs. Shared (more flexible quotas). The maximum number of free Web Apps may vary with your plan. In Standard, you choose which Web Apps run on dedicated virtual machines that correspond to the standard Azure compute resources. You can change the mode of your Web App by clicking the **Pricing tier** tile in the **Usage** section of the corresponding App Service plan blade.

	> ![Web Apps Modes](Images/web-site-modes.png?raw=true "Web Apps Modes")

	> If you are using **Shared** or **Standard**, you will be able to manage custom domains for your Web Apps by going to your Web App's **Settings** blade and clicking **Custom domains and SSL**.

	> ![Custom Domains and SLL](Images/manage-custom-domains.png?raw=true "Custom Domains and SSL")

1. Once the Web app is created, select it and click the **Browse** button to validate that the new Web app is running.

	![Browsing to the new Web app](Images/browsing-to-the-new-web-site.png?raw=true)

	_Browsing to the new web app_

	![Web app running](Images/web-site-running.png?raw=true)

	_Web app running_

<a name="Ex2Task2"></a>
#### Task 2 - Deploying Geek Quiz to Staging Using Git ####

In this task, you will create a staging deployment slot for your Web App. Then, you will use Git to publish the Geek Quiz application directly from your local computer to the staging environment of your Web App.

1. Go back to the portal and open your Web App.
	
1. Select **Scale Up (App Service Plan)** in the **Settings** blade of your web app.

	![Scaling up the App Service Plan ](Images/scaling-up-the-app-service-plan.png?raw=true "Scaling up the App Service Plan")

	_Scaling up the App Service Plan_

1. If your Web App is not on a **Standard** plan, select one by clicking the **Pricing tier** tile. For instance, select the **S1 Standard** plan.

	![Upgrading the Web App to Standard Instance ](Images/upgrading-the-web-site-to-standard-mode.png?raw=true "Upgrading the Web App to Standard Instance")

	_Upgrading the Web app to a Standard plan_

1. Click **Continuous deployment** in the **Settings** blade of your web app and then choose **Local Git Repository** as source. Then, click **OK** to save the changes.

	![Configuring the Git Deployment](Images/configuring-the-git-deployment.png?raw=true "Configuring the Git Deployment")

	_Configuring the Git Deployment in staging Web App_

1. Now, click **Deployment credentials** in the Settings blade of your web app to configure the user that will perform the deployments. Fill in the credentials and then click **Save** at the top.

	![Setting deployment credentials](Images/setting-deployment-credentials.png?raw=true "Setting deployment credentials")

	_Setting deployment credentials_

1. Back in the **Settings** blade, select **Deployment slots**.

	![Opening deploymet slots](Images/enabling-staged-publishing.png?raw=true "Opening deployment slots")

	_Opening deployment slots_

1. Click the **Add Slot** command at the top and create a new slot named **staging**. Set your Web App as **Configuration Source** and then click **OK**.

	![Creating deploymet slot](Images/create-deployment-slot.png?raw=true "Creating deployment slot")

	_Creating deployment slot_

1. After a few seconds you will see a new slot with the name of your Web App followed by _**-staging**_. Select it to navigate to the *staging Web App* settings.

	![Navigating to the staging Web App](Images/navigating-to-the-staging-web-site.png?raw=true "Navigating to the staging Web App")

	_Navigating to the staging Web App_

1. Repeat Step 4 to configure continuous deployment in the *staging Web App* using **Local Git Repository** as source.

1. Now, click the _staging Web App_ **Settings** command, select **Properties** and then copy the **GIT URL** value. You will use it later in this exercise.

	![Copying the Git URL value](Images/coping-the-git-url-value.png?raw=true)

	_Copying the Git URL value_

1. Open a new **Git Bash** console and execute the following commands. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution, located in the **Source\Ex2-DeployingWebSiteToStaging\Begin** folder of this lab. 
	
	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git init
	git config --global user.email "{username@example.com}"
	git config --global user.name "{your-user-name}"
	git add .
	git commit -m "Initial commit"
	````

1. Run the following command to push your site to the remote **Git** repository. Replace the placeholder with the URL you obtained from the Azure Portal.

	> **Note:** When you deploy content to the FTP host or GIT repository of a Microsoft Azure Web App you must authenticate using the **deployment credentials** that you configured in a previous step. If you do not know your deployment credentials you can easily reset them in the Azure Portal by opening the Web App **Settings** and clicking **Deployment credentials**. These deployment credentials are valid for all the Web Apps associated with your subscription.

	````GitBash
	git remote add azure [GIT-URL-STAGING-SLOT]
	git push azure master
	````

1. In order to verify that the site was successfully deployed, go back to the Azure Portal and select your Web App.

1. Navigate to the staging slot of this Web App by clicking **Deployment slots** in the **Settings** blade and then selecting its row inside the **Deployments** blade.

1. In the *staging Web App*, verify that there is an **Active** deployment with your _"initial commit"_ in the **Continuous deployment** blade.

	![Active deployment](Images/active-deployment.png?raw=true)

	_Active deployment_

1. Finally, click the **Browse** command to navigate to the deployed site.

	![Browse site](Images/browse-web-site.png?raw=true)

	_Browse site_

1. If the application was successfully deployed, you will see the Geek Quiz Log in page.

	> **Note:** The address URL of the deployed application contains the name of your Web App followed by _-staging_.

	![Application running in the staging environment](Images/application-running-in-staging.png?raw=true)

	_Application running in the staging environment_

1. If you wish to explore the application, click **Register** to configure a new user. Complete the account details by entering a user name, email address and password. Next, the application shows the first question of the quiz. Answer a few questions to make sure it is working as expected.

	![Application ready to be used](Images/application-ready-to-be-used.png?raw=true)

	_Application ready to be used_

<a name="Ex2Task3"></a>
#### Task 3 - Promoting the Web App to Production ####

Now that you have verified that the site is working correctly in the deployment slot, you are ready to promote it to production. In this task, you will swap the site in a staging slot with the production slot.

1. Go back to the Azure Portal and navigate to the *staging Web App*.

1. Click the **Swap** command at the top.

	![Swap to production](Images/swap-to-production.png?raw=true)

	_Swap to production_

1. Verify that the **Source** targets the staging slot and the **Destination** targets production, and then click **OK** to proceed with the swap operation. Azure will immediately swap the content of the production site with the content of the staging site.

	> **Note:** Some settings from the staged version will automatically be copied to the production version (e.g. connection string overrides, handler mappings, etc.) but others will stay the same (e.g. DNS endpoints, SSL bindings, etc.).

	![Confirming swap operation](Images/confirm-swap-operation.png?raw=true)

	_Confirming swap operation_
	
1. Once the swap is complete, browse to your Web App in both slots. You can verify that the production site is now the one with the GeekQuiz site.

	> **Note:** You might need to refresh your browser to clear the cache. In Microsoft Edge, you can do this by pressing **CTRL+F5**.

	![Web App running in the production environment](Images/web-site-running-in-the-production-environmen.png?raw=true)

1. In the **GitBash** console, update the remote URL for the local Git repository to target the production slot. To do this, run the following command replacing the placeholders with your deployment username and the name of your Web App.

	> **Note:** In the following exercises, you will push changes to the production site instead of staging just for the simplicity of the lab. In a real-world scenario, it is recommended to verify the changes in the staging environment before promoting to production.

	````GitBash
	git remote set-url azure https://<your-user>@<your-web-site>.scm.azurewebsites.net:443/<your-web-site>.git
	````

<a name="Exercise3"></a>
### Exercise 3: Performing Deployment Rollback in Production ###

There are scenarios where you do not have a staging slot to perform hot swap between staging and production, for example, if you are working with **Web Apps** running in **Free** or **Shared** mode. In those scenarios, you should test your application in a testing environment (either locally or in a remote site) before deploying to production. However, it is possible that an issue not detected during the testing phase may arise in the production site. In this case, it is important to have a mechanism to easily switch to a previous and more stable version of the application as quickly as possible.

In **Azure Web Apps**, continuous deployment from source control makes this possible thanks to the **Redeploy** action available in the Azure Portal. Microsoft Azure keeps track of the deployments associated with the commits pushed to the repository and provides an option to redeploy your application using any of your previous deployments, at any time.

In this exercise you will perform a change to the code in the **Geek Quiz** application that intentionally injects a _bug_. You will deploy the application to production to see the error, and then you will take advantage of the redeploy feature to go back to the previous state.

<a name="Ex3Task1"></a>
#### Task 1 - Updating the Geek Quiz Application ####

In this task, you will refactor a small piece of code from the **TriviaController** class by extracting part of the logic that retrieves the selected quiz option from the database to a new method.

1. Switch to the Visual Studio instance with the **GeekQuiz** solution from the previous exercise.

1. In **Solution Explorer**, open the **AnswersService.cs** file in the **Services** folder.

1. Replace the **StoreAsync** method implementation with the following code snippet.

	(Code Snippet - _WebSitesInProduction - Ex3 - StoreAsync_)
	<!-- mark:3-4,17-22 -->
	````C#
    public async Task<bool> StoreAsync(TriviaAnswer answer)
    {
        var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o =>
            MatchesOption(answer, o));

        if (selectedOption != null)
        {
            answer.TriviaOption = selectedOption;
            this.db.TriviaAnswers.Add(answer);

            await this.db.SaveChangesAsync();
        }

        return selectedOption.IsCorrect;
    }

    private static bool MatchesOption(TriviaAnswer answer, TriviaOption o)
    {
        var a = answer.OptionId / 0;
        return o.Id == answer.OptionId
                                && o.QuestionId == answer.QuestionId;
    }
	````

1. Press **CTRL + S** to save the changes.

<a name="Ex3Task2"></a>
#### Task 2 - Redeploying the Geek Quiz Application ####

You will now push the changes you made in the previous task to the repository, which will trigger a new deployment to the production environment. Then, you will troubleshoot an issue using the **F12 development tools** provided by Microsoft Edge and then perform a rollback to the previous deployment from the Azure Portal.

1. Open a new **Git Bash** console to deploy the updated application to Azure Web Apps.

1. Execute the following commands to push the changes to Microsoft Azure. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution. You will be prompted for your deployment password.

	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git add .
	git commit -m "Refactored answer check"
	git push azure master
	````

1. Open Microsoft Edge and navigate to your site (e.g. _http://geek-quiz-site.azurewebsites.net/_). Log in with your user credentials.

1. Press **F12** to launch the development tools, select the **Network** tab and click the **Clear Session** button.

	![Starting network recording](Images/starting-the-network-recording.png?raw=true "Starting network recording")

	_Starting network recording_

1. Select any of the quiz options. You will see that nothing happens.

1. In the **F12** window, the entry corresponding to the POST HTTP request shows an HTTP **500** result.

	![HTTP 500 error](Images/http-500-error.png?raw=true "HTTP 500 error")

	_HTTP 500 error_

1. Select the **Console** tab. An error is logged with the details of the cause. This error is caused by the code refactoring you committed in the previous steps

	![Logged error](Images/logged-error.png?raw=true "Logged error")

	_Logged error_

1. Do not close the browser.

1. In a new browser instance, navigate to the [Azure Portal](http://portal.azure.com) and sign in using the Microsoft account associated with your subscription.

1. Select **App Services** and click the Web app you created in Exercise 2.

1. Open the **Deployments** blade by clicking the **Continuous deployment** option in the **Settings** blade. Notice that all the commits performed are listed in the deployment history.

	![List of existing deployments](Images/list-of-existing-deployments.png?raw=true)

	_List of existing deployments_

1. Select the previous commit and then click **Redeploy** on the command bar.

	![Redeploying the previous commit](Images/redeploying-previous-commit.png?raw=true)

	_Redeploying the previous commit_

1. When prompted to confirm, click **Yes**.

	![Confirming the redeployment](Images/confirming-the-redeployment.png?raw=true)

1. When the deployment completes, switch back to the browser instance with your site and press **CTRL + F5**.
	
1. Click any of the options. The flip animation will now take place and the result (_correct/incorrect_) will be displayed.

1. (Optional) Switch to the **Git Bash** console and execute the following commands to revert to the previous commit.

	> **Note:** These commands create a new commit that undoes all changes in the Git repository that were made in the bad commit. Azure will then redeploy the application using the new commit.

	````GitBash
	git revert HEAD --no-edit
	git push azure master
	````

<a name="Exercise4"></a>
### Exercise 4: Scaling Using Azure Storage ###

**Blobs** are the simplest way to store large amounts of unstructured text or binary data such as video, audio and images. Moving the static content of your application to Storage helps scale your application by serving images or documents directly to the browser.

In this exercise, you will move the static content of your application to a Blob container. Then you will configure your application to add an **ASP.NET URL rewrite rule** in the **Web.config** to redirect your content to the Blob container.

<a name="Ex4Task1"></a>
#### Task 1 - Creating an Azure Storage Account ####

In this task you will learn how to create a new storage account using the management portal.

1. Navigate to the [Azure Portal](http://portal.azure.com) and sign in using the Microsoft account associated with your subscription.

1. Select **New | Data + Storage | Storage account** to start creating a new storage account. 

	![Creating a new Storage Account](Images/creating-a-new-storage-account.png?raw=true "Creating a new Storage Account")

	_Creating a new storage account_

1. In the Storage account blade, click **Create**.

	![Creating the Storage Account](Images/creating-the-storage-account.png?raw=true "Creating the Storage Account")

	_Creating the storage account_

1. Enter a unique name for the account and select a **Location** from the list. Click **Create** to continue.

	![Configuring the new Storage Account](Images/configuring-the-new-storage-account.png?raw=true "Configuring the new Storage Account")

	_Configuring the new storage account_

1. Once the storage account is created it will open automatically. Click **Properties** in the **Settings** blade to see the information about the service endpoints that can be used within your applications.

	![Storage Account created](Images/storage-account-created.png?raw=true "Storage Account created")

	_Storage Account created_

1. Click the **Manage Keys** button in the navigation bar.
	
	![Manage Access Keys button](Images/manage-access-keys-button.png?raw=true "Manage Access Keys button")
	
	_Manage Access Keys button_
	
1. Take note of the **Storage Account Name** and **Primary Access Key** in the **Manage Keys** dialog box, as you will need them in the following exercise. Then, close the dialog box.

	![Manage Keys blade](Images/manage-key-blade.png?raw=true "Manage Keys blade")
	
	_Manage Keys blade_

<a name="Ex4Task2"></a>
#### Task 2 - Uploading an Asset to Azure Blob Storage ####

In this task, you will use the Server Explorer window from Visual Studio to connect to your storage account. You will then create a blob container and upload a file with the Geek Quiz logo to the container.

1. Switch to the Visual Studio instance with the **GeekQuiz** solution from the previous exercise.

1. From the menu bar, select **View** and then click **Server Explorer**.

1. In **Server Explorer**, right-click the **Azure** node and select **Connect to Microsoft Azure Subscription...**. Then, sign in using the Microsoft account associated with your subscription.

	![Connect to Microsoft Azure](Images/connect-to-microsoft-azure.png?raw=true)

	_Connect to Microsoft Azure_

1. Expand the **Azure** node, right-click **Storage** and select **Attach External Storage...**.

	![Attaching an external storage](Images/attaching-an-external-storage.png?raw=true "Attaching an external storage")
	
	_Attaching an external storage_

1. In the **Add New Storage Account** dialog box, enter the **Account name** and **Account key** you obtained in the previous task and click **OK**.

	![Add New Storage Account dialog box](Images/add-new-storage-account-dialog-box.png?raw=true)
	
	_Add New Storage Account dialog box_

1. Your storage account should appear under the **Storage** node. Expand your storage account, right-click **Blobs** and select **Create Blob Container...**. 

	![Create Blob Container](Images/create-blob-container.png?raw=true "Create Blob Container")
	
	_Create Blob Container_

1. In the **Create Blob Container** dialog box, enter _images_ as the name for the blob container and click **OK**.

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
	
1. In **Server Explorer**, right-click the **images** blob container and select **View Blob Container**.

	![View Blob Container](Images/view-blob-container.png?raw=true "View Blob Container")
	
	_View Blob Container_

1. The images container should open in a new window and a legend with no entries should be shown. Click the **Upload Blob** icon to upload a file to the blob container.

	![Images container with no entries](Images/images-container-with-no-entries.png?raw=true "Images container with no entries")

	_Images container with no entries_
	
1. Upload the **logo-big.png** file located in the **Assets** folder of this lab. Leave the **Folder (optional)** field empty.

	![Uploading the asset](Images/uploading-the-asset.png?raw=true "Uploading the asset")
	
	_Uploading the asset_

1. When the upload completes, the file should be listed in the images container. Right-click the file entry and select **Copy URL**.

	![Copy blob file URL](Images/copy-blob-file-url.png?raw=true "Copy blob file URL")
	
	_Copy blob file URL_
	
1. Open Microsoft Edge and paste the URL. The following image should be shown in the browser.

	![logo-big.png image from Azure Blob Storage](Images/logo-bigpng-image-from-storage.png?raw=true "logo-big.png image from storage")
	
	_logo-big.png image from Azure Blob Storage_
	
<a name="Ex4Task3"></a>
#### Task 3 - Updating the Solution to Consume Static Content from Azure Blob Storage ####

In this task, you will configure the **GeekQuiz** solution to consume the image uploaded to Azure Blob Storage (instead of the image located in the web site) by adding an ASP.NET URL rewrite rule in the **web.config** file.

1. In Visual Studio, open the **web.config** file located in the **wwwroot** folder in the **GeekQuiz** project and locate the **\<system.webServer>** element.

1. Add the following code to add a URL rewrite rule, updating the placeholder with your storage account name.

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

	> **Note:** URL rewriting is the process of intercepting an incoming Web request and redirecting the request to a different resource. The URL rewriting rules tells the rewriting engine when and where a request needs to be redirected. A rewriting rule is composed of two strings: the pattern to look for in the requested URL (usually, using regular expressions), and the string to replace the pattern with, if found. For more information, see [URL Rewriting in ASP.NET](http://msdn.microsoft.com/en-us/library/ms972974.aspx).

1. Press **CTRL + S** to save the changes.

1. Open the **Index.cshtml** file located at **Views | Home** and add the following header row inside the div element with the **container** class.

    ````HTML
    <div class="row header">
        <img src="@Url.Content("~/img/logo-big.png")" alt="" />
    </div>
    ````

	![Updated index view](Images/updated-index-view.png?raw=true "Updated index view")
	
	_Updated index view_

1. Now you will deploy the updated application to Azure. Open a new **Git Bash** console and execute the following commands to push the changes into the repository and trigger a new deployment. Update the _[YOUR-APPLICATION-PATH]_ placeholder with the path to the **GeekQuiz** solution. 

	> **Note:** When you deploy content to the FTP host or GIT repository of an Azure Web App you must authenticate using the **deployment credentials** associated with your subscription. If you do not know your deployment credentials you can easily reset them in the Azure Portal by opening the Web App **Settings** and clicking **Deployment credentials**. 

	````GitBash
	cd "[YOUR-APPLICATION-PATH]"
	git add .
	git commit -m "Added URL rewrite rule in web.config file"
	git push azure master
	````

<a name="Ex4Task4"></a>
#### Task 4 - Verification ####

In this task you will use **Microsoft Edge** to browse the **Geek Quiz** application and check that the URL rewrite rule for images works and that you are redirected to the image hosted on **Azure Blob Storage**.

1. Open Microsoft Edge and navigate to your site (e.g. _http://geek-quiz-site.azurewebsites.net/_). Log in using the credentials you created previously.

	![Showing the Geek Quiz website with the image](Images/showing-the-geek-quiz-website-with-the-image.png?raw=true "Showing the Geek Quiz website with the image")

	_Showing the Geek Quiz website with the image_

1. Press **F12** to launch the development tools, select the **Network** tab and start recording.

	![Starting network recording](Images/starting-the-network-recording-2.png?raw=true "Starting network recording")

	_Starting network recording_

1. Press **CTRL + F5** to refresh the web page.

1. Once the page has finished loading, you should see an HTTP request for the **/img/logo-big.png** URL with an HTTP **301** result (redirect) and another request for **http://[YOUR-STORAGE-ACCOUNT].blob.core.windows.net/images/logo-big.png** URL with an HTTP **200** result.

	![Verifying the URL redirect](Images/showing-the-redirect-in-dev-tools.png?raw=true "Showing the redirect in Dev Tools")

	_Verifying the URL redirect_

<a name="Exercise5"></a>
### Exercise 5: Using Autoscale for Web Sites ###

> **Note:** This exercise is optional, since it requires support for Web Load & Performance Testing which is only available for **Visual Studio 2015 Ultimate Edition**. For more information on specific Visual Studio 2015 features, compare versions [here](http://www.microsoft.com/visualstudio/eng/products/compare).

**Azure Web Apps** provides the Autoscale feature for Web Apps running on a Standard plan. Autoscale lets Azure automatically scale the instance count of your Web App depending on the load. When Autoscale is enabled, Azure checks the CPU of your Web App once every five minutes and adds instances as needed at that point in time. If the CPU usage is low, Azure will remove instances once every two hours to ensure that the performance of your Web App is not degraded.

In this exercise you will go through the steps required to configure the **Autoscale** feature for the **Geek Quiz** Web App. You will verify this feature by running a Visual Studio load test to generate enough CPU load on the application to trigger an instance upgrade.

<a name="Ex5Task1"></a>
#### Task 1 - Configuring Autoscale Based on the CPU Metric ####

In this task you will use the Azure Portal to enable the Autoscale feature for the Web App you created in Exercise 2.

1. In the [Azure Portal](https://portal.azure.com/), select **App Services** and click the Web app you created in Exercise 2.

1. Navigate to the **Scale Out (App Service Plan)** option in the **Settings** blade. In the **Scale setting** blade, select the **CPU Percentage** option for the **Scale by** configuration.

	> **Note:** When scaling by CPU, Azure dynamically adjusts the number of instances that the Web app uses if the CPU usage changes.

	![Selecting to scale by CPU](Images/selecting-the-cpu-metric-for-auto-scaling.png?raw=true "Selecting the CPU metric for auto scaling")

	_Selecting to scale by CPU_

1. Set the maximum number of **Instances** to 3 and the **Target range** to **5**-**25** percent. Then, click **Save** in the command bar at the top to save the changes.

	> **Note:** This range represents the average CPU usage for your Web App. Azure will add or remove instances to keep the CPU within this range. The minimum and maximum number of instances used for scaling is specified in the **Instance** configuration. Azure will never go above or beyond that limit.
	> 
	> The default **Target range** values are modified just for the purposes of this lab. By configuring the CPU range with these small values, you are increasing the chances to trigger Autoscale when a moderate load is placed on the application.

	![Changing the target range to be between 5 and 25 percent](Images/changing-the-target-cpu-to-be-between-20-and.png?raw=true "Changing the target CPU to be between 5 and 25 percent")

	_Changing the Target range to be between 5 and 25 percent_

<a name="Ex5Task2"></a>
#### Task 2 - Load Testing with Visual Studio ####

Now that **Autoscale** has been configured, you will create a **Web Performance and Load Test Project** in Visual Studio to generate some CPU load on your Web App.

1. Open **Visual Studio Ultimate 2015** and select **File | New | Project...** to start a new solution.

	![Creating a new project](Images/creating-a-new-project.png?raw=true "Creating a new project")

	_Creating a new project_

1. In the **New Project** dialog box, select **Web Performance and Load Test Project** under the **Visual C# | Test** tab. Make sure **.NET Framework 4.5** is selected, name the project _WebAndLoadTestProject_, choose a **Location** and click **OK**.

	![Creating a new Web and Load Test project](Images/creating-a-new-web-and-load-test-project.png?raw=true "Creating a new Web and Load Test project")

	_Creating a new Web and Load Test project_

1. Inside the **WebTest1.webtest** window, right-click the **WebTest1** node and select **Add Request**.

	![Adding a request to WebTest1](Images/adding-a-request-to-webtest1.png?raw=true "Adding a request to WebTest1")
	
	_Adding a request to WebTest1_

1. In the **Properties** window of the new request node, update the **Url** property to point to the URL of your Microsoft Azure Web App (e.g. _http://geek-quiz.azurewebsites.net/_).

	![Changing the Url property](Images/changing-the-url-property.png?raw=true "Changing the Url property")

	_Changing the Url property_

1. Back in the **WebTest1.webtest** window, right-click **WebTest1** and select **Add Loop...**.

	![Adding a loop to WebTest1](Images/adding-a-loop-to-webtest1.png?raw=true "Adding a loop to WebTest1")

	_Adding a loop to WebTest1_

1. In the **Add Conditional Rule and Items to Loop** dialog box, select the **For Loop** rule and modify the following properties.

	1. **Terminating value:** 1000
	1. **Context Parameter Name:** Iterator
	1. **Increment Value:** 1

	![Selecting the For Loop rule and updating the properties](Images/selecting-the-for-loop-rule-and-updating-the.png?raw=true "Selecting the For Loop rule and updating the properties")

	_Selecting the For Loop rule and updating the properties_

1. Under the **Items in loop** section, select the request you created previously as the first and last items for the loop. Click **OK** to continue.

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

1. In the **Load Pattern** page, make sure the **Constant Load** option is selected. Change the **User Count** setting to **250** users and click **Next**.

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

	![Clicking Next in the Network Mix page](Images/clicking-next-in-the-network-mix-page.png?raw=true "Clicking Next in the Network Mix page")

	_Clicking Next in the Network Mix page_

1. In the **Browser Mix** page, select **Internet Explorer 11.0** as the browser type and click **Next**.

	![Selecting the browser type](Images/selecting-the-browser-type.png?raw=true "Selecting the browser type")

	_Selecting the browser type_

1. In the **Counter Sets** page, click **Next**.

	![Clicking Next in the Counter Sets page](Images/clicking-next-in-the-counter-sets-page.png?raw=true "Clicking Next in the Counter Sets page")

	_Clicking Next in the Counter Sets page_

1. In the **Run Settings** page, select **Load test duration**, make sure the **Run duration** is set to **5 minutes** and then click **Finish**.

	![Setting the load test duration to 5 minutes](Images/setting-the-load-test-duration-to-5-minutes.png?raw=true "Setting the load test duration to 5 minutes")

	_Setting the load test duration to 5 minutes_

1. In **Solution Explorer**, double-click the **Local.settings** file to explore the test settings. Make sure that Visual Studio uses your local computer to run the tests.

	> **Note:** Alternatively, you can configure your test project to run the load tests in the cloud using **Visual Studio Online (VSO)**. VSO provides a cloud-based load testing service that simulates a more realistic load, avoiding local environment constraints like CPU capacity, available memory and network bandwidth. For more information about using VSO to run load tests, see [this article](http://www.visualstudio.com/get-started/load-test-your-app-vs).

	![Test settings](Images/test-settings.png?raw=true)

<a name="Ex5Task3"></a>
#### Task 3 - Autoscale Verification ####

You will now execute the load test you created in the previous task and see how your Web App behaves under load.

1. In **Solution Explorer**, double-click **LoadTest1.loadtest** to open the load test.

	![Opening LoadTest1.loadtest](Images/opening-loadtest1loadtest.png?raw=true "Opening LoadTest1.loadtest")

	_Opening LoadTest1.loadtest_

1. In the **LoadTest1.loadtest** windows, right-click the **Run Settings1** node and select **Properties** or press **ALT + Enter**.

	![Opening Run Settings properties](Images/opening-run-settings-properties.png?raw=true "Opening Run Settings properties")

	_Open Run Settings properties_

1. Update the **WebTest Connection Pool Size** to **100** and save the changes.

	![Run Settings properties](Images/run-settings-properties.png?raw=true "Run Settings properties")

	_Run Settings properties_

1. In the **LoadTest1.loadtest** window, click the first button in the toolbox to run the load test.

	![Running the load test](Images/running-the-load-test.png?raw=true "Running the load test")

	_Running the load test_

1. Wait until the load test completes.

	> **Note:** The load test simulates multiple users that send requests to the site simultaneously. When the test is running, you can monitor the available counters to detect any errors, warnings or other information related to your load test run.

	![Load test running](Images/waiting-until-the-load-test-completes.png?raw=true "Waiting until the load test completes")

	_Load test running_

1. Once the test completes, go back to the Azure Portal and navigate to the App Service Plan in which your web app was created. In the **Scale** tile under the **Usage** section, you should see that the number of instances has increased.

	![New instance automatically deployed](Images/new-instance-automatically-deployed.png?raw=true)

	_New instance automatically deployed_

	> **Note:** It may take several minutes for the changes to appear in the graph (press **CTRL + F5** periodically to refresh the page). If you do not see any changes, you can try the following:
	>
	> - Increase the duration of the load test (e.g. to **10 minutes**)
	> - Reduce the maximum and minimum values of the **Target CPU** range in the Autoscale configuration of your Web App
	> - Run the load test in the cloud with **Visual Studio Online**. More information [here](http://www.visualstudio.com/en-us/get-started/load-test-your-app-vs.aspx)


---

<a name="Summary"></a>
## Summary ##

In this hands-on lab, you have learned how to set up and deploy your application to a production Web App in Microsoft Azure. You started by detecting and updating your databases using **Entity Framework Code First Migrations**, then continued by deploying new versions of your site to different deployment slots using **Git** and performing rollbacks to the latest stable version of your site. Additionally, you learned how to scale your Web App using Storage to move your static content to a Blob container. 


> **Note:** You can take advantage of the [Visual Studio Dev Essentials]( https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx) subscription in order to get everything you need to build and deploy your app on any platform.
