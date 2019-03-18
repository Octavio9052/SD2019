using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace GameBusiness
{
    public class Loader : MarshalByRefObject, ILoader
    {
        private Assembly _assembly;

        public void GetAssembly(byte[] fileBytes)
        {
            try
            {
                this._assembly = Assembly.Load(fileBytes);
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
        }

        public void Execute(object objDb = null)
        {
            var t = _assembly.GetType("Animal.Dog");
            var playMethod = t.GetMethod("Play");
            var eatMethod = t.GetMethod("Eat");
            var o = Activator.CreateInstance(t);

            if (objDb != null) o = objDb;

            BaseAnimalBusiness test;
            test = (BaseAnimalBusiness)o;
            Console.WriteLine(test.Play());
            Console.WriteLine(test.Play());
            Console.WriteLine(test.Play());
            Console.WriteLine(playMethod.Invoke(o, null));
            Console.WriteLine(eatMethod.Invoke(o, null));
            Console.WriteLine(playMethod.Invoke(o, null));
            Console.WriteLine(playMethod.Invoke(o, null));
        }
    }
}
