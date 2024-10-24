namespace Game.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AbilityLevelAttribute(int requiredLevel) : Attribute
{
    public int RequiredLevel = requiredLevel;
}