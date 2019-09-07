using Battleships.Enums;
using Battleships.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Battleships.Board
{
    /// <summary>
    /// Class responsible for placing ship on game board.
    /// </summary>
    public static class ShipPlacer
    {
        /// <summary>
        /// Randomly puts ship on game board.
        /// </summary>
        /// <param name="board">The board on which ship can be placed.</param>
        /// <param name="ship">The ship to place on board.</param>
        public static void PlaceShip(Board board, Ship ship)
        {
            var random = new Random();
            var shipCanBePlaced = false;
            var orientation = GetRandomOrientation();

            while (!shipCanBePlaced)
            {
                var coordinates = new Point
                {
                    X = orientation == Orientation.Horizontal ? random.Next(ship.Size, 10) : random.Next(1, 10),
                    Y = orientation == Orientation.Horizontal ? random.Next(1, 10) : random.Next(ship.Size, 10)
                };

                var shipEnd = board.Tiles.First(t => t.Coordinates == coordinates);

                if (shipEnd.IsOccupied)
                {
                    continue;
                }

                var tilesToOccupy = new List<Tile>
                {
                    shipEnd
                };

                for (int i = 1; i < ship.Size; i++)
                {
                    Tile tile = orientation == Orientation.Horizontal
                        ? board.Tiles.First(t => t.Coordinates.Y == coordinates.Y && t.Coordinates.X == coordinates.X - i)
                        : board.Tiles.First(t => t.Coordinates.X == coordinates.X && t.Coordinates.Y == coordinates.Y - i);

                    if (tile.IsOccupied)
                    {
                        break;
                    }

                    tile.OccupyingShipType = ship.GetType();

                    tilesToOccupy.Add(tile);
                }

                if (tilesToOccupy.Count == ship.Size)
                {
                    ship.Position = tilesToOccupy.Select(t => t.Coordinates).ToList();
                    tilesToOccupy.ForEach(t => board.Tiles.First(boardTile => boardTile == t).IsOccupied = true);
                    shipCanBePlaced = true;
                }
            }
        }

        private static Orientation GetRandomOrientation()
        {
            Array values = Enum.GetValues(typeof(Orientation));
            Random random = new Random();
            return (Orientation)values.GetValue(random.Next(values.Length));
        }
    }
}
