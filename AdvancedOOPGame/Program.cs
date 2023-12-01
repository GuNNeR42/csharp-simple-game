namespace AdvancedOOPGame;

class Program
{
    static void Main(string[] args)
    {
        Player player1 = new(100, 10, 5);
        Player player2 = new(30, 50, 15);
        Enemy enemy1 = new(100, 10);
        Enemy enemy2 = new(100, 10, true);
        Game game = new();

        game.Players.Add(player1);
        game.Players.Add(player2);
        game.Enemies.Add(enemy1);
        game.Enemies.Add(enemy2);

        GameResult result = game.Play();
        Logger.Log(result == GameResult.Win ? "Players have won.\n" : "Enemies have won.\n",
                result == GameResult.Win ? ConsoleColor.Green : ConsoleColor.Red);

        Console.ReadKey();

    }
}



