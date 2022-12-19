using MooGame.Interfaces;

namespace MooGame.Components
{
    public class SaveGame : ISaveGame
    {
        public List<UserObject> UserList = new();

        //This is a method that saves a user's score to a text file.
        public void SaveUserToFile(UserObject user, string filename = "result.txt")
        {
            StreamWriter textFile = new(filename, append: true);
            textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses);
            textFile.Close();
        }

        //This is a method that displays a leaderboard of top scores from a list of UserObject objects.
        public void showTopList()
        {
            returnUserFromTextFile();
            UserList.Sort((player1, player2) =>
            player1.Average().CompareTo(player2.Average()));

            Console.WriteLine("Player   Average guess");
            foreach (UserObject player in UserList)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}",
                    player.UserName, player.NumberOfGames, player.Average()));
            }
        }

        //This is a method that updates a UserObject in the UserList based on a user's name and number of guesses.
        public void UpdatePlayerData(string name, int guess)
        {
            UserObject playerData = new(name, guess);
            int playerIndex = UserList.IndexOf(playerData);

            if (playerIndex < 0)
                UserList.Add(playerData);
            else
                UserList[playerIndex].Update(guess);
        }

        //This is a method that reads in a list of UserObject objects from a text file and adds them to the UserList.
        public void returnUserFromTextFile(string filename = "result.txt")
        {
            StreamReader textDocument = new(filename);
            string line;
            while ((line = textDocument.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]); //man kan använda en tuple för att spara namn och int!
                UpdatePlayerData(name, guesses);
            }
            textDocument.Close();
        }


    }
}
