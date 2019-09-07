using Battleships.Board;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Battleships.Game
{
    /// <summary>
    /// Class responsible for initializing new game.
    /// </summary>
    public static class Game
    {
        /// <summary>
        /// Starts new game.
        /// </summary>
        public static void StartGame()
        {
            var board = new Board.Board();

            var ships = new List<Ship>
            {
                new Battleship(),
                new Destroyer(),
                new Destroyer()
            };

            ships.ForEach(ship => ShipPlacer.PlaceShip(board, ship));

            PlayGame(board, ships);
        }

        private static void PlayGame(Board.Board board, List<Ship> ships)
        {
            var endOfGame = false;
            var shipsToDestroy = ships.Count();

            while (!endOfGame)
            {
                if (!TryParsePlayerInput(out int column, out int row))
                {
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

                        Console.WriteLine($"{shotShip.GetType().Name} was destroyed!");
                        shipsToDestroy--;
                    }

                    if (shipsToDestroy == 0)
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

        private static bool TryParsePlayerInput(out int column, out int row)
        {
            row = 0;
            column = 0;

            Console.WriteLine("\nShoot Tile:");
            var input = Console.ReadLine();

            if (input.Length <= 1)
            {
                Console.WriteLine("Please provide proper value");
                return false;
            }

            column = char.ToUpper(input[0]) - 64;
            if (!int.TryParse(input.Substring(1), out row) || !char.IsLetter(input[0]))
            {
                Console.WriteLine("Please provide value in a proper format. For example 'A5'.");
                return false;
            }
            else if(IsNotInRange(row) || IsNotInRange(column))
            {
                Console.WriteLine("Please provide value in range between 1 and 10 or A to J.");
                return false;
            }

            return true;
        }

        private static bool IsNotInRange(int value)
        {
            return value <= 0 || value > 10;
        }
    }
}
