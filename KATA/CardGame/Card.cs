namespace CardGame
{
    public interface Card 
    {
        int ManaCost { get; set; }
    }

    public class AttackCard : Card
    {
        private int manaCost;
        public int ManaCost { get; set; }
    }
}