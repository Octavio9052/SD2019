using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    /* Tener 4 variables a nivel clase para almacenar:
    * Total de registos procesados,
    * Total PAres,
    * Total Impares y
    * Repetidos
    * La aplicacion deberar cargar en memoria el archivo previamiento creado*/
    class StudentNumberReader
    {
        private const string FilePath = @"D:\Code\SD19\dotNET\HW0103.Threads\HW0103.Threads\res\StudentNumbers.txt";

        public int[] ReadStudentsNumberFile(string path = FilePath)
        {
            string[] lines = File.ReadAllLines(path);
            int[] result = new int[lines.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(lines[i]);
            }
            return result;
        }

        // NOT USED
        public List<int> ReadStudentsNumberFileList(string path = FilePath)
        {
            char[] lineJump = { '\r' };
            List<int> lines = File.ReadAllText(path).Split(lineJump)
                .Select(x => Convert.ToInt32(x)).ToList();
            return lines;
        }
    }
}
