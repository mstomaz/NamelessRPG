using Game.Models;
using Game.Models.Professions.Enum;
using Game.Models.Professions;

namespace Game.Factories;

public static class PlayerFactory
{
    private static readonly Dictionary<ProfessionsEnum, string> _professionValues = new(){
        { ProfessionsEnum.Warrior, "Guerreiro" }
    };

    public static void ListPlayerAvaiableProfessions()
    {
        for (int i = 0; i < _professionValues.Count; i++)
        {
            Console.WriteLine($"{i} - {_professionValues.ElementAt(i).Value}");
        }
    }

    public static Player CreatePlayer(string name, ProfessionsEnum professionValue, IAbilityFactory abilityFactory)
    {
        Player player = new(name, GetChosenProfession(professionValue), abilityFactory);
        return player;
    }

    private static Profession GetChosenProfession(ProfessionsEnum professionValue)
    {
        return (professionValue) switch
        {
            ProfessionsEnum.Warrior => new Warrior(),
            _ => throw new NotImplementedException()
        };
    }
}
