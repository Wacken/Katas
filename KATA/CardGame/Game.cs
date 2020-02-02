namespace CardGame.UnitTest
{
    public interface Game
    {
        Player getOpponent();
        Player Player1 { get; }
        Player Player2 { get; }
    }
    
    internal class StandardGame : Game
    {
        private static StandardGame instance;
        public static StandardGame Instance
        {
            get { return instance != null ? instance : new StandardGame(); }
        }

        // private StandardGame()
        // {
        //     Player1 = new BasePlayer();
        //     Player2 = new BasePlayer();
        // }

        public StandardGame()
        {
            
        }
        
        public Player getOpponent()
        {
            return new BasePlayer();
        }

        public Player Player1 { get; }
        public Player Player2 { get; }
    }
}