del *.nupkg
call nuget pack "%~dp0XunitRetry\XunitRetry.nuspec" -NoDefaultExcludes %*
call nuget pack "%~dp0XunitRetry.Generator.SpecflowPlugin\XunitRetry.Generator.SpecflowPlugin.nuspec" -NoDefaultExcludes %*
