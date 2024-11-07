using Game.Models.Abilities.Enum;

namespace Game.Models.Abilities;

public delegate void AbilityUsage(Entity target, AbilityUsageEventArgs args);

public abstract class AbilityBase
{
    private event Action<string>? OnAbilityLearned;

    public AbilityBase(string name,
        AbilityTypesEnum type,
        int level,
        int cooldown,
        string description)
    {
        Name = name;
        AbilityType = type;
        Level = level;
        Cooldown = cooldown;
        Description = description;
    }

    public string Name { get; init; }
    public AbilityTypesEnum AbilityType { get; init; }
    public int Level { get; init; }
    public int Cooldown { get; protected set; }
    public string Description { get; protected set; }

    public abstract void AbilityAction(Entity target, AbilityUsageEventArgs args);
}