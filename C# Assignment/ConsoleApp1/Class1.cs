using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            var test = "23,45,21|09,33,98,,36,89,-11,09,4,100.5|33,89";
            string[] arr = test.Split(new Char[] { '|', ',' });
            int[] intArr = ConvertToIntArray(arr);
            Array.Sort(intArr);
            Array.Reverse(intArr);
            int sum = intArr[0] + intArr[1] + intArr[2];
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        private static int[] ConvertToIntArray(string[] arr)
        {
            int[] intArr = new int[arr.Length];
            int count = 0;

            foreach (string str in arr)
            {
                if (!string.IsNullOrEmpty(str))
                {
                    int num = int.Parse(str);
                    intArr[count++] = num;
                }
            }
            return intArr;
        }
    }
}
