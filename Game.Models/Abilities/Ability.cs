using Game.Models.Abilities.Enum;

namespace Game.Models.Abilities;

public class Ability
{
    public delegate void AbilityUsage(Entity target, Entity? source = null);

    private event Action<string>? OnSkillLearned;

    public Ability(string name, AbilityUsage action)
    {
        Name = name;
        Action = action;
    }

    public string Name { get; init; }
    public AbilityUsage Action { get; init; }
    public AbilityTypesEnum AbilityType { get; init; }
    public int Cooldown { get; init; }

    public void UseAbility(Entity target, Entity? source = null)
    {
        Action.Invoke(target, source);
    }
}