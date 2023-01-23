using System;

namespace ConsoleApp1
{
    internal class Cyclesandrandoms
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            float health1 = rand.Next(90, 100);
            int damage1 = rand.Next(15, 20);
            int armor1 = rand.Next(75, 100);

            float health2 = rand.Next(80, 110);
            int damage2 = rand.Next(10, 30);
            int armor2 = rand.Next(65, 100);

            Console.WriteLine($"Гладиатор 1 - {health1} здоровье, {damage1} наносимый урон, {armor1} броня");
            Console.WriteLine($"Гладиатор 2 - {health2} здоровье, {damage2} наносимый урон, {armor2} броня");

            while (health1 > 0 && health2 > 0)
            {
                health1 -= Convert.ToSingle(rand.Next(0, damage2 + 1)) / 100 * armor1;
                health2 -= Convert.ToSingle(rand.Next(0, damage1 + 1)) / 100 * armor2;

                Console.WriteLine("Здаровье гладиатора 1 " + health1);
                Console.WriteLine("Здоровье гладиатора 2 " + health2);
            }
            if (health1 <= 0 && health2 <= 0)
            {
                Console.WriteLine("Ничья!!!");
            }
            else if (health1 <= 0)
            {
                Console.WriteLine("Гладиатор 1 пал");
            }
            else if (health2 <= 0)
            {
                Console.WriteLine("Гладиатор 2 пал");
            }
        }
    }
}
