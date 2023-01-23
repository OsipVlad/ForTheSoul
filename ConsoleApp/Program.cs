using System;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region CyclesAndRandoms
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
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Array
            int[] cucubers = new int[10];



            for (int i = 0; i < cucubers.Length; i++)//заполняем массив рандомными числами
            {
                cucubers[i] = rand.Next(0, 101);
                Console.Write(cucubers[i] + " ");
            }

            //дан массив, найдем максимально значение
            int maxElement = int.MinValue;
            
            for(int i = 0; i < cucubers.Length; i++)
            {
                if(maxElement < cucubers[i])
                {
                    maxElement = cucubers[i];
                }
            }
            Console.WriteLine("\nМаксимальное число в массиве: " + maxElement);
            Console.ReadKey();
            Console.Clear();
            #endregion

            #region Программа бронирования мест в самолете
            bool isOpen = true;
            int[] sectors = { 6, 28, 15, 15, 17 };

            while (isOpen)
            {
                Console.SetCursorPosition(0, 18);

                for(int i = 0; i < sectors.Length; i++)
                {
                    Console.WriteLine($"В секторе {i + 1} свободно {sectors[i]} мест.");
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Регистрация рейса.");
                Console.WriteLine("\n\n1 - забронировать места\n\n2 - выход из программы.\n\n");
                Console.Write("Введите номер команды: ");
                var namberCommand = Console.ReadLine();
                
                
                switch (namberCommand)
                {
                    case "1":
                        int userSector, userPlaceAmount;
                        Console.Write("В каком секторе вы хотите лететь? ");
                        userSector = Convert.ToInt32(Console.ReadLine()) - 1;
                        if(sectors.Length <= userSector || userSector < 0)
                        {
                            Console.WriteLine("Такого сектора не существует.");
                            break;
                        }
                        Console.Write("Сколько мест вы хотите забронировать? ");
                        userPlaceAmount = Convert.ToInt32(Console.ReadLine());
                        if(userPlaceAmount < 0)
                        {
                            Console.WriteLine("неверное количество мест.");
                            break;
                        }
                        if(sectors[userSector] < userPlaceAmount)
                        {
                            Console.WriteLine($"В секторе {userSector} недостаточно мест." +
                                $" Остаток {sectors[userSector]}");
                            break;
                        }
                        sectors[userSector] -= userPlaceAmount;
                        Console.WriteLine("Бронирование успешно!");
                        break;
                    case "2":
                        isOpen = false;
                        break;
                    case "":
                        Console.WriteLine("Введите команду!");
                        break;
                    
                    
                }
                Console.ReadKey();
                Console.Clear();
            }
            #endregion
        }







    }
}
