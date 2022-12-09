namespace MooGame
{
    class MainClass
    {

        public static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            game.MainGame();
        }
   }
}

/*
 Do we have repeated code?
- Edsger Dijkstra’s rules?
-Write Your Try-Catch-Finally Statement First
https://github.com/JuanCrg90/Clean-Code-Notes#flag-arguments
    Ska vi ha en trycatch istället för return true/false?
 Not only are learning tests free, they have a positive return on investment. 


De sakerna vi inte gör
AA. Write one test per each concept that you need to verify

A.  Timely Unit tests should be written just before the production code that makes them pass. 
    If you write tests after the production code, then you may find the production code to 
    be hard to test.

B. Sometimes we need to make a variable or utility function protected 
    so that it can be accessed by a test.
    Svar: Istället att ändra protection till public, we can byta till protected. Då är den tillåtet i projekts miljön.

C. First Rule: Classes should be small. Q. Är vår klasser små?
    Second Rule: Classes should be smaller than the first rule  //killen är cool
 
D.  Det här är viktig... Software Systems should separate the startuo process, 
    when the application objects are constructed and the dependencies are "wired" thogether, 
    from the runtime logic that takes over after startup
        Andra ord. Vi måste förbereda variabler och objekt instanser så datorn behöver inte
        rota fram dessa när den kör huvud metoden. 
 
 */