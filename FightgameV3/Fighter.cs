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
    public Random rnd = new Random();
    public Fighter()
    {
        string input = Console.ReadLine().TrimStart().TrimEnd();

        while (input.Length < 3 || input.Length > 12)
        {
            Console.WriteLine("Name can't be shorter than 3 or longer than 12 characters");
            input = Console.ReadLine();
        }
        name = input;
    }
    public void Turn()
    {
        Console.Write(new string('_', Console.WindowWidth));
        Console.WriteLine();
        if (isStunned)
        {
            if (rnd.NextDouble() < 0.4)
            {
                Console.WriteLine("You're no longer stunned!");
                isStunned = false;
            }
            else
            {
                Console.WriteLine("You're still stunned ");
                return;
            }
        }
        if (isPoisoned)
        {
            if (rnd.NextDouble() < 0.3)
            {
                Console.WriteLine("You're no longer sick!\n");
                isPoisoned = false;
            }
            else
            {
                int poisonDamage = rnd.Next(4, 9);
                Console.WriteLine($"You're feeling ill... You took {poisonDamage} in damage\n");
                hp -= poisonDamage;
            }
        }
        ChooseWeapon();
    }
    public void ChooseWeapon()
    {
        Console.WriteLine($"Choose a weapon of the following:");
        for (int i = 0; i < Weapons.allWeapons.Count; i++)
        {
            Console.CursorLeft += 1;
            Console.Write(i + 1 + ": " + Weapons.allWeapons[i].weapon.ToUpper());
            Console.WriteLine(" | " + Weapons.allWeapons[i].description);
        }
        int choiceInt = -1;
        while (choiceInt < 1 || choiceInt >= Weapons.allWeapons.Count + 1)
        {
            Console.Write($"Choise: ");
            string choice = Console.ReadLine();
            int.TryParse(choice, out choiceInt);
        }
        Weapons.allWeapons[choiceInt - 1].Damage(target);
        if (target.hp == 0)
        {
            Console.WriteLine(target.name);
            target.isAlive = false;
        }
    }
    public void TakeDamage(int amount, bool didCrit, bool didStun, bool didPoison, string weapon)
    {
        Console.WriteLine();
        if (didCrit)
        {
            Console.WriteLine($"You landed a critical on {name} dealing {amount * 2} damage with your {weapon}!");
            hp -= amount * 2;
        }
        else if (amount > 0)
        {
            Console.WriteLine($"You dealt {amount} damage to {name} with your {weapon}!");
            hp -= amount;
        }
        if (didStun)
        {
            Console.WriteLine($"\nYou stunned {name} aswell! Wakey wakey");
            isStunned = true;
        }
        if (didPoison)
        {
            Console.WriteLine($"\n{name} got poisoned! No antibiotics for you ;)");
            isPoisoned = true;
        }
        hp = Math.Max(hp, 0);
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
