namespace Vital.Games.Elements
{
    public abstract class Way : IMazeElement
    {
        public Coordinate Location { get; set; }

        public abstract void Draw();
    }
}
