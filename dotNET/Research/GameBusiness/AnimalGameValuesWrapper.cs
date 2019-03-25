using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace GameBusiness
{
    public class AnimalGameValuesWrapper : MarshalByRefObject
    {
        public List<AnimalValue> MarshalledAnimalGameValuesList { get; set; }
    }
}
