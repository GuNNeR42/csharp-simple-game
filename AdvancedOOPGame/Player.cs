namespace AdvancedOOPGame;

public class Player : GameEntity, IHealable
{
    public int Armor { get; set; }

    public Player(int health, int damage, int armor) : base (health, damage)
    {
        Armor = armor;
    }



    /// <summary>
    /// Heals the Player by set amount.
    /// Max HP is capped to 100
    /// </summary>
    /// <param name="amount">Set amount to heal</param>
    public void Heal(int amount)
    {
        if(amount > 0)
        {
            this.Health += amount;
            if (Health > 100)
            {
                Health = 100;
            }
        }

    }

    /// <summary>
    /// Substracts dealt damage from Player's HP
    /// Armor lowers the damage dealt by it's amount.
    /// </summary>
    /// <param name="damage">Damage dealt to Player</param>
    public override void Defend(int damage)
    {
        if (damage > 0 && damage > this.Armor)
        {
            Health = Health - (damage - this.Armor);
        }
    }


    /// <summary>
    /// Attacks specified Enemy.
    /// If the Enemy is killed, Player will be healed by 25 HP
    /// </summary>
    /// <param name="enemy">Enemy instance</param>
    public override void Attack(GameEntity enemy)
    {
        if (enemy.IsAlive)
        {
            enemy.Defend(this.BaseDamage);
            if (!enemy.IsAlive)
            {
                Heal(25);
            }
        }
    }
}



