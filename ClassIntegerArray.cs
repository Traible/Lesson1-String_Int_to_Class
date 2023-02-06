using System;
using System.Collections.Generic;
using System.Linq;
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
}

