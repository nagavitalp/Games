using System;
using Vital.Games.Elements;

namespace Vital.Games.Console
{
    public class ConsoleMazeFactory : IMazeFactory
    {
        private static readonly IDrawCell drawCell = new DrawCell();
        public Destination CreateDestination(Coordinate coordinate)
        {
            return new ConsoleDestination(coordinate, drawCell);
        }

        public Maze CreateMaze()
        {
            return new ConsoleMaze(this, drawCell);
        }

        public Route CreateRoute(Coordinate coordinate)
        {
            return new ConsoleRoute(coordinate, drawCell);
        }

        public Start CreateStart(Coordinate coordinate)
        {
            return new ConsoleStart(coordinate, drawCell);
        }

        public Wall CreateWall(Coordinate coordinate)
        {
            return new ConsoleWall(coordinate, drawCell);
        }

        public Way CreateWay(Coordinate coordinate)
        {
            return new ConsoleWay(coordinate, drawCell);
        }
        public IMazeElement GetMazeElement(string key, Coordinate coordinate)
        {
            switch (key.ToUpperInvariant())
            {
                case Constants.StartIndicator:
                    return CreateStart(coordinate);
                case Constants.TargetIndicator:
                    return CreateDestination(coordinate);
                case Constants.WallIndicator:
                    return CreateWall(coordinate);
                case Constants.WayIndicator:
                    return CreateWay(coordinate);
                default:
                    throw new NotSupportedException(
                        $"{key} key is not supported. Supported keys are {Constants.WallIndicator}, {Constants.WayIndicator}, {Constants.StartIndicator}, {Constants.TargetIndicator}, {Constants.SolutionIndicator}");
            }
        }
    }
}