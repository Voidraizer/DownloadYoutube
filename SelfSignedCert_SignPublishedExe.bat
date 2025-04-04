@echo off
REM Define paths and variables
set SIGNTOOL_PATH="C:\Program Files (x86)\Windows Kits\10\App Certification Kit\signtool.exe"
set CERTIFICATE_PATH="Certificate\DownloadYoutube-SelfSignedCert.pfx"
set CERTIFICATE_PASSWORD="milestails8"
set EXECUTABLE_PATH="bin\Release\net8.0-windows\win-x64\publish\win-x64\DownloadYoutube.exe"
set TIMESTAMP_URL="http://timestamp.digicert.com"

REM Sign the executable
%SIGNTOOL_PATH% sign /f %CERTIFICATE_PATH% /p %CERTIFICATE_PASSWORD% /tr %TIMESTAMP_URL% /td SHA256 /fd SHA256 %EXECUTABLE_PATH%

REM Check if signing was successful
if %ERRORLEVEL% neq 0 (
    echo Signing failed!
    exit /b %ERRORLEVEL%
) else (
    echo Signing succeeded!
)

pause >nul