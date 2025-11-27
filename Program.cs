using ShooterBackend.Models;
using ShooterBackend.Managers;
using ShooterBackend.Utils;
using ShooterBackend.Services;

class Program
{
    static Inventory<Item> itemInventory = new();
    static Inventory<Character> characterInventory = new();
    static Inventory<Weapon> weaponInventory = new();
    static Inventory<PowerUp> powerUpInventory = new();

    static void Main()
    {
        MainMenu();
    }

    // ===================== MAIN MENU =====================
    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Video Game Data Management System ===\n");
            Console.WriteLine("1. Manage Items");
            Console.WriteLine("2. Manage Characters");
            Console.WriteLine("3. Manage Weapons");
            Console.WriteLine("4. Manage PowerUps");
            Console.WriteLine("5. Data Analytics");
            Console.WriteLine("0. Exit");
            Console.Write("\nChoose an option: ");

            switch (Console.ReadLine())
            {
                case "1": EntityMenu("Items"); break;
                case "2": EntityMenu("Characters"); break;
                case "3": EntityMenu("Weapons"); break;
                case "4": EntityMenu("PowerUps"); break;
                case "5": AnalyticsMenu(); break;
                case "0": return;
                default: ShowError(); break;
            }
        }
    }

    // ===================== ENTITY SUB MENU =====================
    static void EntityMenu(string type)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== Manage {type} ===\n");
            Console.WriteLine("1. View All");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Generate Random");
            Console.WriteLine("6. Search");
            Console.WriteLine("0. Back");

            Console.Write("\nChoose: ");
            string choice = Console.ReadLine();

            switch (type)
            {
                case "Items": HandleItemMenu(choice); break;
                case "Characters": HandleCharacterMenu(choice); break;
                case "Weapons": HandleWeaponMenu(choice); break;
                case "PowerUps": HandlePowerUpMenu(choice); break;
            }

            if (choice == "0")
                return;
        }
    }

    // ===================== ITEM HANDLER =====================
    static void HandleItemMenu(string choice)
    {
        switch (choice)
        {
            case "1": itemInventory.ViewAll(); break;
            case "2": AddItem(); break;
            case "3": UpdateItem(); break;
            case "4": DeleteItem(); break;
            case "5":
                Console.Write("Count: ");
                RandomDataGenerator.GenerateItems(itemInventory, int.Parse(Console.ReadLine()));
                break;
            case "6": Search("Item"); break;
            case "0": return;
            default: ShowError(); break;
        }
        Pause();
    }

    // ===================== CHARACTER HANDLER =====================
    static void HandleCharacterMenu(string choice)
    {
        switch (choice)
        {
            case "1": characterInventory.ViewAll(); break;
            case "2": AddCharacter(); break;
            case "3": UpdateCharacter(); break;
            case "4": DeleteCharacter(); break;
            case "5":
                Console.Write("Count: ");
                RandomDataGenerator.GenerateCharacters(characterInventory, int.Parse(Console.ReadLine()));
                break;
            case "6": Search("Character"); break;
            case "0": return;
            default: ShowError(); break;
        }
        Pause();
    }

    // ===================== WEAPON HANDLER =====================
    static void HandleWeaponMenu(string choice)
    {
        switch (choice)
        {
            case "1": weaponInventory.ViewAll(); break;
            case "2": AddWeapon(); break;
            case "3": UpdateWeapon(); break;
            case "4": DeleteWeapon(); break;
            case "5":
                Console.Write("Count: ");
                RandomDataGenerator.GenerateWeapons(weaponInventory, int.Parse(Console.ReadLine()));
                break;
            case "6": Search("Item"); break; 
            case "0": return;
            default: ShowError(); break;
        }
        Pause();
    }

    // ===================== POWERUP HANDLER =====================
    static void HandlePowerUpMenu(string choice)
    {
        switch (choice)
        {
            case "1": powerUpInventory.ViewAll(); break;
            case "2": AddPowerUp(); break;
            case "3": UpdatePowerUp(); break;
            case "4": DeletePowerUp(); break;
            case "5":
                Console.Write("Count: ");
                RandomDataGenerator.GeneratePowerUps(powerUpInventory, int.Parse(Console.ReadLine()));
                break;
            case "6": Search("Item"); break;  // <-- SEARCH
            case "0": return;
            default: ShowError(); break;
        }
        Pause();
    }

    // ===================== ANALYTICS MENU =====================
    static void AnalyticsMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Data Analytics ===");
            Console.WriteLine("1. Item Statistics");
            Console.WriteLine("2. Character Statistics");
            Console.WriteLine("3. Weapon Statistics");
            Console.WriteLine("4. PowerUp Statistics");
            Console.WriteLine("0. Back");

            Console.Write("\nChoose: ");

            switch (Console.ReadLine())
            {
                case "1": AnalysisService.ShowItemStatistics(itemInventory); break;
                case "2": AnalysisService.ShowCharacterStatistics(characterInventory); break;
                case "3": AnalysisService.ShowWeaponStatistics(weaponInventory); break;
                case "4": AnalysisService.ShowPowerUpStatistics(powerUpInventory); break;
                case "0": return;
                default: ShowError(); break;
            }
            Pause();
        }
    }

    // ===================== CRUD METHODS =====================
    static void AddItem()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Category: "); string category = Console.ReadLine();
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());

        itemInventory.Add(new Item(name, category, power, value));
    }

    static void UpdateItem()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Category: "); string category = Console.ReadLine();
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());

        itemInventory.Update(id, new Item(name, category, power, value));
    }

    static void DeleteItem()
    {
        Console.Write("ID: ");
        itemInventory.Delete(int.Parse(Console.ReadLine()));
    }

    // Characters...
    static void AddCharacter()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Level: "); int level = int.Parse(Console.ReadLine());
        Console.Write("Health: "); int health = int.Parse(Console.ReadLine());

        characterInventory.Add(new Character(name, level, health));
    }

    static void UpdateCharacter()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Level: "); int level = int.Parse(Console.ReadLine());
        Console.Write("Health: "); int health = int.Parse(Console.ReadLine());

        characterInventory.Update(id, new Character(name, level, health));
    }

    static void DeleteCharacter()
    {
        Console.Write("ID: ");
        characterInventory.Delete(int.Parse(Console.ReadLine()));
    }

    // Weapons...
    static void AddWeapon()
    {
        Console.Write("Name: "); string name = Console.ReadLine();        
        Console.Write("Rarity: "); string rarity = Console.ReadLine();
        Console.Write("Damage: "); int dmg = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());

        weaponInventory.Add(new Weapon(name, power, value, dmg, rarity));
    }

    static void UpdateWeapon()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Rarity: "); string rarity = Console.ReadLine();
        Console.Write("Damage: "); int dmg = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());

        weaponInventory.Update(id, new Weapon(name, power, value, dmg, rarity));
    }

    static void DeleteWeapon()
    {
        Console.Write("ID: ");
        weaponInventory.Delete(int.Parse(Console.ReadLine()));
    }

    // PowerUps...
    static void AddPowerUp()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Effect: "); string effect = Console.ReadLine();
        Console.Write("Duration: "); int duration = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());
    
        powerUpInventory.Add(new PowerUp(name, power, value, effect, duration));
    }

    static void UpdatePowerUp()
    {
        Console.Write("ID: "); int id = int.Parse(Console.ReadLine());
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Effect: "); string effect = Console.ReadLine();
        Console.Write("Duration: "); int duration = int.Parse(Console.ReadLine());
        Console.Write("Value: "); double value = double.Parse(Console.ReadLine());
        Console.Write("Power: "); int power = int.Parse(Console.ReadLine());

        powerUpInventory.Update(id, new PowerUp(name, power, value, effect, duration));
    }

    static void DeletePowerUp()
    {
        Console.Write("ID: ");
        powerUpInventory.Delete(int.Parse(Console.ReadLine()));
    }

    static void Search(string entity)
    {
        Console.Write("Enter keyword to search in name/category: ");
        string keyword = Console.ReadLine();
        switch (entity)
        {
            case "Item": SearchService.SearchItemsByName(itemInventory, keyword); break;
            case "Character": SearchService.SearchCharacterByName(characterInventory, keyword); break;
            default: ShowError(); break;
        }
    }

    // ===================== HELPERS =====================
    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ShowError()
    {
        Console.WriteLine("Invalid option!");
        Pause();
    }
}
