namespace MooGame
{
    public class GameLogic : SaveGame
    {
        public UserObject userObject { get; /*private*/set; } = new UserObject();
        private bool QuitGame = false;
        private string gameGoal;
        private string guessResult;    // Det här kan vi förbättra 

        public void MainGame()
        {
            Console.WriteLine("New game:\n");   // 
            userObject.GetUserName();
            
            GameLoop();
        }

        private void GameLoop()
        {
            while (!QuitGame)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Moo game!");
                gameGoal = createGuessNumber();
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");
  
                do                                      
                {
                    userObject.GetUserGuess();
                    userObject.NumberOfGuesses++;
                    DisplayResult(userObject.UserGuess);
                } while (guessResult != "BBBB,");  // TODO remove comma  or find better sollution

                Console.WriteLine("Correct! Nr of guesses: " + userObject.NumberOfGuesses);    //Step 11. Display final stats
                saveUserToFile(userObject); //Vi har ÄRVAT det här metoden. 
                showTopList();

                QuitGame = QuitOrPlayGame();
            }
        }
        private bool QuitOrPlayGame()
        {
            Console.WriteLine("Do you want to play again?\nPress 'Q' or 'Ctrl+C' to QUIT or any other key to continue");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer.Substring(0, 1) == "q") return true;
            else
            {
                Console.Clear();
                return false;
            }
        }
        private void DisplayResult(string userGuess)
        {
            string result = checkBullOrCow(gameGoal, userGuess);       //TODO seperate while check bbcc variable and display result function...
            Console.WriteLine(result + "\n");
        }

        public string checkBullOrCow(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (goal[i] == guess[j])
                    {
                        if (i == j) bulls++;
                        else cows++;
                    }
                }
            }
            guessResult = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
            return "Result: [" + "BBBB".Substring(0, bulls) + "] , [" + "CCCC".Substring(0, cows) + "]";
        }

        private string createGuessNumber()
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
