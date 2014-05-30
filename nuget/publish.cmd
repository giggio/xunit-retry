call build.cmd
call nuget push "%~dp0XunitRetry.1*.nupkg" %*
call nuget push "%~dp0XunitRetry.Generator*.nupkg" %*
