using Game.Models.Abilities;
using Game.Models.Professions.Enum;

namespace Game.Models
{
    public interface IAbilityFactory
    {
        List<AbilityBase> GetAbilitiesPerLevel(int level, ProfessionsEnum professionCode);
    }
}
