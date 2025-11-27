using ShooterBackend.Managers;
using ShooterBackend.Models;
using System;
using System.Linq;

namespace Services
{
    public static class SearchService
    {
        public static void SearchItemsByName(Inventory<GameItem> inventory, string name)
        {
            var results = inventory.GetAll()
                                   .Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nSearch results for '{name}':");

            if (!results.Any())
            {
                Console.WriteLine("No items found.");
                return;
            }

            foreach (var item in results)
                item.DisplayInfo();
        }

        public static void FilterWeaponsByRarity(Inventory<Weapon> inventory, string rarity)
        {
            var results = inventory.GetAll()
                                   .Where(w => w.Rarity.Equals(rarity, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\nWeapons of rarity '{rarity}':");

            if (!results.Any())
            {
                Console.WriteLine("No weapons found.");
                return;
            }

            foreach (var weapon in results)
                weapon.DisplayInfo();
        }

        public static void TopCharactersByLevel(Inventory<Character> inventory, int count)
        {
            var top = inventory.GetAll()
                               .OrderByDescending(c => c.Level)
                               .Take(count);

            Console.WriteLine($"\nTop {count} Characters by Level:");

            if (!top.Any())
            {
                Console.WriteLine("No characters found.");
                return;
            }

            foreach (var c in top)
                c.DisplayInfo();
        }
    }
}