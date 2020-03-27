namespace Katas
{
    public class Game
    {
        private int currentFrame = 1;
        private bool isFirstThrow = true;
        Scorer scorer = new Scorer();

        public int Score => ScoreForFrame(currentFrame);

        public void Add(int pins)
        {
            scorer.AddThrow(pins);

            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
            {
                AdvanceFrame();
            }
            else
            {
                isFirstThrow = false;
            }
        }

        private bool LastBallInFrame(int pins)
        {
            return !isFirstThrow || Stike(pins);
        }

        private bool Stike(int pins)
        {
            return pins == 10 && isFirstThrow;
        }

        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }

        public int ScoreForFrame(int theFrame)
        {
            return scorer.ScoreForFrame(theFrame);
        }
    }
}