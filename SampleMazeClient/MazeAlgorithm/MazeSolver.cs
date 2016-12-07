using System;
using System.Collections.Generic;
using System.Linq;
using Vital.Games.Elements;

namespace Vital.Games
{
    public class MazeSolver : IMazeSolver
    {
        private readonly List<IMazeElement> _visitedRoute = new List<IMazeElement>();
        private readonly Stack<IMazeElement> _mazeRoute = new Stack<IMazeElement>();
        private Maze _maze;
        private readonly IMazeFactory _mazeFactory;

        public MazeSolver(IMazeFactory mazeFactory)
        {
            _mazeFactory = mazeFactory;
        }
        private void SolveMaze()
        {
            var startValue = FindAndAddStartNodeToMyRoute();
            if (startValue)
            {
                FindTarget();
            }
            else
            {
                throw new InvalidOperationException("Invalid Maze. Maze doesn't contain either start or destination");
            }

        }

        private bool FindAndAddStartNodeToMyRoute()
        {
            IMazeElement startNode = _maze.FindNode<Start>();
            IMazeElement finishNode = _maze.FindNode<Destination>();

            if (startNode != null && finishNode != null)
            {
                AddToRoute(startNode);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void FindTarget()
        {
            IMazeElement way = GetNonVisitedWay();

            if (way == null)
            {
                _mazeRoute.Pop(); //No Way! lets go back
                FindTarget();
            }
            else
            {
                AddToRoute(way);
                if (!(way is Destination))
                {
                    FindTarget();
                }
            }
        }

        private IMazeElement GetNonVisitedWay()
        {
            List<Coordinate> neighbors = GetProbableNeighbors();
            return GetNonVisitedNeighbor(neighbors);
        }

        private IMazeElement GetNonVisitedNeighbor(List<Coordinate> neighbors)
        {
            foreach (var neighbor in neighbors)
            {
                var node = FindNode(neighbor);

                if (node != null)
                {
                    return node;
                }
            }

            return null;
        }

        private List<Coordinate> GetProbableNeighbors()
        {

            var currentMazeElement = _mazeRoute.Peek(); //get my current position
            var currentNode = currentMazeElement.Location;

            List<Coordinate> neighbors = new List<Coordinate>
            {
                new Coordinate(currentNode.X - 1, currentNode.Y),
                new Coordinate(currentNode.X + 1, currentNode.Y),
                new Coordinate(currentNode.X, currentNode.Y - 1),
                new Coordinate(currentNode.X, currentNode.Y + 1)
            };
            return neighbors;
        }


        private void AddToRoute(IMazeElement start)
        {
            var route = _mazeFactory.CreateRoute(start.Location);
            _visitedRoute.Add(route);
            _mazeRoute.Push(route);
        }

        public Maze SolveMaze(Maze maze)
        {
            _visitedRoute.Clear();
            _mazeRoute.Clear();
            _maze = maze;
            _maze.Refresh();
            SolveMaze();
            var solvedMaze = MergeMyRouteInMaze();
            solvedMaze.Draw();
            return solvedMaze;
        }

        private Maze MergeMyRouteInMaze()
        {
            while (_mazeRoute.Any())
            {
                var node = _mazeRoute.Pop();
                var mazeElement = _maze[node.Location];
                if (mazeElement is Way)
                {
                    _maze[node.Location] = node;
                }
            }

            return _maze;
        }
        private IMazeElement FindNode(Coordinate coordinate)
        {
            var value = _maze.FindNode(coordinate);
            bool isInVisitedRoute = _visitedRoute.Exists(p => p.Location.Equals(coordinate));
            if ((value is Way || value is Destination) && !isInVisitedRoute)
            {
                return value;
            }
            return null;
        }
    }
}
