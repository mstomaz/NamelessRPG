using Game.Models.Enemies.Enum;

namespace Game.Models.Enemies;

public class Enemy : Entity
{
    private int _xpYielded;
    public Enemy(string name)
    {
        Name = name;
        HP = 50;
        XPYielded = Lvl * (int)Difficulty * (int)Grade * (int)Occupation * (int)Size * (int)Type;
    }

    public EnemyDifficultyEnum Difficulty { get; set; } = EnemyDifficultyEnum.Weak;
    public EnemyGradeEnum Grade { get; set; } = EnemyGradeEnum.Common;
    public EnemyOccupationEnum Occupation { get; set; } = EnemyOccupationEnum.Ordinary;
    public EnemySizeEnum Size { get; set; } = EnemySizeEnum.Small;
    public EnemyTypeEnum Type { get; set; } = EnemyTypeEnum.Humanoid;
    public int XPYielded 
    { 
        get => _xpYielded;
        init => _xpYielded = value;
    }

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