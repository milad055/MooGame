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
        private string userNameControl;
        public int NumberOfGuesses { get; set; } = 0;
        public int NumberOfGames { get; private set; }
        
        public string UserGuess { get; set; }       // vad gör ?, ?? och !  sidan 169 och 170  

        public UserObject() { } //"consider declaring the property as nullable" -should we?
        public UserObject(string name, int guesses)
        {
            UserName = name;
            NumberOfGuesses = guesses;    //kanske behövs inte
            NumberOfGames = 1;
        }

        // Methods for getting user input
        public void GetUserName()
        {
            //bool trigger = true;
            while (true)
            {
                Console.Write("Enter user name: ");
                userNameControl = Console.ReadLine().Trim();
                
                if (checkNullorEmpty(userNameControl)) Console.WriteLine("Invalid user name, please try again");
                else if (userNameControl.Length > 10 || userNameControl.Length <= 1) Console.WriteLine("The chosen name is either short or long!");
                else 
                {   UserName = userNameControl;
                    break;
                }
            }
        }

        public void GetUserGuess()
        {
            while (true) {
                Console.Write("Guess: ");
                string userGuess = Console.ReadLine().Trim();
                if(checkNullorEmpty(userGuess)) Console.Write("Invalid guess. Try again");
                else if ((userGuess).Length > 4) Console.WriteLine("Try again...");
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
        public void Update(int guesses)
        {
            NumberOfGuesses += guesses;
            NumberOfGames++;
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
        private bool checkNullorEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
            {
                return true;
            }
            else return false;
        }
        private string checkNull() {
            return userNameControl == null ? "Invalid input": userNameControl;
        }
        private string checkEmptyInput(){
            return userNameControl == "" ? "Invalid input": userNameControl;
        }
        private string checkLength(int min= 0, int max=4)
        {
            return userNameControl.Length < min || userNameControl.Length > max ? "Invalid input": userNameControl;
        }

    }
}
