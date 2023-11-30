namespace AdvancedOOPGame;

public abstract class GameEntity : IFightable
{
    public int Health { get; set; }
    public int Damage { get; set; }
    public bool IsAlive
    {
        get { return Health > 0; }
    }

    public GameEntity(int health, int damage)
    {
        Health = health;
        Damage = damage;
    }

    public abstract void Attack(GameEntity enemy);

    public abstract void Defend(int damage);    
}



