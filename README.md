## AmericanBowlingGame

### Changelog

-   Existing Score calculation module has been moved to folder "ScoreCalculator".
-   Very few naming convention changes added to existing module.
-   New class "Game" added as module.
-   Game module would handle pins drawned on particular roll and decide frames based on pins drawned.
-   Game module would call existing ScoreCalculato module by passing frames with pin drawed and get final score
-   Unit tests for Game module has been added

### Prerequisites

-   .NET Core v2.1.X

### Build code

-   To build code use commnd > dotnet build

### Unit test

-   To run unit test use command > dotnet test
