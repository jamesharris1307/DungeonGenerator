# Research Log

This document records the research, problems encountered and knowledge gained throughout the development of the DungeonGenerator project.

---

## What I Needed to Learn

I needed to research Multidimensional arrays in order to represent the map, rooms and objects. 
I decided to use w3schools to give me an overview of what multidimensional arrays are, how they work
and how to implement one in c# [here](https://www.w3schools.com/cs/cs_arrays_multi.php).

I decided to use an If statement for the Menu however I realised that a switch statement would be 
a cleaner implementation. In the Game Engine I use Godot it offers a match statement instead of 
a switch statement although the Godot documentation says they are the same thing. I decided to change
the if statement to a switch statement and read about it in the docs [here](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)

I needed to learn how to exit the console after the user presses the quit option and I found
the syntax I needed to implement on stack overflow [here](https://stackoverflow.com/questions/10286056/what-is-the-command-to-exit-a-console-application-in-c).

Learnt about primary constructors when implementing the room properties and constructor logic, 
read about them [here](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors).

Decided to implement the symbol rendering logic using an enum, came across a
problem of defining the symbols in all the classes when it would be much
better to define the symbols reference in an enum and then create a renderer
class in order to render the dungeon Researched enums in c# 
[here](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum).

I needed to learn how to implement unit testing in C# and .NET to ensure that 
core features like room placement limits, grid boundary checks, and 
collision detection worked correctly. While ChatGPT initially recommended 
XUnit, I noticed during setup in JetBrains Rider that the IDE offered a 
native test project template pre-configured with NUnit. To keep project 
dependencies simple, I chose to use NUnit instead. I used the 
official NUnit documentation [here](https://docs.nunit.org/articles/nunit/writing-tests/ordinary-tests.html) 
to understand test attributes and assertions, and I structured my test cases 
using the standard Arrange, Act, Assert (AAA) pattern.

### Learning How to Create a GitHub Release

I wanted to learn how to create a formal release of my application on GitHub so that users could access specific versions of the software.

I researched how GitHub releases work and learned that they use Git tags to identify specific versions of a project. I also researched semantic versioning and how version numbers communicate changes between releases.

I needed to understand how to prepare my .NET application for distribution, so I researched the dotnet publish command. I initially looked at publishing a standard Release build using:

`dotnet publish -c Release`

However, I decided to use the following command instead:

`dotnet publish -c Release -r win-x64 --self-contained true`

This publishes the application for 64-bit Windows and includes the .NET runtime, meaning users do not need to install the .NET runtime separately to run it.

I then explored GitHub's release creation process, where I learned how to select a Git tag, write release notes, specify the target branch and mark a release as a pre-release.

This gave me an understanding of how to prepare, version and distribute a particular version of my application through GitHub. I used this knowledge when preparing my v0.1.0 pre-release.

---

## Resources Used

The following resources were used to support my research and development:

- [Microsoft C# and .NET Documentation](https://learn.microsoft.com/en-us/dotnet/)
- [GeeksforGeeks – C# Programming Language](https://www.geeksforgeeks.org/c-sharp/csharp-programming-language/)
- [w3schools](https://www.w3schools.com/cs/cs_arrays_multi.php)
- [StackOverflow](https://stackoverflow.com)
- [Git](https://git-scm.com)
- [NUnit](https://nunit.org)

---

### How I Approached Research

When researching unfamiliar concepts, I prioritised official documentation where possible, particularly Microsoft 
Learn for C# and .NET features and the NUnit documentation for unit testing. I used these resources to understand how 
features worked and how they should be implemented. I also used resources like as W3Schools, GeeksforGeeks 
and Stack Overflow as shown above when I needed alternative explanations or examples. Where possible, I compared 
suggestions by ChatGPT to official documentation and tested implementations within my own project to confirm that 
they worked as expected.

---

## Problems Encountered

### Problem 1: Removing Rider Configuration Files from Git

My first problem occurred when making my initial Git commit. I accidentally included the `.idea/` 
directory, which is generated by JetBrains Rider and contains IDE configuration files. 
I was concerned that removing this directory from GitHub would also delete it from my local project, 
potentially causing problems with my Rider configuration. After researching Git, I discovered the `--cached` 
option for the `git rm` command.

I used the following commands:

```bash
git rm -r --cached .idea
git add .gitignore
git commit -m "Remove Rider configuration from repository"
git push
```

This removed the `.idea/` directory from Git tracking without deleting the local files.

I also added `.idea/` to my `.gitignore` file to prevent it from being tracked in future commits.

---

### Problem 2: Making Room Placement Visually Distinguishable

While testing the room placement functionality, I encountered an issue where rooms appeared to be successfully 
generated, but there was no visible difference in the dungeon output. After investigating the problem, I realised 
that the dungeon constructor initialised all interior cells with `.`. My `Room` class also used `.` when generating 
the room, meaning that placing a room did not visibly change the map. To resolve this, I changed the initial value of 
the dungeon's interior cells to a space character (`' '`). The `Room` class continued to use `.` to represent room floors, 
while `#` represented the outer boundaries. This gave each part of the dungeon a distinct symbol:

- `#` – Outer boundary.
- ` ` – Unoccupied dungeon space.
- `.` – Room floor.

---

### Problem 3: Terminal Display Limitations When Rendering Large Dungeons

While testing larger dungeon dimensions, I increased the map size to 200 columns by 100 rows. Although the dungeon 
was generated correctly, the terminal could not display the entire map width within its available window. This caused 
the output to wrap onto additional lines, making the dungeon difficult to read and not like its expected appearance. 
I identified that this was a limitation of the terminal's display area rather than an issue with the dungeon generation 
logic. The application was still generating the correct 2D array it's just the terminal couldn't display it without wrapping.

---

### Problem 4: Preventing Corridors from Overwriting Existing Rooms

During the implementation of corridor generation, I encountered an issue where corridors would overwrite sections of 
previously generated rooms. My initial implementation modified the dungeon grid directly by writing corridor walls (#) 
and floors (.) into existing cells. To address this, I introduced checks to ensure that corridor sections were only placed 
in empty cells. However, this introduced another issue that being corridors could become partially generated when they 
encountered occupied cells. 

---

### Problem 5: Distinguishing Between Different Types of Dungeon Cells

Initially, I represented the dungeon using a multidimensional char[,] array. This worked for displaying the dungeon, but I 
encountered a limitation when implementing corridor generation. Both the outer dungeon boundary and room walls used #, making 
it impossible to distinguish between them using the character stored in the array. For example, checking whether a cell contained # 
could not tell me whether that cell represented an outer boundary or a room wall. To address this, I researched C# enumerations (enum) 
[here](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum) and introduced a CellType enumeration. 
This allowed me to represent different cell types independently of their displayed characters:

- Empty
- Boundary
- RoomWall
- RoomFloor
- CorridorWall
- CorridorFloor

I also introduced a rendering method that converts each cell type into its corresponding ASCII character. This way I can implement a 
feature in the future where the user can configure the rendering method to display custom symbols if desired.

---

### Problem 6: Handling Invalid User Input

During testing, I encountered an application crash when an empty input was entered at the main menu.

The exception was:

``
System.FormatException:
The input string '' was not in a correct format.
``

The issue occurred because Convert.ToInt32() attempted to convert an empty string into an integer.

I found int.TryParse() as an alternative [here](https://learn.microsoft.com/en-us/dotnet/api/system.int32.tryparse?view=net-10.0).
This method allows the application to check whether user input can be converted successfully before processing it.
I implemented this fix everywhere where appropriate 

---

### Problem 7: Resolving a .NET SDK Error During Docker Builds

While configuring Docker to build and run the application, I encountered an error during the `dotnet restore` stage:

```text
Failed to map file. mmap(/usr/share/dotnet/sdk/10.0.403/dotnet.runtimeconfig.json) failed with error 22
```

Initially, I suspected that the problem was related to my Dockerfile or project configuration. However, after testing 
the restore operation locally, I confirmed that it completed successfully outside Docker. To investigate further, I 
ran `dotnet --info` directly inside the official .NET SDK Docker image. This produced the same error, indicating that 
the issue was not specific to my application. I then tested an earlier SDK image, `mcr.microsoft.com/dotnet/sdk:10.0.301`, 
which ran successfully without producing the error. I therefore changed the SDK version in my Dockerfile from `10.0` to 
`10.0.301`. This resolved the SDK startup issue and allowed me to continue investigating the Docker build process.

---

## What I Learned

- Throughout the development of this project, I gained experience with several C# and software development concepts:


- How Git tracks files and directories, including the difference between removing a file locally and removing it from Git tracking.


- How multidimensional arrays can represent a two-dimensional grid and store information about individual dungeon cells.


- How enums can represent different cell types independently of their displayed characters.


- How separating rendering logic from dungeon data improves code organisation and maintainability.


- The differences between if statements and switch statements when implementing conditional logic.


- How primary constructors can simplify constructor declarations in C#.


- How int.TryParse() can be used to validate user input and prevent conversion exceptions.


- How NUnit can be used to create automated unit tests and verify individual components of an application.


- How Docker uses SDK images to provide a consistent build environment and how different SDK versions can affect application builds.


- How to investigate problems systematically by isolating potential causes and testing alternative approaches.

