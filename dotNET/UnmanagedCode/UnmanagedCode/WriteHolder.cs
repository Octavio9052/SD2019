using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedCode
{
    class WriteHolder
    {
        /// <summary>
        /// The SafeFileHandle to the file to write to. The file must have at least write-level access.
        /// </summary>
        public SafeFileHandle HandlerFile { get; set; }
        /// <summary>
        /// Pointer to the handler of the file to write to. The file must have at least write-level access.
        /// </summary>
        public IntPtr PointerToHandler { get; set; }
        /// <summary>
        /// The variable, array, or string holding the data to write to the file.
        /// </summary>
        public byte[] Buffer { get; set; }
        /// <summary>
        /// The number of bytes of data to write to the file.
        /// </summary>
        public uint BytesToWrite { get; set; }
        /// <summary>
        /// Stores the string to be written. Not actually used in writing operation.
        /// </summary>
        public string StringToWrite { get; set; }
    }
}
