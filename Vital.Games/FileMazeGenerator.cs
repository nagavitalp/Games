using Maze;
using System;
using System.Collections.Generic;

namespace Vital.Games
{
    public class FileMazeGenerator : IMazeGenerator
    {
        private readonly Maze _maze;

        public FileMazeGenerator(IMazeFactory mazeFactory)
        {
            _maze = mazeFactory.CreateMaze();
        }

        public Maze GenerateMaze(Coordinate startAt)
        {
            //TODO: Concentrated in Algo to genrate maze but not on OOAD
            _maze.MazeData = new MazeGenerator1().GetMaze();
            //_maze.MazeData = MazeGenerator.GetMaze();
            _maze.StartAt = startAt;
            _maze.Refresh();
            return _maze;
        }
    }

    //Ref: https://en.wikipedia.org/wiki/Maze_generation_algorithm
    public class MazeGenerator1
    {
        int mazeWidth = 25;
        Stack<Coordinate> coordinatesStack = new Stack<Coordinate>();
        Random randomGenerator = new Random();

        // To support data structure used in existing app need to maintain differen types of data
        string[][] data;
        Coordinate[][] data1;

        public string[][] GetMaze()
        {

            InitializeData();
            // Step 1: Make the initial cell the current cell and mark it as visited
            var currentCell = data1[0][0];
            currentCell.IsVisited = true;

            // Step 2: Recursive call, While there are unvisited cells
            rec(data, currentCell);


            data[0][1] = Constants.StartIndicator;
            data[data.Length - 2][data.Length - 1] = Constants.TargetIndicator;

            CleanUpToSupportCurrentProgram();

            return data;
        }
        private void InitializeData()
        {
            data = new string[(mazeWidth * 2) + 1][];
            data1 = new Coordinate[(mazeWidth * 2)][];
            int totalStars = (2 * mazeWidth) + 1;
            for (int i = 0; i < mazeWidth; i++)
            {
                data1[i] = new Coordinate[mazeWidth];
                for (int j = 0; j < mazeWidth; j++)
                {
                    for (int k = i * 2; k < (i * 2) + 3; k++)
                    {
                        if (data[k] == null)
                        {
                            data[k] = new string[totalStars];
                        }

                        for (int l = j * 2; l < (j * 2) + 3; l++)
                        {
                            data[k][l] = Constants.WallIndicator;
                        }
                    }

                    data1[i][j] = new Coordinate(i, j);
                }
            }
        }
        private void CleanUpToSupportCurrentProgram()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 1; j < data[i].Length; j++)
                {
                    data[i][0] = data[i][0] + data[i][j];
                }
            }
        }

        private void rec(string[][] data, Coordinate currentCell)
        {
            var next = GetRandomUnVisitedNeighbor(currentCell); // current cell has any neighbours which have not been visited
            if (next != null) // If the current cell has any neighbours which have not been visited
            {
                coordinatesStack.Push(currentCell);// Push the current cell to the stack

                RemoveWall(data, currentCell, next); // Remove the wall between the current cell and the chosen cell

                next.IsVisited = true;
                rec(data, next); //Make the chosen cell the current cell and mark it as visited
            }
            else if (coordinatesStack.Count > 0) // Else if stack is not empty
            {
                //Pop a cell from the stack.Make it the current cell
                rec(data, coordinatesStack.Pop());
            }

        }

        private static void RemoveWall(string[][] data, Coordinate currentCell, Coordinate next)
        {
            if (currentCell.Y == next.Y)
            {
                if (currentCell.X < next.X)
                {
                    var x = (2 * currentCell.X) + 1;
                    var y = (2 * currentCell.Y) + 1;
                    data[x][y] = Constants.WayIndicator;
                    data[x + 1][y] = Constants.WayIndicator;
                    data[x + 2][y] = Constants.WayIndicator;
                }
                else
                {
                    var x = (2 * next.X) + 1;
                    var y = (2 * next.Y) + 1;
                    data[x][y] = Constants.WayIndicator;
                    data[x + 1][y] = Constants.WayIndicator;
                    data[x + 2][y] = Constants.WayIndicator;
                }
            }
            if (currentCell.X == next.X)
            {
                if (currentCell.Y < next.Y)
                {
                    var x = (2 * currentCell.X) + 1;
                    var y = (2 * currentCell.Y) + 1;
                    data[x][y] = Constants.WayIndicator;
                    data[x][y + 1] = Constants.WayIndicator;
                    data[x][y + 2] = Constants.WayIndicator;
                }
                else
                {
                    var x = (2 * next.X) + 1;
                    var y = (2 * next.Y) + 1;
                    data[x][y] = Constants.WayIndicator;
                    data[x][y + 1] = Constants.WayIndicator;
                    data[x][y + 2] = Constants.WayIndicator;
                }
            }
            //data[currentCell.X][currentCell.Y] = Constants.WayIndicator;
            //data[next.X][next.Y] = Constants.WayIndicator;
        }


        private Coordinate GetRandomUnVisitedNeighbor(Coordinate currentNode)
        {

            int x = currentNode.X;
            int y = currentNode.Y;
            int counter = 0;
            Coordinate[] cs = new Coordinate[4];
            if (x - 1 > 0)
            {
                var node = data1[currentNode.X - 1][currentNode.Y];
                if (!node.IsVisited)
                {
                    cs[counter] = node;
                    counter++;
                }

            }
            if (x + 1 < mazeWidth)
            {
                var node = data1[currentNode.X + 1][currentNode.Y];
                if (!node.IsVisited)
                {
                    cs[counter] = node;
                    counter++;
                }
            }
            if (y - 1 > 0)
            {

                var node = data1[currentNode.X][currentNode.Y - 1];
                if (!node.IsVisited)
                {
                    cs[counter] = node;
                    counter++;
                }
            }
            if (y + 1 < mazeWidth)
            {
                var node = data1[currentNode.X][currentNode.Y + 1];
                if (!node.IsVisited)
                {
                    cs[counter] = node;
                    counter++;
                }
            }
            if (counter > 0)
            {
                return cs[randomGenerator.Next(0, counter)];
            }
            else
            {
                return null;
            }
        }
    }
}
