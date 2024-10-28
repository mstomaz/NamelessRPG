using Game.Models.Professions;

namespace Game.Models;
public class Player : Entity
{
    private const int _initialHP = 10;
    private const int _initialSTR = 1;
    private const int _initialDEX = 1;
    private const int _initialCON = 1;
    private const int _initialINT = 1;
    private const int _initialWIS = 1;
    private const int _initialCHA = 1;
    private const int _maxLvl = 10;
    public int CONMultiplier = 5;

    public Player(string name)
    {
        Name = name;
        AddInitialCharacheristicsPoints();
    }

    private EventHandler? _onCONIncrease;

    public override int Constitution
    {
        get => _CON;
        set
        {
            _CON = value;
            _onCONIncrease!(this, EventArgs.Empty);
        }
    }

    public int XP { get; private set; } = 0;
    public double XPToNextLvl { get; private set; } = 100;

    private void AddInitialCharacheristicsPoints()
    {
        Strength += _initialSTR;
        Dexterity += _initialDEX;
        Constitution += _initialCON;
        Intelligence += _initialINT;
        Wisdom += _initialWIS;
        Charisma += _initialCHA;
        HP += _initialHP;
    }

    protected override void AttachCharacteristicsHandlers(object? sender, EventArgs args)
    {
        base.AttachCharacteristicsHandlers(sender, args);
        _onCONIncrease += (sender, args) => HP += _CON * CONMultiplier;
    }

    public void GainXP(int xp)
    {
        if (Lvl < _maxLvl)
        {
            XP += xp;
            if (XP >= XPToNextLvl)
                LevelUp();
        }
    }

    private void LevelUp()
    {
        Lvl++;
        Console.WriteLine($"Você subiu de nível! Nível {Lvl}!");
        LearnAbilities();
        XPToNextLvl *= 2 * Profession!.ExpModifier;
    }

    private void LearnAbilities()
    {
        var abilities = new AbilityFactory(this).GetAbilitiesForLevel(Lvl, Profession.ProfessionCode);
        if (abilities.Count > 0)
            Abilities.AddRange(abilities);
    }

    public void AssignProfession(Profession profession)
    {
        Profession = profession;
        AggregateProfessionCharacteristics(profession);
    }
    private void AggregateProfessionCharacteristics(Profession profession)
    {
        Strength += profession.Strength;
        Dexterity += profession.Dexterity;
        Constitution += profession.Constitution;
        Intelligence += profession.Intelligence;
        Wisdom += profession.Wisdom;
        Charisma += profession.Charisma;
        HP += profession.HP;
        LearnAbilities();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public override void ApplyBuff()
    {
        throw new NotImplementedException();
    }

    public override void ApplyDebuff()
    {
        throw new NotImplementedException();
    }
}