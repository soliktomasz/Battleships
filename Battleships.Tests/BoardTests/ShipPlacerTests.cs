using Battleships.Board;
using Battleships.Models;
using FluentAssertions;
using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.UnitTests.BoardTests
{
    [TestFixture]
    public class ShipPlacerTests
    {
        [Test]
        public void PlaceShip_BoardIsEmpty_CorrectlyPlacesShip()
        {
            // Arrange
            var shipToPlace = new Destroyer();
            var existingBoard = new Board.Board(10);

            // Act
            ShipPlacer.PlaceShip(existingBoard, shipToPlace);

            // Assert
            shipToPlace.Position.Should().HaveCount(shipToPlace.Size, "ship was correctly placed on board");
        }

        [Test]
        public void PlaceShip_BoardContainsShip_CorrectlyPlacesShip()
        {
            // Arrange
            var shipToPlace = new Destroyer();

            var existingShipPlacement = new List<Point>
            {
                new Point {X = 5, Y = 5},
                new Point {X = 5, Y = 4},
                new Point {X = 5, Y = 3},
                new Point {X = 5, Y = 2}
            };

            var existingBoard = new Board.Board(10);
            existingBoard.Tiles.Where(t => existingShipPlacement.Contains(t.Coordinates)).ToList().ForEach(t => t.IsOccupied = true);

            // Act
            ShipPlacer.PlaceShip(existingBoard, shipToPlace);

            // Assert
            shipToPlace.Position.Should().NotContain(existingShipPlacement, "ship should be placed without colliding with ship on board");
        }

        [Test]
        public void PlaceShip_BoardWithPlaceForOneShipHOrizontalOrVertical_CorrectlyPlacesShip()
        {
            // Arrange
            var shipToPlace = new Destroyer();
            
            var freeshipSlot = new List<Point>
            {
                new Point {X = 5, Y = 5},
                new Point {X = 5, Y = 4},
                new Point {X = 5, Y = 3},
                new Point {X = 5, Y = 2},
                new Point {X = 5, Y = 5},
                new Point {X = 4, Y = 5},
                new Point {X = 3, Y = 5},
                new Point {X = 2, Y = 5}
            };

            var existingBoard = new Board.Board(10);
            existingBoard.Tiles.Where(t => !freeshipSlot.Contains(t.Coordinates)).ToList().ForEach(t => t.IsOccupied = true);

            // Act
            ShipPlacer.PlaceShip(existingBoard, shipToPlace);

            // Assert
            freeshipSlot.Should().Contain(shipToPlace.Position, "ship should be placed without colliding with ships on board");
        }
    }
}
