namespace Vital.Games
{
    public class MazeGame : IMazeGame
    {
        private readonly IMazeGenerator _mazeGenerator;
        private readonly IMazeSolver _mazeSolver;
        private Maze _maze;

        public MazeGame(IMazeGenerator mazeGenerator, IMazeSolver mazeSolver)
        {
            _mazeGenerator = mazeGenerator;
            _mazeSolver = mazeSolver;
        }

        public void StartNew(Coordinate startAt)
        {
            _maze = _mazeGenerator.GenerateMaze(startAt);
            _maze.Draw();
        }

        public bool MoveLeft()
        {
            var element = new Coordinate(_maze.CurrentElement.Location.X - 1, _maze.CurrentElement.Location.Y);
            return Move(element);
        }

        public bool MoveRight()
        {
            var element = new Coordinate(_maze.CurrentElement.Location.X + 1, _maze.CurrentElement.Location.Y);
            return Move(element);
        }

        public bool MoveUp()
        {
            var element = new Coordinate(_maze.CurrentElement.Location.X, _maze.CurrentElement.Location.Y - 1);
            return Move(element);
        }

        public bool MoveDown()
        {
            var element = new Coordinate(_maze.CurrentElement.Location.X, _maze.CurrentElement.Location.Y + 1);
            return Move(element);
        }

        public void Solve()
        {
            var solvedMaze = _mazeSolver.SolveMaze(_maze);
            solvedMaze.GameOver();
        }

        private bool Move(Coordinate element)
        {
            _maze.CurrentElement.Draw();
            if (_maze.CanMoveAStep(element))
            {
                _maze.MoveAStep(element);
                return true;
            }
            return false;
        }
    }
}