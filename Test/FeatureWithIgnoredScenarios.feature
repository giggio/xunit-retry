Feature: FeatureWithIgnoredScenarios
	A feature with some ignored scenarios

@ignore
Scenario: Some ignored scenario
	Given I will fail

@ignore
@retry
Scenario: Some ignored scenario with retries
	Given I will fail
