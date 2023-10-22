using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {

        static void task1()
        {
            double[] A = new double[5];
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write($"Введите элемент A[{i}]: ");
                A[i] = double.Parse(Console.ReadLine());
            }

            // Объявление и заполнение двумерного массива случайными числами
            Random random = new Random();
            double[,] B = new double[3, 4];
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = random.NextDouble();
                }
            }

            // Вывод одномерного массива A
            Console.WriteLine("Одномерный массив A:");
            foreach (var element in A)
            {
                Console.Write(element + " ");
            }

            // Вывод двумерного массива B в виде матрицы
            Console.WriteLine("\nДвумерный массив B:");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            // Поиск общего максимального и минимального элемента
            double maxA = A.Max();
            double minA = A.Min();
            double maxB = B.Cast<double>().Max();
            double minB = B.Cast<double>().Min();

            // Поиск общей суммы и произведения всех элементов
            double sumA = A.Sum();
            double sumB = B.Cast<double>().Sum();
            double productA = A.Aggregate(1.0, (x, y) => x * y);
            double productB = B.Cast<double>().Aggregate(1.0, (x, y) => x * y);

            // Подсчет суммы четных элементов в массиве A
            double sumEvenA = A.Where(x => x % 2 == 0).Sum();

            // Подсчет суммы нечетных столбцов в массиве B
            double sumOddColumnsB = 0;
            for (int j = 0; j < B.GetLength(1); j++)
            {
                if (j % 2 != 0)
                {
                    for (int i = 0; i < B.GetLength(0); i++)
                    {
                        sumOddColumnsB += B[i, j];
                    }
                }
            }

            Console.WriteLine($"Максимальный элемент в A: {maxA}");
            Console.WriteLine($"Минимальный элемент в A: {minA}");
            Console.WriteLine($"Максимальный элемент в B: {maxB}");
            Console.WriteLine($"Минимальный элемент в B: {minB}");
            Console.WriteLine($"Общая сумма всех элементов в A: {sumA}");
            Console.WriteLine($"Общая сумма всех элементов в B: {sumB}");
            Console.WriteLine($"Общее произведение всех элементов в A: {productA}");
            Console.WriteLine($"Общее произведение всех элементов в B: {productB}");
            Console.WriteLine($"Сумма четных элементов в A: {sumEvenA}");
            Console.WriteLine($"Сумма нечетных столбцов в B: {sumOddColumnsB}");
        }

        static void task2()
        {
            int[] array1 = { 1, 2, 2, 3, 4, 5 };
            int[] array2 = { 2, 3, 4, 4, 5, 6 };


            int[] commonElements = array1.Union(array2).Distinct().ToArray();

            Console.WriteLine("Общие элементы без повторений:");
            foreach (var element in commonElements)
            {
                Console.WriteLine(element);
            }
        }

        static void task3()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();


            string cleanInput = input.Replace(" ", "").ToLower();


            char[] charArray = cleanInput.ToCharArray();
            Array.Reverse(charArray);
            string reversedInput = new string(charArray);

            if (cleanInput == reversedInput)
            {
                Console.WriteLine("Строка является палиндромом.");
            }
            else
            {
                Console.WriteLine("Строка не является палиндромом.");
            }
        }

        static void task4()
        {
            Console.Write("Введите предложение: ");
            string input = Console.ReadLine();

            // Разбиваем предложение на слова, используя пробел как разделитель
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int wordCount = words.Length;
            Console.WriteLine($"Количество слов в предложении: {wordCount}");
        }

        static void task5()
        {
            int[,] matrix = {
            {10, -2, 5, 3, 1},
            {8, 12, -6, 15, 9},
            {7, 4, 0, 2, -3},
            {-5, 13, -8, 11, 6},
            {14, -7, -1, -4, 16}
        };

            int minElement = matrix[0, 0];
            int maxElement = matrix[0, 0];
            int minRow = 0;
            int minCol = 0;
            int maxRow = 0;
            int maxCol = 0;

            // Находим минимальный и максимальный элементы и их позиции
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < minElement)
                    {
                        minElement = matrix[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            int sum = 0;
            bool betweenMinMax = false;

            // Находим сумму элементов между минимальным и максимальным элементами
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == minRow && j == minCol)
                    {
                        betweenMinMax = true;
                    }
                    if (i == maxRow && j == maxCol)
                    {
                        betweenMinMax = false;
                    }
                    if (betweenMinMax)
                    {
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine("Сумма элементов между минимальным и максимальным элементами: " + sum);
        }

        static void task6()
        {
            Console.Write("Введите текст: ");
            string text = Console.ReadLine();

            int maxRun = 1;
            int currentRun = 1;

            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == text[i - 1])
                {
                    currentRun++;
                    if (currentRun > maxRun)
                    {
                        maxRun = currentRun;
                    }
                }
                else
                {
                    currentRun = 1;
                }
            }

            Console.WriteLine("Наибольшее количество идущих подряд одинаковых символов: " + maxRun);
        }

        static void task7()
        {
            Console.Write("Введите строку: ");
            string input = Console.ReadLine();

           
            string lowercaseInput = input.ToLower();

            
            HashSet<char> uniqueLetters = new HashSet<char>();

            
            foreach (char c in lowercaseInput)
            {
                if (char.IsLetter(c))
                {
                    uniqueLetters.Add(c);
                }
            }

            Console.WriteLine("Количество различных букв: " + uniqueLetters.Count);
        }

        static void task8()
        {
            Console.Write("Введите строку длиной 20 символов: ");
            string input = Console.ReadLine();

            if (input.Length == 20)
            {
                int digitCount = input.Count(char.IsDigit);
                Console.WriteLine("Количество цифр в строке: " + digitCount);
            }
            else
            {
                Console.WriteLine("Строка не имеет длину 20 символов.");
            }
        }

        static void task9()
        {
            Console.Write("Введите последовательность символов (20 символов): ");
            string input = Console.ReadLine();

            if (input.Length == 20)
            {
                string name = "imanzhusip"; 

                bool canSpellName = true;

                foreach (char c in name)
                {
                    if (input.Contains(c.ToString()))
                    {
                        input = input.Remove(input.IndexOf(c), 1);
                    }
                    else
                    {
                        canSpellName = false;
                        break;
                    }
                }

                if (canSpellName)
                {
                    Console.WriteLine("Можно составить имя.");
                }
                else
                {
                    Console.WriteLine("Нельзя составить имя.");
                }
            }
            else
            {
                Console.WriteLine("Последовательность символов не имеет длину 20 символов.");
            }
        }

        static void task10()
        {
            Console.Write("Введите текст с пробелами: ");
            string input = Console.ReadLine();

            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            foreach (string word in words)
            {
                if (word.Length > 1 && word[0] == word[word.Length - 1])
                {
                    count++;
                }
            }

            Console.WriteLine("Количество слов, у которых первый и последний символы совпадают: " + count);
        }
        static void Main(string[] args)
        {
            task9();
            Console.ReadKey();
        }
    }
}
