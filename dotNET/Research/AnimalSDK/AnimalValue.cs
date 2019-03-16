using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSDK
{
    public class AnimalValue
    {
        public string PropertyName { get; set; }
        public string TextProperty { get; set; }
        public double MaxValue { get; set; }
        public double MinValue { get; set; }
        public double CurrentValue { get; set; }

        private AnimalValue() { }

        private AnimalValue(string propertyName, string textProperty, double maxValue, double minValue, double currentValue)
        {
            this.PropertyName = propertyName;
            this.TextProperty = textProperty;
            this.MaxValue = maxValue;
            this.MinValue = minValue;
            this.CurrentValue = currentValue;
        }

        public static AnimalValue GetAnimalValue(string name, string textProperty, double maxValue, double minValue, double currentValue)
        {
            return new AnimalValue(name, textProperty,maxValue, minValue, currentValue);
        }
    }
}
