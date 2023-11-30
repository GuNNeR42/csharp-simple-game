namespace AdvancedOOPGame;

interface IFightable
{
    public void Attack(GameEntity gameEntity, int strength);

    public void Defend(int damage);
}



