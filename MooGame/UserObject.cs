using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class UserObject
    {
        public string UserName { get; set; }    //get, set, init 
        
        public int NumberOfGuesses { get; set; } = 0;
        public int NumberOfGames { get; private set; }
        
        public string UserGuess { get; set; }       // vad gör ?, ??, !  sidan 169 och 170  

        public UserObject() { }
        public UserObject(string name, int guesses)
        {
            UserName = name;
            NumberOfGuesses = guesses;    //kanske behövs inte
            NumberOfGames = 1;
        }

        // Methods for getting user input

        public void Update(int guesses)
        {
            NumberOfGuesses += guesses;
            NumberOfGames++;
        }


        public void GetUserName()
        {
            while (true)
            {
                Console.Write("Enter user name: ");
                string userInput = (Console.ReadLine()).Trim();

                checkNullorEmpty(userInput, "Invalid user name, please try again");
               
                if ((userInput).Length > 10 || (userInput).Length <= 1) Console.WriteLine("The chosen name is either short or long!");
                else 
                {   UserName = userInput;
                    break;
                }
            }
        }

        public void GetUserGuess()
        {
            while (true) {
                Console.Write("Guess: ");
                string userGuess = Console.ReadLine().Trim();
                checkNullorEmpty(userGuess, "Invalid guess. Try again.");
                if ((userGuess).Length > 4) Console.WriteLine("Try again...");
                else
                {
                    UserGuess = userGuess;
                    break;
                }
            }
        }
        public static bool ContinueGame()
        {
            Console.WriteLine("Do you want to play again?\nPress 'Q' or 'Ctrl+C' to QUIT or any other key to continue");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "q" || answer.Substring(0, 1) == "q") return true;
            else
            {
                Console.Clear();
                return false;
            }
        }

        public double Average()
        {
            return (double)NumberOfGuesses / NumberOfGames;
        }

        public override bool Equals(Object p)
        {
            return UserName.Equals(((UserObject)p).UserName);
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        // Methods for null control checks
        private void checkNullorEmpty(string userInput, string message)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput)) Console.WriteLine(message);
        }
    }
}
