Feature: Task4

A short summary of the feature

@tag1
Scenario: [WordCorrectlyAppearsInTheFirstParagrap]
	Given [User is at the Home Page]
	When [Change language to Russian]
	Then [Check <word> in first paragraph]
	Examples:
	| word  |
	|"рыба" |

@tag2
Scenario: [TextStartingWithLoremIpsum]
	Given [User is at the Home Page]
	When [Generate new text]
	Then [Check text starting with <Lorem_Ipsum>]
	Examples:
	| Lorem_Ipsum                                              |
	|"Lorem ipsum dolor sit amet, consectetur adipiscing elit" |

@tag3
Scenario: [GeneratedWithCorrectSizeWords]
	Given [User is at the Home Page]
	When [Set button <radio>]
	When [Enter amount <number>]
	When [Generate new text]
	Then [Check amount of words <number>]
	Examples:
	| radio   | number |
	| "words" | 10     |
	| "words" | -1     |
	| "words" | 0      |
	| "words" | 5      |
	| "words" | 20     |

@tag4
Scenario: [GeneratedWithCorrectSizeCharacters]
	Given [User is at the Home Page]
	When [Set button <radio>]
	When [Enter amount <number>]
	When [Generate new text]
	Then [Check amount of characters <number>]
	Examples:
	| radio   | number |
	| "bytes" | 60     |
	| "bytes" | 0      |
	| "bytes" | -10    |

@tag5
Scenario: [VerifyCheckbox]
	Given [User is at the Home Page]
	When [Selects an option without LoremIpsum]
	When [Generate new text]
	Then [Check text without <phrase>]
	Examples:
	| phrase                                                  |
	|"Lorem ipsum dolor sit amet, consectetur adipiscing elit"|

@tag6
Scenario: [ProbabilityOfMoreThan40]
	Given [User is at the Home Page]
	Then [Check probability of word <Word>]
	Examples:
	| Word    |
	| "lorem" |

