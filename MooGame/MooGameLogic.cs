namespace MooGame
{
    public class MooGameLogic
    {
        private UserObject userObject { get; /*private*/set; } = new UserObject();
        private string userGuess;
        private bool QuitGame = false;
        private string gameGoal;
        public string guessResult;   


        public void Game()
        {
            Console.WriteLine("New game:\n");
            userObject.GetUserName();
            while (!QuitGame)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Moo game!");
                gameGoal = createGuessNumber();
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");
  
                do                                      
                {
                    userGuess = userObject.GetUserGuess();
                    DisplayResult(userGuess);
                } while (guessResult != "BBBB,");  // TODO remove comma  or find better sollution

                Console.WriteLine("Correct! Nr of guesses: " + userObject.NumberOfGuesses);
                SaveGame.SaveUserToFile(userObject);
                SaveGame.showTopList();

                QuitGame = QuitOrPlayGame();
            }
        }
        public void DisplayResult(string userGuess)
        {
            string result = CheckBullOrCow(gameGoal, userGuess);
            Console.WriteLine(result + "\n");
        }
        public string CheckBullOrCow(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            // to avoid index overstepping in the for loop
            guess += "    ";     
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
            guessResult = "BBBB".Substring(0, bulls) + "," + 
                "CCCC".Substring(0, cows);

            return "Result: [" + "BBBB".Substring(0, bulls) + 
                "] , [" + "CCCC".Substring(0, cows) + "]";
        }

        public bool QuitOrPlayGame()   
        {
            Console.WriteLine("Do you want to play again?" +
                "\nPress Q or Ctrl+C to QUIT. Or any other key to continue");
            string answer = Console.ReadLine().Trim().ToLower();
            answer += " ";//if user presses enter, to avoid null reference
            if(answer.Substring(0, 1) == "q") return true;
            Console.Clear();
            return false;
        }


        public string createGuessNumber()
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
