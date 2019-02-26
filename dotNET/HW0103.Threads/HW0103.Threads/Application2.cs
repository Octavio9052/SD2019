using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class Application2 : IHomeWork
    {
        public void Run()
        {
            // PrimitivesOnly();
            UsingList();
        }

        private void UsingList()
        {
            Console.WriteLine("Loading values...");

            var processor = new StudentNumberProcessor();
            processor.CalculateValues(processor.ConvertArrayToList(new StudentNumberReader().ReadStudentsNumberFile()));
            processor = null;
        }

        private void PrimitivesOnly()
        {
            Console.WriteLine("Loading values...");

            var processor = new StudentNumberProcessor();
            //processor.CalculateValues(new StudentNumberReader().ReadStudentsNumberFile());
            processor = null;
        }
    }
}
