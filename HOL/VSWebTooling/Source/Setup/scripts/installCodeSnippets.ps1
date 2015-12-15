########################
# Zip Helper Functions #
########################

# Extract the files form the zip
# Usage: extract-zip c:\myzip.zip c:\destination
function Extract-Zip
{
	param([string]$zipfilename, [string] $destination)

	if(test-path($zipfilename))
	{	
		$shellApplication = new-object -com shell.application
		$zipPackage = $shellApplication.NameSpace($zipfilename)
		$destinationFolder = $shellApplication.NameSpace($destination)
		$destinationFolder.CopyHere($zipPackage.Items())
	}
}

# Create a new zip
# Usage: new-zip c:\myzip.zip
function New-Zip
{
	param([string]$zipfilename)
	set-content $zipfilename ("PK" + [char]5 + [char]6 + ("$([char]0)" * 18))
	(dir $zipfilename).IsReadOnly = $false
}


# Add files to a zip via a pipeline
# Usage: dir c:\filesToAdd\*.* -Recurse | add-Zip c:\myzip.zip
function Add-Zip
{
	param([string]$zipfilename)

	if(-not (test-path($zipfilename)))
	{
		set-content $zipfilename ("PK" + [char]5 + [char]6 + ("$([char]0)" * 18))
		(dir $zipfilename).IsReadOnly = $false	
	}
	
	$shellApplication = new-object -com shell.application
	$zipPackage = $shellApplication.NameSpace($zipfilename)
	
	foreach($file in $input) 
	{ 
            $zipPackage.CopyHere($file.FullName)
            Start-sleep -milliseconds 500
	}
}

# List the files in a zip
# Usage: Get-Zip c:\myzip.zip
function Get-Zip
{
	param([string]$zipfilename)
	if(test-path($zipfilename))
	{
		$shellApplication = new-object -com shell.application
		$zipPackage = $shellApplication.NameSpace($zipfilename)
		$zipPackage.Items() | Select Path
	}
}

#####################
# END Zip Functions #
#####################


#####################
#    Main script    #
#####################

[string] $vsiFile = $args[0]

if ($vsiFile -eq $null -OR $vsiFile -eq "")
{
    Write-Error "Missing Argument! The code snippets VSI installer file was expected as a parameter."
    return;
}
if (!(Test-Path "$vsiFile"))
{
    Write-Error "Cannot find the code snippets VSI installer file at $vsiFile."
    return;
}

Write-Host "Installing code snippets VSI: $vsiFile..."

[string] $zipFile = "$vsiFile.zip"
[string] $tempFolder = get-item $env:temp 
[string] $extractLocation = Join-Path $tempFolder ((Get-Item "$vsiFile").Name.Replace(".vsi", ""))
Copy-Item "$vsiFile" "$zipFile" -force

if (Test-Path "$extractLocation")
{
    Remove-item "$extractLocation" -force -recurse
}
New-Item "$extractLocation" -type directory


Write-Host "Extracting vsi content..."
Extract-Zip "$zipFile" "$extractLocation"
Write-Host "Extracting vsi content done!"

[xml] $vscontent = Get-Content (Join-Path "$extractLocation" "*.vscontent")

[string] $documentsFolder = [System.Environment]::GetFolderPath( [System.Environment+SpecialFolder]::MyDocuments )
if (-NOT (test-path "$documentsFolder"))
{
    $documentsFolder = "$env:UserProfile\Documents";
}

# ensure code snippets folder exist
New-Item "$documentsFolder\Visual Studio 2015\Code Snippets" -itemtype directory -force

foreach ($node in $vscontent.VSContent.Content)
{
    Write-Host "Installing Code Snippet $($node.FileName)"
    $codeSnippetFile = Join-Path "$extractLocation" "$($node.FileName)"
    [string] $codeSnippetLocation = ""
    
    switch (($node.Attributes.Attribute | Where-Object { $_.name -eq "lang" }).value) 
    {       
        "XML" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\XML\My Xml Snippets" }
        "XAML" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\XAML\My XAML Snippets" }
		"HTML" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\Visual Web Developer\My HTML Snippets" } 
		"CSS" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\Visual Web Developer\My CSS Snippets" } 
        "JavaScript" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\JavaScript\My Code Snippets" }  
		"csharp" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\Visual C#\My Code Snippets" } 
        "vb" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\Visual Basic\My Code Snippets" } 
        "SQL" { $codeSnippetLocation = "$documentsFolder\Visual Studio 2015\Code Snippets\SQL\My Code Snippets" }         
        
        default { Write-Error "Unexpected code snippet language: $_" }
    }

    if (![string]::IsNullOrWhiteSpace($codeSnippetLocation))
    {
        New-Item -path  $codeSnippetLocation -itemtype directory -force
        Copy-Item "$codeSnippetFile" -destination $codeSnippetLocation -force
    }
    
    Write-Host "Installing Code Snippet $($node.FileName) done!"
}

Write-Host "Removing temp files..."
if (Test-Path "$extractLocation")
{
    Remove-item "$extractLocation" -force -recurse
}
Remove-item "$zipFile" -force
Write-Host "Removing temp files done!"

Write-Host "Installing code snippets VSI: $vsiFile done!"