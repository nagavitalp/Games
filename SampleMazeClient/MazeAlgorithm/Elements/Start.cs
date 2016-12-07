namespace Vital.Games.Elements
{
    public abstract class Start : IMazeElement
    {
        public Coordinate Location { get; set; }

        public abstract void Draw();

    }
}
