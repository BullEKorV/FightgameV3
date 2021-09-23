using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Player one choose a name: ");
        Fighter p1 = new Fighter();
        Console.WriteLine("Player two choose a name: ");
        Fighter p2 = new Fighter();

        UI ui = new UI();
        UI.p1 = p1;
        UI.p2 = p2;

        p1.target = p2;
        p2.target = p1;

        Fighter p = p1;
        UI.p = p;

        while (p1.GetAlive() && p2.GetAlive())
        {
            Console.Clear();
            UI.StatusBar();
            p.Turn();
            UI.StatusBar();

            p = p == p1 ? p2 : p1;
            UI.p = p;

            Console.Write("Press anything to continue...");
            Console.ReadKey();
        }
        Console.ReadLine();
    }
}
