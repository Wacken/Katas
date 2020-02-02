namespace Meiern
{
    public class Game
    {
        private IDices dices;
        private WonStatus status;
        private bool currentPlayer;
        public int LastThrow { get; private set; }

        public enum WonStatus
        {
            None,
            Player,
            Computer
        }

        public Game(IDices dices, bool isPlayerFirst)
        {
            this.dices = dices;
            currentPlayer = isPlayerFirst;
        }

        public void play()
        {
            while (status == WonStatus.None)
            {
                gameLoop();
            }
        }

        private void gameLoop()
        {
            int thrownDices = dices.throwDices();
            if (isMeier(thrownDices))
                status = setPlayerWon(currentPlayer);
            else if (isSmallerThanLast(thrownDices))
                status = setPlayerWon(!currentPlayer);
            else
                status = WonStatus.None;
            LastThrow = thrownDices;
            changeCurrentPlayer();
        }

        private bool isSmallerThanLast(int thrownDices)
        {
            if (isPasch(thrownDices))
                return comparePasch(thrownDices);
            return thrownDices < LastThrow;
        }

        private bool comparePasch(int thrownDices)
        {
            if (isPasch(LastThrow))
                return thrownDices < LastThrow;
            return false;

        }

        private static bool isPasch(int thrownDices)
        {
            return thrownDices % 11 == 0;
        }

        private WonStatus setPlayerWon(bool player)
        {
            return player ? WonStatus.Player : WonStatus.Computer;
        }

        private static bool isMeier(int thrownDices)
        {
            return thrownDices == 21;
        }

        private void changeCurrentPlayer()
        {
            currentPlayer = !currentPlayer;
        }

        public WonStatus playerWon()
        {
            return status;
        }
    }
}