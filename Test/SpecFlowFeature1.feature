@featuretag
Feature: SpecFlowFeature1

@scenariotag
@retry(7)
Scenario: Try do something a few times
	When I try something

Scenario: This will try only once
	When I do something