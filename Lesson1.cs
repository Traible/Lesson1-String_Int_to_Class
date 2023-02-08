using ClassForIntegerArray;
using System.Diagnostics;
using System.Xml.Linq;
using System;
using System.IO;
using System.Reflection;

IntegerArray Массивы = null;

while (true)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Создать пустой массив");
    Console.WriteLine("2. Создать целочисленный массив");
    Console.WriteLine("3. Создать целочисленный массив из строки");
    Console.WriteLine("4. Создать целочисленный массив из списка"); 
    Console.WriteLine("5. Указать путь к файлу");
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("11. Добавить целое число в массив");
    Console.WriteLine("12. Удалить первое число в массиве");
    Console.WriteLine("13. Удалить конкретный число из массива");
    Console.WriteLine("14. Удалить все числа из массива");
    Console.WriteLine("15. Удалить элементы из массива входящие в диапазон");
    Console.WriteLine("16. Вывести массив на экран");
    Console.WriteLine("17. Осортировать массив");
    Console.WriteLine("18. Вывести элементы из массива входящие в диапазон");
    Console.WriteLine("19. Оставить только уникальные элементы");
    Console.WriteLine("20. Вывести элементы, повторяющиеся N раз");
    Console.WriteLine("21. Вывести сумму массива");
    Console.WriteLine("22. Вывести медиану массива");
    Console.WriteLine("23. Вывести cреднее значение элементов массива");
    Console.WriteLine("24. Вывести значение максимального элемента");
    Console.WriteLine("25. Вывести значение минимального элемента");
    Console.WriteLine("26. Записать массив в файл");
    Console.WriteLine("27. Изменить значение по индексу");
    Console.WriteLine("28. Получить значение по индекс");
    Console.Write("\nВыбор: ");

    string inputString = Console.ReadLine();
    try
    {
        string Выбор = inputString;

        switch (Выбор)
        {
            case "1":   // Создать пустой массив
                {
                    Массивы = new IntegerArray();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Выполнено!");
                    Console.ResetColor();
                    break;
                }

            case "2":   // Создать целочисленный массив
                {
                    bool CheckError = false;
                    string? input1 = Console.ReadLine();
                    bool result1 = int.TryParse(input1, out var temp1);
                    if (result1 == true)
                    {
                        int NumberElements = temp1;
                        int[] Массив = new int[NumberElements];
                        for (int i = 0; i < NumberElements; i++)
                        {
                            string? input2 = Console.ReadLine();
                            bool result2 = int.TryParse(input2, out var temp2);
                            if (result2 == true)
                                Массив[i] = temp2;
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Неккоректный ввод!");
                                Console.ResetColor();
                                CheckError = true;
                                break;
                            }
                        }
                        if (CheckError != true)
                        {
                            Массивы = new IntegerArray(Массив);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнено!");
                            Console.ResetColor();
                        }
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неккоректный ввод!");
                        Console.ResetColor();
                        break;
                    }
                    
                }

            case "3":   // Создать целочисленный массив из строки
                {
                    Console.WriteLine("Введите список целых чисел, разделив их символами:");
                    string TempArray = "asd1sf2dg3h123ы1ы2в3ы3ы5ы4ы4ыы3ы3ы3ы3ы3";  // Console.ReadLine(); // test 1 // 2 // 3 // 123 // 1 // 2 // 3
                    Массивы = new IntegerArray(TempArray);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Выполнено!");
                    Console.ResetColor();
                    break;
                }

            case "4":   // Записать список
                {
                    bool Check = false;
                    Console.WriteLine("Введите список целых чисел:");
                    List<int> Temporary = new List<int>();
                    while (true)
                    { 
                        Console.WriteLine("Введите целое число.");
                        Console.WriteLine("Для того чтобы прекратить ввод, нажмите Enter");
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        if (result == true)
                        {
                            Temporary.Add(temp);
                            if (Check == false) Check = true;
                        } 
                        if (input == "") break;
                        if (result == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некоректный ввод.");
                            Console.ResetColor();
                        }
                    }
                    if (Check == true) 
                    {
                        Массивы = new IntegerArray();
                        for (int i = 0; i < Temporary.Count; i++)
                        {
                            Массивы.AddElement(Temporary[i]);
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выполнено!");
                        Console.ResetColor();
                    }
                    break;
                }

            case "5":   //  Считать массив с файла, указав путь к нему
                {
                    Console.WriteLine("Укажите путь к файлу с массивом.");
                    string? Path = @"D:\Test.txt";// Console.ReadLine();
                    string? Temporary = null;
                    try
                    {
                        Temporary = File.ReadAllText(Path);
                    }
                    catch
                    {
                        Temporary = null;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Невозможно считать указанный файл.");
                        Console.ResetColor();
                    }
                    finally
                    {
                        if (Temporary != null)
                        {
                            Массивы = new IntegerArray(Temporary);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнено!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "11":   // Добавить целое число в массив
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите целое число.");
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        if (result == true)
                        {
                            Массивы.AddElement(Convert.ToInt32(input));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнено!");
                            Console.ResetColor();
                        } 
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некоректный ввод.");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "12":  // Удалить первое число в массиве
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Массивы.RemoveFirstElement();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выполнено!");
                        Console.ResetColor();
                    }
                    break;
                }

            case "13":   // Удалить конкретный повторяющийся элемент из массива
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите целое число.");
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        if (result == true)
                        {
                            Массивы.RemoveOneRepeadElement(Convert.ToInt32(input));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнено!");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некоректный ввод.");
                            Console.ResetColor();
                        }
                    }
                    break;
                }
            
            case "14":  // Удалить все числа из массива
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Массивы.RemoveAllElement();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выполнено!");
                        Console.ResetColor();
                    }
                    break;
                }

            case "15":   // Удалить элементы из массива входящие в диапазон 
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        string? input1 = Console.ReadLine();
                        bool result1 = int.TryParse(input1, out var temp1);
                        string? input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out var temp2);
                        if (result1 == true && result2 == true)
                            Массивы.RemoveItemsFromRange(Convert.ToInt32(input1), Convert.ToInt32(input2));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "16":   // Вывести массив на экран
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите желаемый разделитель:        или нажмите Enter -> Space по умолчанию ");
                        string? TempSpace = Convert.ToString(Console.ReadLine());
                        if (TempSpace == "") TempSpace = " ";
                        if (TempSpace == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Непридвиденная ошибка!");
                            Console.ResetColor();
                            break;
                        }
                        Console.WriteLine(Массивы.PrintWithSpaceChar(TempSpace));
                    }
                    break;
                }

            case "17":   // Отсортировать массив
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Выберите как отсортировать массив.");
                        Console.WriteLine("Отсортировать массив по Возрастанию. [по умолчанию] нажмите Enter  ");
                        Console.Write("Отсортировать массив по Убыванию. -> Введите");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  1  ");
                        Console.ResetColor();
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        if (result == true)
                        {
                            if (Convert.ToInt32(input) == 1)
                            {
                                Массивы.Sort(1);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Выполнена сортировка по Убыванию!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Массивы.Sort(0);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Выполнена сортировка по Возрастанию!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "18":   // Вывести элементы из массива входящие в диапазон 
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        string? input1 = Console.ReadLine();
                        bool result1 = int.TryParse(input1, out var temp1);
                        string? input2 = Console.ReadLine();
                        bool result2 = int.TryParse(input2, out var temp2);
                        if (result1 == true && result2 == true)
                            Массивы.GetItemsFromRange(Convert.ToInt32(input1), Convert.ToInt32(input2));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "19":  // Оставить только уникальные элементы
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Массивы.GetUniqueItems();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выполнено!");
                        Console.ResetColor();
                    }
                    break;
                }

            case "20":  // Вывести элементы, повторяющиеся N раз
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите желаемое количество повторений.");
                        string? input = Console.ReadLine();
                        bool result = int.TryParse(input, out var temp);
                        Массивы.GetRepeatItems(Convert.ToInt32(input));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Выполнено!");
                        Console.ResetColor();
                    }
                    break;
                }

            case "21":  // Вывести сумму массива
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                        Массивы.Sum();
                    break;
                }

            case "22":  // Вывести Медиану массива
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else 
                        Массивы.Median();
                    break;
                }

            case "23":  // Вывести cреднее значение элементов массива
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                        Массивы.Average(); 
                    break;
                }

            case "24":  // Вывести значение максимального элемента
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                        Массивы.Max();
                    break; 
                }

            case "25":  // Вывести значение минимального элемента
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                        Массивы.Min();
                    break; 
                }

            case "26":  // Записать массив в файл
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Укажите путь к файлу с массивом.");
                        string? Path = @"D:\Test.txt";// Console.ReadLine();
                        string? Temporary = Массивы.PrintWithSpaceChar(" ");
                        try
                        {
                            File.WriteAllText(Path, Temporary);
                        }
                        catch
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Невозможно считать указанный файл.");
                            Console.ResetColor();
                            break;
                        }
                        finally
                        {
                            if (Temporary != null)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Выполнено!");
                                Console.ResetColor();
                            }
                        }
                    }
                    break;
                }

            case "27":  // Изменить значение по индексу
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите индекс массива.");
                        string? index = Console.ReadLine();
                        bool result1 = int.TryParse(index, out var temp1);
                        Console.WriteLine("Введите целое число на которое хотите заменить.");
                        string? delta = Console.ReadLine();
                        bool result2 = int.TryParse(delta, out var temp2);
                        if (result1 == true && result2 == true)
                            Массивы.EditItem(Convert.ToInt32(index), Convert.ToInt32(delta));
                        else 
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }

            case "28":  // Получить значение по индексу
                {
                    if (Массивы == null)
                        Console.WriteLine("В базе нет массивов.");
                    else
                    {
                        Console.WriteLine("Введите индекс массива.");
                        string? index = Console.ReadLine();
                        bool result = int.TryParse(index, out var temp);
                        if (result == true)
                        Массивы.GetItem(Convert.ToInt32(index));
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Некорректный ввод!");
                            Console.ResetColor();
                        }
                    }
                    break;
                }


            default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такой вариант не предусмотрен.");
                    Console.ResetColor();
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