﻿using System;
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
        
        public string UserGuess { get; set; }       // vad gör ?, ?? och !  sidan 169 och 170  

        public UserObject() { } //"consider declaring the property as nullable" -should we?
        public UserObject(string name, int guesses)
        {
            UserName = name;
            NumberOfGuesses = guesses;    
            NumberOfGames = 1;
        }

        // Methods for getting user input
        public void GetUserName()
        {
            //bool trigger = true;
            while (true)
            {
                Console.Write("Player name: ");
                string userInput = Console.ReadLine().Trim();
                
                if (!ControlUserInput(userInput)) Console.WriteLine("Wrong input, please try again...");
                else break;
            }
        }
        

        public void GetUserGuess()
        {
            while (true) {
                Console.Write("Guess: ");
                string userInput = Console.ReadLine().Trim();
                
                if(!checkNullorEmpty(userInput)) Console.Write("Invalid guess. Try again");
                if(!checkLength(userInput, max: 4)) Console.WriteLine("Try again...");
                else
                {
                    UserGuess = userInput;
                    break;
                }
            }
        }
        // This method is static. Should we explain why?
        
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
        public bool ControlUserInput(string userInput)
        {
            if (!checkNullorEmpty(userInput)) return false;
            if (!checkLength( userInput, max: 10)) return false;

            UserName = userInput;
            return true;
        }
        public bool checkNullorEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
            {
                return false;
            }
            else return true;
        }
        
        public bool checkLength(string userInput, int min= 1, int max=4)
        {
            return userInput.Length < min || userInput.Length > max ? false: true;
        }

    }
}
