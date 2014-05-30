call build.cmd
nuget push "%~dp0XunitRetry.1*.nupkg" %*
nuget push "%~dp0XunitRetry.Generator*.nupkg" %*
