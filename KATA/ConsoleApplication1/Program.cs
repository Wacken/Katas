using Meiern;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(new Dices(new Dice()), true);
            game.play();
        }
    }
}