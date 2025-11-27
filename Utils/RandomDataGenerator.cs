using ShooterBackend.Models;
using ShooterBackend.Managers;
using System;

namespace Utils
{
    public static class RandomDataGenerator
    {
        private static Random random = new Random();

        private static string[] itemNames = { "Sword", "Shield", "Potion", "Ring", "Bow", "Helmet" };
        private static string[] itemCategories = { "Weapon", "Armor", "Healing", "Accessory" };
        private static string[] characterNames = { "Hero", "Villain", "Mage", "Knight", "Rogue" };
        private static string[] weaponNames = { "Sword", "Axe", "Bow", "Dagger", "Spear" };
        private static string[] weaponRarities = { "Common", "Rare", "Epic", "Legendary" };
        private static string[] powerUpEffects = { "Heal", "Shield", "Speed Boost", "Strength Boost" };

        // Generate generic GameItems
        public static void GenerateItems(Inventory<GameItem> inventory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var item = new GameItem(
                    name: itemNames[random.Next(itemNames.Length)] + " " + random.Next(1, 101),
                    category: itemCategories[random.Next(itemCategories.Length)],
                    power: random.Next(1, 101),
                    value: Math.Round(random.NextDouble() * 100, 2)
                );
                inventory.Add(item);
            }
        }

        // Generate Characters
        public static void GenerateCharacters(Inventory<Character> inventory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var character = new Character(
                    name: characterNames[random.Next(characterNames.Length)],
                    level: random.Next(1, 21),
                    health: random.Next(50, 201)
                );
                inventory.Add(character);
            }
        }

        // Generate Weapons
        public static void GenerateWeapons(Inventory<Weapon> inventory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var weapon = new Weapon(
                    name: weaponNames[random.Next(weaponNames.Length)] + " " + random.Next(1, 101),
                    power: random.Next(10, 101),
                    value: Math.Round(random.NextDouble() * 200, 2),
                    damage: random.Next(5, 51),
                    rarity: weaponRarities[random.Next(weaponRarities.Length)]
                );
                inventory.Add(weapon);
            }
        }

        // Generate PowerUps
        public static void GeneratePowerUps(Inventory<PowerUp> inventory, int count)
        {
            for (int i = 0; i < count; i++)
            {
                var powerUp = new PowerUp(
                    name: "PowerUp " + random.Next(1, 101),
                    power: random.Next(5, 51),
                    value: Math.Round(random.NextDouble() * 50, 2),
                    effect: powerUpEffects[random.Next(powerUpEffects.Length)],
                    duration: random.Next(5, 61) // seconds
                );
                inventory.Add(powerUp);
            }
        }
    }
}
