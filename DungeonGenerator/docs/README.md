
# Dungeon Generator

---

## What I built

---

For this technical assessment I have built a command-line software application that I find interesting. 
The user is able to pick from a few options:
- Create Dungeon
- Place Room
- Generate Procedural Dungeon
- Clear Console
- Quit Programme



## Why I built it

---

The inspiration for this project came from a game I heard of called
[Warsim: The Realm of Aslona](https://store.steampowered.com/app/659540/Warsim_The_Realm_of_Aslona/).
This is where I first took in interest in procedural generation and I wanted to create something similar.
I was already working on a few game projects in Godot at the time and didn't want to start a new project
without finishing the ones I was already working on.

For this technical assessment I was going to create the procedural generation in Godot however, the
technical brief asked that I try a new technology. When I was studying in university we were given
constraints with what programming languages and technologies we could use. Most of the assessments
required the use of Java and Java Libraries such as JavaFX but some assessments allowed us to pick
our tech stack. For me the languages I worked with in Uni were Java, Python, C++, HTML, CSS and
JavaScript. Up until completing this technical assessment I hadn't used C# and since the technical
brief encouraged me to use a tech stack I had little or no experience in, I decided to give C# a go.
Luckily for me my student licence for JetBrains was stil active even though I have graduated and I have
access to the education edition of JetBrains Rider which supports C# development.


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

Dungeon Class:

Room Class:

Renderer Class:

Corridor Class:

CellType:

ProceduralDungeonGenerator:

Docker File

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

I would make the project compatible with game engines
such as Unity and Godot to allow more developers 
to use the program. I would create gui to better
represent the dungeon creator process so the user
can watch their dungeon get created in real time.


## _Notes_

---

I originally wanted to create an automated email workflow in Python
however I already did something very similar as part of a personal 
project. I decided to listen to what the technical assessment brief
mentioned which was to try something I haven't used before and create
something I find interesting.