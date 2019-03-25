using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
            var testObj = (AnimalWrapper)objDb;

            if (File.Exists(@"C:\Users\Octavio\Desktop\test.pet"))
            {
                Stream stream = new FileStream(@"C:\Users\Octavio\Desktop\test.pet", FileMode.Open,
                    FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                testObj = (AnimalWrapper)formatter.Deserialize(stream);
                stream.Close();
                stream.Dispose();
                stream = null;

                BaseAnimalBusiness test;
                // test = (BaseAnimalBusiness)o;
                test = testObj.AnimalState;
                Console.WriteLine(test.Play());
                Console.WriteLine(test.Play());
                Console.WriteLine(test.Play());

                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream(@"C:\Users\Octavio\Desktop\test.pet", FileMode.Create, FileAccess.Write);
                formatter2.Serialize(stream2, testObj);
                stream2.Close();
                stream2.Dispose();
                stream2 = null;
            }
            else
            { 
                var t = _assembly.GetType("Animal.Dog");
                var playMethod = t.GetMethod("Play");
                var eatMethod = t.GetMethod("Eat");
                var o = Activator.CreateInstance(t);

                Console.WriteLine(playMethod.Invoke(o, null));
                Console.WriteLine(eatMethod.Invoke(o, null));
                Console.WriteLine(playMethod.Invoke(o, null));
                Console.WriteLine(playMethod.Invoke(o, null));

                testObj.AnimalState = (BaseAnimalBusiness) o;

                IFormatter formatter2 = new BinaryFormatter();
                Stream stream2 = new FileStream(@"C:\Users\Octavio\Desktop\test.pet", FileMode.Create, FileAccess.Write);
                formatter2.Serialize(stream2, testObj);
                stream2.Close();
                stream2.Dispose();
                stream2 = null;
            }
        }
    }
}
