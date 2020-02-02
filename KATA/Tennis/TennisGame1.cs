namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private const string playerName1 = "player1";
        private int m_score1 = 0;
        private int m_score2 = 0;

        public void WonPoint(string playerName)
        {
            if (playerName == playerName1)
                m_score1 ++;
            else
                m_score2 ++;
        }

        public string GetScore()
        {
            Scorer scorer = new Scorer();
            return scorer.execute(m_score1, m_score2);
        }

        class Scorer
        {
            public string execute(int score1, int score2)
            {
                if (isSameScore(score1, score2))
                    return showSamePoints(score1);
                else if (winConditionReached(score1, score2))
                    return showWinning(score1, score2);
                else
                    return showScore(score1, score2);
            }

            private static bool isSameScore(int score1, int score2)
            {
                return score1 == score2;
            }

            private static bool winConditionReached(int score1, int score2)
            {
                return score1 >= 4 || score2 >= 4;
            }
            
            private string showSamePoints(int score1)
            {
                switch (score1)
                {
                    case 0:
                        return "Love-All";
                    case 1:
                        return "Fifteen-All";
                    case 2:
                        return "Thirty-All";
                    default:
                        return "Deuce";
                }
            }

            private string showWinning(int score1, int score2)
            {
                int minusResult = score1 - score2;
                if (minusResult == 1) return "Advantage player1";
                else if (minusResult == -1) return "Advantage player2";
                else if (minusResult >= 2) return "Win for player1";
                else return "Win for player2";
            }

            private string showScore(int score1, int score2)
            {
                string score = "";

                score += tennisScore(score1);
                score += "-";
                score += tennisScore(score2);

                return score;
            }
            
            private static string tennisScore(int score)
            {
                switch (score)
                {
                    case 0:
                        return "Love";
                    case 1:
                        return "Fifteen";
                    case 2:
                        return "Thirty";
                    case 3:
                        return "Forty";
                    default:
                        return "";
                }
            }
        }
    }
}
