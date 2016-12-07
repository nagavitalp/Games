namespace Vital.Games.Elements
{
    public abstract class Route : IMazeElement
    {
        public Coordinate Location { get; set; }

        public abstract void Draw();
    }
}
