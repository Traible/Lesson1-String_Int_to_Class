using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassForIntegerArray;
internal class IntegerArray
{
    private List<int> Array;

    public IntegerArray()
    {
        Array = new List<int>();
    }

    public IntegerArray(int[] Temporary)
    {
        Array = new List<int>();
        for (int i = 0; i < Temporary.Length; i++)
            Array.Add(Temporary[i]);
    }

    public IntegerArray(string Temporary)
    {
        Array = new List<int>();

        for (int i = 0; i < Temporary.Length; i++)
        {
            int Temp = 0;
            for (int j = i; j < Temporary.Length; j++)
            {
                if (Temporary[i] >= '0' && Temporary[i] <= '9')
                {
                    Temp = Temp * 10 + Convert.ToInt32(Temporary[i]);
                    if (j == Temporary.Length) Array.Add(Temp);
                }
                else
                {
                    Array.Add(Temp);
                    i = j;
                    break;
                }
            }
        }
    }
}