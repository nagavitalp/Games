namespace Vital.Games.Console
{
    public interface IDrawCell
    {
        void Draw(Coordinate location, System.ConsoleColor backGroundColor, System.ConsoleColor foreGroundColor,string text);
    }
}
