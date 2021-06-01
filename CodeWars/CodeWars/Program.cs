using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    class Program
    {
        static void Main(string[] args)
        {

            var actual = DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);
            
            
        }

        private static int[] DeleteNth(int[] arr, int x)
        {
            var result = new List<int>();
            foreach (var item in arr)
            {
                if (result.Count(i => i == item) < x)
                    result.Add(item);
            }
            return result.ToArray();
        }
    }
}
