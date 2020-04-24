using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using TicTacToe;
using TicTacToe.Interfaces;

namespace TicTacToeTests
{
    [TestFixture]
    public class GameTests
    {
        private Mock<IBoard> _mockGameBoard;
        private Mock<IPlayerRepository> _mockPlayerRepository;

        [SetUp]
        public void Setup()
        {
        }

        #region Constructor Tests

        [Test]
        public void AnInvalid_PlayerRepository_Throws_ArgumentNullException()
        {
            // Arrange 
            _mockGameBoard = new Mock<IBoard>(MockBehavior.Strict);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Game(_mockGameBoard.Object, null));

            // Assert
            exception.ParamName.Should().Be("playerRepository");
        }

        [Test]
        public void AnInvalid_Board_Throws_ArgumentNullException()
        {
            // Arrange 
            _mockPlayerRepository = new Mock<IPlayerRepository>(MockBehavior.Strict);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Game(null, _mockPlayerRepository.Object));

            // Assert
            exception.ParamName.Should().Be("gameBoard");
        }

        [Test]
        public void ANull_PlayerForX_Throw_ArgumentNullException()
        {
            // Arrange
            PlayerForX playerForX = null;
            _mockPlayerRepository = new Mock<IPlayerRepository>(MockBehavior.Strict);
            _mockGameBoard = new Mock<IBoard>(MockBehavior.Strict);

            _mockPlayerRepository
                .Setup(pr => pr.GetPlayer(It.Is<string>(s => s.Equals("PlayerX"))))
                .Returns(playerForX);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Game(_mockGameBoard.Object, _mockPlayerRepository.Object));

            // Assert
            exception.ParamName.Should().Be("PlayerForX");
        }

        [Test]
        public void ANull_PlayerForO_Throw_ArgumentNullException()
        {
            // Arrange
            PlayerForX playerForO = null;
            _mockPlayerRepository = new Mock<IPlayerRepository>(MockBehavior.Strict);
            _mockGameBoard = new Mock<IBoard>(MockBehavior.Strict);

            _mockPlayerRepository
                .Setup(pr => pr.GetPlayer(It.Is<string>(s => s.Equals("PlayerX"))))
                .Returns(new PlayerForX());

            _mockPlayerRepository
                .Setup(pr => pr.GetPlayer(It.Is<string>(s => s.Equals("PlayerO"))))
                .Returns(playerForO);

            // Act
            var exception = Assert.Throws<ArgumentNullException>(() => new Game(_mockGameBoard.Object, _mockPlayerRepository.Object));

            // Assert
            exception.ParamName.Should().Be("PlayerForO");
        }

        [Test]
        public void Valid_Parameters_Return_Constructed_Game()
        {
            // Arrange
            _mockPlayerRepository = new Mock<IPlayerRepository>(MockBehavior.Strict);
            _mockGameBoard = new Mock<IBoard>(MockBehavior.Strict);

            _mockPlayerRepository
                .Setup(pr => pr.GetPlayer(It.Is<string>(s => s.Equals("PlayerX"))))
                .Returns(new PlayerForX());

            _mockPlayerRepository
                .Setup(pr => pr.GetPlayer(It.Is<string>(s => s.Equals("PlayerO"))))
                .Returns(new PlayerForO());

            // Act and Assert
            Assert.DoesNotThrow(() => new Game(_mockGameBoard.Object, _mockPlayerRepository.Object));
        }

        #endregion

        #region Play Tests

        #endregion
    }
}
