using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEIRMANOVA_HW9_MULTITHREAD
{
    class SeqCalc : IArrayCalculator
    {
        public int GetSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;

        }
    }
}
