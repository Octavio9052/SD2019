using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class Application3 : IHomeWork
    {
        public void Run()
        {
            UsingList();
        }

        private void UsingList()
        {
            Console.WriteLine("Loading values...");

            var processor = new StudentNumberProcessor();

            processor.RunByThreads(processor.ConvertArrayToList(new StudentNumberReader().ReadStudentsNumberFile()));
        }
    }
}
