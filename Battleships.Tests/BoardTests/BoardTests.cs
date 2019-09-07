using FluentAssertions;
using NUnit.Framework;

namespace Battleships.UnitTests.BoardTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void Board_CorrectBoardSizeProvided_CreatesBoard()
        {
            // Arrange
            const int boardSize = 10;

            // Act
            var board = new Board.Board(boardSize);

            // Assert
            board.Tiles.Should().HaveCount(100, "board was created correctly");
        }
    }
}
