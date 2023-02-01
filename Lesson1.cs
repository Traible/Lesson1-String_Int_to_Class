using ClassForIntegerArray;
using System.Xml.Linq;

List<IntegerArray> Массивы = new List<IntegerArray>();

while (true)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Создать пустой массив");
    Console.WriteLine("2. Добавить сотрудника(Подробный вариант)");
    Console.Write("\nВыбор: ");

    string inputString = Console.ReadLine();
    try
    {
        string Выбор = inputString;

        switch (Выбор)
        {
            case "1":
                {
                    // Сотрудник Новичек = new Сотрудник(familia, name, null, age, null, null);
                    IntegerArray.new();
                    break;
                }

            case "2":
                {

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