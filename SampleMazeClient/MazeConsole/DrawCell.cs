using System;

namespace Vital.Games.Console
{
    public class DrawCell : IDrawCell
    {
        public void Draw(Coordinate location, ConsoleColor backGroundColor, ConsoleColor foreGroundColor, string text)
        {
            System.Console.SetCursorPosition(location.X, location.Y);
            System.Console.BackgroundColor = backGroundColor;
            System.Console.ForegroundColor = foreGroundColor;
            System.Console.Write(text);
            System.Console.SetCursorPosition(location.X, location.Y);
        }
    }
}