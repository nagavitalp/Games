using Vital.Games.Elements;

namespace Vital.Games.Console
{
    public class ConsoleRoute : Route
    {
        private readonly IDrawCell _drawCell;
        public ConsoleRoute(Coordinate location, IDrawCell drawCell)
        {
            Location = location;
            _drawCell = drawCell;
        }

        public override void Draw()
        {
            _drawCell.Draw(Location, System.ConsoleColor.White, System.ConsoleColor.Black, Constants.SolutionIndicator);
        }
    }
}