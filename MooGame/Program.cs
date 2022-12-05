using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            
            UserInput userInput = new UserInput();
            userInput.GetUserName();
            
            
            //control if userName is null or empty. If it is, then ask again?


            bool playOn = true; //GAME MECHANIC
            //Console.WriteLine("Enter your user name:\n"); // Step1. get user info
            //string name = Console.ReadLine();

            while (playOn)
            {
                string goal = makeGoal();   // Step 2. Create goal


                Console.WriteLine("New game:\n");   // Step 3. Display game title
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string guess = Console.ReadLine();  //Step 4. Get user input

                userInput.numberOfGuesses = 1;     //GAME MECHANIC
                string bbcc = checkBC(goal, guess); //Step 5. Control user input
                Console.WriteLine(bbcc + "\n");     //Step 6. Display game stats
                while (bbcc != "BBBB,")             //Step 7. Control win condition
                {
                    userInput.numberOfGuesses++; //GAME MECHANIC
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = checkBC(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true); //Step 8. Save user data // READ Mechanic
                output.WriteLine(userInput.UserName + "#&#" + userInput.numberOfGuesses);        //Step 9. Display user data
                output.Close(); //Step ?
                showTopList();  // Step 10 Read user history
                Console.WriteLine("Correct, it took " + userInput.numberOfGuesses + " guesses\nContinue?");    //Step 11. Display final stats
                string answer = Console.ReadLine();     //
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n") //GAME MECHANIC
                {
                    playOn = false;
                }
            }
        }
        static string makeGoal()
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

        static string checkBC(string goal, string guess)
        {
            int cows = 0, bulls = 0;
            guess += "    ";     // if player entered less than 4 chars
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
            return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
        }


        static void showTopList()
        {
            StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }
            results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }

    class PlayerData
    {
        public string Name { get; private set; }
        public int NGames { get; private set; }
        int totalGuess;


        public PlayerData(string name, int guesses)
        {
            this.Name = name;
            NGames = 1;
            totalGuess = guesses;
        }

        public void Update(int guesses)
        {
            totalGuess += guesses;
            NGames++;
        }

        public double Average()
        {
            return (double)totalGuess / NGames;
        }


        public override bool Equals(Object p)
        {
            return Name.Equals(((PlayerData)p).Name);
        }


        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}