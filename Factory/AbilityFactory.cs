using Game.Entities.Abilities.Base;
using Game.Entities.Abilities.Base.Warrior;
using Game.Entities.Professions.Enum;
using Game.Entities;

namespace Game.Factory;

public class AbilityFactory
{
    private readonly Entity _entity;
    private readonly Dictionary<ProfessionsEnum, Dictionary<int, List<AbilityBase>>> _abilitiesLookup = [];

    public AbilityFactory(Entity entity)
    {
        _entity = entity;
        _abilitiesLookup = new()
        {
            { ProfessionsEnum.Warrior,
                new Dictionary<int, List<AbilityBase>>()
                {
                    { 1, new List<AbilityBase>() { new MightyStrike(_entity) } }
                }
            }
        };
}

    public List<AbilityBase> GetAbilitiesForLevel(int level, ProfessionsEnum professionCode)
    {
        var abilities = new List<AbilityBase>();

        if (_abilitiesLookup.TryGetValue(professionCode, out var abilitiesByLevel))
        {
            if (abilitiesByLevel.TryGetValue(level, out var abilityFactories))
            {
                foreach (var factory in abilityFactories)
                {
                    abilities.Add(factory);
                }        
            }
        }

        return abilities;
    }
}
