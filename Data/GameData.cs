using System.Collections.Generic;
using ShooterBackend.Models;

namespace ShooterBackend.Data
{
    public class GameData
    {
        public List<GameItem> Items { get; set; } = new();
        public List<Character> Characters { get; set; } = new();
        public List<Weapon> Weapons { get; set; } = new();
        public List<PowerUp> PowerUps { get; set; } = new();
    }
}
