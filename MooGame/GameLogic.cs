namespace MooGame
{
    public class GameLogic : SaveGame
    {
        public bool QuitGame { get; set; } = false;
       
        private string gameGoal;
        
        public UserObject userObject { get; set; } = new UserObject();
       
        private string bbcc;    // Det här kan vi förbättra 

        public void MainGame()
        {
            Console.WriteLine("Welcome to the Moo game!");
            userObject.GetUserName();
            
            GameLoop();
        }

        private void GameLoop()
        {
            while (!QuitGame)
            {
                gameGoal = makeGoal();
                Console.WriteLine("New game:\n");   // 
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");
  
                do                                      
                {
                    userObject.GetUserGuess();
                    userObject.NumberOfGuesses++;
                    Console.WriteLine(userObject.UserGuess + "\n"); // ska vi radera den?? Vad ser bra ut?
                    DisplayResult(gameGoal, userObject.UserGuess);
                } while (bbcc != "BBBB,");  // TODO remove comma  or find better sollution

                saveUserToFile(userObject); //Vi har ÄRVAT det här metoden. 
                Console.WriteLine("Correct, it took " + userObject.NumberOfGuesses + " guesses");    //Step 11. Display final stats

                QuitGame = UserObject.ContinueGame();
            }
        }

        private void DisplayResult(string gameGoal, string userGuess)
        {
            string result = checkBC(gameGoal, userGuess);       //TODO seperate while check bbcc variable and display result function...
            Console.WriteLine(result + "\n");
        }

        private string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // 
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
            bbcc = "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
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
