namespace AdvancedOOPGame;

public class Game
{
    public Guid Id { get; private set; }
    public List<Player> Players { get; set; }
    public List<Enemy> Enemies { get; set; }

    private int AlivePlayersCount => Players.Count(player => player.IsAlive);
    private int AliveEnemiesCount => Enemies.Count(enemy => enemy.IsAlive);

    public Game()
    {
        Players = new List<Player>();
        Enemies = new List<Enemy>();
        Id = new Guid();
    }


    /// <summary>
    /// Starts the game simulation.
    /// Game stops when all Players or all Enemies are dead.
    /// </summary>
    /// <returns>Enum of GameResult (Win or Lose)</returns>
    public GameResult Play()
    {
        while(AliveEnemiesCount != 0 && AlivePlayersCount != 0)
        {
            ExecutePlayersTurn();
            ExecuteEnemiesTurn();
        }
        return AlivePlayersCount == 0 ? GameResult.Lose : GameResult.Win;
    }


    /// <summary>
    /// Every Players attacks all Enemies
    /// Result of every round is logged to console
    /// </summary>
    private void ExecutePlayersTurn()
    {
        foreach (Player player in Players.Where(player => player.IsAlive))
        {
            foreach (Enemy enemy in Enemies.Where(enemy => enemy.IsAlive))
            {
                player.Attack(enemy);
                Logger.Log(message: $"Player {nameof(player)} dealt {player.BaseDamage} damage to {nameof(enemy)} \n{nameof(enemy)} now has {enemy.Health} health.\n\n\n",
                            color: ConsoleColor.Cyan);
            }
        }
    }


    /// <summary>
    /// Every Enemy attacks all Players
    /// Result of every round is logged to console
    /// </summary>
    private void ExecuteEnemiesTurn()
    {
        foreach (Enemy enemy in Enemies.Where(enemy => enemy.IsAlive)) foreach (Player player in Players.Where(player => player.IsAlive))
            {
                enemy.Attack(player);
                Logger.Log(message: $"Enemy {nameof(enemy)} dealt {enemy.BaseDamage * enemy.DamageMultiplier} damage to {nameof(player)} \n" +
                    $"Player's shield absorbed {player.Armor} HP\n" + //tady nebude player.armor fungovat vždy
                    $"{nameof(player)} now has {player.Health} health.\n\n\n",
                            color: ConsoleColor.Cyan);
            }
    }
}



