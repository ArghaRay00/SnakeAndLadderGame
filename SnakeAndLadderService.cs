using System;
using System.Collections.Generic;
namespace snake_ladder
{
    class SnakeAndLadderService
    {
        private static readonly int DEFAULT_BOARD_SIZE = 100; //The board will have 100 cells numbered from 1 to 100.
        private static readonly int DEFAULT_NO_OF_DICES = 1;
        private SnakeAndLadderBoard Board { get; set; }
        private Queue<Player> Players { get; set; }
        private int NoOfDices;
        private int initialNumberOfPlayers;
        private bool shouldGameContinueTillLastPlayer; //optional rule3
        private bool shouldAllowMultipleDiceRollOnSix; //optional rule4


        public SnakeAndLadderService(int boardSize)
        {
            this.Board = new SnakeAndLadderBoard(boardSize);
            this.Players = new Queue<Player>();
            this.NoOfDices = SnakeAndLadderService.DEFAULT_NO_OF_DICES;
        }

        public SnakeAndLadderService() : this(SnakeAndLadderService.DEFAULT_BOARD_SIZE)
        {

        }


        //    Setters for making the game more extensible   
        public void SetNoOfDices(int noOfDices)
        {
            this.NoOfDices = noOfDices;
        }
        public void SetShouldGameContinueTillLastPlayer(bool shouldGameContinueTillLastPlayer)
        {
            this.shouldGameContinueTillLastPlayer = shouldGameContinueTillLastPlayer;
        }

        public void SetShouldAllowMultipleDiceRollOnSix(bool shouldAllowMultipleDiceRollOnSix)
        {
            this.shouldAllowMultipleDiceRollOnSix = shouldAllowMultipleDiceRollOnSix;
        }

        // Initialize Board

        public void SetPlayers(IList<Player> players)
        {
            this.initialNumberOfPlayers = players.Count;
            IDictionary<string, int> playerPieces = new Dictionary<string, int>();

            foreach (var player in players)
            {
                this.Players.Enqueue(player);
                playerPieces[player.Id] = 0;
            }
            this.Board.setPlayerPieces(playerPieces);
        }

        public void SetSnakes(IList<Snake> snakes)
        {
            Board.setSnakes(snakes);
        }
        public void SetLadders(IList<Ladder> ladders)
        {
            Board.setLadders(ladders); // Add ladders to board
        }

        // Core business logic for the game
        private int GetNewPositionAfterGoingThroughSnakesAndLadders(int newPosition)
        {
            int previousPosition;

            do
            {
                previousPosition = newPosition;
                foreach (var snake in Board.Snakes)
                {
                    if (snake.Start == newPosition)
                    {
                        newPosition = snake.End;
                    }
                }

                foreach (var ladder in Board.Ladders)
                {
                    if (ladder.Start == newPosition)
                    {
                        newPosition = ladder.End;
                    }
                }
            }
            while (newPosition != previousPosition);
            return newPosition;
        }

        private void MovePlayer(Player player, int positions)
        {
            int oldPostion = Board.PlayerPieces[player.Id];
            int newPosition = oldPostion + positions;

            int boardSize = Board.Size;

            if (newPosition > boardSize)
            {
                newPosition = oldPostion;
            }
            else
            {
                newPosition = GetNewPositionAfterGoingThroughSnakesAndLadders(newPosition);
            }

            Board.PlayerPieces[player.Id] = newPosition;

            Console.WriteLine(player.Name + " rolled a " + positions + " and moved from " + oldPostion + " to " + newPosition);
        }

        private int GetTotalValueAfterDiceRolls()
        {
            // Can use noOfDices and setShouldAllowMultipleDiceRollOnSix here to get total value (Optional requirements)
            return DiceService.roll();
        }
        private bool HasPlayerWon(Player player)
        {
            int playerPosition = Board.PlayerPieces[player.Id];
            int winningPosition = Board.Size;
            return playerPosition == winningPosition;
        }

        private bool IsGameCompleted()
        {
            int currentNumberOfPlayers = Players.Count;
            return currentNumberOfPlayers < initialNumberOfPlayers;
        }

        public void StartGame()
        {
            while (!IsGameCompleted())
            {
                int totalDiceValue = GetTotalValueAfterDiceRolls();
                Player currentPlayer = Players.Dequeue();
                MovePlayer(currentPlayer, totalDiceValue);
                if (HasPlayerWon(currentPlayer))
                {
                    Console.WriteLine(currentPlayer.Name + " wins the game");
                    Board.PlayerPieces.Remove(currentPlayer.Id);
                }
                else
                {
                    Players.Enqueue(currentPlayer);
                }
            }
        }

    }
}