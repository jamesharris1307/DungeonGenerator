
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

Tests

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