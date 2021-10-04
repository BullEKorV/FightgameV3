using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Newtonsoft.Json;

class Weapon
{
    public static List<Weapon> allWeapons = GetWeaponsJson();
    Random rnd = new Random();
    public string weapon { get; set; }
    public string description { get; set; }
    public int damageMax { get; set; }
    public int damageMin { get; set; }
    public float critChance { get; set; }
    public float stunChance { get; set; }
    public float poisonChance { get; set; }
    public float accuracy { get; set; }
    public void Damage(Fighter target)
    {
        if (rnd.NextDouble() > accuracy)
        {
            Console.WriteLine("\nMissed oopsi lmao");
            return;
        }
        int damage = rnd.Next(damageMin, damageMax);
        bool didCrit = rnd.NextDouble() < critChance;
        bool didStun = rnd.NextDouble() < stunChance;
        bool didPoison = rnd.NextDouble() < poisonChance;

        target.TakeDamage(damage, didCrit, didStun, didPoison, weapon);
    }
    public static List<Weapon> GetWeaponsJson()
    {
        string response = File.ReadAllText("Weapons.json");

        List<Weapon> weapons = JsonConvert.DeserializeObject<List<Weapon>>(response);

        return weapons;
    }
}