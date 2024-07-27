# WorldCupScoreBoard

# Football World Cup Score Board

This repository contains the implementation of a Football World Cup Score Board in C#. The solution includes functionality for starting games, finishing games, updating scores, and retrieving a summary of games. Unit tests are included to ensure the correctness of the implementation.

## Assumptions

1. **Uniqueness of Teams in Active Games**: It is assumed that a pair of home and away teams is unique in the list of active games. Hence, no two active games can have the same combination of home and away teams.
2. **Order of Games**: The summary of games is ordered first by the total score (home score + away score) in descending order. In case of a tie, the games are ordered by the time they were added to the scoreboard, with the most recently added game appearing first.
3. **Score Updates**: It is assumed that score updates are always valid (i.e., non-negative integers).

## Implementation

The solution consists of the following classes:

### Game Class

- `Game` class represents a football match between two teams.
- Contains properties for the home team, away team, home score, and away score.
- Includes a method to update the score and an overridden `ToString` method to format the score.

### ScoreBoard Class

- `ScoreBoard` class manages the list of active games.
- Allows starting a new game, finishing an existing game, updating the score of a game, and retrieving a summary of active games.
