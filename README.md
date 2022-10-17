# -Challenge-RobotToy

-Challenge-RobotToy is an implementation of a programming interview challenge.
The prompt is below:

The application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are no
other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented
from falling to destruction. Any movement that would result in the robot falling from the table must be prevented,
however further valid movement commands must still be allowed.

Create a console application that can read in commands of the following form -
PLACE X,Y,F
MOVE
LEFT
RIGHT
REPORT

F can be NORTH,SOUTH,EAST,WEST

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)
can be considered to be the SOUTH WEST most corner. 
It is required that the first command to the robot is a PLACE
command, after that, any sequence of commands may be issued, in any order, including another PLACE command. 
The application should discard all commands in the sequence until a valid PLACE command has been executed. 
MOVE will move the toy robot one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the
robot. 
REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.

A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands. 
Input can be from a file, or from standard input, as the developer chooses.
Provide test data to exercise the application.
It is not required to provide any graphical output showing the movement of the toy robot.
The application should handle error states appropriately and be robust to user input.

## Installation

-Challenge-RobotToy is built on C# .NET Standard 6 and Visual Studio 2022 Community Edition.
Both can be obtained through: https://visualstudio.microsoft.com/vs/

Open the solution file in the root of the project called "ToyRobot.sln"
And follow the steps inside visual studio to build and run the console application.

Alternatively you can user powershell to build the project:

```Powershell
dotnet build .\ToyRobot.sln
```

And run the applicaiton:

```Powershell
.\src\ToyRobot\bin\Debug\net6.0\ToyRobot.exe --path .\src\ToyRobot\tests.txt
```

## Usage

The path of a .txt file containg the robot's commands must be declared via command line argument `--path VALUE`.

An example command file is below:

```
PLACE 3,1,NORTH
LEFT
MOVE
RIGHT
MOVE
REPORT
PLACE 3,1,NORTH
REPORT
RIGHT
MOVE
MOVE
REPORT
```

The size of the table is at a default 5x5 units but this can be configured using the `--size VALUE` command line argument.