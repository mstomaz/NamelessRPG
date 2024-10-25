using Game.Entities.Abilities;
using Game.Entities.Professions.Enum;
using System.ComponentModel;
using System.Reflection;

namespace Game.Entities.Professions;

public class Warrior : Profession
{
    public Warrior(string name)
    {
        Name = name;
        ProfessionCode = ProfessionsEnum.Warrior;
        HP = 10;
        Strength = 1;
        Dexterity = 1;
        Constitution = 1;
        ExpModifier = 0.1;
    }
}