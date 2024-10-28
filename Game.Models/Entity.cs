using Game.Models.Abilities.Base;
using Game.Models.Professions;

namespace Game.Models;

public abstract class Entity : Charactheristics
{
    protected int _damage;

    protected EventHandler? _onSTRIncrease;

    /// <summary>
    /// Represents the ability usage method signature.
    /// </summary>
    /// <param name="target">The target of the ability.</param>
    public delegate void AbilityUsage(Entity target);

    public AbilityUsage Action { get; protected set; } = default!;
    public override int Strength
    {
        get => Strength;
        set
        {
            Strength = value;
            _onSTRIncrease!(this, EventArgs.Empty);
        }
    }
    public virtual int Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public int Lvl { get; set; } = 1;
    public Profession? Profession { get; set; }
    public List<AbilityBase> Abilities = [];

    protected virtual void AttachCharacteristicsHandlers(object? sender, EventArgs args)
    {
        _onSTRIncrease += (sender, args) => Damage += _STR;
    }
    public virtual void TakeDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine($"{Name} takes {damage} damage and is left with {_HP} HP!");
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
