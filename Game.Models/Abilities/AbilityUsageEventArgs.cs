namespace Game.Models.Abilities
{
    public class AbilityUsageEventArgs : EventArgs
    {
        public Entity? User { get; set; }

        public static new readonly AbilityUsageEventArgs Empty = new();
        
        public AbilityUsageEventArgs() { }
        public AbilityUsageEventArgs(Entity? user)
        {
            User = user;
        }
    }
}
