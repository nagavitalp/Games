namespace Vital.Games.Elements
{
    public abstract class Wall : IMazeElement
    {
        public Coordinate Location { get; set; }

        public abstract void Draw();
    }
}
