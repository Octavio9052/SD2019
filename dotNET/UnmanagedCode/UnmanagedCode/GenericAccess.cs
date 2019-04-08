using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnmanagedCode
{
    /// <summary>
    /// As defined in the Access Mask Format
    /// https://docs.microsoft.com/es-mx/windows/desktop/SecAuthZ/access-mask-format
    /// </summary>
    enum GenericAccess : UInt32
    {
        GENERIC_READ = 0x80000000, // 31
        GENERIC_WRITE = 0x40000000, // 30
        GENERIC_EXECUTE = 0x20000000, // 29
        GENERIC_ALL = 0x10000000, // 28
        RIGHT_TO_ACCESS_SACL = 0x1000000 // 24
    }
}
