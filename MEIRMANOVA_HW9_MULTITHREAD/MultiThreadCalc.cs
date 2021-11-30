using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;

namespace MEIRMANOVA_HW9_MULTITHREAD

{
    class MultiThreadCalc : IArrayCalculator
    {
        private int _threadCount;
        public MultiThreadCalc(int threadCount)
        {
            _threadCount = threadCount;
        }

        public int GetSum(int[] array)
        {
            var partSize = array.Count() / _threadCount;
            ConcurrentBag<int> sumBag = new ConcurrentBag<int>();
            List<Thread> listThread = new List<Thread>();

            for (int i = 0; i < _threadCount; i++)
            {
                var query = array.Skip(partSize * i);
                if (i != _threadCount - 1)
                {
                    query = query.Take(partSize);
                }
                listThread.Add(new Thread(delegate () { sumBag.Add(GetPartSum(query.ToArray())); }));
                listThread[i].Start();
            }
            listThread.ForEach(x => x.Join());

            return sumBag.Sum();
        }
        private static int GetPartSum(int[] array)
        {
            var seqCalc = new SeqCalc();
            return seqCalc.GetSum(array);
        }
    }
}
