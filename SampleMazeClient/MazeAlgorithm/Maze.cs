using System.Linq;
using System.Collections.Generic;
using Vital.Games.Elements;

namespace Vital.Games
{
    public abstract class Maze
    {
        private readonly IMazeFactory _mazeFactory;

        protected Maze(IMazeFactory mazeFactory)
        {
            _mazeFactory = mazeFactory;
        }

        protected int Breadth => Elements.GetUpperBound(0);
        protected int Height => Elements.GetUpperBound(1);
        public string[][] MazeData { get; set; }
        public void Refresh()
        {
            var maxRowSize = MazeData.Length;
            int maxColSize = MazeData.Select(t => t[0].Length).Concat(new[] { 0 }).Max();
            var maze = new IMazeElement[maxColSize, maxRowSize];
            
            //// Populate data into maze array
            for (int row = 0; row < MazeData.Length; ++row)
            {
                var data = MazeData[row][0].ToCharArray();
                for (int column = 0; column < data.Length; ++column)
                {
                    string key = data[column].ToString().ToUpperInvariant();
                    maze[column, row] = _mazeFactory.GetMazeElement(key, new Coordinate(StartAt.X + column, StartAt.Y + row));
                    if (key == Constants.StartIndicator)
                    {
                        CurrentElement = maze[column, row];
                    }
                }
            }
            Elements = maze;
        }
        
        public IMazeElement this[Coordinate coordinate]
        {
            get { return Elements[coordinate.X - StartAt.X, coordinate.Y - StartAt.Y]; }
            set { Elements[coordinate.X - StartAt.X, coordinate.Y - StartAt.Y] = value; }
        }

        public IMazeElement[,] Elements { get; set; }

        public IMazeElement CurrentElement { get; set; }
        public Coordinate StartAt { get; set; }

        public void MoveAStep(Coordinate coordinate)
        {
            var toMoveElement = FindNode(coordinate);
            if (toMoveElement is Way)
            {
                this[coordinate] = _mazeFactory.CreateRoute(coordinate);
                CurrentElement = this[coordinate];
                CurrentElement.Draw();
            }
            else if (toMoveElement is Route)
            {
                this[CurrentElement.Location] = _mazeFactory.CreateWay(CurrentElement.Location);
                this[CurrentElement.Location].Draw();
                CurrentElement = toMoveElement;
                CurrentElement.Draw();
            }
            else if (toMoveElement is Destination)
            {
                GameOver();
            }
        }

        public abstract void GameOver();

        public bool CanMoveAStep(Coordinate coordinate)
        {
            if (ElementExists(coordinate))
            {
                return !(this[coordinate] is Wall);
            }
            return false;
        }

        public virtual void Draw()
        {
            foreach (var item in Elements)
            {
                item.Draw();
            }
        }

        public bool ElementExists(Coordinate coordinate)
        {
            if (coordinate.X < StartAt.X || coordinate.Y < StartAt.Y || coordinate.X > Breadth + StartAt.X ||
                coordinate.Y > Height + StartAt.Y)
            {
                return false;
            }
            return true;
        }

        public IMazeElement FindNode(Coordinate coordinate)
        {
            if (ElementExists(coordinate))
            {
                return this[coordinate];
            }
            return null;
        }

        public IMazeElement FindNode<T>()
        {
            foreach (var element in Elements)
            {
                if (element is T)
                {
                    return element;
                }
            }

            throw new KeyNotFoundException($"IMazeElement of type {typeof (T)} not found");
        }
    }
}