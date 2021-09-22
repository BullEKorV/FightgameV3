using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Newtonsoft.Json;

class Weapons
{
    public static List<Weapon> allWeapons = GetWeaponsJson();
    public static List<Weapon> GetWeaponsJson()
    {
        string response = File.ReadAllText("Weapons.json");

        List<Weapon> weapons = JsonConvert.DeserializeObject<List<Weapon>>(response);

        return weapons;
    }
}
class Weapon
{
    Random rnd = new Random();
    public string type { get; set; }
    public int damageMax { get; set; }
    public int damageMin { get; set; }
    public float critChance { get; set; }
    public float stunChance { get; set; }
    public float posionChance { get; set; }
    public float accuracy { get; set; }
    public void Damage(Fighter target)
    {
        if (rnd.NextDouble() > accuracy)
        {
            Console.WriteLine("Missed oopsi lmao");
            return;
        }
        int damage = rnd.Next(damageMin, damageMax);
        bool didCrit = rnd.NextDouble() < critChance;
        bool didStun = rnd.NextDouble() < stunChance;
        bool didPoison = rnd.NextDouble() < posionChance;

        target.TakeDamage(damage, didCrit, didStun, didPoison, type);
    }
}