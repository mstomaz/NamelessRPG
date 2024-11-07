using Game.Models.Abilities.Enum;
using Game.Models.Professions.Enum;

namespace Game.Models.Abilities.Base.Warrior;

public class MightyStrike : AbilityBase
{
    private double dmgModifier = 1.5;

    public MightyStrike() : base(
        name: "Ataque Poderoso",
        type: AbilityTypesEnum.Offensive,
        cooldown: 3,
        level: 1,
        description: "O guerreiro usa toda sua força para desferir um poderoso golpe no inimigo.")
    { }

    public override void AbilityAction(Entity target, AbilityUsageEventArgs args)
    {
        int damage = (int)(args.User!.Damage * dmgModifier);
        target.TakeDamage(damage);
    }
}
