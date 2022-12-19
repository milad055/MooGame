namespace MooGame.Components
{
    public class UserObject
    {
        public string UserName { get; set; }
        public int NumberOfGuesses { get; set; } = 0;
        public int NumberOfGames { get; set; }
        private string userGuess;

        public UserObject() { }
        public UserObject(string name, int guesses)
        {
            UserName = name;
            NumberOfGuesses = guesses;
            NumberOfGames = 1;
        }

        // Methods for getting user input
        public void GetUserName()
        {
            bool check = false;
            while (!check)
            {
                Console.Write("Player name: ");
                check = CheckUserName(Console.ReadLine().Trim());
            }
        }
        public bool CheckUserName(string userInput)
        {
            if (!checkNullorEmpty(userInput) || !checkLength(userInput, max: 10))
            {
                Console.WriteLine("Name not approved, please try again...");
                return false;
            }
            UserName = userInput;
            return true;
        }

        public string GetUserGuess()
        {
            bool check = false;
            while (!check)
            {
                Console.Write("Guess: ");
                check = CheckUserGuess(Console.ReadLine().Trim());
            }
            NumberOfGuesses++;
            return userGuess;
        }
        public bool CheckUserGuess(string userInput)
        {
            if (!checkNullorEmpty(userInput))
            {
                Console.Write("Invalid guess. Try again");
                return false;
            }
            else if (!checkLength(userInput))
            {
                Console.WriteLine("Try again...");
                return false;
            }
            else
            {
                userGuess = userInput;
                return true;
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

        public override bool Equals(object p)
        {
            return UserName.Equals(((UserObject)p).UserName);
        }

        public override int GetHashCode()
        {
            return UserName.GetHashCode();
        }

        // Methods for control checks nulls and string length
        public bool checkNullorEmpty(string userInput)
        {
            if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
            {
                return false;
            }
            else return true;
        }

        public bool checkLength(string userInput, int min = 1, int max = 4)
        {
            return userInput.Length < min || userInput.Length > max ? false : true;
        }

    }
}
