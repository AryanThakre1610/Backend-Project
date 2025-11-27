namespace ShooterBackend.Models
{
    public class Item : GameEntity
    {
        public string Category { get; set; }
        public int Power { get; set; }
        public double Value { get; set; }

        public Item(string name, string category, int power, double value)
            : base(name)
        {
            Category = category;
            Power = power;
            Value = value;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"[Item] ID: {Id}, Name: {Name}, Category: {Category}, Power: {Power}, Value: {Value:C}");
        }
    }
}
