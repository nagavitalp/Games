using Maze;

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
            _maze.MazeData = MazeGenerator.GetMaze();
            _maze.StartAt = startAt;
            _maze.Refresh();
            return _maze;
        }
    }
}
