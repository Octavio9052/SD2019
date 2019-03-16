using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace Animal
{
    public class Dog : BaseAnimalBusiness
    {
        private AnimalValue nameValue;
        private AnimalValue FunValue;

        public Dog()
        {
            nameValue = AnimalValue.GetAnimalValue("Name", "Diablo", 0, 0, 0);
            FunValue = AnimalValue.GetAnimalValue("Fun", string.Empty, 100, 0, 0);
            AddGameProperty(nameValue);
            AddGameProperty(FunValue);
        }

        public override string Play()
        {
            var currentValue = GetGameProperties().First(x => x.PropertyName.Equals("Fun")).CurrentValue;
            var maxValue = GetGameProperties().First(x => x.PropertyName.Equals("Fun")).MaxValue;
            var minValue = GetGameProperties().First(x => x.PropertyName.Equals("Fun")).MinValue;
            var name = GetGameProperties().First(x => x.PropertyName.Equals("Name")).TextProperty;

            currentValue += 12;
            FunValue.CurrentValue += 20;

            if (FunValue.CurrentValue > maxValue) FunValue.CurrentValue = maxValue;
            if (FunValue.CurrentValue < minValue) FunValue.CurrentValue = minValue;

            return $"You have played with {name}, his fun is at {FunValue.CurrentValue}";
        }

        public override string Eat()
        {
            var name = GetGameProperties().First(x => x.PropertyName.Equals("Name")).TextProperty;
            return $"{name} ate";
        }

        public override string Sleep()
        {
            var name = GetGameProperties().First(x => x.PropertyName.Equals("Name")).TextProperty;
            return $"{name} is sleeping";
        }
    }
}
