using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Score
    {
        public int gameID;
        public string playerName;
        public int score;

        public Score(int gameId, string playerName, int score)
        {
            this.gameID = gameId;
            this.playerName = playerName;
            this.score = score;
        }

    }
}
