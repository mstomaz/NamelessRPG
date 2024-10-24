using Game.Entities.Abilities;
using Game.Entities.Professions;
using Game.Entities.Professions.Enum;
using Game.Factory;

namespace Game.Entities;

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
    private const int _constitutionMultiplier = 5;

    public Player(string name, ProfessionsEnum classCode)
    {
        Name = name;
        AddInitialCharacheristicsPoints();
        Profession = ClassFactory.SetPlayerClass(classCode);
        Strength += Profession.Strength;
        Dexterity += Profession.Dexterity;
        Constitution += Profession.Constitution;
        Intelligence += Profession.Intelligence;
        Wisdom += Profession.Wisdom;
        Charisma += Profession.Charisma;
        Damage = Strength;
        HP += Profession.HP + AddInitialCONToHPIncrease();
        LearnAbilities();
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
    private int AddInitialCONToHPIncrease()
    {
        return Constitution * _constitutionMultiplier;
    }
    public void GainXP(int xp)
    {
        if (Lvl < _maxLvl)
        {
            this.XP += xp;
            if (this.XP >= XPToNextLvl)
            LevelUp();
        }            
    }
    private void LevelUp()
    {
        Lvl++;
        Console.WriteLine($"Você subiu de nível! Nível {Lvl}!");
        LearnAbilities();
        XPToNextLvl *= 2 * Profession.ExpModifier;
    }
    private void LearnAbilities()
    {
        var abilities = Profession.GetAbilitiesForLevel(Lvl);
        foreach (var ability in abilities)
        {
            Abilities.Add(new Ability(ability.Name, ability.Action));
        }
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