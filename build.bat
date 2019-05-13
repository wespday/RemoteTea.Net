@ECHO ON
@SETLOCAL

@ECHO.
@ECHO  **** STARTING BUILD  ****

CALL "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\Tools\VsDevCmd.bat"
@ECHO ON

@SET THIS_SCRIPT_FOLDER=%~dp0
CD /D "%THIS_SCRIPT_FOLDER%"
@SET ARTIFACTS=artifacts
@SET NUGET_COMMAND="nuget.exe"
@SET PACKAGE_VERSION=%APPVEYOR_BUILD_VERSION%

IF NOT "%APPVEYOR_BUILD_VERSION%"=="" (
	SET RUNNING_ON_BUILD_SERVER="TRUE"
	SET COMMIT_ID=%APPVEYOR_REPO_COMMIT:~0,7%
)

IF "%PACKAGE_VERSION%"=="" (
	SET PACKAGE_VERSION=1.0.5
)

SET PRERELEASE_PACKAGE_VERSION=%PACKAGE_VERSION%-prerelease

@SET NUGET_PACKAGE_ID=SharkByte.RemoteTea.Net
@SET SOLUTION=remoteteanet\RemoteTea.Net.sln
@SET PROJECT_FOLDER=remoteteanet
@SET NUGET_PACKAGE_FOLDER=%ARTIFACTS%\%NUGET_PACKAGE_ID%
@SET DOTNET_FRAMEWORK=net48
@SET NUGET_FRAMEWORK_FOLDER=%NUGET_PACKAGE_FOLDER%\lib\%DOTNET_FRAMEWORK%
@SET MSBUILDARGS=/target:Rebuild /fileLogger /verbosity:minimal /property:GenerateFullPaths=true

@ECHO  **** CLEAN  ****
MSBuild "%SOLUTION%" /target:Clean /verbosity:minimal ||  GOTO BuildFailed
RMDIR /Q /S "%ARTIFACTS%" >nul 2>&1

@ECHO.
@ECHO  **** BUIILD DEBUG  ****
MSBuild "%SOLUTION%" %MSBUILDARGS% ||  GOTO BuildFailed
MKDIR "%ARTIFACTS%"
COPY msbuild.log "%ARTIFACTS%\msbuild.DEBUG.log" ||  GOTO BuildFailed

@ECHO.
@ECHO  **** BUIILD RELEASE  ****
MSBuild "%SOLUTION%" %MSBUILDARGS% /property:Configuration=Release ||  GOTO BuildFailed
COPY msbuild.log "%ARTIFACTS%\msbuild.RELEASE.log" ||  GOTO BuildFailed

@ECHO.
@ECHO  **** STAGE NUGET PACKAGE FOLDER ****
MKDIR "%NUGET_FRAMEWORK_FOLDER%" ||  GOTO BuildFailed
XCOPY /F "%PROJECT_FOLDER%\bin\Release\RemoteTea.Net.*" "%NUGET_FRAMEWORK_FOLDER%\" ||  GOTO BuildFailed
XCOPY /F "%PROJECT_FOLDER%\bin\Release\RemoteTea.Net.*" "%NUGET_PACKAGE_FOLDER%\Tools\" ||  GOTO BuildFailed
XCOPY /F "%PROJECT_FOLDER%\bin\Release\%NUGET_PACKAGE_ID%.nuspec" "%NUGET_PACKAGE_FOLDER%\" ||  GOTO BuildFailed
echo f | XCOPY /F /Y "%PROJECT_FOLDER%\..\LICENSE.txt" "%NUGET_PACKAGE_FOLDER%\license\LICENSE.txt" ||  GOTO BuildFailed
XCOPY /F "jportmap\bin\Release\jportmap.*" "%NUGET_PACKAGE_FOLDER%\Tools\" ||  GOTO BuildFailedildFailed
XCOPY /F "jrpcgen\bin\Release\jrpcgen.*" "%NUGET_PACKAGE_FOLDER%\Tools\" ||  GOTO BuildFailedildFailed

@ECHO.
@ECHO  **** CREATE PRE-RELEASE NUGET PACKAGE ****
%NUGET_COMMAND% pack "%NUGET_PACKAGE_FOLDER%\%NUGET_PACKAGE_ID%.nuspec" -Version %PRERELEASE_PACKAGE_VERSION% ^
     -NonInteractive -OutputDirectory %ARTIFACTS% -Properties "commit_id=%COMMIT_ID%" ||  GOTO BuildFailed

@ECHO.
@ECHO  **** CREATE RELEASE NUGET PACKAGE ****
%NUGET_COMMAND% pack "%NUGET_PACKAGE_FOLDER%\%NUGET_PACKAGE_ID%.nuspec" -Version %PACKAGE_VERSION% ^
     -NonInteractive -OutputDirectory %ARTIFACTS% -Properties "commit_id=%COMMIT_ID%" ||  GOTO BuildFailed

@ECHO.
@ECHO **** BUILD SUCCESSFUL ****
GOTO:EOF

:BuildFailed
@ECHO.
@ECHO *** BUILD FAILED ***
EXIT /B -1