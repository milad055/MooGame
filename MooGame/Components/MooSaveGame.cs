using MooGame.Interfaces;

namespace MooGame.Components
{
    public class MooSaveGame : ISaveGame
    {
        public List<UserObject> UserList = new();

        public void SavePlayerData(UserObject user, string filename = "result.txt")
        {
            StreamWriter textFile = new(filename, append: true);
            textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses);
            textFile.Close();
        }

        public void DisplayPlayerData()
        {
            ReadPlayerData();
            UserList.Sort((player1, player2) =>
            player1.Average().CompareTo(player2.Average()));

            Console.WriteLine("Player   Average guess");
            foreach (UserObject player in UserList)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}",
                    player.UserName, player.NumberOfGames, player.Average()));
            }
        }

        public void ReadPlayerData(string filename = "result.txt")
        {
            StreamReader textDocument = new(filename);
            string line;
            while ((line = textDocument.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                UpdatePlayerData(name, guesses);
            }
            textDocument.Close();
        }

        public void UpdatePlayerData(string name, int guess)
        {
            UserObject playerData = new(name, guess);
            // if user is not found, IndexOf returns -1
            int playerIndex = UserList.IndexOf(playerData);

            if (playerIndex < 0)
                UserList.Add(playerData);
            else
                UserList[playerIndex].Update(guess);
        }

    }
}
