using ShooterBackend.Models;
using ShooterBackend.Managers;
using Utils;
using Services;
using System;

class Program
{
    static void Main()
    {
        var itemInventory = new Inventory<GameItem>();
        var charInventory = new Inventory<Character>();
        var weaponInventory = new Inventory<Weapon>();
        var powerUpInventory = new Inventory<PowerUp>();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Video Game Data Management System ===\n");
            Console.WriteLine("1. View Items");
            Console.WriteLine("2. Add Item");
            Console.WriteLine("3. Update Item");
            Console.WriteLine("4. Delete Item");
            Console.WriteLine("5. Generate Random Items");
            Console.WriteLine("6. View Characters");
            Console.WriteLine("7. Add Character");
            Console.WriteLine("8. Update Character");
            Console.WriteLine("9. Delete Character");
            Console.WriteLine("10. Generate Random Characters");
            Console.WriteLine("11. Show Item Statistics");
            Console.WriteLine("12. Show Character Statistics");
            Console.WriteLine("13. View Weapons");
            Console.WriteLine("14. Add Weapon");
            Console.WriteLine("15. Delete Weapon");
            Console.WriteLine("16. Generate Random Weapons");
            Console.WriteLine("17. Show Weapon Statistics");
            Console.WriteLine("18. View PowerUps");
            Console.WriteLine("19. Add PowerUp");
            Console.WriteLine("20. Generate Random PowerUps");
            Console.WriteLine("21. Show PowerUp Statistics");
            Console.WriteLine("22. Search Items by Name");
            Console.WriteLine("22. Filter Weapons by Rarity");
            Console.WriteLine("23. Show PowerUp Statistics");
            Console.WriteLine("24. Show Top Characters by Level");

            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            switch (Console.ReadLine())
            {
                // GameItem
                case "1": itemInventory.ViewAll(); break;
                case "2": AddItem(itemInventory); break;
                case "3": UpdateItem(itemInventory); break;
                case "4": DeleteItem(itemInventory); break;
                case "5":
                    Console.Write("Number of random items to generate: ");
                    int itemCount = int.Parse(Console.ReadLine());
                    RandomDataGenerator.GenerateItems(itemInventory, itemCount);
                    break;

                // Character
                case "6": charInventory.ViewAll(); break;
                case "7": AddCharacter(charInventory); break;
                case "8": UpdateCharacter(charInventory); break;
                case "9": DeleteCharacter(charInventory); break;
                case "10":
                    Console.Write("Number of random characters to generate: ");
                    int charCount = int.Parse(Console.ReadLine());
                    RandomDataGenerator.GenerateCharacters(charInventory, charCount);
                    break;

                // Stats for GameItem and Character
                case "11": AnalysisService.ShowItemStatistics(itemInventory); break;
                case "12": AnalysisService.ShowCharacterStatistics(charInventory); break;

                // Weapons
                case "13": weaponInventory.ViewAll(); break;
                case "14": AddWeapon(weaponInventory); break;
                case "15": DeleteWeapon(weaponInventory); break;
                case "16":
                    Console.Write("Number of random weapons to generate: ");
                    int weaponCount = int.Parse(Console.ReadLine());
                    RandomDataGenerator.GenerateWeapons(weaponInventory, weaponCount);
                    break;
                case "17": AnalysisService.ShowWeaponStatistics(weaponInventory); break;

                // PowerUps
                case "18": powerUpInventory.ViewAll(); break;
                case "19": AddPowerUp(powerUpInventory); break;
                case "20":
                    Console.Write("Number of random power-ups to generate: ");
                    int powerUpCount = int.Parse(Console.ReadLine());
                    RandomDataGenerator.GeneratePowerUps(powerUpInventory, powerUpCount);
                    break;
                case "21": AnalysisService.ShowPowerUpStatistics(powerUpInventory); break;
                case "22":
                    Console.Write("Enter name to search: ");
                    SearchService.SearchItemsByName(itemInventory, Console.ReadLine());
                    break;

                case "23":
                    Console.Write("Enter rarity (Common, Rare, Epic, Legendary): ");
                    SearchService.FilterWeaponsByRarity(weaponInventory, Console.ReadLine());
                    break;

                case "24":
                    Console.Write("How many characters to show? ");
                    int count = int.Parse(Console.ReadLine());
                    SearchService.TopCharactersByLevel(charInventory, count);
                    break;

                // Exit
                case "0": exit = true; break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        Console.WriteLine("Exiting program. Goodbye!");
    }

    // --- GameItem CRUD ---
    static void AddItem(Inventory<GameItem> inventory)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Category: ");
        string category = Console.ReadLine();
        Console.Write("Power: ");
        int power = int.Parse(Console.ReadLine());
        Console.Write("Value: ");
        double value = double.Parse(Console.ReadLine());

        inventory.Add(new GameItem(name, category, power, value));
    }

    static void UpdateItem(Inventory<GameItem> inventory)
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Name: ");
        string name = Console.ReadLine();
        Console.Write("New Category: ");
        string category = Console.ReadLine();
        Console.Write("New Power: ");
        int power = int.Parse(Console.ReadLine());
        Console.Write("New Value: ");
        double value = double.Parse(Console.ReadLine());

        inventory.Update(id, new GameItem(name, category, power, value));
    }

    static void DeleteItem(Inventory<GameItem> inventory)
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        inventory.Delete(id);
    }

    // --- Character CRUD ---
    static void AddCharacter(Inventory<Character> inventory)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Level: ");
        int level = int.Parse(Console.ReadLine());
        Console.Write("Health: ");
        int health = int.Parse(Console.ReadLine());

        inventory.Add(new Character(name, level, health));
    }

    static void UpdateCharacter(Inventory<Character> inventory)
    {
        Console.Write("Enter ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("New Name: ");
        string name = Console.ReadLine();
        Console.Write("New Level: ");
        int level = int.Parse(Console.ReadLine());
        Console.Write("New Health: ");
        int health = int.Parse(Console.ReadLine());

        inventory.Update(id, new Character(name, level, health));
    }

    static void DeleteCharacter(Inventory<Character> inventory)
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        inventory.Delete(id);
    }

    // --- Weapon CRUD ---
    static void AddWeapon(Inventory<Weapon> inventory)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Power: ");
        int power = int.Parse(Console.ReadLine());
        Console.Write("Value: ");
        double value = double.Parse(Console.ReadLine());
        Console.Write("Damage: ");
        int damage = int.Parse(Console.ReadLine());
        Console.Write("Rarity: ");
        string rarity = Console.ReadLine();

        inventory.Add(new Weapon(name, power, value, damage, rarity));
    }

    static void DeleteWeapon(Inventory<Weapon> inventory)
    {
        Console.Write("Enter ID to delete: ");
        int id = int.Parse(Console.ReadLine());
        inventory.Delete(id);
    }

    // --- PowerUp CRUD ---
    static void AddPowerUp(Inventory<PowerUp> inventory)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Power: ");
        int power = int.Parse(Console.ReadLine());
        Console.Write("Value: ");
        double value = double.Parse(Console.ReadLine());
        Console.Write("Effect: ");
        string effect = Console.ReadLine();
        Console.Write("Duration (seconds): ");
        int duration = int.Parse(Console.ReadLine());

        inventory.Add(new PowerUp(name, power, value, effect, duration));
    }
}
