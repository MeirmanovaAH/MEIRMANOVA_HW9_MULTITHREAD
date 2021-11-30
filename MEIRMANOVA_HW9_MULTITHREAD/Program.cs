using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace MEIRMANOVA_HW9_MULTITHREAD
{
    class Program
    {
        static void Main(string[] args)
        {
            var exampleList = new List<int>() { 100000, 1000000, 10000000 };
            var seqCalc = new SeqCalc();
            var multiThreadCalc = new MultiThreadCalc(Environment.ProcessorCount);
            var linqCalc = new LinqCalc();
            
            int sum = 0;
            foreach (int exmplst in exampleList)
            {
                var arr = new int[exmplst];
                for (int i = 0; i < exmplst; i++)
                    arr[i] = 1;

                var sw = new Stopwatch();
                sw.Start();
                sum = seqCalc.GetSum(arr);
                sw.Stop();
                Console.WriteLine($"Sequence. Sum = {sum} duration = {sw.ElapsedMilliseconds}");
                sw.Reset();
                sw.Start();
                sum = multiThreadCalc.GetSum(arr);
                sw.Stop();
                Console.WriteLine($"MultiThread. Sum = {sum} duration = {sw.ElapsedMilliseconds}");
                sw.Reset();
                sw.Start();
                sum = linqCalc.GetSum(arr);
                sw.Stop();
                Console.WriteLine($"Parallel LINQ. Sum = {sum} duration = {sw.ElapsedMilliseconds}");
            }

        }
    }
}

