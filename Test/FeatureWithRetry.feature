@featuretag
@retry(8)
Feature: A feature with retries

@scenariotag
Scenario: Try do something a few times with another tag
	When I try something

@scenariotag
@retry(12)
Scenario: Try do something a few times with another retry inside scenario
	When I try something

Scenario: Try do something a few times with retry from feature
	When I try something