using Game.Entities.Abilities;
using Game.Entities.Professions.Enum;

namespace Game.Entities.Professions;

public abstract class Profession : Charactheristics
{
   public ProfessionsEnum ClassCode { get; init; }
   public double ExpModifier { get; init; }

    public abstract List<Ability> GetAbilitiesForLevel(int level);
}