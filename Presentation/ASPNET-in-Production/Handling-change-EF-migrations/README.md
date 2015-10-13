<a name="title" />
# Handling change (EF migrations, Deployment rollback) #

---
<a name="Overview" />
## Overview ##

In this demo you go through the steps of enabling Entity Framework migrations to GeekQuiz database, changing the model and understanding how those changes are reflected in the database. Additionally, you will deploy to Azure using Git and perform a rollback to the previous deployment from Azure Preview Portal.

<a id="goals" />
### Goals ###

In this demo, you will see how to:

1. Enable Entity Framework migrations on an existing database
1. Update the object model and database accordingly using Entity Framework migrations
1. Deploy to Microsoft Azure using Git
1. Rollback to a previous deployment using the Azure Preview Portal

<a name="technologies" />
### Key Technologies ###

1. [Entity Framework 6](http://www.asp.net/entity-framework).
1. [Git](http://git-scm.com/).

<a name="setup" />
### Setup and Configuration ###
Follow these steps to setup your environment for the demo.

1. Copy the contents of the **source\begin** folder to a separate directory. Both demo segments start from the same begin solution, so you will need to remember the directory to where you copied the files for the second segment.
1. Configure an Azure SQL Database following the steps provided in [this link](https://azure.microsoft.com/en-gb/documentation/articles/sql-database-get-started/). Copy the ADO.NET connection string value.
1. Create a new **Web App** in Azure Preview Portal.

	![Create Web App](Images/createwebapp.png?raw=true "Create Web App")

	_Create Web App_

1. In the **Application settings** of your new Web App, update the connection string key for the DB to _DefaultConnection_ and value copied from previous step. Save the changes.

	![Default Connection](Images/default-connection.png?raw=true "Default Connection")

	_Default connection_

1. Configure the **GeekQuiz** web site to support [Publishing with Git](https://azure.microsoft.com/documentation/articles/web-sites-publish-source-control/) and push the duplicate of the begin solution to the remote repository.
1. Leave the Azure Preview Portal in a separate browser window/tab.
1. Navigate to the created site and register an account.
1. Open Visual Studio 2013.
1. Open the **GeekQuiz.sln** solution located under **source\begin**.
1. Run the solution and register a new user in order to generate the SQL database.
1. In Visual Studio, close all open files.
1. Make sure that you have an Internet connection, as this demo requires it to push to a remote git repository.
1. Open the **Package Manager Console** and dock it in the bottom panel.
1. Open the **SQL Server Object Explorer** and dock it in the left panel.
1. Open the **Solution Explorer** and dock it in the right panel.

After completing the aforementioned steps, the resulting Visual Studio layout should be similar to the one shown in the following figure.
	
![Visual Studio Layout](Images/vslayout.png?raw=true "Visual Studio Layout")

_Visual Studio Layout_ 

<a name="Demo" />
## Demo ##
This demo is composed of the following segments:

1. [Migrations](#segment1)
1. [Deployment rollback](#segment2)

<a name="segment1" />
### Migrations ###

1. In **SQL Server Object Explorer**, expand the different nodes until the columns of the **dbo.TriviaQuestions** table are displayed. This is shown in the following figure.

	![Trivia Questions Columns](Images/trivia-questions-columns.png?raw=true "Trivia Questions Columns")

	_Trivia Questions Columns_

1. In the **Package Manager Console**, enter the following command and then press **Enter**. An initial migration based on the existing model will be created.

	<!-- mark:1 -->
	````PowerShell
	Enable-Migrations -ContextTypeName GeekQuiz.Models.TriviaContext
	````

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

1. In the **Package Manager Console**, enter the following command and then press **Enter**. A new migration will be created.

	<!-- mark:1 -->
	````PowerShell
	Add-Migration QuestionHint
	````

	> **Speaking point:** Explain that the migration only accounts for the diff between the current model and the one from the previous migration. The `Up` method applies the changes to the target database and the `Down` method reverts those changes.

1. In the **Package Manager Console**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	Update-Database -Verbose
	````

1. Highlight the generated SQL statement that is displayed as part of the command's output, as highlighted in the following code snippet.

	<!-- mark:8 -->
	````PowerShell
	PM> Update-Database -Verbose
	Using StartUp project 'GeekQuiz'.
	Using NuGet project 'GeekQuiz'.
	Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
	Target database is: 'GeekQuiz' (DataSource: (LocalDb)\v11.0, Provider: System.Data.SqlClient, Origin: Configuration).
	Applying explicit migrations: [201309232022545_QuestionHint].
	Applying explicit migration: 201309232022545_QuestionHint.
	ALTER TABLE [dbo].[TriviaQuestions] ADD [Hint] [nvarchar](max)
	INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
	VALUES (N'201309232022545_QuestionHint', N'GeekQuiz.Models.TriviaContext',  0x1F8B0800000000000400DD5ACD72DB3610BE77A6EFC0E1A9ED4C44DBB9B41E291947B6D34C6B3B31955C3330B992310141160015A9AFD6431FA9AFD0A5F80FFEEB27567C93A0DDC562F7DB5DF0A3FEFBE7DFF1EB95C78C2508497D3E314F4727A601DCF15DCA17133354F317BF9AAF5FFDF8C3F8CAF556C6A754EE6524879A5C4ECC47A58273CB92CE2378448E3CEA085FFA7335727CCF22AE6F9D9D9CFC669D9E5A80264CB46518E3FB902BEAC1E60B7E9DFADC81408584DDF82E3099ACE32FF6C6AA714B3C9001716062BE05F8F221A47F8F6251D3B86094A01B36B0B96910CE7D45143A79FE5182AD84CF1776800B84CDD601A0DC9C300989F3E7B978DF739C9C45E7B072C5ADE2606627C4335E612CD43A726F73CE8939137449C905975F41142551F60F58971670E9BDF003106A7D0FF344FF9D6B1A5659CFD21533B5824EE4027EE2EAE59969DC868C91070659C40AA1B5952FE02D70104481FB9E2805824736607394CAEEDA5E981991EF874942B099C60D59FD097CA11E27267E348D6BBA02375D497CF8C8296213959408A16B9BBB2072B6FB60ED563E8420B7B2734B9674B1899766314E6FEC9D69DC03DB08C9471AC4281E15F3FFB92C7D2D7CEFDE671A484A429F6D3F140EFA33F3BB2467442C40953D1F5B391E7BA034716C0B9416036B1D06D45BE7EE098B634615833DD4C6D023CAA92F04382ADDFA8D8FE0217C679CA73968417A8A464D5EC77AAD5803DAEB65F780F7CCBD67D8979F087ABF53AEF63F0C1A611943431E0A8F29C6FAE031C56E1F3C5E48E93B74E3704D03D69D2DC7E28ABBC6804A8A33A1C7039312324503461D746F62FE520979BF6DB200E9DBE4912E6F746AEAA575C72F818102E3C289EF6E53221DE2564180B174CB2B588D20A272200C6F9D520982E8AB962EE50E0D08EB7F1CCD44CFFA8F5CCC36D37FB984007854BAFD73D7C78BD6B96B659B6A81EC8ADBD82A00B40F6EEBAE37ED706ABDEBE8604A6ECF8331DB764DEA5918C782D796A3EC8A93C3C1BB25C907713A7F48F806B5107776D451A801A2540FD12AAC54A506220D1B544DEDE008CB47452DF82B58AF3396CDC3066329C87B194BE3DF6C2EEFF29AC142CCEA5DAC0CE482468FF9ADA777D850CC8E5B095B0537C3C660C57021847A772887A877F86A9F249B82D7D9970776E6CAF932F07606AEAD17F7CD474BD0D29B56568F39ED64C5BC53CA4F590D04D5F8860401DE570B8455B262D8315B357D610F2788BCD886E5C81A9E28F336DB092FFD6401DAAFB8357A7A4D85549744910712DD98A7AE5711EBD57DD2BDEA9A50358B69DDA75AD1E7585323EFCAEDAADAAE1303D7783E2F1A149BE79B064055D537F4216144D43C524D7D167ABC796E356BA7E455D142BAD6DF4A3E768A769A8751B3A5E2C42BDAEA98849616DBCAF0ABA4B172532963630072D252DD1D39F5FDA937729AD4F71BEBC3E03079582F1A4896067890933E2547F2E523434E3E1B77C74ED3C5A0377A9A0D1C6FC663AEA568225EF9C679AE8C5E5D24DB3D1BC1DAA81D2763AFFB8551650EC622A681A15952379A81F65A2AF04691C0C8FE8B4D19852828A9C00DE1748EB99EF95F002F4B6727A767DA6BA72D5E015952BAECF8DE035529F30D3E06527AFAAB976D6C68DA9DDCE640F3E597507C4984F348C44F1E59FD5CB455E5169FF70B9223CC5489966E4CD4766F391E68D771BF9BF703C71EFB22CDBF8772DB271F9E530A4F434AD733063B30F13BB0862DD7A28332DACF9BBB1E98D183A22B6507B7E6CC777E8772F4FCF3B3E59AABA4507FBEB9936E8E2FD613D37DF0115D71436FE5FC5A19E94E42BA79BB262EB09DB3EE4159376FD9CCDA3E35AFAD1FAFEE09B62F89DDC8BB7E3F5CF5C083B4F4CF2622F2200C74F571177B43E15F94D8CE245DE426A2FF5472704A5D219379C7E77EDA9E348F5211EDF276038AB8D8322E84A273E228FCD9012937FFD5F84458882257DE03B8EFF85DA88250E191C17B60A5BF9C444DAE6DFF0DCD5EF6799C54F23E8E806E523C02DCF13721656EE6F775CD9DBFC144D43D93CB75944B155DB217EBCCD2ADCF7B1A4AC29735FD1978014363F28EDB6409CDBE75C7B01CB1F125250B413C99D8C8F5F12BC2CFF556AFFE07832C9B6C072C0000 , N'6.0.0-20905')

	Running Seed method.
	````

1. In **SQL Server Object Explorer**, click **Refresh**.

	![Clicking the refresh button](Images/refresh.png?raw=true "Clicking the refresh button")

	_Clicking the refresh button_

1. Expand the different nodes until the columns of the **dbo.TriviaQuestions** table are displayed. The new **Hint** column will be displayed.

	![Showing the new Hint Column](Images/hint-column.png?raw=true "Showing the new Hint Column")

	_Showing the new Hint Column_

1. Back in the **TriviaQuestion.cs** editor, add a `StringLength` constraint to the _Hint_ property, as shown in the following code snippet.

	<!-- mark:10 -->
	````C#
	public class TriviaQuestion
	{
		 public int Id { get; set; }

		 [Required]
		 public string Title { get; set; }

		 public virtual List<TriviaOption> Options { get; set; }

		 [StringLength(150)]
		 public string Hint { get; set; }
	}
	````

1. In the **Package Manager Console**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	Add-Migration QuestionHintLength
	````
1. In the **Package Manager Console**, enter the following command and then press **Enter**.

	<!-- mark:1 -->
	````PowerShell
	Update-Database -Verbose
	````

1. Highlight the generated SQL statement that is displayed as part of the command's output, as highlighted in the following code snippet.

	<!-- mark:8 -->
	````PowerShell
	PM> Update-Database -Verbose
	Using StartUp project 'GeekQuiz'.
	Using NuGet project 'GeekQuiz'.
	Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
	Target database is: 'GeekQuiz' (DataSource: (LocalDb)\v11.0, Provider: System.Data.SqlClient, Origin: Configuration).
	Applying explicit migrations: [201309232026541_QuestionHintLength].
	Applying explicit migration: 201309232026541_QuestionHintLength.
	ALTER TABLE [dbo].[TriviaQuestions] ALTER COLUMN [Hint] [nvarchar](150)
	INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
	VALUES (N'201309232026541_QuestionHintLength', N'GeekQuiz.Models.TriviaContext',  0x1F8B0800000000000400DD5ACD72DB3610BE77A6EFC0E1A9ED4C44DB99CEB41E291947B6D34C6B3BB1945C3330B992310141160055B9AFD6431FA9AFD0A5F80FF057B262C53709DA5D2C76BFDD053FEABF7FFE1DBF5EFBCC5A819034E013FB7874645BC0DDC0A37C39B123B578F18BFDFAD5F7DF8D2F3C7F6D7DCAE45EC672A8C9E5C4BE572A3C751CE9DE834FE4C8A7AE0864B0502337F01DE205CEC9D1D1AFCEF1B10368C2465B9635BE8DB8A23E6CBEE0D769C05D085544D855E00193E93AFE32DB58B5AE890F32242E4CECB7005F3E44F4EF51226A5B678C127463066C615B84F34011854E9E7E94305322E0CB59880B84CD1F4240B905611252E74F0BF1BEE7383A89CFE1148A5BC5C1CE4F8867BCC058A887D8BDCD3927F65CD01525675CFE05A22C89B2BFC343650197DE8B2004A11E6E6191EABFF36CCBA9EA39BA62AE56D2895DC04F5CBD3CB1ADEB883172C7208F5829B4331508780B1C0451E0BD274A81E0B10DD81CC5D85DDB0B33238AFD30490836DBBA22EB3F802FD5FDC4C68FB67549D7E0652BA90F1F39456CA2921211746D7313C6CE761FACDDCA8708E45676AEC98A2E37F1D22C26E94DBCB3AD5B601B21794FC304C5A372FE3F57A52F45E0DF064C034945E8F32C88848BFECC832EC939114B5055CFC74E81C71E284D1DDB02A5E5C03AFB01F5D6B97BC2E29853C5E0116A63E811E53410025C956DFD2640F010BE33CEB31CB4203D43A326AF63BD56AC01EDF5B28F80F7DCBD67D8979F087ABF51AE5A763DFEF9689B61D008CB041A725F78CC30D6078F1976FBE0F14CCAC0A51B876B1AB0EE6C351617DCB306545292093D1E989488291A32EAA27B13FB2723E4FDB6C903A46F5344BABAD1B1AD97D60D3F07060AAC3337B9BB4D89748967820063E95557B01A41C4E54018DE3AA51204D167962EE52E0D09EB7F1CCD44CFFA8F5DCC37D37F398710785CBAFD73D7C78BD6B9EBE49B6A81EC8ADBD82901B40F6EEBAE37ED706ABDEBE8604A6FCF8331DB764DEA59188782D796A3EC8A93FDC1BB25C97B71BA7848F80AB5907476D451A801A2520FF12AAC955103B1C60C544DEDE0082B46452DF80DACD719CBE76183B10CE4BD8C65F16F36577479CD602966F52E1A03B9A4D1637EEBE91D3614F3E31A613370336C0C1A864B21D4BB433544BDC357FB24D914BCCEBE3CB0331BE7CBC1DB19B8B65EDC371F2D41CB6E5A793D16B49393F04E193FE5341054E32B1286785F2D1156E98A354BD8AAE98BD97082C84F6C38AEACE189726FF39DF0D24F96A0FD8A5BA3A7975448754E14B923F18D79EAF98658AFEE93ED55D784CC2C66759F69C59F134D8DBCABB62BB35DA7062EF17C7E3C2836CF370D8032D537F4216144D43C524D0316F9BC796E356B67E455D942B6D6DF4A3176CA769A8751B3A5F2C42BDBEA98848E165B63F81969346E2A556C0C404E56AABB23A7BE3FF5464E93FAE3C67A3F384C1FD6CB06D2A5011E14A44FC59162F9C09053CCC6DDB1D37431E88D9E6603879BF1846B299B4856BE729E8DD1AB8BE4BBE723581BB5E374EC75BF3032E66022625B189A15F5E219387B900AFC512C309AFDC9A68C421C944CE08A70BAC05CCF832F8097A593A3E313EDB5D316AF801C293D7678EF814CCA7C838F81949EFEEA651B1B9A7627B739D07CF525145F11E1DE13F1834FD63F966D99DCE2F37E41728099AAD0D28D89DAEE2DC71DED3AEE37F37EE0D0635FA6F9334B26D1BF4DE53D26355EB00B4FC34FD793073B90F23B10882D37A4BD92DBCF9BC61E98D1BDA22B230AB7A6CF777E9D72F054F4B3A59D4D7EA83FF5DCC93C2777EC89EDDD0588AEA4A1B7D27FADE4742737DDBC5D132DD84E5FF760AF9BB76C26709F9AE2D68F57F730DB97CF6EA460BF1DDA7AE0415AFA671327B91732DA7CF2C5DE50FA4325B63349978589F8EF951CDC4A57C865DEF14590B527CDA34C44BBC75D81221EB68C33A1E882B80A7F7641CACDDF363E1116A1C8857F07DE3B7E13A930527864F0EF58E5DF2771936BDB7FC3B8577D1EA795FC18474037291E016EF89B88322FF7FBB2E6FADF6022EE9EE93D3BCEA58AEFDBCB87DCD275C07B1A4AC39737FD39F8214363F286CFC80A9A7DEB8E613562E3734A9682F832B551E8E357849FE7AF5FFD0F710C4B3A122C0000 , N'6.0.0-20905')

	Running Seed method.
	````

1. Refresh **SQL Server Object Explorer**, and expand the tree nodes until the node representing the **Hint** column is visible.

	![Showing the new constrain](Images/constraint.png?raw=true "Showing the new constrain")

	_Showing the new constrain_

<a name="segment2" />
### Deployment Rollback ###

1. Open the **GeekQuiz.sln** solution that you copied to a separate folder during the setup phase.
1. Double-click the **AnswersService.cs** file in **Solution Explorer**.
1. Select the code highlighted in the following figure.

	![Selecting the code](Images/select-code.png?raw=true "Selecting the code")

	_Selecting the code_

1. Right-click the selected code, expand the **Refactor** menu and select **Extract Method...**.

	![Extracting code as a new method](Images/extract-method.png?raw=true "Extracting code as a new method")

	_Extracting code as a new method_

1. Name the method _MatchesOption_. The resulting code is shown in the following snippet.

	<!-- mark:6-7,12-16 -->
	````C#
	public async Task<bool> StoreAsync(TriviaAnswer answer)
	{
		 this.db.TriviaAnswers.Add(answer);

		 await this.db.SaveChangesAsync();
		 var selectedOption = await this.db.TriviaOptions.FirstOrDefaultAsync(o =>
			  MatchesOption(answer, o));

		 return selectedOption.IsCorrect;
	}

	private static bool MatchesOption(TriviaAnswer answer, TriviaOption o)
	{
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

1. Open the web site using IE 11.

1. Log-in using the previously created credentials.

	![Log in](Images/log-in.png?raw=true "Log in")

	_Log in_

1. Press **F12** to open the development tools.

1. Select the network tab and start recording.

	![Starting Network Recording](Images/network-recording.png?raw=true "Starting Network Recording")

	_Starting Network Recording_

1. Select any of the four answers. Nothing will happen.

1. Show that the web request failed with a 500 error.

	![Showing the 500 error](Images/500-error.png?raw=true "Showing the 500 error")

	_Showing the 500 error_

1. Select the console tab. An error will have been logged.

	![Showing the logged error](Images/logged-error.png?raw=true "Showing the logged error")

	_Showing the logged error_

1. Highlight the  details part of the error: `Details: LINQ to Entities does not recognize the method 'Boolean MatchesOption`.

	> **Speaking point:** This clearly point to the last refactoring. Let's rollback to the previous working version.

1. Do not close the GeekQuiz site, and switch to the browser window/tab that has the Azure Preview Portal open.

1. Open the web site and select **Active Deployment**. Both commits will be listed in the deployment history.

	![Showing the existing deployments](Images/existing-deployment.png?raw=true "Showing the existing deployments")

	_Showing the existing deployments_

1. Select the initial commit and click **REDEPLOY**.

	![Redeploying the initial commit](Images/redeploy.png?raw=true "Redeploying the initial commit")

	_Redeploying the initial commit_

1. When prompted to confirm, click **YES**.

1. Once the deployment is finished, switch back to the web site and press **CTRL + F5**.

1. Click any of the options. The flip animation will take place and the result (correct/incorrect) will be displayed.

---

<a name="summary" />
## Summary ##

By completing this demo you should have:

1. Used Entity Framework migrations to update GeekQuiz database to reflect the changes in the object model
1. Deployed a change (bug) to Microsoft Azure using Git
1. Rollback to the last working deployment using the Azure Preview Portal

---
