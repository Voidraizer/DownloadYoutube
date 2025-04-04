@echo off
REM Define the path to the signtool and the executable
set SIGNTOOL_PATH="C:\Program Files (x86)\Windows Kits\10\App Certification Kit\signtool.exe"
set EXECUTABLE_PATH="bin\Release\net8.0-windows\win-x64\publish\win-x64\DownloadYoutube.exe"

REM Verify the signature
%SIGNTOOL_PATH% verify /pa /v %EXECUTABLE_PATH%

REM Pause to view the results
echo.
echo Press any key to continue...
pause >nul