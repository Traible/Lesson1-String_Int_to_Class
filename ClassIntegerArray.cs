using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassForIntegerArray;
internal class IntegerArray
{
    private List<int> Matrix;

    public IntegerArray()
    {
        Matrix = new List<int>();
    }
    public IntegerArray(int number)
    {
        Matrix = new List<int>(number);
    }

    public IntegerArray(int[] Temporary)
    {
        Matrix = new List<int>();
        for (int i = 0; i < Temporary.Length; i++)
            Matrix.Add(Temporary[i]);
    }

    public IntegerArray(string Temporary)
    {
        Temporary += ".";
        Matrix = new List<int>();
        //this.Temporary = Temporary;
        for (int i = 0; i < Temporary.Length; i++)
        {
            int? Temp = null;
            for (int j = i; j < Temporary.Length; j++)
            {
                if (Temporary[j] >= '0' && Temporary[j] <= '9')
                {
                    if (Temp == null) Temp = 0;
                        Temp = Temp * 10 + Convert.ToInt32(Convert.ToString(Temporary[j]));
                    if (j == Temporary.Length)
                    {
                        if (Temp != null)
                            Matrix.Add((int)Temp);
                    }
                }
                else
                {
                    if (Temp != null)
                    Matrix.Add((int)Temp);
                    i = j;
                    break;
                }
            }
        }
    }
    //public string Print()
    //{
    //    var Output = string.Join(" ", Matrix);
    //    return Output;
    //}

    public string PrintWithSpaceChar(string SpaceChar)
    {
        var Output = string.Join(SpaceChar, Matrix);
        return Output;
    }

    public void AddElement(int number)
    {
        Matrix.Add(number);
    }
    public void RemoveFirstElement()
    {
        Matrix.RemoveAt(0);
    }

    public void Sort(int number)
    {
        Matrix.Sort();
        if (number == 1) Matrix.Reverse();
    }

    public void RemoveOneRepeadElement(int number)
    {
        for (int i = Matrix.Count - 1; i >= 0; i--)
        {
                    if (number == Matrix[i])
                    {
                        Matrix.RemoveAt(i);
                    }
        }
    }

    public void RemoveItemsFromRange(int Max, int Min)
    {
        bool Check = false;
        if (Min > Max)
        {
            int Temp = Max;
            Max = Min;
            Min = Temp;
        }

        for (int i = Matrix.Count - 1; i > 0; i--)
        {
            if (Matrix[i] <= Max && Matrix[i] >= Min)
            {
                Matrix.RemoveAt(i);
                Check = true;
            }
        }
        if (Check == true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выполнено!");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Заданного диапазона нет в массиве!");
            Console.ResetColor();
        }

    }

    public void GetItemsFromRange(int Max, int Min)
    {
        string? Output = null;
            if (Min > Max)
            {
                int Temp = Max;
                Max = Min;
                Min = Temp;
            }
            
            for (int i = 0; i < Matrix.Count; i++)
            {
                if (Matrix[i] <= Max && Matrix[i] >= Min)
                {
                    Output += Matrix[i] + " ";
                }
            }
        
        if (Output != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выполнено!");
            Console.ResetColor();
            Console.WriteLine(Output);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Заданного диапазона нет в массиве!");
            Console.ResetColor();
        }
    }

    public void GetUniqueItems()
    {
        for (int i = Matrix.Count - 1; i >= 0; i--)
        {
            int Temp = Matrix[i];
            for (int j = Matrix.Count - 1; j >= 0; j--)
            {
                if (i != j)
                {
                    if (Temp == Matrix[j])
                    {
                        Matrix.RemoveAt(i);
                        break;
                    }
                }
            }
        }
    }
    public void RemoveAllElement()
    {
        Matrix.Clear();
    }

    public void GetRepeatItems(int Amount)
    {
        int TempAmount = 0;
        string? Output = null;
        for (int i = Matrix.Count - 1; i >= 0; i--)
        {
            TempAmount = 0;
            int TempForNumber = Matrix[i];
            for (int j = Matrix.Count - 1; j >= 0; j--)
            {
                if (i != j)
                {
                    if (TempForNumber == Matrix[j])
                        TempAmount++;
                }

            }
            if (TempAmount == Amount)
                Output += Matrix[i] + " ";
        }

        if (Output != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Выполнено!");
            Console.ResetColor();
            Console.WriteLine(Output);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Элементов соответствующих данным условиям нет в массиве!");
            Console.ResetColor();
        }
    }

    public void Sum()
    {
        int Sum;
        Sum = Matrix.Sum();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Сумма массива: " + Sum);
    }

    public void Max()
    {
        int Max;
        Max = Matrix.Max();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Значение максимального элемента массива: " + Max);
    }

    public void Min()
    {
        int Min;
        Min = Matrix.Min();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Значение максимального элемента массива: " + Min);
    }

    public void Average()
    {
        int Sum;
        float Average;
        Sum = Matrix.Sum();
        Average = (float)Sum / (float)Matrix.Count;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Среднее значение элементов массива: " + Average);
    }

    public void Median()
    {
        float Temp = Matrix.Count;
        float Median = 0;
        float temp1 = Temp / 2;
        int temp2 = Matrix.Count / 2;
        if (temp1 == temp2)
        {
            for (int i = ((Matrix.Count + 1) / 2) - 1, j = 0; j < 2; j++, i++)
            {
                Median += Matrix[i];
            }
            Median /= 2;
        }
        else
        {
            Median = Matrix[Matrix.Count / 2];
        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Медиана массива:" + Median);
    }

    public void EditItem(int index, int delta)
    {
        Matrix[index] = delta;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
    }

    public void GetItem(int index)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Выполнено!");
        Console.ResetColor();
        Console.WriteLine("Искомый элемент:" + Matrix[index]);
    }
}

