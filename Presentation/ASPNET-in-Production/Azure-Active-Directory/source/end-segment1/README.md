README.md
==========

To use this solution you have to follow these steps:

1. Update the **Web.config** file located inside the **GeekQuiz** folder with the Azure AD tenant created in the **Setup** section of this demo:

  ````HTML
  <?xml version="1.0" encoding="utf-8"?>
  <configuration>
    ...
    <appSettings>
      ...
      <add key="ida:FederationMetadataLocation" value="https://login.windows.net/[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/FederationMetadata/2007-06/FederationMetadata.xml" />
      <add key="ida:Realm" value="https://[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/GeekQuiz" />
      <add key="ida:AudienceUri" value="https://[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/GeekQuiz" />
    </appSettings>
    ...
    <system.identityModel>
      <identityConfiguration>
        ...
        <audienceUris>
          <add value="https://[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/GeekQuiz" />
        </audienceUris>
        ...
    </system.identityModel>
    ...
    <system.identityModel.services>
      <federationConfiguration>
        <cookieHandler requireSsl="true" />
        <wsFederation passiveRedirectEnabled="true" issuer="https://login.windows.net/[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/wsfed" realm="https://[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com/GeekQuiz" requireHttps="true" />
      </federationConfiguration>
    </system.identityModel.services>
  </configuration>
  ```

2. Create an application inside the Azure AD tenant created in the **Setup** section of this demo with the following information:

* Name: GeekQuiz
* Sign-on URL: https://localhost:44305/ (or the port used in the solution)
* App ID URL: https://[YOUR-AZURE-AD-DOMAIN]/GeekQuiz
