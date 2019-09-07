using Battleships.Board;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Battleships.Game
{
    public static class Game
    {
        public static void StartGame()
        {
            var endOfGame = false;
            var board = new Board.Board();
            var ships = new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };
            var shipsToDestroy = ships.Count();

            ships.ForEach(ship => ShipPlacer.PlaceShip(board, ship));

            while (!endOfGame)
            {
                Console.WriteLine("\nShoot Tile:");
                var input = Console.ReadLine();

                if (input.Length <= 1)
                {
                    Console.WriteLine("Please provide proper value");
                    continue;
                }

                var column = char.ToUpper(input[0]) - 64;

                if (!int.TryParse(input.Substring(1), out int row) || IsNotInRange(row) || IsNotInRange(column) || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("Please provide value in a proper format. For example 'A5'.");
                    continue;
                }

                var shotTile = board.Tiles.First(t => t.Coordinates.X == column && t.Coordinates.Y == row);

                if (shotTile.IsOccupied)
                {
                    Console.WriteLine("That's a direct hit!");
                    shotTile.IsOccupied = false;

                    var shotShip = ships.Find(ship => ship.Position.Contains(new Point { X = column, Y = row }));
                    shotShip.Hits += 1;

                    if (shotShip.Size == shotShip.Hits)
                    {
                        Console.WriteLine($"{shotShip.Name} was destroyed!");
                        shipsToDestroy--;
                    }

                    if(shipsToDestroy == 0)
                    {
                        Console.WriteLine("Congratulations! You've won!");
                        endOfGame = true;
                    }
                }
                else
                {
                    Console.WriteLine("That's a miss.");
                }
            }

        }

        private static bool IsNotInRange(int value)
        {
            return value <= 0 || value > 10;
        }
    }
}
