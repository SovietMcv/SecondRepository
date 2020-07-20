using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Выполнил Федосенко Антон Александрович
//1. Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения оптимизированной и не оптимизированной программы. Написать функции сортировки, которые возвращают количество операций.
//2. *Реализовать шейкерную сортировку.
//3. Реализовать бинарный алгоритм поиска в виде функции, которой передается отсортированный массив. Функция возвращает индекс найденного элемента или -1, если элемент не найден.
//4. *Подсчитать количество операций для каждой из сортировок и сравнить его с асимптотической сложностью алгоритма.

namespace FindAndSort
{
    class Program
    {
		static void NumsExchange(ref int x1, ref int x2)
		{
			x1 = x1 + x2;
			x2 = x1 - x2;
			x1 = x1 - x2;
		}
		static void BinarySearch(int[] AllElements,int ArraySize, int SearchValue)
        {
			int LeftTerminator;
			int RightTerminator;
			int Middle;
			LeftTerminator = 0;
			RightTerminator = ArraySize - 1;
			Middle = LeftTerminator + (RightTerminator - LeftTerminator) / 2;

			while (LeftTerminator <= RightTerminator && AllElements[Middle] != SearchValue)
			{
				if (AllElements[Middle] <= SearchValue)
				{
					LeftTerminator = Middle + 1;
				}
				else
				{
					RightTerminator = Middle - 1;
				}
				Middle = LeftTerminator + (RightTerminator - LeftTerminator) / 2;
			}
			if (AllElements[Middle] == SearchValue)
			{
				Console.WriteLine($"Индекс найденного элемента {Middle}");
			}
			else
			{
				Console.WriteLine("-1");
			}
			Console.ReadLine();
		}
		static void InterpolationSearch(int[] Array, int length, int SearchValue)
		{
			int min = 0;
			int max = length - 1;
			while (min <= max)
			{

				int middle = min + ((SearchValue - Array[min]) * (max - min) / (Array[max] - Array[min]));
				if (Array[middle] == SearchValue)
				{
					break;
				}
				else if (Array[middle] < SearchValue)
				{
					min = middle + 1;
				}
				else if (Array[middle] > SearchValue)
				{
					max = middle - 1;
				}
			}			
		}
		static int[] BubbleSortOptimised(int[] AllElements, int ArraySize)
		{
			//Я внёс 3 оптимизации:
			//первая - это проверка, что мы не берём в работы элементы, которые уже отсортировали
			//вторая - сделал проход слева-направо и справа-налево, это я тако понял и есть шейкерная сортировка, то есть как-будто стакан трясём
			//третье - исключая уже отсортированные элементы при проходе слева и справа можно предположить, что при номере прохода равной половине длины массива уже всё будет отсортировано и можно выйти
			int i;
			int j;
			int counterN = 0;
			int counterCH = 0;
			int k;
			for (i = 0; i < ArraySize; i++)
			{
				if (counterN > ArraySize / 2)  break;
				if (i % 2 != 0)
				{
					for (j = counterCH; j < ArraySize - 1 - counterN; j++)
						if (AllElements[j] > AllElements[j + 1])
						{
							NumsExchange(ref AllElements[j], ref AllElements[j + 1]);
						}
					counterN++;
				}
				else
				{
					for (k = ArraySize-counterN-1; k >= counterCH+1 ; k--)
						if (AllElements[k] < AllElements[k - 1])
						{
							NumsExchange(ref AllElements[k-1], ref AllElements[k]);
						}
					counterCH++;
				}
			}
			Console.WriteLine($"Количество итераций оптимизированной пузырьковой сортировки равно {counterCH + counterN}");
			Console.WriteLine($"Для цикла в цикле формула ассимптотической сложности будет O(N^2) и худший случай равен {ArraySize * ArraySize}");
            return AllElements;
		}
		static void BubbleSort(int[] Array,int ArraySize)
        {
			int i;
			int j;
			int counter = 0;
			for (i = 0; i < ArraySize; i++)
			{
				for (j = 0; j < ArraySize - 1; j++)
				{
					if (Array[j] > Array[j + 1])
					{
						NumsExchange(ref Array[j], ref Array[j + 1]);
					}
					counter++;
				}
			}
			Console.WriteLine($"Количество итераций стандартной пузырьковой сортировки равно {counter}");
			Console.WriteLine($"Для цикла в цикле формула ассимптотической сложности будет O(N^2) и худший случай равен {ArraySize * ArraySize}");
			Console.ReadLine();
		}

		static void LinearSearch(int[] AllElements, int SearchValue, int ArraySize)
        {
			int i;
			i = 0;

			while (i < ArraySize && AllElements[i] != SearchValue)
			{
				i++;
			}

			if (i != ArraySize)
			{
				Console.WriteLine("Index:%d Value:%d", i, AllElements[i]);
			}
			else
			{
				Console.WriteLine("Value not found");
			}
		}
		static void Main(string[] args)
        {
			int[] AllElements;
			int ArraySize;
			int SearchValue;
			int i;
			Random random = new Random();

			Console.WriteLine("Input Array size(N):");
			ArraySize = Convert.ToInt32(MyMethods.NumsCheckNoRestr(Console.ReadLine()));
			AllElements = new int[ArraySize];

			for (i = 0; i < ArraySize; i++)
			{
				AllElements[i] = random.Next(10, 100);
			}

			Console.WriteLine("Input value for search:");
			SearchValue = Convert.ToInt32(MyMethods.NumsCheckNoRestr(Console.ReadLine()));
			BinarySearch(BubbleSortOptimised(AllElements, ArraySize), ArraySize, SearchValue);
			BubbleSort(AllElements, ArraySize);
		}
    }
}
