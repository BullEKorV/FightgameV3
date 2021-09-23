using System;

class UI
{
    public static Fighter p, p1, p2;
    public static void StatusBar()
    {
        // moves the cursor to top to write the statusbar
        int x = Console.CursorLeft;
        int y = Console.CursorTop;

        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(1, 0);

        // Player 1
        Console.ForegroundColor = ConsoleColor.White;
        if (p1.GetStunned()) Console.ForegroundColor = ConsoleColor.Red;
        else if (p1.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkGreen;
        else if (p1.GetStunned() && p1.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkMagenta;
        else if (!p1.GetAlive()) Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(p1.name);
        Console.ResetColor();
        Console.Write("'s health: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(p1.hp);
        Console.ResetColor();

        // Player 2
        Console.CursorLeft = Console.WindowWidth - p2.name.Length - 12 - p2.hp.ToString().Length;

        Console.ForegroundColor = ConsoleColor.White;
        if (p2.GetStunned()) Console.ForegroundColor = ConsoleColor.Red;
        else if (p2.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkGreen;
        else if (p2.GetStunned() && p2.GetPoisoned()) Console.ForegroundColor = ConsoleColor.DarkMagenta;
        else if (!p2.GetAlive()) Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write(p2.name);
        Console.ResetColor();
        Console.Write("'s health: ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(p2.hp);
        Console.ResetColor();

        // Write current players turn
        Console.SetCursorPosition(Console.WindowWidth / 2 - p1.name.Length / 2 - 4, 0);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(p.name + "'s turn");
        Console.ResetColor();

        // Restore previous position
        Console.SetCursorPosition(x, y + 1);
    }
}
