<a name="title"></a>
# Handling change (EF migrations, Deployment rollback) #

---
<a name="Overview"></a>
## Overview ##

In this demo you go through the steps of enabling Entity Framework migrations to GeekQuiz database, changing the model and understanding how those changes are reflected in the database. Additionally, you will deploy to Azure using Git and perform a rollback to the previous deployment from Azure Portal.

<a id="goals"></a>
### Goals ###

In this demo, you will see how to:

1. Update the object model and database accordingly using Entity Framework migrations
1. Deploy to Microsoft Azure using Git
1. Rollback to a previous deployment using the Azure Portal

<a name="technologies"></a>
### Key Technologies ###

1. [Entity Framework 7](http://www.asp.net/entity-framework).
1. [Git](http://git-scm.com/).

<a name="setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Copy the contents of the **source\begin** folder to a separate directory. Both demo segments start from the same begin solution, so you will need to remember the directory to where you copied the files for the second segment.

1. Configure an Azure SQL Database following the steps provided in [this link](https://azure.microsoft.com/en-us/documentation/articles/sql-database-get-started/). Copy the ADO.NET connection string value.

1. Create a new **Web App** in Azure Portal.

	> **Note:** To avoid issues with the local storage while deploying with git, use a Basic Service Plan or greater.

1. In the **Application settings** of your new Web App, update the connection string key for the DB to _DefaultConnection_ and value copied from previous step. Save the changes.

	![Default Connection](Images/default-connection.png?raw=true "Default Connection")

	_Default connection_

1. Configure the **GeekQuiz** web site to support [Publishing with Git](https://azure.microsoft.com/documentation/articles/web-sites-publish-source-control/) and push the duplicate of the begin solution to the remote repository.

1. Leave the Azure Portal in a separate browser window/tab.

1. Navigate to the created site and register an account.

1. Enable the ASP.NET Core command-line tools. Open a command-prompt and run:

	````
	dnvm upgrade
	````

1. Open Visual Studio 2015.

1. Open the **GeekQuiz.sln** solution located under **source\begin**.

1. Run the solution and register a new user in order to generate the SQL database.

1. In Visual Studio, close all open files.

1. Make sure that you have an Internet connection, as this demo requires it to push to a remote git repository.

1. Open the **SQL Server Object Explorer** and dock it in the left panel.

1. Open the **Solution Explorer** and dock it in the right panel.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Migrations](#segment1)
1. [Deployment rollback](#segment2)

<a name="segment1"></a>
### Migrations ###

1. In the **Solution Explorer**, select the GeekQuiz project and press **Shift + Alt + ,** to open a Command Prompt in the folder where the project is located.

1. In the **Command Prompt** you just opened, enter the following command and then press **Enter**. An initial migration based on the existing model will be created.

	<!-- mark:1 -->
	````PowerShell
	dnx ef migrations add InitialMigration --context TriviaDbContext
	````

	![Creating the initial migration](Images/creating-the-initial-migration.png?raw=true "Creating the initial migration")

	_Creating the initial migration_

1. Back in Visual Studio, show that the new migration was created inside the **TriviaDb** folder located under the **Migrations** folder.

	![Showing the initial migration](Images/showing-the-initial-migration.png?raw=true "Showing the initial migration")

	_Showing the initial migration_

1. In the **Command Prompt**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	dnx ef database update --context TriviaDbContext --verbose
	````

	![Applying the initial migration](Images/applying-the-initial-migration.png?raw=true "Applying the initial migration")

	_Applying the initial migration_


1. In **SQL Server Object Explorer**, expand the different nodes until the columns of the **dbo.TriviaQuestions** table are displayed. This is shown in the following figure.

	![Trivia Questions Columns](Images/trivia-questions-columns.png?raw=true "Trivia Questions Columns")
 
	_Trivia Questions Columns_


1. In **Solution Explorer**, double-click the **TriviaQuestion.cs** file located inside the **Models** folder.

1. Add the *Hint* property, as shown in the following code snippet.

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

1. Switch back to the **Command Prompt**, enter the following command and then press **Enter**. A new migration will be created.

	<!-- mark:1 -->
	````PowerShell
	dnx ef migrations add QuestionHint --context TriviaDbContext
	````

	> **Speaking point:** Explain that the migration only accounts for the diff between the current model and the one from the previous migration. The `Up` method applies the changes to the target database and the `Down` method reverts those changes.

1. In the **Command Prompt**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	dnx ef database update --context TriviaDbContext --verbose
	````

1. In **SQL Server Object Explorer**, click **Refresh**.

	![Clicking the refresh button](Images/refresh.png?raw=true "Clicking the refresh button")

	_Clicking the refresh button_

1. Expand the different nodes until the columns of the **dbo.TriviaQuestions** table are displayed. The new **Hint** column will be displayed.

	![Showing the new Hint Column](Images/hint-column.png?raw=true "Showing the new Hint Column")

	_Showing the new Hint Column_

<a name="segment2"></a>
### Deployment Rollback ###

1. Open the **GeekQuiz.sln** solution that you copied to a separate folder during the setup phase.

1. Double-click the **AnswersService.cs** file in **Solution Explorer**.

1. Replace the StoreAsync method implementation with the following snippet.

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

1. Open the Git console and enter the following commands.

	````PowerShell
	git add .

	git commit -m "Refactored answer check to a different method"

	git push azure master
	````

1. Open the web site using **Microsoft Edge**.

1. Log-in using the previously created credentials.

	![Logging in](Images/log-in.png?raw=true "Logging in")

	_Logging in_

1. Press **F12** to open the development tools.

1. Select the network tab, make sure that it is recording and clear the session. 

	![Starting Network Recording](Images/network-recording.png?raw=true "Starting Network Recording")

	_Starting Network Recording_

1. Select any of the four answers. Nothing will happen.

1. Show that the web request failed with a 500 error.

	![Showing the 500 error](Images/500-error.png?raw=true "Showing the 500 error")

	_Showing the 500 error_

	> **Speaking point:** This clearly point to the last change. Let's rollback to the previous working version.

1. Do not close the GeekQuiz site, and switch to the browser window/tab that has the Azure Portal open.

1. Open the Web app and select **Continuous deployment** under **PUBLISHING** in the **Settings** blade. Both commits will be listed in the deployment history.

	![Showing the existing deployments](Images/existing-deployment.png?raw=true "Showing the existing deployments")

	_Showing the existing deployments_

1. Select the initial commit and click **REDEPLOY**.

	![Redeploying the initial commit](Images/redeploy.png?raw=true "Redeploying the initial commit")

	_Redeploying the initial commit_

1. When prompted to confirm, click **YES**.

1. Once the deployment is finished, switch back to the web site and press **CTRL + F5**.

1. Click any of the options. The flip animation will take place and the result (correct/incorrect) will be displayed.

---

<a name="summary"></a>
## Summary ##

By completing this demo you should have:

1. Used Entity Framework migrations to update GeekQuiz database to reflect the changes in the object model
1. Deployed a change (bug) to Microsoft Azure using Git
1. Rollback to the last working deployment using the Azure Portal

---
