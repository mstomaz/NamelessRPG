using Game.Models;
using Game.Models.Professions.Enum;
using Game.Models.Professions;

namespace Game.Factories;

public static class ProfessionFactory
{
    private static readonly Dictionary<ProfessionsEnum, string> _classValues = new(){
        { ProfessionsEnum.Warrior, "Guerreiro" }
    };

    public static void ListPlayerClasses()
    {
        for (int i = 0; i < _classValues.Count; i++)
        {
            Console.WriteLine($"{i} - {_classValues.ElementAt(i).Value}");
        }
    }

    public static void AssignProfession(Player player, ProfessionsEnum professionCode)
    {
        switch (professionCode)
        {
            case ProfessionsEnum.Warrior:
                player.AssignProfession(new Warrior());
                break;
            default: // should be unreachable
                break;
        }
    }
}
