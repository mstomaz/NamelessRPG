using Game.Entities.Professions.Enum;
using Game.Models.Abilities.Base;
using Game.Models.Abilities.Enum;

namespace Game.Models.Abilities.Base.Warrior;

public class MightyStrike : AbilityBase
{
    public MightyStrike(Entity user) : base(
        name: "Mighty Strike",
        type: AbilityTypesEnum.Offensive,
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
