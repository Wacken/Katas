using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace Meiern
{
    [TestFixture]
    public class GameTest
    {
        [Test]
        public void createDices()
        {
            Dices dices = new Dices(null);
            Assert.NotNull(dices);
        }

        [TestCase(1, 3, 31)]
        [TestCase(3, 1, 31)]
        [TestCase(1, 1, 11)]
        public void throws_N_ReturnsCombinedNumber(int firstThrow, int secondThrow, int result)
        {
            Die die = Substitute.For<Die>();
            die.throws().Returns(firstThrow, secondThrow);
            Dices dices = new Dices(die);
            int number = dices.throwDices();
            Assert.AreEqual(result, number);
        }

        [Test]
        public void play_PlayerThrowsHighest_PlayerWins()
        {
            var game = createGame(21);
            game.play();
            assertPlayerWon(game);
        }

        [Test]
        public void play_ComputerFirstThrowsHighest_ComputerWins()
        {
            var game = createGame(21, false,null);
            game.play();
            Assert.AreEqual(Game.WonStatus.Computer,game.playerWon(),game.LastThrow.ToString());
        }

        [Test]
        public void play_ComputerAndPlayerThrowsHighest_PlayerWins()
        {
            var game = createGame(66, false, new[] {21});
            game.play();
            assertPlayerWon(game);;
        }
        
        [TestCase(new[]{66,31})]
        [TestCase(new[]{22,11})]
        [TestCase(new[]{31,11,21})]
        [TestCase(new[]{31,43,22,55,66,31})]
        [TestCase(new[]{33,31})]
        public void play_PlayerStarts_PlayerWins(int[] diceThrows)
        {

            Game game = createGame(diceThrows[0], true, 
                Enumerable.Range(1,diceThrows.Length - 1).Select(index => diceThrows[index]).ToArray());
            game.play();
            assertPlayerWon(game);
        }
        
        

        private static void assertPlayerWon(Game game)
        {
            Assert.AreEqual(Game.WonStatus.Player,game.playerWon(),game.LastThrow.ToString());
        }

        private Game createGame(int firstDice)
        {
            return createGame(firstDice, true, null);
        }

        private static Game createGame(int firstDice, bool isPlayerFirst, int[] otherDice)
        {
            IDices dices = Substitute.For<IDices>();
            dices.throwDices().Returns(firstDice,otherDice);
            Game game = new Game(dices, isPlayerFirst);
            return game;
        }
    }
}