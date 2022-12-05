using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class GameLogic
    {
        public bool QuitGame { get; set; } = false;
        private string gameGoal;
        public UserInput userInput { get; set; } = new UserInput();
        private string bbcc;

        public void MainGame()
        {
            Console.WriteLine("Welcome to the Moo game!");
            userInput.GetUserName();  // Step1. get user info
            
            GameLoop();
        }

        private void GameLoop()
        {
            while (!QuitGame)
            {
                makeGoal();
                Console.WriteLine("New game:\n");   // Step 3. Display game title
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");

                do                                      //Step 7. Control win condition
                {
                    userInput.GetUserGuess();
                    userInput.numberOfGuesses++;
                    Console.WriteLine(userInput.UserGuess + "\n");
                    DisplayResult(gameGoal, userInput.UserGuess);
                } while (bbcc != "BBBB");

                //streamWriterSaveFile();
                //showTopPlayerList();
                //continueGame();
            }
        }

        private void DisplayResult(string gameGoal, string userGuess)
        {
            bbcc = checkBC(gameGoal, userGuess);
            Console.WriteLine(bbcc + "\n");
        }

        private string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }
                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            return "Result: [" + "BBBB".Substring(0, bulls) + "] , [" + "CCCC".Substring(0, cows) + "]";
        }

        private string makeGoal()
        {
            Random randomGenerator = new Random();
            string goal = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                string randomDigit = "" + random;
                while (goal.Contains(randomDigit))
                {
                    random = randomGenerator.Next(10);
                    randomDigit = "" + random;
                }
                goal = goal + randomDigit;
            }
            return goal;
        }
    }
}
