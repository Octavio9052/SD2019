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
    public class AnimalLoaderAndExecuter : MarshalByRefObject
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

        public AnimalGameValuesWrapper Execute(object objDb = null)
        {
            BaseAnimalBusiness baseAnimal;

            if (File.Exists(@"C:\Users\Octavio\Desktop\guid.pet"))
            {
                Stream stream = new FileStream(@"C:\Users\Octavio\Desktop\guid.pet", FileMode.Open,
                    FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                baseAnimal = (BaseAnimalBusiness) formatter.Deserialize(stream);
                stream.Close();
                stream.Dispose();
                Console.WriteLine(baseAnimal.Play());
                Console.WriteLine(baseAnimal.Eat());
                Console.WriteLine(baseAnimal.Sleep());
            }
            else
            {
                var t = _assembly.GetType("Animal.Dog");
                var playMethod = t.GetMethod("Play");
                var eatMethod = t.GetMethod("Eat");
                var sleepMethod = t.GetMethod("Sleep");
                var o = Activator.CreateInstance(t);
                baseAnimal = (BaseAnimalBusiness) o;

                Console.WriteLine(playMethod.Invoke(o, null));
                Console.WriteLine(eatMethod.Invoke(o, null));
                Console.WriteLine(sleepMethod.Invoke(o, null));
                baseAnimal.Sleep();
            }

            PersistPetState(baseAnimal);

            var testValuesList = new AnimalGameValuesWrapper();

            testValuesList.MarshalledAnimalGameValuesList = (List<AnimalValue>)baseAnimal.GetGameProperties();

            return testValuesList;
        }

        private bool PersistPetState(BaseAnimalBusiness o)
        {
            IFormatter formatter = new BinaryFormatter();
            try
            {
                Stream stream = new FileStream(@"C:\Users\Octavio\Desktop\guid.pet", FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, o);

                stream.Close();
                stream.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
