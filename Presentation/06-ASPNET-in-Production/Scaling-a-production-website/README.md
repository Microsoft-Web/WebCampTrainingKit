<a name="title"></a>
# Scaling a production web site #

---
## Overview ##

In this demo you will go through the steps required to configure auto-scaling in a _Microsoft Azure Web App_ and demostrate this feature using a Visual Studio Load test. Additionally, you will see how to scale a site using _Azure Storage_.

<a id="goals"></a>
### Goals ###

In this demo, you will see how to:

1. Configure auto-scaling for a Web App using the _Microsoft Azure portal_
1. Create and configure a load test project in _Visual Studio_
1. Use _Azure Storage_ to scale a web app

<a name="technologies"></a>
### Key Technologies ###

- [Visual Studio 2015][1]
- [Microsoft Azure][2]

[1]: https://www.visualstudio.com/
[2]: http://azure.microsoft.com/

<a name="setup"></a>
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Create a _Azure Storage account_ (e.g. _geekquiz_), create a blob container named _images_ and upload the **logo-big.png** image located inside the **source\assets** folder.

1. Open the **GeekQuiz.sln** solution located under the **source\end** folder. Find the `<system.webServer>` element in the **web.config** file located in **wwwroot** and change the url of the **Redirect** action using the _Azure Storage account_ you have just created.

	![Updating the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Updating the Rewrite Rule")

	_Updating the Rewrite Rule_

1. Open the **GeekQuiz.sln** solution located under the **source\end** folder in Visual Studio and publish it to a new (free) Azure Web App. In the **Create App Service** dialog box, select an existing Database server or create a new one.

	![Create App Service dialog box](images/create-app-service-dialog-box.png?raw=true "Create App Service dialog box")

	_Create App Service dialog box_

	> **Note:** Make sure to update the **ConnectionString** value located in the **appsettings.json** file with the connection string of your database before deploying.

1. Register a new user account.

1. Open the **StressGeekQuiz.sln** solution located under **source\end**.

1. In the **Solution Explorer**, double-click **WebTest1.webtest**.

1. Select the **http://geekquizdemo.azurewebsites.net** node, as shown in the following figure.

	![Selecting the Loop child node](images/node-selection.png?raw=true "Selecting the Loop child node")

	_Selecting the Loop child node_

1. In the **Properties** window, update the **Url** field to point to the site you just created.

	![Changing the Url](images/url-change.png?raw=true "Changing the Url")

	_Changing the Url_

1. Save all files and close the solution.

<a name="Demo"></a>
## Demo ##
This demo is composed of the following segments:

1. [Configuring auto-scaling](#segment1)
1. [Load testing with Visual Studio](#segment2)
1. [Scaling GeekQuiz using Azure Storage](#segment3)
1. [Auto-scaling result](#segment4)

<a name="segment1"></a>
### Configuring auto-scaling ###

1. Open the [Azure Portal](https://portal.azure.com/) and log in with your credentials.

1. Select the **App Services** tab and filter the list by your site name.

	![filtering App Services](images/filtering-app-services.png?raw=true "filtering App Services")

	_Filtering App Services_

1. Click the app service where you deployed GeekQuiz during the setup steps.

1. Open the **App Service Plan** blade.

	![Opening the App Service Plan blade](images/app-service-plan.png?raw=true "Opening the App Service Plan blade")

	_Opening the App Service Plan blade_

1. Openning

	![Opening the Pricing tier blade](images/pricing-tier.png?raw=true "Opening the Pricing tier blade")

	_Opening the App Service Plan blade_

1. Change the web app's pricing tier to **S1 Standard**.

	![Changing the pricing tier](images/web-app-pricing-tier.png?raw=true "Changing the pricing tier")

	_Changing the pricing tier_

1. Show that there is only one instance.

	![Showing that there is only one instance](images/one-instance.png?raw=true "Showing that there is only one instance")

	_Showing that there is only one instance_

1. Select the **CPU Percentage** metric for scaling.

	![Selecting the CPU metric for scaling](images/cpu-percentage-scaling.png?raw=true "Selecting the CPU Percentage metric for scaling")

	_Selecting the CPU Percentage metric for scaling_

1. Change the Instances to **1**-**3** and Target range to **5**-**25**.

	![Changing the CPU Percentage](images/target-cpu-percentage.png?raw=true "Changing the CPU Percentage")

	_Changing the CPU Percentage_

	> **Speaking point:** Explain that this is done as we cannot ensure that a bigger load is generated with VS.

1. Save the changes.

	> **Note:** Don't close the management portal.


<a name="segment2"></a>
### Load testing with Visual Studio ###

1. Open the **StressGeekQuiz.sln** solution located under **source\end**.

1. In the **Solution Explorer**, double-click **LoadTest1.loadtest**.

1. Run the load test.

	![Running the load test](images/run-load-test.png?raw=true "Running the load test")

	_Running the load test_

1. Open a new instance of Visual Studio.

	> **Speaking point:** Let's take a look at how that solution can be built.

1. Open the **New Project** dialog.

1. Select **Test** in the templates tree, and select **Web Performance and Load Test project**.

	![Creating the new load test project](images/test-project.png?raw=true "")

	_Creating the new load test project_

1. Click **OK**.

1. Right-click **WebTest1** and select **Add Request**.

	![Adding a request](images/add-request.png?raw=true "Adding a request")

	_Adding a request_

1. Select the new node.

1. In the **Properties** window, update the **Url** field to point to the Azure web app.

	![Changing the Url property](images/url-change.png?raw=true "Changing the Url property")

	_Changing the Url property_

1. Right-click **WebTest1** and select **Add Loop...**.

	![Adding a loop](images/add-loop.png?raw=true "Adding a loop")

	_Adding a loop_

1. Select the **For Loop** rule.

	![Selecting the For Loop](images/for-loop.png?raw=true "Selecting the For Loop")

	_Selecting the For Loop_

1. Update the following values:

	1. **Terminating value:** 1000.
	1. **Context Parameter Name:** Iterator.
	1. **Increment Value:** 1.

	![Updating the configuration values](images/values.png?raw=true "Updating the configuration values")

	_Updating the configuration values_

1. Select the GeekQuiz request as the first and last item of the loop.

	![Selecting the items for the loop](images/items.png?raw=true "Selecting the items for the loop")

	_Selecting the items for the loop_

1. Click **OK**.

1. In the **Solution Explorer**, right-click the **WebAndLoadTestProject1** project, expand the **Add** menu and select **Load Test...**. A wizard will start.

	![Adding a Load Test](images/load-test.png?raw=true "Adding a Load Test")

	_Adding a Load Test_

1. In the **New Load Test Wizard** dialog, click **Next**.

1. Select **Do not use think times** and click **Next**.

	![Selecting not to use Think times](images/think-times.png?raw=true "Selecting not to use Think times")

	_Selecting not to use Think times_

1. Change the **User Count** to **250** users and click **Next**.

	![Changing the user count](images/user-count.png?raw=true "Changing the user count")

	_Changing the user count_

1. Select **Based on sequential test order** and click **Next**.

	![Selecting the test mix model](images/text-mix.png?raw=true "Selecting the test mix model")

	_Selecting the test mix model_

1. Click **Add...**.

1. Double-click **Web Test 1** and click **OK**.

	![Adding the test](images/add-tests.png?raw=true "Adding the test")

	_Adding the test_

1. Click **Next**.

1. In the **Network Mix** page, click **Next**.

1. Select **Internet Explorer 11.0** as the browser type and click **Next**.

	![Selecting the Browser Type](images/browser-type.png?raw=true "Selecting the Browser Type")

	_Selecting the Browser Type_

1. In the **Counter Sets** page, click **Next**.

1. Set the load test duration to 10 minutes and click **Finish**.

	![Setting the load test duration](images/load-test-duration.png?raw=true "Setting the load test duration")

	_Setting the load test duration_

1. Close the current instance of **Visual Studio**.

<a name="segment3"></a>
### Scaling GeekQuiz using Azure Storage ###

1. Open _Microsoft Edge_.

1. Navigate to the image that you uploaded to _Azure Storage_ during setup. For example, if the name of the storage account is _geekquiz_ the URL for the image will be _http://geekquiz.blob.core.windows.net/images/logo-big.png_.

	![Showing the logo](images/logo-big.png?raw=true "Showing the logo")

	_Showing the logo_

1. Open the **GeekQuilz.sln** solution located under **source\end**.

1. Open the site's **web.config** file located at **wwwroot** for edition.

1. Find the `<system.webServer>` element.

1. Highlight the URL rewrite rule as shown in the following figure.

	![Highlighting the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Highlighting the Rewrite Rule")

	_Highlighting the Rewrite Rule_

1. Back in Microsoft Edge, open the deployed GeekQuiz site (log in if necessary).

	![Showing the Geek Quiz website with the image](images/geek-quiz-with-image.png?raw=true "Showing the Geek Quiz website with the image")

	_Showing the Geek Quiz website with the image_

1. Press **F12** to launch the development tools, select the **Network** tab and start recording.

	![Starting the network recording](images/start-recording.png?raw=true "Starting the network recording")

	_Starting the network recording_

1. Press **CTRL + F5** to refresh the web page.

1. Once the page has finished loading, switch back to the development tools and show that the request for the image was redirected to _Azure Storage_.

	![Showing the redirect in Dev Tools](images/redirect-in-dev-tools.png?raw=true "Showing the redirect in Dev Tools")

	_Showing the redirect in Dev Tools_

<a name="segment4"></a>
### Auto-scaling result ###

1. Back in the management portal, press **CTRL + F5** to refresh the page.

1. Show that a new instance was automatically deployed.

	![Showing that the new instance](images/new-instance.png?raw=true "Showing that the new instance")

	_Showing that the new instance_

---

<a name="summary"></a>
## Summary ##

By completing this demo you should have:

1. Configured auto-scaling for a website using the _Microsoft Azure portal_
1. Created a load test project in _Visual Studio_
1. Used _Azure Storage_ to scale the static content of a web site

---
