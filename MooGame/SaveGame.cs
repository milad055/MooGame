namespace MooGame
{
    public static class SaveGame
    {
        public static List<UserObject> UserList = new List<UserObject>();

        public static void SaveUserToFile(UserObject user, string filename = "result.txt")
        {
            StreamWriter textFile = new StreamWriter(filename, append: true);
            textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses); //SKa vi ändra  "#&#"?? alt = "|"
            textFile.Close();
        }

        public static void showTopList()
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

        public static void UpdatePlayerData(string name, int guess)
        {
            UserObject playerData = new UserObject(name, guess);
            int playerIndex = UserList.IndexOf(playerData);

            if (playerIndex < 0)
                UserList.Add(playerData);
            else
                UserList[playerIndex].Update(guess);
        }

        internal static void returnUserFromTextFile(string filename= "result.txt")
        {
            StreamReader textDocument = new StreamReader(filename);
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
