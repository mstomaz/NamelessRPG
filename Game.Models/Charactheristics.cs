namespace Game.Models;

public abstract class Charactheristics
{
    protected int _HP;
    protected int _STR;
    protected int _DEX;
    protected int _CON;
    protected int _INT;
    protected int _WIS;
    protected int _CHA;

    public string? Name { get; init; }
    public int HP
    {
        get => _HP;
        set => _HP = value;
    }
    public virtual int Strength
    {
        get => _STR;
        set => _STR = value;
    }
    public int Dexterity
    {
        get => _DEX;
        set => _DEX = value;
    }
    public virtual int Constitution
    {
        get => _CON;
        set => _CON = value;
    }
    public int Intelligence
    {
        get => _INT;
        set => _INT = value;
    }
    public int Wisdom
    {
        get => _WIS;
        set => _WIS = value;
    }
    public int Charisma
    {
        get => _CHA;
        set => _CHA = value;
    }
}