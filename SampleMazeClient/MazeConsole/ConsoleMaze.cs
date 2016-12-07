namespace Vital.Games.Console
{
    public class ConsoleMaze : Maze
    {
        private readonly IDrawCell _drawCell;
        public ConsoleMaze(IMazeFactory mazeFactory, IDrawCell drawCell) : base(mazeFactory)
        {
            _drawCell = drawCell;
        }

        public override void GameOver()
        {
            var coordinate = new Coordinate((Breadth / 2) - 5 + StartAt.X, (Height / 2) + StartAt.Y);
            _drawCell.Draw(coordinate, System.ConsoleColor.White, System.ConsoleColor.Blue, Constants.GameOver);
        }
    }
}
