using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenrateEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isFirstInt = true;
            for (int i = 1000; i <= 3000; i++)
            {
                if (IsAllLiteralEven(i))
                {
                    if (!isFirstInt)
                        Console.Write(",");
                    else
                        isFirstInt = false;
                    Console.Write(i);

                }
            }
            Console.ReadLine();
        }

        private static bool IsAllLiteralEven(int i)
        {
            int chkValue = i;
            while(chkValue > 0)
            {
                int dgt = chkValue % 10;
                if (dgt % 2 != 0)
                    return false;
                chkValue = chkValue / 10;
            }
            return true;
        }
    }
}
