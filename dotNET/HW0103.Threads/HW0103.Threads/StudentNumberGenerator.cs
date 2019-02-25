using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class StudentNumberGenerator
    {
        private const byte DefaultDigitsAmount = 5;

        public string[] GenerateStudentNumbers(int amountToGenerate)
        {
            return GenerateStudentNumbers(amountToGenerate, DefaultDigitsAmount);
        }

        public string[] GenerateStudentNumbers(int amountToGenerate, int digits)
        {
            string[] arrayToSave = new string[amountToGenerate];
            Random generator = new Random();

            for (int i = 0; i < amountToGenerate; i++)
            {
                arrayToSave[i] = generator.Next(0, (int) Math.Pow(10, digits) - 1).ToString("D" + digits);
            }

            return arrayToSave;
        }
    }
}
