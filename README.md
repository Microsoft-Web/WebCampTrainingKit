<html lang="en">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Web Camp Training Kit</title>
  <link rel="stylesheet" href="style.css">
</head>
<body>
  <div class="container">
    <div class="jumbotron">
      <h1>Web Camp</h1>
      <p>February 2016 release. Source: <a href="http://aka.ms/webcamps-training-kit">http://aka.ms/webcamps-training-kit</a></p>
      <p>
        <a href="http://aka.ms/CloudCamp-AzureTrial" class="btn btn-success">Sign up for Microsoft Azure</a>
        <a href="http://visualstudio.com" class="btn btn-success">Get Visual Studio 2015</a>
        <a href="http://get.asp.net" class="btn btn-success">Install ASP.NET Core</a>        
      </p>
    </div>
    <div class="panel panel-default">
      <div class="panel-heading">
        <h3 class="panel-title">Suggested agenda for a one day Web Camp</h3>
      </div>
      <div class="panel-body">
        <table class="table table-bordered table-hover">
          <tr>
            <th>Session</th>
            <th>Time (min)</th>
            <th>Activity</th>
          </tr>
          <tr>
            <td>Keynote</td>
            <td>30</td>
            <td><a href='Presentation/01-Keynote/Keynote.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td rowspan="4">Introduction to ASP.NET and Visual Studio 2015 Web Tooling</td>
            <td rowspan="4">90</td>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/ASPNET-and-VS-Web-Tooling.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/GettingStartedASPNETCore/'>Demo - Getting started with ASP.NET Core</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/Visual-Studio-and-Web-Essentials/'>Demo - Visual Studio and Web Essentials</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/TagHelpers/'>Demo - Tag Helpers</a></td>
          </tr>
          <tr>
            <td rowspan="2">Building Web Applications using the latest ASP.NET technologies</td>
            <td rowspan="2">60</td>
            <td><a href='Presentation/03-Build-and-deploy-ASPNET/Build-and-deploy-ASPNET.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/03-Build-and-deploy-ASPNET/GeekQuiz-Build-and-deploy-ASP/'>Demo - Building and deploying an ASP.NET application</a></td>
          </tr>
          <tr>
            <td rowspan="2">Building web front ends for both desktop and mobile using the latest web standards</td>
            <td rowspan="2">60</td>
            <td><a href='Presentation/04-Modern-Web-Front-Ends/Modern-web-front-ends.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/04-Modern-Web-Front-Ends/GeekQuiz-SPA-Interface/'>Demo - Building a SPA interface using Angular 2</a></td>
          </tr>
          <tr>
            <td rowspan="3">API Services for both web and devices</td>
            <td rowspan="3">60</td>
            <td><a href='Presentation/05-HTTP-Services/HTTP-Services.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/05-HTTP-Services/GeekQuiz-Web-API-backend/'>Demo - Overview of Web API backend from GeekQuiz</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/05-HTTP-Services/GeekQuiz-Web-API-Universal-Windows/'>Demo - Building a Universal Windows application front end</a></td>
          </tr>
          <tr>
            <td rowspan="4">Running, improving and maintaining a site in the real world</td>
            <td rowspan="4">60</td>
            <td><a href='Presentation/06-ASPNET-in-Production/ASPNET-in-Production.pptx'>Presentation</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/06-ASPNET-in-Production/Scaling-a-production-website/'>Demo - Scaling a production website</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/06-ASPNET-in-Production/Handling-change-EF-migrations/'>Demo - Handling change (EF migrations, Deployment rollback)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/06-ASPNET-in-Production/Azure-Active-Directory/'>Demo - AAD Authentication</a></td>
          </tr>
          <tr>
            <td>Wrap Up</td>
            <td>30</td>
            <td><a href='Presentation/07-Conclusion/Conclusion.pptx'>Presentation</a></td>
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
          <tr>
            <th>Name</th>
            <th>Time (min)</th>
            <th>Description</th>
          </tr>
          <tr>
            <td><a href='HOL/WebSitesInProduction/'>Web Sites in Production</a></td>
            <td>75</td>
            <td>This hands-on lab will show you the different topics you could encounter when deploying your site to production environments in Microsoft Azure.</td>
          </tr>
          <tr>
            <td><a href='HOL/VSWebTooling/'>Visual Studio 2015 Web Tooling</a></td>
            <td>45</td>
            <td>This hands-on lab will show you how to use the new HTML, CSS and JavaScript editor features included in Web Essentials.</td>
          </tr>
          <tr>
            <td><a href='HOL/IntroToASPNETCore/'>Introduction to ASP.NET Core 1.0</a></td>
            <td>60</td>
            <td>This hands-on lab will introduce you to ASP.NET Core 1.0, a new open-source and cross-platform framework for building modern cloud-based Web applications using .NET.</td>
          </tr>
          <tr>
            <td><a href='HOL/AspNetApiSpa/'>ASP.NET MVC 6 and Single-Page Applications (SPAs)</a></td>
            <td>60</td>
            <td>This hands-on lab will show you how to create a Single-Page Application (SPA) by implementing the service layer with ASP.NET Web API to expose the required endpoints to retrieve the application data. Then, you will build a rich and responsive UI using AngularJS 2 and CSS3 transformation effects.</td>
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
          <tr>
            <th>Session</th>
            <th>Description</th>
            <th>Demos</th>
          </tr>
          <tr>
            <td><a href='Presentation/01-Keynote/Keynote.pptx'>Keynote</a></td>
            <td>This session will overview the Microsoft web platform and introduce fundamental building blocks like Visual Studio 2015 and NuGet. It will include an overview of Microsoft Azure and encourage attendees to sign up so they can "play along" with
              demos throughout the day.</td>
            <td></td>
          </tr>
          <tr>
            <td rowspan="3"><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/ASPNET-and-VS-Web-Tooling.pptx'>Introduction to ASP.NET and Visual Studio 2015 Web Tooling</a></td>
            <td rowspan="3">We'll start out by explaining the One ASP.NET experience in Visual Studio 2015. We'll continue with an introduction to ASP.NET Core. Next, we'll introduce new features for web developers in Visual Studio 2015 and Web Essentials, explaining how Visual
              Studio is the best editor for HTML, CSS and JavaScript as well as your back end code. We'll also look at some new features across the ASP.NET platform including new Bootstrap templates, the new scaffolding system, and the new membership
              and identity system.</td>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/GettingStartedASPNETCore/'>Demo - Getting started with ASP.NET Core</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/TagHelpers/'>Tag Helpers</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/02-ASPNET-and-VS-Web-Tooling/Visual-Studio-and-Web-Essentials/'>Visual Studio and Web Essentials</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/03-Build-and-deploy-ASPNET/Build-and-deploy-ASPNET.pptx'>Building Web Applications using the latest ASP.NET technologies</a></td>
            <td>This session will include a quick introduction to the MVC pattern, then build and deploy an ASP.NET Core website using MVC, Entity Framework Code First, and Microsoft Azure Web Apps. We'll continue building this demo scenario (the GeekQuiz app
              from the BUILD 2013 keynote) throughout the day.</td>
            <td><a href='Presentation/03-Build-and-deploy-ASPNET/GeekQuiz-Build-and-deploy-ASP/'>Building and deploying an ASP.NET application</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/04-Modern-Web-Front-Ends/Modern-web-front-ends.pptx'>Building web front ends for both desktop and mobile using the latest web standards</a></td>
            <td>In this session, we'll dig into the latest web standards - HTML5, CSS3, JavaScript with jQuery, and responsive web design. We'll see how to apply some of the web dev features in Visual Studio 2015 shown earlier in the day with real world application.
              This session extends the GeekQuiz application by building in a single page application (SPA) interface using Angular 2 and CSS3 transitions.</td>
            <td><a href='Presentation/04-Modern-Web-Front-Ends/GeekQuiz-SPA-Interface/'>Building a SPA interface using Angular 2</a></td>
          </tr>
          <tr>
            <td rowspan="2"><a href='Presentation/05-HTTP-Services/HTTP-Services.pptx'>API Services for both web and devices</a></td>
            <td rowspan="2">This session will begin by explaining what HTTP services are and some HTTP API design principles like REST and Hypermedia. We'll build out the HTTP API back end for the GeekQuiz application using ASP.NET Web API, then show how we can leverage
              it with a Windows Store front end.</td>
            <td><a href='Presentation/05-HTTP-Services/GeekQuiz-Web-API-backend/'>Overview of Web API backend from GeekQuiz</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/05-HTTP-Services/GeekQuiz-Web-API-Universal-Windows/'>Building a Universal Windows application front end</a></td>
          </tr>
          <tr>
            <td rowspan="3"><a href='Presentation/06-ASPNET-in-Production/ASPNET-in-Production.pptx'>Running, improving and maintaining a site in the real world</a></td>
            <td rowspan="3">We've built and deployed a site, but that's the easy part. How do we keep it running and make it better? We'll see how to leverage Microsoft Azure to solve three real world challenges: scaling, handling change (without downtime or headaches)
              and managing multiple environments.</td>
            <td><a href='Presentation/06-ASPNET-in-Production/Scaling-a-production-website/'>Scaling a production website</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/06-ASPNET-in-Production/Handling-change-EF-migrations/'>Handling change (EF migrations, Deployment rollback)</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/06-ASPNET-in-Production/Azure-Active-Directory/'>AAD Authentication</a></td>
          </tr>
          <tr>
            <td><a href='Presentation/Conclusion/07-Conclusion.pptx'>Wrap Up</a></td>
            <td>This session will review what's been covered throughout the day and show where to go to learn more.</td>
            <td></td>
          </tr>
        </table>
      </div>
    </div>
</body>
</html>
