using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Player one choose a name: ");
        Fighter p1 = new Fighter();
        Console.WriteLine("Player two choose a name: ");
        Fighter p2 = new Fighter();

        UI ui = new UI(p1, p2);

        Fighter p = p1;

        while (p1.GetAlive() && p2.GetAlive())
        {
            Console.Clear();
            UI.instance.StatusBar();
            p.Turn();
            UI.instance.StatusBar();

            p = p == p1 ? p2 : p1;
            UI.instance.p = p;

            Console.Write("Press anything to continue...");
            Console.ReadKey();
        }
        Console.ReadLine();
    }
}
