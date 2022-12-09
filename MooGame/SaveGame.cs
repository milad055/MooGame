namespace MooGame
{
    public class SaveGame
    {
        
        public static void saveUserToFile(UserObject user)
        {
            StreamWriter textFile = new StreamWriter("result.txt", append: true);
            textFile.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses); //SKa vi ändra  "#&#"??
            textFile.Close(); 
        }

        // Methods
        public static void showTopList()
        {
            StreamReader textDocument = new StreamReader("result.txt");
            List<UserObject> userList = new List<UserObject>();
            string line;
            while ((line = textDocument.ReadLine()) != null)
            {
                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);
                UserObject playerData = new UserObject(name, guesses);
                int playerIndex = userList.IndexOf(playerData);

                if (playerIndex < 0) 
                    userList.Add(playerData);
                else 
                    userList[playerIndex].Update(guesses);
            }

            // ska vi ändra på det här metoden? Svårt att förstå
            userList.Sort((player1, player2) =>     
            player1.Average().CompareTo(player2.Average()));

            Console.WriteLine("Player   Average guess");
            foreach (UserObject player in userList)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", 
                    player.UserName, player.NumberOfGames, player.Average()));
            }
            textDocument.Close();
        }
    }
}
