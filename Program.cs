using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameGuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Эта программа проверит вашу интуицию");
            Console.WriteLine("Сейчас я загадаю число а ваша задача - отгадать его.");
            Console.WriteLine("Выберите уровень сложности 1-4: ");
            Console.WriteLine("1. Лёгкий (1-100)");
            Console.WriteLine("2. Средний (1-1000)");
            Console.WriteLine("3. Сложный (1-10 000)");
            Console.WriteLine("4. Хардкор (1-10 0000)");
            Console.WriteLine("Введите уровень сложности: ");
            
            int userLevel = 0;
            
            while (true)
            {
                string inputLevel = Console.ReadLine();
                bool isNumberLevel = int.TryParse(inputLevel, out int level);
                if (isNumberLevel && (level >= 1 && level <= 4))
                {
                    userLevel = level;
                    break;
                }
                Console.WriteLine("Некорректный ввод. Введите пожалуйста число.");
            }

            int maxNumber = 0;

            switch (userLevel)
            {
                case 1:
                    maxNumber = 100;
                    break;
                case 2:
                    maxNumber = 1000;
                    break;
                case 3:
                    maxNumber = 10000;
                    break;
                case 4:
                    maxNumber = 100000;
                    break;
            }

            Random rnd = new Random();
            int number = rnd.Next(1, maxNumber + 1);
         
            Console.WriteLine($"Сейчас я загадаю число от 1 до {maxNumber} (включительно), а ваша задача - отгадать его.");
            
            Console.WriteLine("Постарайтесь сделать это за наименьшее количество попыток! Итак, ваши варианты?");
            
            int attempts = 0;

            while (true)
            {
                Console.WriteLine($"Попытка номер {attempts + 1}");
                Console.WriteLine("Введите число: ");
                string userInput = Console.ReadLine();
                bool isParsed = int.TryParse(userInput, out int userNumber);

                if (!isParsed)
                {
                    Console.WriteLine("Некорректный ввод. Введите пожалуйста число.");
                    continue;
                }

                attempts += 1;

                if (userNumber == number)
                {
                    Console.WriteLine("Браво! Вы угадали число");
                    Console.WriteLine($"Количество попыток: {attempts}");
                    break;
                }

                if (userNumber < number)
                {
                    Console.WriteLine("Моё число больше! Попробуйте ещё!");
                    continue;
                }

                Console.WriteLine("Моё число меньше! Попробуйте ещё!");
            }
        }
    }
}
