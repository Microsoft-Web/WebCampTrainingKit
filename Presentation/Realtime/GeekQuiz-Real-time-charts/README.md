<a name="title" />
# Real-time charts in the GeekQuiz application #

---
<a name="Overview" />
## Overview ##
This demo shows how you can leverage SignalR to see realtime statistics of a website.

<a id="goals" />
### Goals ###
In this demo, you will see how:

1. Statistics are generated in the StatisticsService
1. SignalR Hub pushes updates to the front end (Statistics.cshtml)
1. To display realtime updates as charts

<a name="technologies" />
### Key Technologies ###

* [SignalR](http://signalr.net/)

<a name="setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Open Visual Studio 2015.
1. Open the **GeekQuiz.sln** solution located inside the **source\end** folder.
1. Close all open files in Visual Studio.

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Code walkthrough](#segment1)
1. [Real time charts](#segment2)

<a name="segment1" />
### Code walkthrough ###

1. In the **Solution Explorer**, expand the **Hubs** folder and double-click **StatisticsHub.cs**.

1. In the **Solution Explorer**, expand the **Services** folder and double-click **StatisticsService.cs**.

1. Select the `var hubContext = GlobalHost.ConnectionManager.GetHubContext<StatisticsHub>();` as shown in the following figure.

	![Selecting the call to GetHubContext](Images/gethubcontext.png?raw=true "Selecting the call to GetHubContext")

	_Selecting the call to GetHubContext_

1. Highlight the `updateStatistics` method call.

	![Highlighting the updateStatistics method call](Images/updatestatistics.png?raw=true "Highlighting the updateStatistics method call")

	_Highlighting the updateStatistics method call_

	> **Speaking point:** Explain that this takes advantage of C# `dynamic` type and results in events with the name of the method, to which clients can listen.

1. Click `NotifyUpdates` and press **SHIFT + F12** to find all references to the method.

1. Double-click the `await this.statisticsService.NotifyUpdates();` reference in the **Find Symbol Results** window.

	![Navigating to the NotifyUpdates caller](Images/notifyupdatesreference.png?raw=true "Navigating to the NotifyUpdates caller")

	_Navigating to the NotifyUpdates caller_

	> **Speaking point:** We are updating the stats for all clients every time a question is answered. If we were handling a large number of answers and clients simultaneously we could batch updates.

1. Press **CTRL + ,**, type _Statistics.cshtml_ and press **Enter**.

1. Scroll to the bottom of the file.

1. Highlight the `var hub = connection.createHubProxy("StatisticsHub");` line as shown in the following figure.

	![Highlighting the call to createHubProxy](Images/createhubproxy.png?raw=true "Highlighting the call to createHubProxy")

	_Highlighting the call to createHubProxy_

1. Highlight the code that adds the listener for the `"updateStatistics"` event.

	![Highlighting the updateStatistics listener code](Images/updatestatisticslistener.png?raw=true "Highlighting the updateStatistics listener code")

	_Highlighting the updateStatistics listener code_

	> **Speaking point:** Note that the event we are listening to has the same name as the method we invoke when updating the statistics.

1. Highlight the `connection.start();` line.


<a name="segment2" />
### Real time charts ###

1. Press **F5** to start running the web site.

1. If prompted to log-in, do so.

1. Once the site has started, open a new browser window, and navigate to **/Home/Statistics**.

	![Navigating to the statistics view](Images/statistics.png?raw=true "Navigating to the statistics view")

	_Navigating to the statistics view_

1. Place both windows side by side.

1. Answer questions in one window. The charts and numbers in the other one will update automatically.

	![Showing how charts and numbers are automatically updated](Images/automatic-update.png?raw=true "Showing how charts and numbers are automatically updated")

	_Showing how charts and numbers are automatically updated_


---
<a name="Summary" />
## Summary ##

By completing this demo you should have understood how you can leverage SignalR to push realitme statistics to a page in a web site.

---
