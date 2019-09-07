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
            // Act
            var board = new Board.Board();

            // Assert
            board.Tiles.Should().HaveCount(100, "board was created correctly");
        }
    }
}
