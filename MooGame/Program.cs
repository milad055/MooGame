using MooGame.Components;
using MooGame.Interfaces;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ISaveGame saveGame = new MooSaveGame();
            MooGameLogic game = new(saveGame);
            game.StartGame(); 
        }
   }
}