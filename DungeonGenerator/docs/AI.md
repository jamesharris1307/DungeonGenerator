
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

### Suggestion 2:

I utilised ChatGPT to assist in the Docker error when creating a docker image. The AI
assistant was able to recommend a different version of the Microsoft SDK that allows the
docker file to build.

Also, there was an issue with Docker Desktop where when I created a container that didn't 
allow input the Console.ReadLine defaulted to null and caused the main menu to just loop
indefinetly.

## How verified AI suggestions

- Checking Documentation [Here]()
- Validating through Unit Test
- Validating through manual testing by building the project and running the .exe