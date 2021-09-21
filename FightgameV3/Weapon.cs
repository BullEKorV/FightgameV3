using System;
using System.Collections.Generic;
using System.Numerics;
using System.IO;
using Newtonsoft.Json;

public class Weapons
{
    static List<Weapon> GetWeaponsJson()
    {
        string response = File.ReadAllText("Weapons.json");

        List<Weapon> weapons = JsonConvert.DeserializeObject<List<Weapon>>(response);

        return weapons;
    }
}
class Weapon
{
    public string type { get; set; }
    public int damageMax { get; set; }
    public int damageMin { get; set; }
    public float critChance { get; set; }
    public float stunChance { get; set; }
    public float posionChance { get; set; }
    public float accuracy { get; set; }
}