using ShooterBackend.Managers;
using ShooterBackend.Models;

namespace ShooterBackend.Services
{
    public static class AnalysisService
    {
        // Existing: Item statistics
        public static void ShowItemStatistics(Inventory<Item> inventory)
        {
            var items = inventory.GetAll();
            if (!items.Any())
            {
                Console.WriteLine("No items to analyze.");
                return;
            }

            Console.WriteLine($"\nTotal Items: {items.Count}");
            Console.WriteLine($"Average Power: {items.Average(i => i.Power):F2}");
            Console.WriteLine($"Average Value: {items.Average(i => i.Value):C}");

            var byCategory = items.GroupBy(i => i.Category)
                                  .Select(g => new { Category = g.Key, Count = g.Count() });

            Console.WriteLine("\nItems by Category:");
            foreach (var group in byCategory)
                Console.WriteLine($"{group.Category}: {group.Count}");
        }

        // Existing: Character statistics
        public static void ShowCharacterStatistics(Inventory<Character> inventory)
        {
            var characters = inventory.GetAll();
            if (!characters.Any())
            {
                Console.WriteLine("No characters to analyze.");
                return;
            }

            Console.WriteLine($"\nTotal Characters: {characters.Count}");
            Console.WriteLine($"Average Level: {characters.Average(c => c.Level):F2}");
            Console.WriteLine($"Average Health: {characters.Average(c => c.Health):F2}");
        }

        // New: Weapon statistics
        public static void ShowWeaponStatistics(Inventory<Weapon> inventory)
        {
            var weapons = inventory.GetAll();
            if (!weapons.Any())
            {
                Console.WriteLine("No weapons to analyze.");
                return;
            }

            Console.WriteLine($"\nTotal Weapons: {weapons.Count}");
            Console.WriteLine($"Average Power: {weapons.Average(w => w.Power):F2}");
            Console.WriteLine($"Average Damage: {weapons.Average(w => w.Damage):F2}");

            var byRarity = weapons.GroupBy(w => w.Rarity)
                                  .Select(g => new { Rarity = g.Key, Count = g.Count() });

            Console.WriteLine("\nWeapons by Rarity:");
            foreach (var group in byRarity)
                Console.WriteLine($"{group.Rarity}: {group.Count}");
        }

        // New: PowerUp statistics
        public static void ShowPowerUpStatistics(Inventory<PowerUp> inventory)
        {
            var powerUps = inventory.GetAll();
            if (!powerUps.Any())
            {
                Console.WriteLine("No power-ups to analyze.");
                return;
            }

            Console.WriteLine($"\nTotal PowerUps: {powerUps.Count}");
            Console.WriteLine($"Average Power: {powerUps.Average(p => p.Power):F2}");
            Console.WriteLine($"Average Duration: {powerUps.Average(p => p.Duration):F2}s");

            var byEffect = powerUps.GroupBy(p => p.Effect)
                                    .Select(g => new { Effect = g.Key, Count = g.Count() });

            Console.WriteLine("\nPowerUps by Effect:");
            foreach (var group in byEffect)
                Console.WriteLine($"{group.Effect}: {group.Count}");
        }
    }
}
