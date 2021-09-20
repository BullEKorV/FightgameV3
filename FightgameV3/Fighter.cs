using System;

namespace FightgameV3
{
    public class Fighter
    {
        public string name;
        public int hp = 100;
        public bool isStunned = false;
        public Fighter()
        {
            Console.WriteLine("Choose a name: ");
            string input = Console.ReadLine().TrimStart().TrimEnd();

            while (input.Length < 3 || input.Length > 10)
            {
                Console.WriteLine("Name can't be shorter than 3 or longer than 10 characters");
                input = Console.ReadLine();
            }
            name = input;
        }
        public void takeDamage()
        {

        }
    }
}