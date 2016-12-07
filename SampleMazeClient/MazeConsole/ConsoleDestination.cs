using Vital.Games.Elements;

namespace Vital.Games.Console
{
    public class ConsoleDestination : Destination
    {
        private readonly IDrawCell _drawCell;
        public ConsoleDestination(Coordinate location,IDrawCell drawCell)
        {
            Location = location;
            _drawCell = drawCell;
        }

        public override void Draw()
        {
            _drawCell.Draw(Location, System.ConsoleColor.White, System.ConsoleColor.Black,Constants.TargetIndicator);
        }

    }
}