using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    public class StudentNumberProcessor
    {
        public int TotalProcessed { get; set; }
        public int TotalEven { get; set; }
        public int TotalOdd { get; set; }
        public int TotalRepeated { get; set; }

        public void RunByThreads(List<int> list)
        {
            List<List<int>> chunks = ChunkBy(list, list.Count/2);
            Thread threadOne = new Thread(new ParameterizedThreadStart(CalculateValues));
            Thread threadTwo = new Thread(new ParameterizedThreadStart(CalculateValues));
            threadOne.Start(chunks.First());
            threadTwo.Start(chunks.Last());

            while (threadOne.IsAlive || threadTwo.IsAlive)
            {
            }
        }

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


                int repetitions = 0;
                for (var i = 0; (repetitions < 2)&(i < processedValues.Length); i++)
                {
                    var itemValue = processedValues[i];
                    if (studentId == itemValue)
                        repetitions++;
                    if (repetitions > 1)
                    {
                        TotalRepeated++;
                    }
                }
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        public void CalculateValues(object paramList)
        {
            List<int> list = (List<int>) paramList;
            List<int> processed = new List<int>();

            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing values...");
            stopwatch.Start();
            foreach (var studentId in list)
            {
                if ((studentId & 1) == 0)
                {
                    lock (this)
                    {
                        TotalEven++;
                    }
                }
                else
                {
                    lock (this)
                    {
                        TotalOdd++;
                    }
                }

                lock (this)
                {
                    TotalProcessed++;
                }
                processed.Add(studentId);
                int repetitions = 0;
                foreach (var item in processed)
                {
                    if (studentId == item)
                        repetitions++;
                    if (repetitions > 1)
                    {
                        lock (this)
                        {
                            TotalRepeated++;
                        }
                        break;
                    }
                }
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        public void PrintResults(long elapsedMs)
        {
            Console.WriteLine();
            Console.WriteLine("Total processed " + TotalProcessed);
            Console.WriteLine("Total odd " + TotalOdd);
            Console.WriteLine("Total even " + TotalEven);
            Console.WriteLine("Total repeated " + TotalRepeated);
            Console.WriteLine("Total time elapsed: " + elapsedMs + " ms");
            Console.WriteLine();
        }

        public List<int> ConvertArrayToList(int[] list)
        {
            List<int> outputList = new List<int>();

            foreach (var number in list)
            {
                outputList.Add(number);
            }

            return outputList;
        }

        public List<List<int>> ChunkBy(List<int> originalList, int chunkSize)
        {
            return originalList
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
