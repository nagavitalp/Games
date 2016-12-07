using Vital.Games.Elements;

namespace Vital.Games.Console
{
    public class ConsoleWay : Way
    {
        private readonly IDrawCell _drawCell;
        public ConsoleWay(Coordinate location, IDrawCell drawCell)
        {
            Location = location;
            _drawCell = drawCell;
        }

        public override void Draw()
        {
            _drawCell.Draw(Location, System.ConsoleColor.Blue, System.ConsoleColor.White, Constants.WayIndicator);
        }
    }
}