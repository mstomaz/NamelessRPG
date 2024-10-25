using Game.Entities.Abilities.Enum;
using Game.Entities.Professions.Enum;

namespace Game.Entities.Abilities.Base;
public abstract class AbilityBase
{
    public AbilityBase(
        string name, 
        AbilityTypesEnum type, 
        int cooldown, 
        int level, 
        ProfessionsEnum professionCode) 
    {
        Name = name;
        Type = type;
        Cooldown = cooldown;
        Level = level;
        ProfessionCode = professionCode;
    }
    public string? Name { get; protected set; }
    public AbilityTypesEnum Type { get; init; }
    public int Cooldown { get; private set; }
    public int Level { get; private set; }
    public ProfessionsEnum ProfessionCode { get; }
    public Entity? User { get; init; }

    public abstract void AbilityAction(Entity target);
}