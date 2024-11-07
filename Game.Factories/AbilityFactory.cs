using Game.Models;
using Game.Models.Abilities;
using Game.Models.Abilities.Base.Warrior;
using Game.Models.Professions.Enum;

namespace Game.Factories;

public class AbilityFactory : IAbilityFactory
{
    private readonly Dictionary<ProfessionsEnum, Dictionary<int, List<AbilityBase>>> _abilitiesPerLvlAndProf = 
        new() {
            { ProfessionsEnum.Warrior,
                new Dictionary<int, List<AbilityBase>>()
                {
                    { 1, new List<AbilityBase>() { new MightyStrike() } }
                }
            }
        };

    public List<AbilityBase> GetAbilitiesPerLevel(int level, ProfessionsEnum professionCode)
    {
        var abilities = new List<AbilityBase>();

        if (_abilitiesPerLvlAndProf.TryGetValue(professionCode, out var abilitiesByProf))
        {
            if (abilitiesByProf.TryGetValue(level, out var abilitiesByLvl))
            {
                foreach (var ability in abilitiesByLvl)
                    abilities.Add(ability);
            }
        }

        return abilities;
    }
}
