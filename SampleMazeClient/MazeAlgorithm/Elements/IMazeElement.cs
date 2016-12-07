namespace Vital.Games.Elements
{
    public interface IMazeElement
    {
        Coordinate Location { get; set; }
        void Draw();
    }

    
}
