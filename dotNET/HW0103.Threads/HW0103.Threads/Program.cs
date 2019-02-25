using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class Program
    {
        private const string header =
@"
------------------------------
1 - StudentNumberGenerator
2 - Read and process (sync)
3 - Read and process (thread)
Input 0 to end
------------------------------
";

        static void Main(string[] args)
        {
            while (ExecuteApp(RequestApp(header)) != 0) ;
        }

        static int ExecuteApp(int pick)
        {
            switch (pick)
            {
                case 0:
                    return 0;
                case 1:
                    RunHomeWork(new Application1());
                    break;
                case 2:
                    RunHomeWork(new Application2());
                    break;
                case 3:
                    RunHomeWork(new Application3());
                    break;
            }
            return 4;
        }

        static void RunHomeWork(IHomeWork app)
        {
            app.Run();
            app = null;
        }

        static int RequestApp(string text)
        {
            int idx = 4;
            do
            {
                Console.WriteLine(text);
                try
                {
                    idx = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            } while (idx > 3);

            return idx;
        }
    }
}
