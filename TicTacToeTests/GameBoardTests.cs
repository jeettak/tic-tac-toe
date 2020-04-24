using System;
using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameBoardTests
    {
        private Fixture _fixture;
        private GameBoard _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new GameBoard();
            _fixture = new Fixture();
        }

        #region MakeMove Tests

        [Test]
        public void AnInvalid_Player_ProvidedTo_MakeMove_Throws_ArgumentNullException()
        {
            // Arrange and Act
            var exception = Assert.Throws<ArgumentNullException>(() => _sut.MakeMove(null, 1));

            // Assert
            exception.ParamName.Should().Be("player");
        }

        [TestCase(0)]
        [TestCase(10)]
        public void AnInvalid_InputValue_Throws_ArgumentException(int value)
        {
            // Arrange 
            var player = _fixture.Create<PlayerForX>();
            
            // Act
            var exception = Assert.Throws<ArgumentException>(() => _sut.MakeMove(player, value));

            // Assert
            exception.ParamName.Should().Be("input");
        }

        [Test]
        public void Valid_Input_For_MakeMove_Completes_Successfully()
        {
            // Arrange 
            var input = 5;
            var player = _fixture.Create<PlayerForX>();

            // Act
            Assert.DoesNotThrow(() => _sut.MakeMove(player, input));

            // Assert
            _sut.TotalTurns.Should().Be(1);
        }

        #endregion

        #region ResetBoard Tests

        [Test]
        [Ignore("Need to refactor the console interaction")]
        public void TotalTurns_Is_Zero_When_ResetBoard_Invoked()
        {
            // Arrange and Act
            _sut.ResetBoard();

            // Assert
            _sut.TotalTurns.Should().Be(0);
        }

        #endregion
    }
}
