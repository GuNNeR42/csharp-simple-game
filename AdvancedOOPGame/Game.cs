namespace AdvancedOOPGame;

public class Game
{
    public Guid Id { get; private set; }
    public List<Player> Players { get; set; }
    public List<Enemy> Enemies { get; set; }

    private int AlivePlayersCount
    {
        get { return Players.Count(player => player.IsAlive);}
    }
    private int AliveEnemiesCount
    {
        get { return Enemies.Count(enemy => enemy.IsAlive); }
    }

    public Game()
    {
        Players = new List<Player>();
        Enemies = new List<Enemy>();
        Id = new Guid();
    }

    public GameResult Play()
    {
        while(AliveEnemiesCount != 0 || AlivePlayersCount != 0)
        {
            ExecutePlayersTurn();
            ExecuteEnemiesTurn();
        }
        return AlivePlayersCount == 0 ? GameResult.Lose : GameResult.Win;
    }

    private void ExecutePlayersTurn()
    {
        foreach (Player player in Players)
        {
            foreach (Enemy enemy in Enemies)
            {
                if (enemy.IsAlive)
                {
                    player.Attack(enemy);
                }
            }
        }
    }

    private void ExecuteEnemiesTurn()
    {
        foreach (Enemy enemy in Enemies)
        {
            foreach (Player player in Players)
            {
                if (player.IsAlive)
                {
                    enemy.Attack(player);
                }
            }
        }

    }

    //private GameResult EvaluateRound()
    //{
    //    bool allDead = true;

    //    foreach (Enemy enemy in Enemies)
    //    {
    //        if (enemy.IsAlive)
    //        {
    //            allDead = false;
    //            re
    //        }
    //    }
    //}

}



