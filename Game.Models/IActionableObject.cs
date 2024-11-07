namespace Game.Models
{
    public delegate void DamageSuffered<T>(T sender, int damage) where T : Entity;
    public interface IActionableObject
    {
        event DamageSuffered<Entity> OnDmgTaken;
    }
}
