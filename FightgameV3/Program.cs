using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Player one choose a name: ");
        Fighter p1 = new Fighter();
        Console.WriteLine("Player two choose a name: ");
        Fighter p2 = new Fighter();

        p1.target = p2;
        p2.target = p1;

        Console.Clear();

        Fighter p = p1;

        while (p1.GetAlive() || p2.GetAlive())
        {
            Console.Clear();
            StatusBar(p1, p2);
            p.ChooseWeapon();
            // StatusBar(p1, p2);

            p = p == p1 ? p2 : p1;
            Console.ReadKey();
        }

        Console.ReadLine();
    }
    static void StatusBar(Fighter p1, Fighter p2)
    {
        // moves the cursor to top to write the statusbar
        int x = Console.CursorLeft;
        int y = Console.CursorTop;
        Console.CursorTop = Console.WindowTop;
        Console.CursorLeft = Console.WindowLeft;

        // Player 1
        Console.ForegroundColor = ConsoleColor.White;
        if (p1.GetStunned()) Console.ForegroundColor = ConsoleColor.Red;
        else if (p1.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkGreen;
        else if (!p1.GetAlive()) Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(p1.name);
        Console.ResetColor();
        Console.Write("'s health: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(p1.hp);
        Console.ResetColor();

        // Player 2
        Console.CursorLeft = Console.WindowWidth - p2.name.Length - 11 - p2.hp.ToString().Length;

        Console.ForegroundColor = ConsoleColor.White;
        if (p2.GetStunned()) Console.ForegroundColor = ConsoleColor.Red;
        else if (p2.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkGreen;
        else if (!p2.GetAlive()) Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(p2.name);
        Console.ResetColor();
        Console.Write("'s health: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(p2.hp + "       ");
        Console.ResetColor();

        // Restore previous position
        Console.SetCursorPosition(x, y + 1);
    }
}
