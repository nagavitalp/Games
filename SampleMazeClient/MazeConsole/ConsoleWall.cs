using Vital.Games.Elements;

namespace Vital.Games.Console
{
    public class ConsoleWall : Wall
    {
        private readonly IDrawCell _drawCell;
        public ConsoleWall(Coordinate location, IDrawCell drawCell)
        {
            Location = location;
            _drawCell = drawCell;
        }

        public override void Draw()
        {
            _drawCell.Draw(Location, System.ConsoleColor.Blue, System.ConsoleColor.White, Constants.WallIndicator);
        }
    }
}