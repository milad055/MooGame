using MooGame.Interfaces;
using System;

namespace MooGame.Components
{
    public class MooGameLogic
    {
        private string userGuess;
        private bool QuitGame = false;
        private string gameGoal;
        public string guessResult;
        private readonly UserObject _userObject;
        public ISaveGame saveGame = new SaveGame();
        public MooGameLogic()
        {
            _userObject = new UserObject();
        }

        //This is a method that start the main game loop for a number guessing game.
        public void RunGame()
        {
            Console.WriteLine("New game:\n");
            _userObject.GetUserName();
            while (!QuitGame)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Moo game!");
                gameGoal = CreateGuessNumber();
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + gameGoal + "\n");

                do
                {
                    userGuess = _userObject.GetUserGuess();
                    DisplayResult(userGuess);
                } while (guessResult != "BBBB,");

                Console.WriteLine("Correct! Nr of guesses: " + _userObject.NumberOfGuesses);
                saveGame.SaveUserToFile(_userObject);
                saveGame.showTopList();

                QuitGame = QuitOrPlayGame();
            }
        }

        //This is a method that takes in a string userGuess and displays the result of comparing it to the gameGoal number.
        public void DisplayResult(string userGuess)
        {
            string result = CheckBullOrCow(gameGoal, userGuess);
            Console.WriteLine(result + "\n");
        }

        //This is the CheckBullOrCow method that is called in the DisplayResult method. It takes in two strings, goal and guess, and compares them to determine the number of bulls and cows in the guess string.
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
            guessResult = string.Concat("BBBB".AsSpan(0, bulls), ",", "CCCC".AsSpan(0, cows));

            return "Result: [" + "BBBB".Substring(0, bulls) +
                "] , [" + "CCCC".Substring(0, cows) + "]";
        }

        //This is a method that prompts the user to decide whether to quit the game or play again.
        //It does this by displaying a message asking the user to press "Q" or "Ctrl+C" to quit, or any other key to continue playing.
        public static bool QuitOrPlayGame()
        {
            Console.WriteLine("Do you want to play again?" +
                "\nPress Q or Ctrl+C to QUIT. Or any other key to continue");
            string answer = Console.ReadLine().Trim().ToLower();
            answer += " ";//if user presses enter, to avoid null reference
            if (answer.Substring(0, 1) == "q") return true;
            Console.Clear();
            return false;
        }

        //This is a method that creates a random four-digit number for the user to guess in the game.
        public static string CreateGuessNumber()
        {
            Random randomGenerator = new();
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
                goal += randomDigit;
            }
            return goal;
        }
    }
}
