using Vital.Games.Elements;

namespace Vital.Games
{
    public interface IMazeFactory
    {
        Wall CreateWall(Coordinate coordinate);
        Way CreateWay(Coordinate coordinate);
        Start CreateStart(Coordinate coordinate);
        Destination CreateDestination(Coordinate coordinate);
        Maze CreateMaze();
        Route CreateRoute(Coordinate coordinate);
        IMazeElement GetMazeElement(string key, Coordinate coordinate);
    }
}
