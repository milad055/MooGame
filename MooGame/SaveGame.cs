using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame
{
    public class SaveGame
    {
        
        public static void saveUserToFile(UserObject user)
        {
            StreamWriter output = new StreamWriter("result.txt", append: true);
            output.WriteLine(user.UserName + "#&#" + user.NumberOfGuesses); //SKa vi ändra  "#&#"??
            output.Close(); 
            showTopList();   
        }

        // Methods
        static void showTopList()
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
                {
                    userList.Add(playerData);
                }
                else
                {
                    userList[playerIndex].Update(guesses);
                }
            }

            userList.Sort((player1, player2) => player1.Average().CompareTo(player2.Average()));
            Console.WriteLine("Player   Average guess");
            foreach (UserObject player in userList)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.UserName, player.NumberOfGames, player.Average()));
            }
            textDocument.Close();
        }
    }
}
