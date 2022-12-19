using System;
using System.Linq;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a random code
            int[] code = GenerateCode();

            // Keep playing until the player guesses the code or runs out of attempts
            int attempts = 0;
            while (attempts < 10)
            {
                // Get the player's guess
                int[] guess = GetGuess();

                // Check the guess and print the result
                int exactMatches = GetExactMatches(guess, code);
                int partialMatches = GetPartialMatches(guess, code);
                Console.WriteLine($"{exactMatches} exact matches, {partialMatches} partial matches");

                // Check if the player has won
                if (exactMatches == code.Length)
                {
                    Console.WriteLine("Congratulations, you won!");
                    break;
                }

                attempts++;
            }

            if (attempts == 10)
            {
                Console.WriteLine("You ran out of attempts. Better luck next time!");
            }
        }

        static int[] GenerateCode()
        {
            // Generate a random 4-digit code
            Random rand = new Random();
            return Enumerable.Range(0, 4).Select(i => rand.Next(1, 7)).ToArray();
        }

        static int[] GetGuess()
        {
            // Get the player's guess
            Console.WriteLine("Enter your guess (4 digits between 1 and 6):");
            string input = Console.ReadLine();
            return input.Select(c => int.Parse(c.ToString())).ToArray();
        }

        static int GetExactMatches(int[] guess, int[] code)
        {
            // Count the number of exact matches
            int count = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == code[i])
                {
                    count++;
                }
            }
            return count;
        }

        static int GetPartialMatches(int[] guess, int[] code)
        {
            // Count the number of partial matches
            int count = 0;
            foreach (int g in guess)
            {
                if (code.Contains(g))
                {
                    count++;
                }
            }
            return count - GetExactMatches(guess, code);
        }
    }
}
