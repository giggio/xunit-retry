@featuretag
@retry
Feature: A feature with default retries

@scenariotag
Scenario: Try do something a few times with another tag
	When I try something 3 times

@scenariotag
@retry(12)
Scenario: Try do something a few times with another retry inside scenario
	When I try something

Scenario: Try do something a few times with retry from feature
	When I try something 3 times