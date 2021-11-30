using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEIRMANOVA_HW9_MULTITHREAD
{
    class LinqCalc : IArrayCalculator
    {
        public int GetSum(int[] array)
        {
            return array.AsParallel().Sum();
        }
    }
}