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

        public Assembly GetAssembly(byte[] fileBytes)
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

            return null;
        }

        public object Execute()
        {
            /*
            foreach (Type item in _assembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(type))
                {
                    var ctor = item.GetConstructor(new[] { ctorType });

                    var objectLoaded = ctor.Invoke(ctorParameters);

                    var method = type.GetMethod(methodName);
                    return method.Invoke(objectLoaded, parameters);
                    break;
                }
            }
            throw new ArgumentException(String.Format("Method Error does not exist"));
            */
            var t = _assembly.GetType("Animal.Dog");
            var playMethod = t.GetMethod("Play");
            var eatMethod = t.GetMethod("Eat");
            var o = Activator.CreateInstance(t);
            BaseAnimalBusiness test;
            test = (BaseAnimalBusiness)o;
            Console.WriteLine(test.Play());
            Console.WriteLine(test.Play());
            Console.WriteLine(test.Play());
            Console.WriteLine(playMethod.Invoke(o, null));
            Console.WriteLine(eatMethod.Invoke(o, null));
            Console.WriteLine(playMethod.Invoke(o, null));
            Console.WriteLine(playMethod.Invoke(o, null));

            return null;
        }
    }
}
