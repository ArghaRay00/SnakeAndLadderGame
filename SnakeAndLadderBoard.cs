using System;
using System.Collections.Generic;


namespace snake_ladder
{
    class SnakeAndLadderBoard
    {
        public int Size { get; private set; }
        public IList<Snake> Snakes { get; private set; }
        public IList<Ladder> Ladders { get; private set; }
        public IDictionary<string, int> PlayerPieces { get; private set; }

        public SnakeAndLadderBoard(int size)
        {
            this.Size = size;
            this.Snakes = new List<Snake>();
            this.Ladders = new List<Ladder>();
            this.PlayerPieces = new Dictionary<string, int>();
        }

        public void setSnakes(IList<Snake> snakes)
        {
            this.Snakes = snakes;
        }

        public void setLadders(IList<Ladder> ladders)
        {
            this.Ladders = ladders;
        }

        public void setPlayerPieces(IDictionary<string, int> playerPieces)
        {
            this.PlayerPieces = playerPieces;
        }
    }
}