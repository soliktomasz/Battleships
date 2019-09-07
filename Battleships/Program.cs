using System;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello to Battleships!\n\nTo shoot tile type letter for column and number for row.\nFor example: 'A5'");

            Game.Game.StartGame();
        }
    }
}
