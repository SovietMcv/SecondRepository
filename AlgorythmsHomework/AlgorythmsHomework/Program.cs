using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Выполнил Федосенко Антон Александрович
//Делал 4 задачи, которые объявили в конце вебинара

//1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.
//2. Найти максимальное из четырех чисел. Массивы не использовать.
//3. Написать программу обмена значениями двух целочисленных переменных
//4. Написать программу нахождения корней заданного квадратного уравнения.
namespace AlgorythmsHomework
{
    class Program
    {
        static string[] TaskMap = new string[] { "NumPad1 = Вычисление индекса массы тела", "NumPad2 = Нахождение максимально числа из 4", "Numpad3 = Обмен значений переменных","NumPad4 = Вычисление корней квадратного уравнения, Escape - Выйти из программы" };
        static ConsoleKey[] KeyValues = new ConsoleKey[] { ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3, ConsoleKey.NumPad4, ConsoleKey.Escape };
        static ConsoleKeyInfo key;
        //static bool GoForward = false;
        static double mass;
        static double height;
        static double BodyMassIdx;
        static double IdxMinNorm = 18.5;
        static double IdxMaxNorm = 25;
        //static double NormMass;
        static double MassCorrection;
        //static string text;
        static void BodyMassIndex()
        {
            Console.Clear();
            Console.WriteLine("Чтобы вывести индекс массы тела, вам нужно будет по очереди ввести свою массу и свой рост.");
            Console.WriteLine("Укажите свой рост в метрах, пожалуйста.");
            height = MyMethods.NumsCheck(Console.ReadLine());
            Console.WriteLine("Укажите свой вес в кг, пожалуйста.");
            mass = MyMethods.NumsCheck(Console.ReadLine());           
            Console.WriteLine("Ваш индекс равен " + $"{mass / (height * height):F}");
            MassCorrection = (BodyMassIdx > IdxMaxNorm || BodyMassIdx < IdxMinNorm) ? ((BodyMassIdx > IdxMaxNorm) ? (mass - IdxMaxNorm * height * height) : (IdxMinNorm * height * height - mass)) : 0;
            Console.WriteLine(MassCorrection == 0 ? "Ваш вес в норме" : (BodyMassIdx > IdxMaxNorm ? $"Вам нужно похудеть на {MassCorrection} кг" : $"Вам нужно набрать {MassCorrection:F} кг"));
            Console.WriteLine("Сейчас вас отправит в главное меню");
            Console.ReadKey();
        }
        static void FindMaxNum(double x1, double x2, double x3, double x4)
        {
            double res = x1 > x2 ? (x1 > (x3 = x3 > x4 ? x3 : x4) ? x1 : x3) : (x2 > (x3 = x3 > x4 ? x3 : x4) ? x2 : x3);
            Console.WriteLine($"Максимальное число равно {res}") ;
            Console.WriteLine("Сейчас вас отправит в главное меню");
            Console.ReadKey();
        }
        static void NumsExchange(ref int x1, ref int x2)
        {
            x1 = x1 + x2;
            x2 = x1 - x2;
            x1 = x1 - x2;
            Console.WriteLine($"x1 = {x1}, x2 = {x2}");
            Console.ReadKey();
            Console.WriteLine("Сейчас вас отправит в главное меню");
            Console.ReadKey();
        }
        static void FindRoots(double a, double b, double c)
        {
            var query = $"({a})x^2 + ({b})x + ({c}) = 0";
            Console.WriteLine($"Ваше уравнение {query}");
            var D = b * b - 4 * a * c;
            if (D == 0)
            {
                Console.WriteLine($"У уравнения один корень равный {(-b)/2*a}");
            }
            else if (D > 0)
            {
                Console.WriteLine($"У уравнения два корня. Первый равен {(-b + Math.Sqrt(b * b - 4*a*c))/2*a}; Второй равен {-b - Math.Sqrt(b * b - 4 * a * c)/2*a}");
            }
            else
            {
                Console.WriteLine("У уровнения нет корней");
            }
            Console.WriteLine("Сейчас вас отправит в главное меню");
            Console.ReadKey();
        }

        static void FetchTasks(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.NumPad1:
                    {
                        BodyMassIndex();
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        Console.WriteLine("Введите первое число");
                        double x1 = MyMethods.NumsCheck(Console.ReadLine());
                        Console.WriteLine("Введите второе число");
                        double x2 = MyMethods.NumsCheck(Console.ReadLine());
                        Console.WriteLine("Введите третье число");
                        double x3 = MyMethods.NumsCheck(Console.ReadLine());
                        Console.WriteLine("Введите четвёртое число");
                        double x4 = MyMethods.NumsCheck(Console.ReadLine());
                        FindMaxNum(x1, x2, x3, x4);
                    }
                    break;
                case ConsoleKey.NumPad3:
                    {
                        Console.WriteLine("Введите первое число");
                        int x1 = Convert.ToInt32(MyMethods.NumsCheck(Console.ReadLine()));
                        Console.WriteLine("Введите второе число");
                        int x2 = Convert.ToInt32(MyMethods.NumsCheck(Console.ReadLine()));
                        NumsExchange(ref x1, ref x2);
                    }
                    break;
                case ConsoleKey.NumPad4:
                    {
                        Console.WriteLine("Формула квадратного уравнения выглядит так ax^2 + bx + c = 0");
                        Console.WriteLine("Введите a");
                        double a = MyMethods.NumsCheckNoRestr(Console.ReadLine());
                        Console.WriteLine("Введите b");
                        double b = MyMethods.NumsCheckNoRestr(Console.ReadLine());
                        Console.WriteLine("Введите c");
                        double c = MyMethods.NumsCheckNoRestr(Console.ReadLine());
                        FindRoots(a, b, c);
                    }
                    break;
            }              
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Добрый день! Давайте выберем задачу для выполнения.Для вывода списка возможных задач нажмите любую клавишу.");
                Console.ReadLine();
                foreach (var x in TaskMap)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine();
                Console.WriteLine("Чтобы выбрать задачу нажмите указанную клавишу в списке");
                key = Console.ReadKey();
                Console.WriteLine();
                foreach (var n in KeyValues)
                {
                    if (key.Key == n && key.Key != ConsoleKey.Escape)
                    {
                        FetchTasks(key.Key);
                        break;
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                }
            }
            while (key.Key != ConsoleKey.Escape);
            Console.WriteLine("Всего доброго!");
            Console.ReadLine();
        }
    }
}
