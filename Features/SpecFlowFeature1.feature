Feature: Check if word is present in paragraph
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Check if the word is present on the page
	When I navigate to lipsum.com
	And switch the page language to Russian
	Then assert that there is the word 'рыба' in the first paragraph
