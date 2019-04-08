using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnmanagedCode
{
    class WriteAPI
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern SafeFileHandle CreateFile(string lpFileName,
                                                uint dwDesiredAccess,
                                                uint dwShareMode,
                                                IntPtr lpSecurityAttributes,
                                                uint dwCreationDisposition,
                                                uint dwFlagsAndAttributes,
                                                IntPtr hTemplateFile);

        [DllImport("kernel32.dll", EntryPoint = "WriteFile")]
        public static extern bool WriteFileOne(SafeHandle hFile,
                                               byte[] lpBuffer,
                                               uint nNumberOfBytesToWrite,
                                               out uint lpNumberOfBytesWritten,
                                               [In] ref NativeOverlapped lpOverlapped);

        [DllImport("kernel32.dll", EntryPoint = "WriteFile")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool WriteFileTwo(IntPtr hFile,
                                               byte[] lpBuffer,
                                               uint nNumberOfBytesToWrite,
                                               out uint lpNumberOfBytesWritten,
                                               [In] ref NativeOverlapped lpOverlapped);
    }
}
