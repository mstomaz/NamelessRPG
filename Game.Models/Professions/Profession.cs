using Game.Models.Professions.Enum;

namespace Game.Models.Professions
{
    public class Profession : Charactheristics
    {
        public ProfessionsEnum ProfessionCode { get; init; }
        public double ExpModifier { get; init; }
    }
}
