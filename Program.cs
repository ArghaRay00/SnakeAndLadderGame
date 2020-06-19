using System;
using System.Collections.Generic;

namespace snake_ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter Number of snakes (s) followed by s lines each containing 2 numbers denoting the head and tail positions of the snake.\n Number of ladders (l) followed by l lines each containing 2 numbers denoting the start and end positions of the ladder.\n Number of players(p) followed by p lines each containing a name.\n See Docs folder for detailed input");
                int noOfSnakes = int.Parse(Console.ReadLine());
                IList<Snake> snakes = new List<Snake>();

                for (int i = 0; i < noOfSnakes; i++)
                {
                    string[] tokens = Console.ReadLine().Split(' ');
                    snakes.Add(new Snake(int.Parse(tokens[0]), int.Parse(tokens[1])));
                }


                int noOfLadders = int.Parse(Console.ReadLine());
                IList<Ladder> ladders = new List<Ladder>();

                for (int i = 0; i < noOfLadders; i++)
                {
                    string[] tokens = Console.ReadLine().Split(' ');
                    ladders.Add(new Ladder(int.Parse(tokens[0]), int.Parse(tokens[1])));
                }


                int noOfPlayers = int.Parse(Console.ReadLine());
                IList<Player> players = new List<Player>();
                for (int i = 0; i < noOfPlayers; i++)
                {
                    players.Add(new Player(Console.ReadLine()));
                }

                SnakeAndLadderService snakeAndLadderService = new SnakeAndLadderService();
                snakeAndLadderService.SetPlayers(players);
                snakeAndLadderService.SetSnakes(snakes);
                snakeAndLadderService.SetLadders(ladders);
                snakeAndLadderService.StartGame();
            }
            catch (FormatException exception)
            {
                Console.WriteLine("Error in parsing the input" + exception.Message);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(" enter proper input" + exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine("Exception is thrown by" + exception.GetType().FullName);
            }
            finally
            {
                Console.WriteLine(" press Enter to exit");
                Console.ReadLine();
            }
        }
    }
}