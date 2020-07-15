using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Выполнил Федосенко Антон Александрович
//1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
//2. Реализовать функцию возведения числа a в степень b:
//a.без рекурсии;
//b.рекурсивно;
//c. * рекурсивно, используя свойство четности степени.

namespace Recursion
{
    class Program
    {
        static string[] TaskMap = new string[] { "NumPad1 = Перевод из десятичной си в двоичную", "NumPad2 = Возведение в степень", "Escape - Выйти из программы" };
        static ConsoleKey[] KeyValues = new ConsoleKey[] { ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.Escape };
        static ConsoleKeyInfo key;
        static string res;
        static int counter;
        static int fnum;
        static string BinaryToDecimalConvert(int num)
        {
           if (num/2 !=0)
            {
                BinaryToDecimalConvert(num / 2);
            }
            return res += num % 2;
        }
        static int Exponentiation(int num,int exp,int v)
        {
            if (v==1)
            {
                if (counter != exp)
                {
                    counter++;
                    Exponentiation(num, exp,v);
                }
                return fnum *= num;
            }
            else
            {
                if(counter != exp)
                {
                    counter++;
                    Exponentiation(num, exp,v);
                }
                return fnum *= num * num;
            }
            
        }
        static void FetchTasks(ConsoleKey key)
        {
            switch(key)
            {
                case ConsoleKey.NumPad1:
                    {
                        res = "";
                        Console.WriteLine("Введите число для преобразования");
                        Console.WriteLine($"Число в двоичном представлении {BinaryToDecimalConvert(Convert.ToInt32(MyMethods.NumsCheckNoRestr(Console.ReadLine())))}");
                        Console.ReadLine();
                    }
                    break;
                case ConsoleKey.NumPad2:
                    {
                        counter = 1;
                        fnum = 1;
                        Console.WriteLine("Введите число для возведения в степень");
                        var nm = Convert.ToInt32(MyMethods.NumsCheckNoRestr(Console.ReadLine()));
                        Console.WriteLine("Введите степень");
                        var exp = Convert.ToInt32(MyMethods.NumsCheckNoRestr(Console.ReadLine()));
                        Console.WriteLine($"Результат возведения в степень {Exponentiation(nm, exp % 2 == 0 ? exp / 2 : exp, exp % 2 == 0 ? 0 : 1)}");
                        Console.ReadLine();
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
