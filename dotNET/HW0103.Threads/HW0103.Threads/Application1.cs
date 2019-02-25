using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW0103.Threads
{
    class Application1 : IHomeWork
    {
        public void Run()
        {
            PrintVerbatim();
            var generator = new StudentNumberGenerator();
            var writer = new StudentNumberWriterToFile();

            // Request input: text to display to user, if is a isNumber
            var amount = int.Parse(RequestInput("How many ids?", true));
            var digits = int.Parse(RequestInput("How many digits? (0 for default)", true));
            var path = RequestInput("What path to save the file? (0 for default)", false);


            Console.WriteLine("Creating string[]...");
            // If digits is 0 then use single param method, generator will use default digits value (5)
            var content = digits == 0 ? generator.GenerateStudentNumbers(amount) : generator.GenerateStudentNumbers(amount, digits);


            Console.WriteLine("Writing to file...");
            // if path is 0 use default path.
            if (path.Equals("0"))
                Console.WriteLine(writer.WriteToFile(content) ? "File created" : "Try again");
            else
                Console.WriteLine(writer.WriteToFile(path, content) ? "File created" : "Try again error in path");
            Console.ReadLine();
        }

        public string RequestInput(string displayText, bool isNumber)
        {
            return isNumber ? RequestNumber(displayText).ToString() : RequestPath(displayText);
        }

        private int RequestNumber(string displayText)
        {
            int result;
            do
            {
                Console.WriteLine(displayText);
            } while (!int.TryParse(Console.ReadLine(), out result));

            return result > 0 ? result : 0;
        }

        private string RequestPath(string displayText)
        {
            Console.WriteLine(displayText);
            displayText = Console.ReadLine();
            return displayText;
        }

        public void PrintVerbatim()
        {
            Console.WriteLine(@"- - - - - - - - - - - - - - - - - - - - - - - -
            STUDENT NUMBER GENERATOR
This app will generate n amount of students ids
and write it to a file
Optional: Set how many digits the ids will have
	  Set the path of the file to write
WARNING: Max number 100000000 will create a file
of more than 500 MB (when 5 digits string)
- - - - - - - - - - - - - - - - - - - - - - - -"); //268435448
            Console.WriteLine();
        }
    }
}
