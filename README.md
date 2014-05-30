# Xunit Retry

This is the repo for xUnit Retry project. It holds both xUnitRetry and it's SpecFlow plugin.

## Documentation

This xUnit plugin allows you to run a test and, if it fails, rerun it a number of times, by default `3`.

### Why you shouldn't use this

Tests that pass sometimes, and sometimes they don't are a bad smell. Your tests should be consistent: either they always pass, or they always fail.
So, don't you this xUnit plugin, instead make your tests consistent.

### Why you maybe want to use this

The above rule should be followed always, but sometimes you can't.
Some tests are inherently incosistent, like tests that touch some type of physical artifact, like the network, files, or a web browser.
Such tests may fail for reasons outside of your control. Maybe the network had a hiccup, or your web browser driver failed to communicate properly with the web browser.
Who knows? If you can trace the problem and eliminate, then do that, it is the preferred option. If you can't, then you have this xUnit plugin.

## Why I wrote this

The main problem I have is with end to end tests driving a web browser. I use mostly Selenium WebDriver and I have developed lots of techniques that help me work around
most of the issues caused by the inherent instability of such tests, but some are just not easily fixable. This is the problem I am solving for myself.

## Two flavors

You can use it directly or with SpecFlow.

### Using it directly

You can specify the retry count like this:

```csharp
[Retry(5)] //will try 5 times
public void TryAFewTimes()
{
    tried++;
    Assert.True(tried >= 5);
}
```

Or you can use the default, which is 3:

```csharp
[Retry] //note there is no count here
public void TryAFewTimes()
{
    tried++;
    Assert.True(tried >= 3);
}
```

### Using it with SpecFlow

The way you use it with SpecFlow is by using tags.
You can add it to a feature. When you do that every scenario in the feature will use the specified retry count (or the default if none was specified).
You can specify the retry count:

```Gherkin
@retry(8)
Feature: A feature with retries
```

... or not specify it, and it will use the default:

```Gherkin
@retry
Feature: A feature with default retries
```

And you can add it to scenarios directly and specify a retry count:

```Gherkin
@retry(12)
Scenario: Try something
	When I try something 10 times
```

Or use the default:

```Gherkin
@retry
Scenario: Try something
	When I try something 3 times
```

If you use it on the feature and on the scenario the scenario count takes precedence.

## Installing via Nuget

Just run on your package manager console:

```
Install-Package XUnitRetry
```

Or, for the SpecFlow one:

```
Install-Package XunitRetry.Generator.SpecflowPlugin
```

## Issues

* You can check the [Github issues](https://github.com/giggio/xunit-retry/issues) directly.

## Maintainers

* [Giovanni Bassi](http://blog.lambda3.com.br/L3/giovannibassi/), [Lambda3](http://www.lambda3.com.br), [@giovannibassi](http://twitter.com/giovannibassi)

## License

This software is open source, [licensed at GPL V2](https://github.com/giggio/xunit-retry/blob/master/LICENSE.txt). Check out the terms of the license before you contribute, fork, copy or do anything
with the code. If you decide to contribute you agree to grant copyright of all your contribution to this project, and agree to
mention clearly if do not agree to these terms. Your work will be licensed with the project at GPL V2, along the rest of the code.
