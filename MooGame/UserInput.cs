using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class UserInput
    {
        public int numberOfGuesses { get; set; } = 0;
        public string UserName { get; set; }    //get, set, init 
        public string UserGuess { get; set; }       // vad gör ?, ??, !  sidan 169 och 170  

        public bool QuitGame { get; set; } = false;

        public void GetUserName()
        {
            while (true)
            {
                Console.Write("Enter user name: ");
                string userName = (Console.ReadLine()).Trim();
                checkNullorEmpty(userName, "Invalid user name, please try again");
                if ((userName).Length > 10 || (userName).Length <= 1) Console.WriteLine("The chosen name is either short or long!");
                else 
                {   UserName = userName;
                    break;
                }
            }
        }

        private void checkNullorEmpty(string userInput, string message)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput)) Console.WriteLine(message);
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


        // 1. Get user name at the start of the game ( maybe add the name in class constructor so we don't need a method?)

        // a tiny method to get user input COnsole.ReadLine()... 

        //



        // 2. User input for guesses in the game 
        // 2a. string input, control for null in a good way
        // 3. Ask user to Quit game or continue



    }
}
