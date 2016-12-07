namespace Vital.Games.Elements
{
    public abstract class Destination : IMazeElement
    {
        public Coordinate Location { get; set; }

        public abstract void Draw();
    }
}
