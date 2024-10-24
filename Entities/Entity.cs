using Game.Entities.Professions;
using Game.Entities.Abilities;

namespace Game.Entities;

public abstract class Entity : Charactheristics
{
    public int Lvl { get; set; } = 1;
    public int Damage { get; set; }
    public Profession Profession { get; init; } = default!;
    public List<Ability> Abilities = [];

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
    }
    public abstract void ApplyBuff();
    public abstract void ApplyDebuff();
}
