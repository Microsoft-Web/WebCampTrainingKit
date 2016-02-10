<a name="title"></a>
# Azure Active Directory Authentication #

---
<a name="Overview"></a>
## Overview ##

1. File / New / Configure Azure Active Directory in a new project.
1. Show the GeekQuiz solution with Azure Active Directory Authentication.
1. Deploy and show portal configuration.

<a id="goals"></a>
### Goals ###
In this demo, you will see how to:

1. Create an application in Visual Studio that is automatically integrated with an Azure Active Directory tenant.
1. Deploy an existing application using Visual Studio to an Azure Web App and have it automatically integrate with an Azure Active Directory tenant.

<a name="technologies"></a>
### Key Technologies ###

- [Azure Active Directory](http://azure.microsoft.com/en-us/services/active-directory/)
- [Visual Studio 2015](https://www.visualstudio.com/)

<a name="Setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Create a new [Azure Active Directory tenant](https://azure.microsoft.com/en-us/documentation/articles/active-directory-howto-tenant/).

1. Create a new Web App in Azure.

1. Configure an Azure SQL Database following the steps provided in [this link](https://azure.microsoft.com/en-us/documentation/articles/sql-database-get-started/). Copy the ADO.NET connection string value.

1. In the **Application settings** of your new Web App, update the connection string key for the DB to _DefaultConnection_ and value copied from previous step. Save the changes.

	![Default Connection](images/default-connection.png?raw=true "Default Connection")

	_Default connection_

1. Download the publish profile. This is required for segment #2.

	> **Important:** At the time of writing, you can only create one AD per subscription and it cannot be deleted.

1. Open Visual Studio 2015.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Adding a new website to an organization](#segment1).
1. [Running the organization's GeekQuiz](#segment2).

<a name="segment1"></a>
### Adding a new website to an organization ###

1. Open the **File / New / Project** dialog and select the **Visual C# / Web** templates.

1. Select the **ASP.NET Web Application** template, name the application _GeekQuiz_ and click **OK**.

	![Creating a new project](images/creating-a-new-project.png?raw=true "Creating a new project")

	_Creating a new project_

1. Select the **Web Application** template under **ASP.NET 5 Templates**.

1. Click **Change Authentication**.

	![Updating the authentication method](images/updating-the-authentication-method.png?raw=true "Updating the authentication method")

	_Updating the authentication method_

	> **Speaking Point:** VS tooling allows you to enable AAD authentication easily. All you need is to provide your tenant domain name and administrator credentials, the two-way trust between your AAD tenant and your web application is automatically configured.

1. In the **Change Authentication** dialog box, select **Work And School Accounts**.

	![Selecting the Work And School Accounts option](images/selecting-organizational-accounts.png?raw=true "Selecting the Work And School Accounts option")

	_Selecting Work And School Accounts_

1. 	Expand the first combo box to show the different options.

	![Showing the organization account types](images/showing-the-organization-types.png?raw=true "Showing the organization account types")

	_Showing the organization account types_

1. Enter your domain (e.g.: "mydomainname.onmicrosoft.com") as **Domain**.

	![Setting the domain name](images/updating-the-domain.png?raw=true "TODO")

	_Setting the domain name_

1. Click the button with the chevron to see more options.

	![Showing more options](images/showing-more-options.png?raw=true "Showing more options")

	_Showing more options_

1. Click **OK** to continue.

	![Completing the authentication update](images/completing-the-authentication-update.png?raw=true "Completing the authentication update")

	_Completing the authentication update_

1. Sign in using an admin account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

	![Signing in with an organization admin account](images/signing-in-with-an-organization-admin-account.png?raw=true "Signing in with an organization admin account")

	_Signing in with an organization admin account_

1. Back in the **New ASP.Net Project** dialog box, click **OK**.

	![Completing the project creation](images/creating-the-project.png?raw=true "Completing the project creation")

	_Completing the project creation_

	> **Speaking Point:** VS tooling configures two-way trust relationship between your app and your AAD tenant. Your app is registered as a Relying Party in the tenant; and the tenant is configured as an Identity Provider for the app.

1. Press **CTRL+F5** to run the web site.

1. If a certificate error is displayed, click **Continue to this website**.

1.	Sign in using a user account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

	![Signing in using one of the organization's user account](images/logging-in-with-an-organization-user.png?raw=true "Signing in using one of the organization's user account")

	_Signing in using one of the organization's user account_

1. Show that you are logged as the organization's user.

	![Showing that you are logged as the organization's user](images/showing-the-organization-user-logged.png?raw=true "Showing that you are logged as the organization's user")

	_Showing that you are logged as the organization's user_

1. Close the browser.

<a name="segment2"></a>
### Running the organization's GeekQuiz ###

1. Open the **GeekQuiz.sln** solution located under **source\end-segment2**.

1. Right-click the **GeekQuiz** project and select **Publish**.

	![Publishing the Website](images/publishing-the-site.png?raw=true "Publishing the Website")

	_Publishing the Website_

1. In the **Publish Web** dialog box, click **Import**.

	![Importing the publish profile](images/selecting-the-profile.png?raw=true "Importing the publish profile")

	_Importing the publish profile_

1. In the **Import Publish Settings** dialog, click **Browse...** to select the previously downloaded publish profile file and click **OK**.

	![Selecting the publish profile file](images/selecting-import-publish-profile.png?raw=true "Selecting the publish profile file")

	_Selecting the publish profile file_

1. Back in the **Publish Web** dialog, click **Publish**.

	![Reviewing the connection settings to deploy](images/reviewing-the-connection-settings-to-deploy.png?raw=true "Reviewing the connection settings to deploy")

	_Reviewing the connection settings to deploy_

	> **Note:** If Visual Studio prompt you with the Sign in dialog box, just sign in using an admin account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

	> ![Signing in with an organization admin account](images/signing-in-with-an-organization-admin-account.png?raw=true "Signing in with an organization admin account")

	> _Signing in with an organization admin account_

1. Once the deployment is completed and the browser is opened, sign in using an admin account for your organization (e.g.: "admin@mydomainname.onmicrosoft.com")

	![Signing in with an organization admin account](images/signing-in-with-an-organization-admin-account-published-site.png?raw=true "Signing in with an organization admin account")

	_Signing in with an organization admin account_

1. In the Authorization page, click **Accept**.

	![Accepting the application permissions](images/accepting-the-permissions.png?raw=true "Accepting the application permissions")

	_Accepting the application permissions_

1. Show that you are logged as the organization's user.

	![Showing that you are logged as the organization's user](images/showing-the-geekquiz-with-ad.png?raw=true "Showing that you are logged as the organization's user")

	_Showing that you are logged as the organization's user_

1. Switch to the _Azure Classic Portal_.

1. Navigate to the **Active Directory** section and select the one used for this demo.

	![Selecting your active directory](images/selecting-your-active-directory.png?raw=true "Selecting your active directory")

	_Selecting your active directory_

1. Navigate to the **USERS** tab and show the users that you used for the demo.

	![Showing the organization's users](images/showing-the-organization-users.png?raw=true "Showing the organization's users")

	_Showing the organization's users_

1. Navigate to the **APPLICATIONS** tab and filter them by **Application that my company owns** to show the new two applications, which were automatically created.

	![Showing the organization's applications](images/showing-the-geekquiz-application-in-the-portal.png?raw=true "Showing the organization's applications")

	_Showing the organization's applications_

---

<a name="summary"></a>
## Summary ##

By completing this demo you learned how to integrate your website with an existing Azure Active Directory tenant.

---
