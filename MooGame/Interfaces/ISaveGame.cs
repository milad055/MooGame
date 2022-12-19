using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MooGame.Components;

namespace MooGame.Interfaces
{
    public interface ISaveGame
    {
        public static List<UserObject>? UserList;
        
        public void SaveUserToFile(UserObject user, string filename="result.txt");
        public void showTopList();
        public void UpdatePlayerData(string name, int guess);
        public void returnUserFromTextFile(string filename="result.txt");


    }
}
