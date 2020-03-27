namespace Katas
{
    internal class Scorer
    {
        private readonly int[] throws = new int[21];
        private int currentThrow;
        private int ball;

        public void AddThrow(int pins)
        {
            throws[currentThrow++] = pins;
        }

        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0; currentFrame < theFrame; currentFrame++)
            {
                if (Strike())
                {
                    score += 10 + NextTowBalls;
                    ball++;
                }
                else if (Spare())
                {
                    score += 10 + NextBall;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    ball += 2;
                }
            }

            return score;
        }

        private int NextTowBalls => (throws[ball + 1] + throws[ball + 2]);

        private bool Strike()
        {
            return throws[ball] == 10;
        }

        private int TwoBallsInFrame => throws[ball] + throws[ball + 1];

        private int NextBall => throws[ball + 2];

        private bool Spare()
        {
            return throws[ball] + throws[ball + 1] == 10;
        }
    }
}