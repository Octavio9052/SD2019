using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class StaticStudentNumberProcessor
    {
        public static int TotalProcessed { get; set; }
        public static int TotalEven { get; set; }
        public static int TotalOdd { get; set; }
        public static int TotalRepeated { get; set; }

        public static void RunByThreads(List<int> list)
        {
            Thread threadOne = new Thread(new ParameterizedThreadStart(CalculateValues));
            Thread threadTwo = new Thread(new ParameterizedThreadStart(CalculateValues));
            threadOne.Start(list);
            threadTwo.Start(list);

        }

        public static void CalculateValues(int[] list)
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
                for (var i = 0; (repetitions < 2) & (i < processedValues.Length); i++)
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

        public static void CalculateValues(object paramList)
        {
            List<int> list = (List<int>)paramList;
            List<int> processed = new List<int>();

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

                TotalProcessed++;
                processed.Add(studentId);
                int repetitions = 0;
                foreach (var item in processed)
                {
                    if (studentId == item)
                        repetitions++;
                    if (repetitions > 1)
                    {
                        TotalRepeated++;
                        break;
                    }
                }
            }
            stopwatch.Stop();
            PrintResults(stopwatch.ElapsedMilliseconds);
        }

        public static void PrintResults(long elapsedMs)
        {
            Console.WriteLine();
            Console.WriteLine("Total processed " + TotalProcessed);
            Console.WriteLine("Total odd " + TotalOdd);
            Console.WriteLine("Total even " + TotalEven);
            Console.WriteLine("Total repeated " + TotalRepeated);
            Console.WriteLine("Total time elapsed: " + elapsedMs + " ms");
            Console.WriteLine();
        }

        public static List<int> ConvertArrayToList(int[] list)
        {
            List<int> outputList = new List<int>();

            foreach (var number in list)
            {
                outputList.Add(number);
            }

            return outputList;
        }
    }
}
