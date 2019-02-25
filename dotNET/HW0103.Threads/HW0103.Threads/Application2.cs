using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    /**
     * Aplicacion 2
     
     * Procesara de forma sincrona las operacions llamando un metodo CalcularValores(lista) al que le pasara una lista de valores aprocesar
     *
     * En el metodo antes de iniciar el ciclo debera considerar tomar el tiempo de procesamiento
     * En el mismo metodo debera haber un ciclo que procese la lista que se le paso y determine los valores antes mencionados
     */
    class Application2
    {
        public void Run()
        {
            PrimitivesOnly();
            UsingList();

            Console.ReadLine();
        }

        private void UsingList()
        {
            var reader = new StudentNumberReader();
            var processor = new StudentNumberProcessor();
            Console.WriteLine("Loading values...");
            var list = reader.ReadStudentsNumberFile();
            processor.TestCalculate(list);
            list = null;
            processor = null;
            reader = null;
        }

        private void PrimitivesOnly()
        {
            var reader = new StudentNumberReader();
            var processor = new StudentNumberProcessor();
            Console.WriteLine("Loading values...");
            var values = reader.ReadStudentsNumberFile();
            processor.CalculateValues(values);
            values = null;
            processor = null;
            reader = null;
        }
    }
}
