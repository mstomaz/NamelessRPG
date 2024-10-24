using Game.Entities.Professions;
using Game.Entities.Professions.Enum;

namespace Game.Factory;

public static class ClassFactory
{
    private static readonly Dictionary<ProfessionsEnum, string> _classValues =  new(){
        {ProfessionsEnum.Warrior, "Guerreiro" }
    };

    public static void ListPlayerClasses()
    {
        for (int i = 0; i < _classValues.Count; i++)
        {
            Console.WriteLine($"{i} - {_classValues.ElementAt(i).Value}");
        }
    }

    public static Profession SetPlayerClass(ProfessionsEnum classCode)
    {
        return classCode switch 
        {
            ProfessionsEnum.Warrior => new Warrior("Guerreiro"),
            _ => throw new NotImplementedException()
        };
    }
}
