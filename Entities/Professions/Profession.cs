using Game.Entities.Abilities;
using Game.Entities.Professions.Enum;

namespace Game.Entities.Professions;

public abstract class Profession : Charactheristics
{
   public ProfessionsEnum ProfessionCode { get; init; }
   public double ExpModifier { get; init; }
}