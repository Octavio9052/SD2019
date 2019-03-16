using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameBusiness
{
    public class Loader2 : MarshalByRefObject
    {
        public Assembly GetAssembly(string fullPath)
        {
            try
            {
                return Assembly.LoadFile(fullPath);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane);
            }
            catch (FileLoadException fle)
            {
                Console.WriteLine(fle);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe);
            }
            catch (BadImageFormatException bife)
            {
                Console.WriteLine(bife);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae);
            }

            return null;
        }
    }
}
