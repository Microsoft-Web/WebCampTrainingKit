<html lang="en">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>AzureReadiness: Web Camp</title>
  <link rel="stylesheet" href="style.css">
</head>
<body>
  <div class="container">
    <div class="jumbotron">
      <h1>Web Camp</h1>
      <p>Mar 31, 2015 release. Source: <a href="http://aka.ms/msftwebcamps">http://aka.ms/msftwebcamps</a></p>
      <p>
        <a href="http://aka.ms/CloudCamp-AzureTrial" class="btn btn-success">Sign up for Microsoft Azure</a>
      </p>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Suggested agenda for a one day Web Camp</h3>
      </div>
      <div class="panel-body">
        <table class="table table-bordered table-hover">
          <colgroup>
            <col>
            <col>
            <col>
          </colgroup>
          <tr>
            <th>Session</th>
            <th>Time (min)</th>
            <th>Activity</th>
          </tr>
          <tr>
            <td>Keynote</td>
            <td>30</td>
            <td><a href='Presentation/Keynote/Keynote.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td rowspan="3">Introduction to ASP.NET and Visual Studio 2013 Web Tooling</td>
            <td rowspan="3">60</td>
            <td><a href='Presentation/ASPNET-and-VS-Web-Tooling/ASPNET-and-VS-Web-Tooling.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-and-VS-Web-Tooling/One-ASP-NET/Demo.md'>Demo - One ASP.NET</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-and-VS-Web-Tooling/Visual-Studio-and-Web-Essentials/DEMO.md'>Demo - Visual Studio and Web Essentials</a></td>
          </tr>
          <tr>
            <td rowspan="2">Building Web Applications using the latest ASP.NET technologies</td>
            <td rowspan="2">60</td>
            <td><a href='Presentation/Build-and-deploy-ASPNET/Build-and-deploy-ASPNET.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Build-and-deploy-ASPNET/GeekQuiz-Build-and-deploy-ASP/Demo.md'>Demo - Building and deploying an ASP.NET application</a></td>
          </tr>
          <tr>
            <td rowspan="2">Building web front ends for both desktop and mobile using the latest web standards</td>
            <td rowspan="2">60</td>
            <td><a href='Presentation/Modern-Web-Front-Ends/Modern-web-front-ends.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Modern-Web-Front-Ends/GeekQuiz-SPA-Interface/DEMO.md'>Demo - Building a SPA Interface using EmberJS</a></td>
          </tr>
          <tr>
            <td rowspan="4">API Services for both web and devices</td>
            <td rowspan="4">60</td>
            <td><a href='Presentation/HTTP-Services/HTTP-Services.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Web-API-backend/Demo.md'>Demo - Overview of Web API backend from GeekQuiz</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Excel-front-end/Demo.md'>Demo - Building an Excel front end (using apps for Office)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Web-API-Windows-Store/DEMO.md'>Demo - Building a Windows Store front end</a></td>
          </tr>
          <tr>
            <td rowspan="4">Running, improving and maintaining a site in the real world</td>
            <td rowspan="4">60</td>
            <td><a href='Presentation/ASPNET-in-Production/ASPNET-in-Production.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-in-Production/Scaling-a-production-website/DEMO.md'>Demo - Scaling a production website</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-in-Production/Handling-change-EF-migrations/DEMO.md'>Demo - Handling change (EF migrations, Deployment rollback)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-in-Production/Azure-Active-Directory/Demo.md'>Demo - AAD Authentication</a></td>
          </tr>
          <tr>
            <td rowspan="2">Real-time Communications with SignalR</td>
            <td rowspan="2">60</td>
            <td><a href='Presentation/Realtime/Realtime.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Realtime/GeekQuiz-Real-time-charts/DEMO.md'>Demo -Real-time charts in the GeekQuiz application</a></td>
          </tr>
          <tr>
            <td>Wrap Up</td>
            <td>30</td>
            <td><a href='Presentation/Conclusion/Conclusion.pptx'>Presentation</a></td>
          </tr>
        </table>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Hands on Labs</h3>
      </div>
      <div class="panel-body">
        <table class="table table-bordered table-hover">
          <colgroup>
            <col>
            <col>
            <col>
          </colgroup>
          <tr>
            <th>Name</th>
            <th>Time (min)</th>
            <th>Description</th>
          </tr>
          <tr>
            <td><a href='HOL/WebSitesInProduction/HOL.md'>Web Sites in Production</a></td>
            <td>75</td>
            <td>This hands-on lab will show you the different topics you could encounter when deploying your site to production environments in Microsoft Azure.</td>
          </tr>
          <tr>
            <td><a href='HOL/VSWebTooling/HOL.md'>Visual Studio 2013 Web Tooling</a></td>
            <td>45</td>
            <td>This hands-on lab will show you how to use the new HTML, CSS and JavaScript editor features including in Web Essentials.</td>
          </tr>
          <tr>
            <td><a href='HOL/RealTimeSignalR/HOL.md'>Real-Time SignalR</a></td>
            <td>60</td>
            <td>This hands-on lab will show you how to add SignalR to your application and send notifications from the server to your connected clients using Hubs. Additionally, you will learn how to scale out your application by using a backplane component when your application is deployed in multiple IIS instances.</td>
          </tr>
          <tr>
            <td><a href='HOL/BringingTogetherOneAspNet/HOL.md'>Bringing Together One ASP.NET</a></td>
            <td>60</td>
            <td>Visual Studio 2013 introduces a new unified project system which lets you build an application and use all the ASP.NET technologies in one project. This feature eliminates the need to pick one technology at the start of a project and stick with it, and instead encourages the use of multiple ASP.NET frameworks within one project.</td>
          </tr>
          <tr>
            <td><a href='HOL/AspNetWebApiSpa/HOL.md'>ASP.NET Web API and Single-Page Applications (SPAs)</a></td>
            <td>60</td>
            <td>This hands-on lab will show you how to create an Single-Page Application (SPA) by implementing the service layer with ASP.NET Web API to expose the required endpoints to retrieve the application data. Then, you will build a rich and responsive UI using AngularJS and CSS3 transformation effects.</td>
          </tr>
        </table>
      </div>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Full presentation list</h3>
      </div>
      <div class="panel-body">
        <table class="table table-bordered table-hover">
          <colgroup>
            <col>
            <col>
            <col>
          </colgroup>
          <tr>
            <th>Session</th>
            <th>Description</th>
            <th>Demos</th>
          </tr>
          <tr>
            <td><a href='Presentation/Keynote/Keynote.pptx'>Keynote</a></td>
            <td>This session will overview the Microsoft web platform and introduce fundamental building blocks like Visual Studio 2013 and NuGet. It will include an overview of Microsoft Azure and encourage attendees to sign up so they can "play along" with
              demos throughout the day.</td>
            <td></td>
          </tr>
          <tr>
            <td rowspan="2"><a href='Presentation/ASPNET-and-VS-Web-Tooling/ASPNET-and-VS-Web-Tooling.pptx'>Introduction to ASP.NET and Visual Studio 2013 Web Tooling</a></td>
            <td rowspan="2">We'll start out by explaining the One ASP.NET experience in Visual Studio 2013, showing how to create hybrid web applications. Next, we'll introduce new features for web developers in Visual Studio 2013 and Web Essentials, explaining how Visual
              Studio is the best editor for HTML, CSS and JavaScript as well as your back end code. We'll also look at some new features across the ASP.NET platform including new Bootstrap templates, the new scaffolding system, and the new membership
              and identity system.</td>
            <td><a href='Presentation/ASPNET-and-VS-Web-Tooling/One-ASP-NET/Demo.md'>One ASP.NET</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-and-VS-Web-Tooling/Visual-Studio-and-Web-Essentials/DEMO.md'>Visual Studio and Web Essentials</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Build-and-deploy-ASPNET/Build-and-deploy-ASPNET.pptx'>Building Web Applications using the latest ASP.NET technologies</a></td>
            <td>This session will include a quick introduction to the MVC pattern, then build and deploy a website using ASP.NET MVC, Entity Framework Code First, and Microsoft Azure Web Apps. We'll continue building this demo scenario (the GeekQuiz app
              from the BUILD 2013 keynote) throughout the day.</td>
            <td><a href='Presentation/Build-and-deploy-ASPNET/GeekQuiz-Build-and-deploy-ASP/Demo.md'>Building and deploying an ASP.NET application</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Modern-Web-Front-Ends/Modern-web-front-ends.pptx'>Building web front ends for both desktop and mobile using the latest web standards</a></td>
            <td>In this session, we'll dig into the latest web standards - HTML5, CSS3, JavaScript with jQuery, and responsive web design. We'll see how to apply some of the web dev features in Visual Studio 2013 shown earlier in the day with real world application.
              This session extends the GeekQuiz applicaiton by building in a single page application (SPA) interface using Ember.js and CSS3 transitions.</td>
            <td><a href='Presentation/Modern-Web-Front-Ends/GeekQuiz-SPA-Interface/DEMO.md'>Building a SPA Interface using EmberJS</a></td>
          </tr>
          <tr>
            <td rowspan="3"><a href='Presentation/HTTP-Services/HTTP-Services.pptx'>API Services for both web and devices</a></td>
            <td rowspan="3">This session will begin by explaining what HTTP services are and some HTTP API design principles like REST and Hypermedia. We'll build out the HTTP API back end for the GeekQuiz application using ASP.NET Web API, then show how we can leverage
              it with a Windows Store front end and apps for Office in Excel.</td>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Web-API-backend/Demo.md'>Overview of Web API backend from GeekQuiz</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Excel-front-end/Demo.md'>Building an Excel front end (using apps for Office)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/HTTP-Services/GeekQuiz-Web-API-Windows-Store/DEMO.md'>Building a Windows Store front end</a></td>
          </tr>
          <tr>
            <td rowspan="3"><a href='Presentation/ASPNET-in-Production/ASPNET-in-Production.pptx'>Running, improving and maintaining a site in the real world</a></td>
            <td rowspan="3">We've built and deployed a site, but that's the easy part. How do we keep it running and make it better? We'll see how to leverage Microsoft Azure to solve three real world challenges: scaling, handling change (without downtime or headaches)
              and managing multiple environments.</td>
            <td><a href='Presentation/ASPNET-in-Production/Scaling-a-production-website/DEMO.md'>Scaling a production website</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-in-Production/Handling-change-EF-migrations/DEMO.md'>Handling change (EF migrations, Deployment rollback)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/ASPNET-in-Production/Azure-Active-Directory/Demo.md'>AAD Authentication</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Realtime/Realtime.pptx'>Real-time Communications with SignalR</a></td>
            <td>ASP.NET SignalR enables real-time communications between your application and each connected client - browsers or otherwise. We'll learn how to write code for SignalR, then use it to add real-time HTML5 charts to the GeekQuiz application,
              power interactive games and more.</td>
            <td><a href='Presentation/Realtime/GeekQuiz-Real-time-charts/DEMO.md'>Real-time charts in the GeekQuiz application</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Conclusion/Conclusion.pptx'>Wrap Up</a></td>
            <td>This session will review what's been covered throughout the day and show where to go to learn more.</td>
            <td></td>
          </tr>
        </table>
      </div>
    </div>
</body>
</html>
