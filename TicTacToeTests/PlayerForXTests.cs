using FluentAssertions;
using NUnit.Framework;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class PlayerForXTests
    {
        private PlayerForX _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PlayerForX();
        }

        [Test]
        public void PlayerId_Should_Return_2()
        {
            // Arrange, Act and Assert
            _sut.PlayerId.Should().Be(1);
        }

        [Test]
        public void PlayerSignature_Should_Return_O()
        {
            // Arrange, Act and Assert
            _sut.PlayerSignature.Should().Be('X');
        }
    }
}
