using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSDK
{
    [Serializable]
    public abstract class BaseAnimalBusiness : IAnimalActions
    {
        private readonly ICollection<AnimalValue> _gameProperties = new List<AnimalValue>();

        public ICollection<AnimalValue> GetGameProperties()
        {
            return new List<AnimalValue>(this._gameProperties);
        }

        public void AddGameProperty(AnimalValue gameProperty)
        {
            this._gameProperties.Add(gameProperty);
        }

        public abstract string Play();
        public abstract string Eat();
        public abstract string Sleep();
    }
}
