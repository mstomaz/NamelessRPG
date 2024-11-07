using Game.Models.Professions;

namespace Game.Models;
public class Player : Entity
{
    private readonly IAbilityFactory _abilityFactory;
    private const int _initialHP = 10;
    private const int _initialSTR = 1;
    private const int _initialDEX = 1;
    private const int _initialCON = 1;
    private const int _initialINT = 1;
    private const int _initialWIS = 1;
    private const int _initialCHA = 1;
    private const int _maxLvl = 10;

    public int CONMultiplier = 5;

    public Player(string name, Profession profession, IAbilityFactory abilityFactory)
    {
        Name = name;
        Profession = profession;
        _abilityFactory = abilityFactory;
        InitializePlayer();
    }

    private EventHandler? _onCONIncrease;
    public Action<string>? OnLvlUp;

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
    public double XPToNextLvl { get; private set; } = 1000;

    private void InitializePlayer()
    {
        AttachCharacteristicsHandlers(this, EventArgs.Empty);
        AddInitialCharacheristicsPoints();
        AddProfessionCharacteristics();
    }

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

    private void AddProfessionCharacteristics()
    {
        Strength += Profession!.Strength;
        Dexterity += Profession.Dexterity;
        Constitution += Profession.Constitution;
        Intelligence += Profession.Intelligence;
        Wisdom += Profession.Wisdom;
        Charisma += Profession.Charisma;
        HP += Profession.HP;
        LearnAbilities();
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
        OnLvlUp!($"Você subiu de nível! Nível {Lvl}.");
        LearnAbilities();
        XPToNextLvl = (Lvl - 1) * Lvl * 500 * Profession!.ExpModifier;
    }

    private void LearnAbilities()
    {
        var abilities = _abilityFactory.GetAbilitiesPerLevel(Lvl, Profession!.ProfessionCode);
        if (abilities.Count > 0)
            Abilities.AddRange(abilities);
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