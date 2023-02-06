using ClassForIntegerArray;
using System.Diagnostics;
using System.Xml.Linq;

IntegerArray Массивы = null;

while (true)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Создать пустой массив");
    Console.WriteLine("2. Создать целочисленный массив");
    Console.WriteLine("3. Создать целочисленный массив из строки");
    Console.WriteLine("4. Вывести все массивы на экран");
    Console.Write("\nВыбор: ");

    string inputString = Console.ReadLine();
    try
    {
        string Выбор = inputString;

        switch (Выбор)
        {
            case "1":
                {
                    Массивы = new IntegerArray();
                    break;
                }

            case "2":
                {
                    bool CheckError = false;
                    string? input1 = Console.ReadLine();
                    bool result1 = int.TryParse(input1, out var temp1);
                    if (result1 == true)
                    {
                        int NumberElements = Convert.ToInt32(input1);
                        int[] Массив = new int[NumberElements];
                        for (int i = 0; i < NumberElements; i++)
                        {
                            string? input2 = Console.ReadLine();
                            bool result2 = int.TryParse(input2, out var temp2);
                            if (result2 == true)
                                Массив[i] = Convert.ToInt32(input2);
                            else
                            {
                                Console.WriteLine("Неккоректный ввод!");
                                CheckError = true;
                                break;
                            }
                        }
                        if (CheckError != true)
                        Массивы = new IntegerArray(Массив);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Неккоректный ввод!");
                        break;
                    }
                    
                }

            case "3":
                {
                    Console.Write("Введите список целых чисел, разделив их символами:  ");
                    string TempArray = "asd43sf43dg55h3"; //Console.ReadLine(); test 43 // 43 // 55 // 3
                    Массивы = new IntegerArray(TempArray);
                    break;
                }

            case "4":
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите желаемый разделитель:           или нажмите Enter -> Space по умолчанию ");
                        string? TempSpace = Convert.ToString(Console.ReadLine());
                        if (TempSpace == "")
                            TempSpace = " ";
                        if (TempSpace == null) 
                        {
                            Console.WriteLine("Непридвиденная ошибка!");
                            break;
                        }
                        Console.WriteLine(Массивы.PrintWithSpaceChar(TempSpace));
                    }
                    break;
                }

            case "5":
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите целое число.");
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        if (result == true)
                            Массивы.AddElement(Convert.ToInt32(input));
                        else
                            Console.WriteLine("Некоректный ввод.");
                    }
                    break;
                }

            default:
                {
                    Console.WriteLine("Такой вариант не предусмотрен.");
                    break;
                }
        }
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadLine();
    }
    finally
    {
        Console.Clear();
    }
}