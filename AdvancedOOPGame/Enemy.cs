namespace AdvancedOOPGame;

public class Enemy : GameEntity
{
    public bool IsBoss { get; set; }
    public double DamageMultiplier { get; private set; } = 1.0;
    public double ReceivedDamageMultiplier { get; private set; } = 1.0;

    public Enemy(int health, int damage, bool isBoss = false) : base(health, damage)
    {
        IsBoss = isBoss;
        if (isBoss)
        {
            DamageMultiplier = 1.5;
            ReceivedDamageMultiplier = 0.75;
        }
    }


    /// <summary>
    /// Attacks specified player
    /// Dealt damage is calculated as BaseDamage x Multiplier (if IsBoss, multiplier is 1.5x)
    /// </summary>
    /// <param name="player">Player instance</param>
    public override void Attack(GameEntity player)
    {
        /**
         * In case of non-int values, 
         * dealtDamage values will be floored to nearest int
         */
        int dealtDamage = Convert.ToInt32(Math.Floor(this.BaseDamage * DamageMultiplier));
        player.Defend(dealtDamage);
    }



    /// <summary>
    /// Substracts dealt damage from Enemy's HP
    /// Boss has receivedDamageMultiplier set to 0.75x
    /// </summary>
    /// <param name="damage">Damage dealt</param>
    public override void Defend(int damage)
    {
        if (damage > 0)
        {
            /**
             * In case of non-int values, 
             * receivedDamage values will be Ceiled to nearest int
             */
            int receivedDamage = Convert.ToInt32(Math.Ceiling(this.BaseDamage * ReceivedDamageMultiplier));
            Health = Health - receivedDamage;
        }

    }
}



