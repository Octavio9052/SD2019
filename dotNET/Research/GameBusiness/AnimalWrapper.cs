﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSDK;

namespace GameBusiness
{
    [Serializable]
    public class AnimalWrapper : MarshalByRefObject
    {
        public BaseAnimalBusiness AnimalState { get; set; }
    }
}
