using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSDK
{
    public interface IAnimalValue
    {
        string PropertyName { get; set; }
        string TextProperty { get; set; }
        double MaxValue { get; set; }
        double MinValue { get; set; }
        double CurrentValue { get; set; }

    }
}
