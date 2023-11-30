namespace AdvancedOOPGame;

public class Enemy : GameEntity
{
    public bool IsBoss { get; set; }

    public Enemy(int health, int damage, bool isBoss) : base(health, damage)
    {
        IsBoss = isBoss;
    }

    public override void Attack(GameEntity player)
    {
        /**
         * If Enemy is IsBoss, damage multiplier is 1.5x
         * Then performs attack on Player by launching the Player's Defend method
         */
        double damageMultiplier = 1.0;

        if (this.IsBoss)
        {
            damageMultiplier = 1.5;
        }

        if (!player.IsAlive)
        {
            return;
        }
        else
        {
            /**
             * In case of non-int values, 
             * dealtDamage values will be floored to nearest int
             */
            int dealtDamage = Convert.ToInt32(Math.Floor(this.Damage * damageMultiplier));
            player.Defend(dealtDamage);
        }
    }

    public override void Defend(int damage)
    {
        /**
         * If dealt damage is > 0
         * Sets recievedDamageMultiplier (if Enemy is Boss, multiplier is 0.75x)
         */
        if (damage > 0)
        {
            double recievedDamageMultiplier = 1.0;
            if (this.IsBoss)
            {
                recievedDamageMultiplier = 0.75;
            }

            /**
             * In case of non-int values, 
             * recievedDamage values will be Ceiled to nearest int
             */
            int recievedDamage = Convert.ToInt32(Math.Ceiling(this.Damage * recievedDamageMultiplier));
            Health = Health - (recievedDamage);
        }

    }
}



