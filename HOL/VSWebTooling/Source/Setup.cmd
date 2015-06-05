@echo off
setlocal
CD /d "%~dp0"

::Test If script has Admin Priviledges/is elevated
REG QUERY "HKU\S-1-5-19"
IF %ERRORLEVEL% NEQ 0 (
    ECHO Please run this script as an administrator
    pause
    EXIT /B 1
)
cls
echo Setup Options
echo =============
echo.
echo 1. Execute setup scripts.
echo    WARNING: The setup could fail and the Hands-on Lab might not work properly if you don't have all the prerequisites installed.
echo.
echo 2. Exit.
echo.
choice /c:12 /M "Choose an option: " 
if errorlevel 2 goto exit
if errorlevel 1 goto execsetup


:execsetup
REM Here executes the Setup.cmd only.
echo Executing setup scripts.
call .\Setup\Setup.cmd
goto exit

:pause
pause

:exit


