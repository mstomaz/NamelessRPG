using Game.Models.Abilities;
using Game.Models.Professions;

namespace Game.Models;

public abstract class Entity : Charactheristics, IActionableObject
{
    protected int _damage;

    protected EventHandler? _onSTRIncrease;
    public event DamageSuffered<Entity>? OnDmgTaken;

    public AbilityUsage? Action { get; protected set; }
    public override int Strength
    {
        get => _STR;
        set
        {
            _STR = value;
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
        OnDmgTaken!(this, damage);
    }
    public abstract void ApplyBuff();
    public abstract void ApplyDebuff();

    public void ReadyAbility(AbilityBase ability)
    {
        Action = ability.AbilityAction;
    }
    public void UseAbility(Entity target, AbilityUsageEventArgs args)
    {
        Action!(target, args);
    }
}
