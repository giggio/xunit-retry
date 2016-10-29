call build.cmd
call nuget push "%~dp0XunitRetry.2*.nupkg" %* -Source https://www.nuget.org/api/v2/package
call nuget push "%~dp0XunitRetry.Generator*.nupkg" %* -Source https://www.nuget.org/api/v2/package