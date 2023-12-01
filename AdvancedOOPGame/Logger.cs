using System;
namespace AdvancedOOPGame
{
	public static class Logger
	{
        static readonly ConsoleColor defaultColor = ConsoleColor.White;
        public static void Log(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ForegroundColor = defaultColor;
        }
    }
}

