using Game.Entities;
using Game.Entities.Abilities;
using Game.Entities.Enemies;
using Game.Entities.Professions;
using Game.Entities.Professions.Enum;
using Game.Factory;

namespace Game;

public class GameMain
{
    static void Main()
    {
        
        Console.Write("Qual é seu nome? ");
        string? playerName = Console.ReadLine().Trim();

        Console.WriteLine("Escolha sua classe:");
        ClassFactory.ListPlayerClasses();
        uint classValue = uint.Parse(Console.ReadLine()?.Trim());
        var classCode = (ProfessionsEnum)classValue;

        var player = new Player(playerName, classCode);
        Enemy enemy = new Enemy("goblin");

        for (int i = 0; i < player.Abilities.Count; i++)
        {
            Console.WriteLine("{0} - {1}", i, player.Abilities[i].Name);
        }
        Console.WriteLine("Choose an ability:");
        int ability = int.Parse(Console.ReadLine().Trim());

        player.ReadyAbility(player.Abilities[ability]);
        player.UseAbility(enemy);
        
    }
}