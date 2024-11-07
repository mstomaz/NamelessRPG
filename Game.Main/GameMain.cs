using Game.Factories;
using Game.Models.Abilities;
using Game.Models.Enemies;
using Game.Models.Professions.Enum;

namespace Game;

public class GameMain
{
    static void Main()
    {
        Console.Write("Qual é seu nome? ");
        string? playerName = Console.ReadLine().Trim();

        Console.WriteLine("Escolha sua classe:");
        PlayerFactory.ListPlayerAvaiableProfessions();
        uint professionValue = uint.Parse(Console.ReadLine()?.Trim());
        var professionCode = (ProfessionsEnum)professionValue;

        var player = PlayerFactory.CreatePlayer(playerName, professionCode, new AbilityFactory());
        var playerAbilityArgs = new AbilityUsageEventArgs(player);
        Enemy enemy = new("goblin");

        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Console.WriteLine("{0} - {1}", i, player.Abilities[i].Name);
        }
        Console.WriteLine("Escolha uma habilidade:");
        int ability = int.Parse(Console.ReadLine().Trim());
        Console.WriteLine("{0}\n{1}", player.Abilities[ability].Name, player.Abilities[ability].Description);
        Console.WriteLine("Usar?");
        bool useAbility = Console.ReadLine().ToUpper() == "Y" ? true : false;

        if (useAbility)
        {
            player.ReadyAbility(player.Abilities[ability]);
            player.UseAbility(enemy, playerAbilityArgs);
        }
    }
}