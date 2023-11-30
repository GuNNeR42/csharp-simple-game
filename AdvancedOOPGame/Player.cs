namespace AdvancedOOPGame;

public class Player : GameEntity, IHealable
{
    public int Armor { get; set; }

    public Player(int health, int damage, int armor) : base (health, damage)
    {
        Armor = armor;
    }

    public void Heal(int amount)
    {
        /**
         * If the Heal amount is > 0,
         * adds the amount to Health and then if Health exceeds 100,
         * caps Health to 100
         */
        if(amount > 0)
        {
            this.Health += amount;
            if (Health > 100)
            {
                Health = 100;
            }
        }

    }

    public override void Defend(int damage)
    {
        /**
         * If the attack dmg. is > 0 and is greater than Player's armor,
         * The difference between Damage and Armor will be subtracted from Health
        **/

        if (damage > 0 && damage > this.Armor)
        {
            Health = Health - (damage - this.Armor);
        }
    }

    public override void Attack(GameEntity enemy)
    {
        /**
         * If the selected enemy is alive,
         * calls Defend method on specified enemy,
         * if the enemy is not alive after the attack,
         * adds 25 HP
         */
        if (!enemy.IsAlive)
        {
            return;
        }
        else
        {
            enemy.Defend(this.Damage);
            if (!enemy.IsAlive)
            {
                Heal(25);
            }
        }
    }
}



