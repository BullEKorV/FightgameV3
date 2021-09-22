using System;
using System.Threading;

class Fighter
{
    public string name;
    public int hp = 100;
    private bool isAlive = true;
    private bool isStunned = false;
    private bool isPoisoned = false;
    public Fighter target;
    public Fighter()
    {
        string input = Console.ReadLine().TrimStart().TrimEnd();

        while (input.Length < 3 || input.Length > 10)
        {
            Console.WriteLine("Name can't be shorter than 3 or longer than 10 characters");
            input = Console.ReadLine();
        }
        name = input;
    }
    public void ChooseWeapon()
    {
        for (int i = 0; i < Weapons.allWeapons.Count; i++)
        {
            Console.WriteLine(i + 1 + ": " + Weapons.allWeapons[i].type.ToUpperInvariant());
        }
        Console.WriteLine($"Choose a number between 1 and {Weapons.allWeapons.Count}");
        int choiceInt = -1;
        while (choiceInt < 1 || choiceInt >= Weapons.allWeapons.Count + 1)
        {
            string choice = Console.ReadLine();
            int.TryParse(choice, out choiceInt);
        }

        Weapons.allWeapons[choiceInt - 1].Damage(target);
    }
    public void TakeDamage(int amount, bool didCrit, bool didStun, bool didPoison, string weapon)
    {
        if (didCrit)
        {
            Console.WriteLine($"Nice crit!\nYou decimated {target.name} with {amount * 2} damage with your {weapon}!");
            target.hp -= amount * 2;
        }
        else
        {
            Console.WriteLine($"You dealt {amount} damage to {target.name} with your {weapon}!");
            target.hp -= amount;
        }
        Thread.Sleep(1000);
        if (didStun)
        {
            Console.WriteLine($"You stunned {target.name} aswell! Wakey wakey");
            target.isStunned = true;
        }
        if (didPoison)
        {
            Console.WriteLine($"{target.name} got poisoned! No antibiotics for you ;)");
            target.isPoisoned = true;
        }
    }
    public bool GetAlive()
    {
        return isAlive;
    }
    public bool GetStunned()
    {
        return isStunned;
    }
    public bool GetPoisoned()
    {
        return isPoisoned;
    }
}
