README.md
==========

To use this solution you have to follow these steps:

1. Right-click on the **GeekQuiz** project and select **Manage User Secrets** to open the **secrets.json** file.

1. Update the **secrets.json** file with the Azure AD tenant created in the **Setup** section of this demo:

	````JavaScript
	{
	  "Authentication": {
		 "AzureAd": {
			"ClientId": "[YOUR-AZURE-AD-CLIENT-ID]",
			"AADInstance": "https://login.microsoftonline.com/",
			"PostLogoutRedirectUri": "https://localhost:44329/",
			"Domain": "[YOUR-AZURE-AD-DOMAIN-NAME].onmicrosoft.com",
			"TenantId": "[YOUR-AZURE-AD-TENANT-ID]"
		 }
	  }
	}
	````

2. Create an application inside the Azure AD tenant created in the **Setup** section of this demo with the following information:

* Name: GeekQuiz
* Sign-on URL: https://localhost:44329/ (or the port used in the solution)
* App ID URL: https://[YOUR-AZURE-AD-DOMAIN]/GeekQuiz
