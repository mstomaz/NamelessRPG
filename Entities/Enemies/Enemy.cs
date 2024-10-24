using Game.Entities.Enemies.Enum;

namespace Game.Entities.Enemies;

public class Enemy : Entity
{
    public Enemy(string name)
    {
        Name = name;
        HP = 50;
    }

    public EnemyDifficultyEnum Difficulty { get; set; }
    public int XPGiven { get; }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }
    public override void ApplyBuff()
    {
        throw new NotImplementedException();
    }
    public override void ApplyDebuff()
    {
        throw new NotImplementedException();
    }
}