using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameBusiness
{
    interface ILoader
    {
        void GetAssembly(byte[] fileBytes);
    }
}
