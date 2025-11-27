namespace ShooterBackend.Models
{
    public class Character : GameEntity
    {
        public int Level { get; set; }
        public int Health { get; set; }

        public Character(string name, int level, int health)
            : base(name)
        {
            Level = level;
            Health = health;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Character] ID: {Id}, Name: {Name}, Level: {Level}, Health: {Health}");
        }
    }
}
