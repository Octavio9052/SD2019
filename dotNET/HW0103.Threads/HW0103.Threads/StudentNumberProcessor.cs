using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    public class StudentNumberProcessor
    {
        public int TotalProcessed { get; set; }
        public int TotalEven { get; set; }
        public int TotalOdd { get; set; }
        public int TotalRepeated { get; set; }

        public void CalculateValues(int[] list)
        {
            int[] processedValues = new int[list.Length];
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing values...");
            stopwatch.Start();
            foreach (var studentId in list)
            {
                if ((studentId & 1) == 0)
                {
                    TotalEven++;
                }
                else
                {
                    TotalOdd++;
                }

                processedValues[TotalProcessed++] = studentId;

                if (TotalProcessed != list.Length) continue;

                foreach (var itemValue in processedValues)
                {
                    if (studentId == itemValue) TotalRepeated++;
                }
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        //Not Used
        public void CalculateValues(List<int> list)
        {
            var processedValues = new List<int>(list);
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing values...");
            stopwatch.Start();
            foreach (var studentId in list)
            {
                if ((studentId & 1) == 0)
                {
                    TotalEven++;
                }
                else
                {
                    TotalOdd++;
                }

                processedValues[TotalProcessed++] = studentId;

                if (TotalProcessed != list.Capacity) continue;

                foreach (var itemValue in processedValues)
                {
                    if (studentId == itemValue) TotalRepeated++;
                }
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        public void TestCalculate(int[] list)
        {
            List<int> intList = new List<int>();
            foreach (var number in list)
            {
                intList.Add(number);
            }

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing values...");
            stopwatch.Start();
            foreach (var studentId in intList)
            {
                if ((studentId & 1) == 0)
                {
                    TotalEven++;
                }
                else
                {
                    TotalOdd++;
                }

                TotalProcessed++;
                if (TotalProcessed != intList.Capacity) continue;
                if (intList.Contains(studentId)) TotalRepeated++;
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        public void PrintResults(long elapsedMs)
        {
            Console.WriteLine();
            Console.WriteLine("Total Processed " + TotalProcessed);
            Console.WriteLine("Total Odd " + TotalOdd);
            Console.WriteLine("Total Even " + TotalEven);
            Console.WriteLine("Total Repeated " + TotalRepeated);
            Console.WriteLine();
            Console.WriteLine("Total time elapsed: " + elapsedMs + " ms");
        }
    }
}
