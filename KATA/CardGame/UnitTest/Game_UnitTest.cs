using NUnit.Framework;

namespace CardGame.UnitTest
{
    [TestFixture]
    public class Game_UnitTest
    {
        [Test]
        [Ignore("Creational Endless Loop")]
        public void Game_Null_HasTwoPlayers()
        {
            Assert.NotNull(StandardGame.Instance.Player1);
            Assert.NotNull(StandardGame.Instance.Player2);
        }
    }
}