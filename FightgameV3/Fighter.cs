using System;

public class Fighter
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
    public void TakeDamage()
    {

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
