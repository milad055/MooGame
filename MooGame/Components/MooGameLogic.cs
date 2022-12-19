using MooGame.Interfaces;
using System;

namespace MooGame.Components
{
    public class MooGameLogic
    {
        private string _playerGuess;
        private bool _quitGame = false;
        private string _gameGoalNumber;
        private string _playerGuessResult;
        private readonly UserObject _userObject;
        public ISaveGame saveGame = new SaveGame();
        public MooGameLogic()
        {
            _userObject = new UserObject();
        }

        public void StartGame()
        {
            Console.WriteLine("New game:\n");
            _userObject.GetUserName();
            while (!_quitGame)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Moo game!");
                _gameGoalNumber = GenerateGuessNumber();
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + _gameGoalNumber + "\n");

                do
                {
                    _playerGuess = _userObject.GetUserGuess();
                    DisplayResult(_playerGuess);
                } while (_playerGuessResult != "BBBB,");

                Console.WriteLine("Correct! Nr of guesses: " + _userObject.NumberOfGuesses);
                saveGame.SavePlayerData(_userObject);
                saveGame.DisplayPlayerData();

                _quitGame = QuitOrPlayGame();
            }
        }
        public void DisplayResult(string userGuess)
        {
            string result = CheckBullOrCow(_gameGoalNumber, userGuess);
            Console.WriteLine(result + "\n");
        }

        // Bulls [B] When player gets the number and the position correctly. [BBBB] To win the game.
        // Cows [C] When player gets the number but the position is wrong.
        public string CheckBullOrCow(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            
            guess += "    "; // += to avoid index overstepping in the for loop if user presses Enter key
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
            // _playerGuessResult variable is used to control winning condition
            // return statement is used for displaying the result with better formatting
            _playerGuessResult = string.Concat("BBBB".AsSpan(0, bulls), ",", "CCCC".AsSpan(0, cows));
            return "Result: [" + "BBBB".Substring(0, bulls) +
                "] , [" + "CCCC".Substring(0, cows) + "]";
        }

        public static bool QuitOrPlayGame()
        {
            Console.WriteLine("Do you want to play again?" +
                "\nPress Q or Ctrl+C to QUIT. Or any other key to continue");
            string answer = Console.ReadLine().Trim().ToLower();
            answer += " ";// This is used if user presses enter, to avoid null reference issue
            if (answer.Substring(0, 1) == "q") return true;
            Console.Clear();
            return false;
        }

        public static string GenerateGuessNumber()
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
