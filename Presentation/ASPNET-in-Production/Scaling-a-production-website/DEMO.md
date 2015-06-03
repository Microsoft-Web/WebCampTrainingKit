<a name="title" />
# Scaling a production web site #

---
## Overview ##

In this demo you will go through the steps required to configure auto-scaling in a _Windows Azure Web Site_ and demostrate this feature using a Visual Studio Load test. Additionally, you will see how to scale a site using _Windows Azure Storage_.

<a id="goals" />
### Goals ###

In this demo, you will see how to:

1. Configure auto-scaling for a website using the _Windows Azure portal_
1. Create and configure a load test project in _Visual Studio_
1. Use _Windows Azure Storage_ to scale a website

<a name="technologies" />
### Key Technologies ###

- [Microsoft Visual Studio 2013][1]
- [Windows Azure][2]

[1]: http://www.microsoft.com/visualstudio/eng/visual-studio-2013
[2]: http://www.windowsazure.com

<a name="setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Follow the steps detailed in [this link](http://docs.nuget.org/docs/creating-packages/hosting-your-own-nuget-feeds) to setup local sources for the following directories:

	1. **C:\Program Files (x86)\Microsoft Web Tools\Packages**
	1. **C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Stack 5\Packages**

	![NuGet Sources](images/nuget-sources.png?raw=true)

1. Create a _Windows Azure storage account_ (e.g. _geekquizstorage_), create a blob container named _images_ and upload the **logo-big.png** image located inside the **source\assets** folder.

1. Open the **GeekQuiz.sln** solution located under the **source\end** folder. Find the '<system.webServer>' element in the **web.config** file and change the url of the **Redirect** action using the _Windows Azure storage account_ you have just created.

	![Updating the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Updating the Rewrite Rule")

	_Updating the Rewrite Rule_

1. Create a (free) web site in Windows Azure and deploy the web site that is part of the **GeekQuiz.sln** solution located under the **source\end** folder.

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

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Configuring auto-scaling](#segment1)
1. [Load testing with Visual Studio](#segment2)
1. [Scaling GeekQuiz using Windows Azure storage](#segment3)
1. [Auto-scaling result](#segment4)

<a name="segment1" />
### Configuring auto-scaling ###

1. Open the [Azure Management portal](https://manage.windowsazure.com/) and log in with your credentials.

1. Select the **WEB SITES** tab.

	![Opening the Web site tab](images/web-sites.png?raw=true "Opening the Web site tab")
	
	_Opening the Web site tab_

1. Click the website where you deployed GeekQuiz during the setup steps.

1. Open the scaling configuration page.

	![Opening the Scaling configuration page](images/scale.png?raw=true "Opening the Scaling configuration page")

	_Opening the Scaling configuration page_

1. Change the web site's mode to **Standard**.

	![Changing the web site's mode to Standard](images/web-site-mode.png?raw=true "Changing the web site's mode to Standard")

	_Changing the web site's mode to Standard_

1. Clear all other web sites from the list of sites to be updated.

	![Clearing all other Web Sites](images/clear-web-sites.png?raw=true "Clearing all other Web Sites")

	_Clearing all other Web Sites_

1. Show that there is only one instance.

	![Showing that there is only one instance](images/one-instance.png?raw=true "Showing that there is only one instance")

	_Showing that there is only one instance_

1. Select the **CPU** metric for scaling.

	![Selecting the CPU metric for scaling](images/cpu-scaling.png?raw=true "Selecting the CPU metric for scaling")

	_Selecting the CPU metric for scaling_

1. Change the target CPU to **20**-**40**.

	![Changing the target CPU](images/target-cpu.png?raw=true "Changing the target CPU")

	_Changing the target CPU_

	> **Speaking point:** Explain that this is done as we cannot ensure that a bigger load is generated with VS.

1. Save the changes. 
	
	> **Note:** Don't close the management portal.


<a name="segment2" />
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

1. In the **Properties** window, update the **Url** field to point to the Azure web site.

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

1. Select **Internet Explorer 10.0** as the browser type and click **Next**.

	![Selecting the Browser Type](images/browser-type.png?raw=true "Selecting the Browser Type")

	_Selecting the Browser Type_

1. In the **Counter Sets** page, click **Next**.

1. Set the load test duration to 5 minutes and click **Finish**.

	![Setting the load test duration](images/load-test-duration.png?raw=true "Setting the load test duration")

	_Setting the load test duration_

1. Close the current instance of **Visual Studio**.

<a name="segment3" />
### Scaling GeekQuiz using Windows Azure storage ###

1. Open _Internet Explorer_.

1. Navigate to the image that you uploaded to _Windows Azure Storage_ during setup. For example, if the name of the storage account is _geekquizstorage_ the URL for the image will be _http://geekquizstorage.blob.core.windows.net/images/logo-big.png_.

	![Showing the logo](images/logo-big.png?raw=true "Showing the logo")

	_Showing the logo_

1. Open the **GeekQuilz.sln** solution located under **source\end**.

1. Open the site's **web.config** file for edition.

1. Find the `<system.webServer>` element.

1. Highlight the URL rewrite rule as shown in the following figure.

	![Highlighting the Rewrite Rule](images/highlighting-rewrite-rule.png?raw=true "Highlighting the Rewrite Rule")

	_Highlighting the Rewrite Rule_

1. Back in Internet Explorer, open the deployed GeekQuiz site (log in if necessary).

	![Showing the Geek Quiz website with the image](images/geek-quiz-with-image.png?raw=true "Showing the Geek Quiz website with the image")

	_Showing the Geek Quiz website with the image_

1. Press **F12** to launch the development tools, select the **Network** tab and start recording.

	![Starting the network recording](images/start-recording.png?raw=true "Starting the network recording")

	_Starting the network recording_

1. Press **CTRL + F5** to refresh the web page.

1. Once the page has finished loading, switch back to the development tools and show that the request for the image was redirected to _Windows Azure storage_.

	![Showing the redirect in Dev Tools](images/redirect-in-dev-tools.png?raw=true "Showing the redirect in Dev Tools")

	_Showing the redirect in Dev Tools_

<a name="segment4" />
### Auto-scaling result ###

1. Back in the management portal, press **CTRL + F5** to refresh the page.

1. Show that a new instance was automatically deployed.

	![Showing that the new instance](images/new-instance.png?raw=true "Showing that the new instance")

	_Showing that the new instance_

---

<a name="summary" />
## Summary ##

By completing this demo you should have:

1. Configured auto-scaling for a website using the _Windows Azure portal_
1. Created a load test project in _Visual Studio_
1. Used _Windows Azure Storage_ to scale the static content of a web site

---