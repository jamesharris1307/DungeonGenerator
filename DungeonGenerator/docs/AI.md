
# AI Disclosure

---

## Tools Used

---

- ChatGPT


## AI suggestions

---

### Suggestion 1: Helping with looping through multidimensional arrays

I utilised ChatGPT to help me create some of the for loops when iterating
through the 2d multidimensional array. 

```
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 || y == height - 1 ||
                    x == 0 || x == width - 1)
                {
                    _map[y, x] = CellType.Boundary;
                }
                else
                {
                    _map[y, x] = CellType.Empty;
                }
            }
        }
```

The code above first iterates through rows and then the nested for loop
iterates through the columns. A boundary detection is done to check if the 
current cell is positioned along the outer edge of the dungeon. If the cell
is on the outer edge it is assigned boundary otherwise its assigned empty.


These types of for loops can be confusing when implementing and ChatGPT was
helpful in simplifying that process. The corridor logic was particully 
tricky for me when attempting to complete unassisted.

```
            // Horizontal corridor.
            int minX = Math.Min(startX, endX);
            int maxX = Math.Max(startX, endX);

            for (int x = minX; x <= maxX; x++)
            {
                if (_map[startY, x] == CellType.Empty)
                {
                    _map[startY - 1, x] = CellType.CorridorWall;
                    _map[startY, x] = CellType.CorridorFloor;
                    _map[startY + 1, x] = CellType.CorridorWall;
                }
            }

            // Vertical corridor.
            int minY = Math.Min(startY, endY);
            int maxY = Math.Max(startY, endY);

            for (int y = minY; y <= maxY; y++)
            {
                if (_map[y, endX] == CellType.Empty)
                {
                    _map[y, endX - 1] = CellType.CorridorWall;
                    _map[y, endX] = CellType.CorridorFloor;
                    _map[y, endX + 1] = CellType.CorridorWall;
                }
            }
        }
    }
```

This code above connects two rooms by generating an L-shaped corridor between 
their centre coordinates. It first calculates the minimum and maximum X 
coordinates using Math.Min() and Math.Max() to determine the horizontal path, 
then iterates through each position using a for loop. It checks whether each 
cell is empty before assigning corridor walls and floors. The same process is 
repeated vertically using the Y coordinates.

### Suggestion 2: Docker configuration and troubleshooting

I utilised ChatGPT to help investigate an error encountered when building my 
Docker image. The initial Dockerfile used a different version of the 
Microsoft .NET SDK image, which resulted in a build error. ChatGPT suggested 
changing the SDK image version to `10.0.301`, which resolved the issue and allowed 
the Docker image to build successfully.

I also encountered an issue with Docker Desktop when creating and running a container. 
The container was not configured to accept interactive input, meaning that 
`Console.ReadLine()` returned `null`. This caused the application's main menu to 
repeatedly display because it was unable to receive user input.

I investigated the issue and identified that the problem was with how the container 
was being launched rather than the application's menu logic. I corrected the 
container configuration to allow interactive input. 

### Suggestion 3:

When looking at how to create unit tests in C# .NET ChatGPT recommended that I use XUnit
as seen [here](https://xunit.net/?tabs=cs). I initially was going to integrate XUnit
as a dependency in this project however earlier when I was creating my project in 
JetBrains Rider I noticed that I could create a Test project and after doing this
I found out that it came with NUnit already as a dependency and already configured
for my use. So even though XUnit seemed perfectly reasnoble to utilise in this
prject I went with NUnit because it was the simpler option.

## How verified AI suggestions

- Checking Documentation
- Validating through Unit Test
- Validating through manual testing by building the project and running the .exe
- Getting the AI to explain all their suggestions step by step.

## Overall Conclusion:

Using AI as a tool to help with the development of this project was mostly helpful. I
prefer using an AI agent where it doesn't have access to my code base but can just
make suggestions that I can read through and decide on my own what changes to make.
Which is what I did here. I had a browser open with ChatGPT on and I asked it for
suggestions as detailed above.

One thing to note that many of the AI's suggestions were later changed in favour of
a better solution. For example the changes suggested for the Docker Image being run
without input caused an endless loop, the AI suggestions caused problems with the main
applicaiton just running in the IDE so they were removed and reverted back to a stable
version. Also, the AI suggestion to utilise XUnit was more overhead than just using
NUnit which was already pre-configured with JetBrains Rider. I think this was missed
by the AI because it didn't have a reference to what IDE I was using.