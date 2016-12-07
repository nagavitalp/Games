using System;
using Vital.Games;

namespace SampleMazeClient
{
    public class Program
    {
        private static IMazeGame mazeGame;

        public static void Main(string[] args)
        {
            var result = true;
            mazeGame = DependencyFactory.Resolve<IMazeGame>();
            mazeGame.StartNew(new Coordinate(2, 2));
            //ShowOptions();
            while (result)
            {
                var input = Console.ReadKey();

                result = Execute(input);
                if (!result)
                {
                    result = Execute1(input);
                }
            }
        }


        public static bool Execute(ConsoleKeyInfo input)
        {
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    if(!mazeGame.MoveLeft())
                    {
                        Console.Beep();
                    }
                    return true;
                case ConsoleKey.RightArrow:
                    if(!mazeGame.MoveRight())
                    {
                        Console.Beep();
                    }
                    return true;
                case ConsoleKey.UpArrow:
                    if(!mazeGame.MoveUp())
                    {
                        Console.Beep();
                    }
                    return true;
                case ConsoleKey.DownArrow:
                    if(!mazeGame.MoveDown())
                    {
                        Console.Beep();
                    }
                    return true;
            }

            return false;
        }
        public static bool Execute1(ConsoleKeyInfo input)
        {            
            string inputChar = input.KeyChar.ToString().ToUpperInvariant();
            if (inputChar == "S")
            {
                mazeGame.Solve();
                return true;
            }
            else if (inputChar == "N")
            {
                mazeGame.StartNew(new Coordinate(2,2));
                return true;
            }
            else if(input.Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }

        private static void ShowOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Press 'N' for new game");
            Console.WriteLine("Press 'S' to solve game");
            Console.WriteLine("Press 'esc' to quit game");
        }
    }
}