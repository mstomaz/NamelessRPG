using Game.Models.Professions.Enum;

namespace Game.Models.Professions;

public class Warrior : Profession
{
    public Warrior()
    {
        Name = "Guerreiro";
        HP = 10;
        Strength = 1;
        Dexterity = 1;
        Constitution = 1;
        ProfessionCode = ProfessionsEnum.Warrior;
        ExpModifier = 1.1;
    }
}