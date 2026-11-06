
# Dungeon Generator

---

## Introduction:

Please watch the roughly 4 minutes Video to see a visual demonstration of the 
application [here](https://youtu.be/L15bhmfdLqw?si=A7IguYx9hH0L9a26)

## What I built

---

For this technical challenge I built a C# console based ASCII Dungeon Generator.
This interactive application allows users to construct custom dungeon layouts,
place rooms dynamically and generate procedural dungeons directly within the 
terminal.

The Applicaiton features an interactive command line menu that offers:

- Creating a blank dungeon map (with no rooms initialised)


- Random Room Insertion: Add rooms with custom dimensions to an existing dungeon.
(Currently, rooms are placed randomly within valid map boundaries rather than 
at exact user-specified coordinates, automatically handling collision detection 
and corridor connections.)


- Fully procedural generation that allows the user to generate a complete 
dungeon layout automatically by specifying the map dimensions and the target 
number of rooms.


- Viewport management in the form of clearing the console screen when the terminal
becomes cluttered with previous map iterations.


- Application control where the user can cleanly exit the program via the menu
options.

## Why I built it

---

### Why procedural generation:
The inspiration for this project came from a game I heard of called
[Warsim: The Realm of Aslona](https://store.steampowered.com/app/659540/Warsim_The_Realm_of_Aslona/).
This is where I first took in interest in procedural generation and I wanted to create something similar.

### Why C#
During my studies in university, our module assessments mostly required the use of specific tech stacks, usually Python, Java, or HTML, CSS, and JavaScript. Because of these constraints, I had not previously used C#.

Even the module assessments that allowed us to choose our own tools were heavily supported by 
lectures and workshops for a specific stack, which indirectly guided us toward what was 
officially taught. Since none of my assessments required us to utilise C# and .NET and since none of 
the modules were taught in C# and .NET, I had never explored it before.

The reason why I chose C# for this technical challenge was because the technical brief
encouraged me to use a technology I haven't used before and also to create something I found 
interesting and hadn't created before.

Since I have no experience in C# or with procedural generation and I have an interest in command
line ASCII procedural generation I thought this would be the perfect project to meet the technical challenges
requirements and to showcase my ability to learn a new tech and to challenge myself to learn an industry 
standard language and framework.


## How to Run

---

### Option 1: Run the Executable (Windows)

1. Download the latest release ZIP from the [GitHub Releases page]().
2. Extract the ZIP file to a location of your choice.
3. Open the extracted folder.
4. Run `DungeonGenerator.exe`.
5. Follow the instructions displayed in the console.

Windows may display a security warning because the executable is not digitally signed. Only run the executable if you have downloaded it directly from this repository and are comfortable proceeding.

### Option 2: Run from Source

To build and run the application from source, you will need:

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [Git](https://git-scm.com/)

1. Clone the repository:

   ```bash
   git clone <repository-url>
   ```

2. Navigate to the project directory:

   ```bash
   cd DungeonGenerator/DungeonGenerator
   ```

3. Build the application:

   ```bash
   dotnet build
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

### Option 3: Run Using Docker

If you have Docker Desktop installed and running:

1. Clone the repository.
2. Navigate to the solution directory containing the Dockerfile's parent project folder.
3. Build the Docker image:

   ```bash
   docker build -t dungeon-generator -f DungeonGenerator/Dockerfile .
   ```

4. Run the container:

   ```bash
   docker run -it --rm dungeon-generator
   ```

Be careful not to run the container without input enabled as the menu will just loop forever.

## How it Works

---

The dungeon is created with an outer for loop and an inner for loop. As shown below:

```csharp
    public Dungeon(int width, int height)
    {
        _map = new CellType[height, width];

        // Loop through the rows
        for (int y = 0; y < height; y++)
        {
            // Loop through the columns
            for (int x = 0; x < width; x++)
            {
                // Detect a boundary cell
                if (y == 0 || y == height - 1 ||
                    x == 0 || x == width - 1)
                {
                    // Assign Room Boundary Cell Type
                    _map[y, x] = CellType.Boundary;
                }
                else
                {
                    // Assign Room Floor Cell Type
                    _map[y, x] = CellType.Empty;
                }
            }
        }
    }
```

The dungeon and room creation logic is fairly simple. A width and height parameter is required by the 
method. The first for loop sets the size of the rows based off the width parameter given. Because we
are saying `y < height` instead of saying `y <= height` I didn't need to subtract 1 from the height value
as the less than means not equal to but less than the height parameter. I am using the height parameter for
the y as the number of rows determines the height of the dungeon/room. The inner for loop sets 
the size of the columns based of the width which also doesn't need to subtract 1 from the width parameter
as the number of columns determines the width of the dungeon/room. The next piece of code is 
there to check if a cell is a boundary. If a cell is equal to 0 or the height - 1 then it is a boundary
else it should be assigned empty. This code is present in more than one place which means it should adhere to
the DRY principle, however to keep the code base simple for now I have not encaplusated it but in order
to properly scale this codebase it should be written once and then used by the appropriate classes.

```csharp
    public bool PlaceRandomRoom(int width, int height)
    {
        int dungeonWidth = _map.GetLength(1);
        int dungeonHeight = _map.GetLength(0);

        // Check the room fits inside the dungeon
        if (width <= 0 || height <= 0 ||
            width > dungeonWidth - 2 ||
            height > dungeonHeight - 2)
        {
            return false;
        }

        // Attempt to find a suitable position
        for (int attempt = 0; attempt < 100; attempt++)
        {
            // Generate random coordinates within the dungeon boundaries.
            int x = _random.Next(1, dungeonWidth - width);
            int y = _random.Next(1, dungeonHeight - height);

            Room newRoom = new Room(x, y, width, height);

            if (!Overlaps(newRoom))
            {
                newRoom.GenerateRoom(_map);
                
                // After room generated successfully add to rooms list
                _rooms.Add(newRoom);
                return true;
            }
        }
        return false;
    }
```

The code above places a room randomly within the bounds of the dungeon map. This method
doesn't worry about if a dungeon already exists because it gets called only if a dungeon exits.
A check is then performed to see if the room size is bigger than the dungeon size. If the room
can fit within the dungeon it checks if the room would overlap another room. I set the number
of attempts to 100 because it could check forever and get stuck in a loop otherwise. If a suitable
location is found the room is placed and then added to the Rooms List.

```csharp
    // Check if a room overlaps another room
    private bool Overlaps(Room newRoom)
    {
        foreach (Room existingRoom in _rooms)
        {
            bool overlaps =
                newRoom.X < existingRoom.X + existingRoom.Width &&
                newRoom.X + newRoom.Width > existingRoom.X &&
                newRoom.Y < existingRoom.Y + existingRoom.Height &&
                newRoom.Y + newRoom.Height > existingRoom.Y;

            if (overlaps)
            {
                return true;
            }
        }
        return false;
    }
```

This method checks to see if a potential room will overlap with another room. It iterates through
each room in the rooms list and uses a boolean to check if overlapping is true or false. It 
just does the check and lets the method using this method decide what to do if it returns 
true or false.

```csharp
    // Connect rooms together using an L-shaped corridor
    public void ConnectRooms()
    {
        for (int i = 0; i < _rooms.Count - 1; i++)
        {
            Room firstRoom = _rooms[i];
            Room secondRoom = _rooms[i + 1];

            int startX = firstRoom.CentreX;
            int startY = firstRoom.CentreY;

            int endX = secondRoom.CentreX;
            int endY = secondRoom.CentreY;

            // Horizontal corridor logic
            int minX = Math.Min(startX, endX);
            int maxX = Math.Max(startX, endX);

            for (int x = minX; x <= maxX; x++)
            {
                // Place the corridor floor through the centre
                CarveCorridorFloor(startY, x);

                // Place corridor walls above and below
                PlaceCorridorWall(startY - 1, x);
                PlaceCorridorWall(startY + 1, x);
            }

            // Vertical corridor logic
            int minY = Math.Min(startY, endY);
            int maxY = Math.Max(startY, endY);

            for (int y = minY; y <= maxY; y++)
            {
                // Place the corridor floor through the centre
                CarveCorridorFloor(y, endX);

                // Place corridor walls to the left and right
                PlaceCorridorWall(y, endX - 1);
                PlaceCorridorWall(y, endX + 1);
            }
        }
    }
```

This method was a tricky one to implement, and I had some help from ChatGPT when working through the logic.
The first for loop iterates through the room list, selecting the current room and the next room in the list. The corridor starts at the centre of the first room and finishes at the centre of the second room. These coordinates are stored in separate variables.
The next two for loops handle the horizontal and vertical corridor generation.
The horizontal corridor logic uses Math.Min() and Math.Max() to determine the starting and ending X coordinates. It then iterates through each X coordinate, placing a floor cell through the centre of the corridor and two wall cells above and below it.
The vertical corridor logic works in a similar way, but operates on the Y coordinates instead. It places floor cells through the centre and two wall cells to the left and right.
Together, these two loops create an L-shaped corridor connecting the centres of two rooms.

```csharp
    // Convert cell types into their ASCII characters
    private char GetDisplayCharacter(CellType cell)
    {
        return cell switch
        {
            CellType.Empty => ' ',
            CellType.Boundary => '#',
            CellType.RoomWall => '#',
            CellType.RoomFloor => '.',
            CellType.CorridorWall => '#',
            CellType.CorridorFloor => '.',
            _ => '?'
        };
    }
```

This method candles assigning the correct ASCII symbol to the appropriate cells. In the future I am going
to allow the user to configure the symbols used to represent different cells, but I haven't implemented
that yet.

```csharp
    // Display the dungeon
    public void Display(Dungeon dungeon)
    {
        // Loop through the rows
        for (int y = 0; y < dungeon.Height; y++)
        {
            // Loop the columns
            for (int x = 0; x < dungeon.Width; x++)
            {
                Console.Write(GetDisplayCharacter(dungeon.GetCell(y, x)));
            }

            Console.WriteLine();
        }
    }
```

This method iterated through the created dungeon two dimensional array and assigns the correct symbol
to the appropriate cell.

```csharp
namespace DungeonGenerator;

public enum CellType
{
    Empty,
    Boundary,
    RoomWall,
    RoomFloor,
    CorridorWall,
    CorridorFloor
}
```

I decided to represent the state of each cell using an Enum. Having recently worked with Finite State 
Machines in Godot to create a more reliable Player object, I realised that a similar concept could be 
applied to the cells in this application. Each cell can only represent one cell type at a time. 
Rather than having developers manually enter character symbols throughout the codebase whenever 
assigning a cell type, an Enum provides a predefined collection of named constants. This makes 
assigning cell types more reliable, improves readability and reduces the likelihood of inconsistent 
values being used throughout the application.

```csharp

namespace DungeonGenerator;

// This Class handles the procedural generation of a dungeon

public class ProceduralDungeonGenerator
{
    private readonly Random _random = new();

    public Dungeon Generate(int width, int height, int roomCount)
    {
        Dungeon dungeon = new Dungeon(width, height);

        for (int i = 0; i < roomCount; i++)
        {
            // Generate random room dimensions
            int roomWidth = _random.Next(5, 15);
            int roomHeight = _random.Next(5, 15);

            // Attempt to place room.
            bool placed = dungeon.PlaceRandomRoom(roomWidth, roomHeight);

            if (!placed)
            {
                Console.WriteLine($"Could not place room {i + 1}.");
            }
        }

        // Connect the generated rooms
        dungeon.ConnectRooms();
        return dungeon;
    }
}
```

The above class handles the procedural generation of the dungeon including placing rooms within the
dungeon. A dungeon is first created and then a room is created with random dimensions. The 
algorithm then attempts to place the room in the dungeon if it can't be created an error message is 
created. Then the rooms are connected using the connect rooms method and the dungeon is 
returned to be displayed by the dungeon renderer class which is done in the program.cs class.



### Dockerfile

The Dockerfile uses a multi-stage build to build and run the application.

It follows this process:

1. Base: Sets up the .NET runtime environment that will eventually run the application.


2. Build: Uses the .NET SDK to restore the required packages, copy the source code and compile the application.


3. Publish: Prepares the compiled application and its dependencies so they are ready to run.


4. Final: Creates the final container using the smaller .NET runtime image and copies the published application into it.


The reason for using multiple stages is to avoid including unnecessary development tools in the final container. This keeps the final Docker image smaller and only includes what is needed to run the application.

### Automated test execution

```yaml

name: Run Unit Tests

on:
  push:
  pull_request:

jobs:
  test:
    runs-on: ubuntu-latest

    steps:
      - name: Checkout repository
        uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: '10.0.x'

      - name: Restore dependencies
        run: dotnet restore

      - name: Run unit tests
        run: dotnet test --no-restore

```

I configured a GitHub Actions workflow to automatically execute the unit tests whenever code is pushed to the remote repository or a pull request is created or updated.
The workflow runs on an Ubuntu virtual machine, checks out the repository, installs the required .NET 10 SDK, restores project dependencies and executes the unit tests using dotnet test.
This provides automated verification that the application continues to pass its unit tests as the codebase develops.

### Tests

The project uses NUnit to verify that the individual classes behave as expected. Each test follows the Arrange, Act, Assert (AAA) pattern:
- Arrange: Prepare the objects and data required for the test.
- Act: Execute the method being tested.
- Assert: Compare the actual result against the expected result.

#### Dungeon Tests
The DungeonTests class verifies that a dungeon is initialised correctly and that its underlying grid has the expected dimensions and cell types.
- Constructor_SetsCorrectDimensions – Creates a dungeon with specified width and height, then verifies that the Width and Height properties return the correct values.
- Constructor_SetsCorrectInterior – Iterates through the interior cells of the dungeon and verifies that each is initially assigned CellType.Empty.
- Constructor_SetsCorrectBoundary – Verifies that the outermost rows and columns are assigned CellType.Boundary, ensuring the dungeon has a correctly initialised perimeter.

#### Corridor Tests
The CorridorTests class verifies the behaviour of the ConnectRooms() method, which creates L-shaped corridors between rooms.
- ConnectRooms_CreatesCorridorFloors – Verifies that connecting rooms creates cells assigned CellType.CorridorFloor, representing the walkable corridor between rooms.
- ConnectRooms_CreatesCorridorWalls – Verifies that corridor walls are generated alongside the corridor floor, using CellType.CorridorWall.
- ConnectRooms_DoesNotOverwriteBoundaries – Checks that the dungeon's outer boundary cells remain unchanged when corridor generation is performed.
- ConnectRooms_DoesNotThrow_WhenNoRoomsExist – Verifies that calling ConnectRooms() on a dungeon without any rooms does not cause an exception.
- ConnectRooms_DoesNotThrow_WhenOneRoomExists – Verifies that calling ConnectRooms() when only one room exists does not cause an exception. Since there is no second room to 
connect, no corridor should be required.

#### Room Tests
The RoomTests class verifies that rooms store their properties correctly and generate the expected walls and floors within the dungeon grid.
- Constructor_SetsCorrectCoordinates – Verifies that the room stores the supplied X and Y coordinates correctly.
- Constructor_SetsCorrectDimensions – Verifies that the room stores the supplied width and height correctly.
- CentreX_ReturnsCorrectCentreCoordinate – Checks that the calculated horizontal centre coordinate is correct based on the room's X position and width.
- CentreY_ReturnsCorrectCentreCoordinate – Checks that the calculated vertical centre coordinate is correct based on the room's Y position and height.
- GenerateRoom_CreatesCorrectWalls – Generates a room on a test grid and verifies that its top, bottom, left and right edges are assigned CellType.RoomWall.
- GenerateRoom_CreatesCorrectFloor – Verifies that the interior cells of a generated room are assigned CellType.RoomFloor, ensuring the room has a walkable interior.

#### Dungeon Renderer Tests
The DungeonRendererTests class verifies that the DungeonRenderer correctly converts dungeon cell types into their corresponding ASCII characters and displays the dungeon in the console.

- Display_RendersDungeonCorrectly – Creates a 5 × 5 dungeon and captures the console output using StringWriter and Console.SetOut(). It then compares the captured output against an expected 
ASCII representation. This verifies that boundary cells are displayed as #, empty cells are displayed as spaces, and the dungeon is rendered with the correct rows, columns and line endings.

The test also uses a try/finally block to restore the original console output and dispose of the StringWriter, ensuring that the test cleans up correctly even if an assertion fails.


## What I would improve:

---

In the future, I think I'll split the corridor generation logic into its own class to improve encapsulation and keep 
responsibilities separate.

The cells are all stored as coordinates and I could have a feature where the dungeon data can be saved and then
exported as a data file and imported into a game engine such as unity or Godot. A script could then be written into
unity or Godot and that could interpret the dungeon data and then create a 3d or 2D visual layout with actual
textures instead of just ASCII symbols that a player object could interact with. 

One possible development would be to introduce an entity system that allows developers to create and manage objects 
within the dungeon, such as player characters, enemies and interactive objects. These entities could maintain their own 
coordinates and expose methods for movement, allowing them to interact with the existing dungeon grid.

I could also introduce a collection of APIs that developers could use to interact with the underlying systems 
without needing to manage the implementation themselves. For example, developers could create a player character, control 
its movement, check which cell it currently occupies and determine whether a destination cell is accessible.
This could eventually provide the foundations for a simple turn-based ASCII game engine, where developers could implement 
their own gameplay mechanics, combat systems and interactions using the functionality provided by the framework.

This would be a great opportunity for me to explore creating an ASCII game engine and creating documentation for 
developers to learn and create their own ASCII style games.

## _Notes_

---

I originally wanted to create an automated email workflow in Python
however I already did something very similar as part of a personal 
project. I decided to listen to what the technical assessment brief
mentioned which was to try something I haven't used before and create
something I find interesting.