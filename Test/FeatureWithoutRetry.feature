@featuretag
Feature: A feature without retries

@scenariotag
@retry(7)
Scenario: Try do something a few times
	When I try something

@retry
Scenario: Try do something with default times
	When I try something 3 times

Scenario: This will try only once
	When I do something