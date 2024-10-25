using Game.Entities.Professions.Enum;

namespace Game.Entities.Abilities.Base.Warrior;

public class MightyStrike : AbilityBase
{
    public MightyStrike(Entity user) : base(
        name: "Mighty Strike",
        type: Enum.AbilityTypesEnum.Offensive,
        cooldown: 3,
        level: 1,
        ProfessionsEnum.Warrior)
    {
        User = user;
    }

    public override void AbilityAction(Entity target)
    {
        double dmgMultiplier = 1.5;
        int damage = (int)(User!.Damage * dmgMultiplier);
        target.TakeDamage(damage);
    }
}
