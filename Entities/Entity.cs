using Game.Entities.Professions;
using Game.Entities.Abilities;
using Game.Entities.Abilities.Base;
using System.Security.Cryptography;

namespace Game.Entities;

public abstract class Entity : Charactheristics
{
    /// <summary>
    /// Represents the ability usage method signature.
    /// </summary>
    /// <param name="target">The target of the ability.</param>
    public delegate void AbilityUsage(Entity target);

    public AbilityUsage Action { get; protected set; } = default!;
    public int Lvl { get; set; } = 1;
    public int Damage { get; set; }
    public Profession Profession { get; init; } = default!;
    public List<AbilityBase> Abilities = [];

    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine($"{Name} takes {damage} damage and is left with {HP} HP!");
    }
    public abstract void ApplyBuff();
    public abstract void ApplyDebuff();

    public void ReadyAbility(AbilityBase ability)
    {
        Action = ability.AbilityAction;
    }
    public void UseAbility(Entity target)
    {
        Action(target);
    }
}
