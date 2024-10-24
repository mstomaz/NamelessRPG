using Game.Attributes;
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
        ClassCode = ProfessionsEnum.Warrior;
        HP = 10;
        Strength = 1;
        Dexterity = 1;
        Constitution = 1;
        ExpModifier = 0.1;
    }

    public override List<Ability> GetAbilitiesForLevel(int level)
    {
        var abilities = new List<Ability>();

        var warriorAbilitiesType = typeof(WarriorAbilities);

        foreach (var method in warriorAbilitiesType.GetMethods())
        {
            var requiredLevel = method.GetCustomAttribute<AbilityLevelAttribute>()!.RequiredLevel;

            if (level == requiredLevel)
            {
                string name = method.GetCustomAttribute<DisplayNameAttribute>()!.DisplayName;
                var action = (Ability.AbilityUsage)Delegate.CreateDelegate(typeof(Ability.AbilityUsage), method);
                abilities.Add(new Ability(name, action));
            }
            else break;
        }

        return abilities;
    }

    public class WarriorAbilities
    {
        [AbilityLevel(1)]
        [DisplayName("Mighty Strike")]
        public static void MightyStrike(Entity target, Entity attacker)
        {
            double dmgMultiplier = 1.5;
            int damage = (int)(attacker.Damage * dmgMultiplier);
            target.TakeDamage(damage);
            Console.WriteLine($"{target.Name} takes {damage} damage and is left with {target.HP} HP!");
        }

        [AbilityLevel(3)]
        [DisplayName("Blood Sacrifice")]
        public static void BloodSacrifice(Entity target)
        {

        }
    }
}