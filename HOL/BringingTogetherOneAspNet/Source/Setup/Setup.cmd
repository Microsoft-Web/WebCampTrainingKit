@ECHO off
%~d0

CD "%~dp0"
ECHO Install Visual Studio 2013 Code Snippets for the lab:
ECHO -------------------------------------------------------------------------------
CALL .\Scripts\InstallCodeSnippets.cmd
ECHO Done!
ECHO.
ECHO *******************************************************************************
ECHO.

@PAUSE
