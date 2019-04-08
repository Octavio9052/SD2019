using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedCode
{
    class Unmanaged
    {
        public IntPtr hFile;
        public byte[] lpBuffer;
        public uint nNumberOfBytesToWrite;
        public uint lpNumberOfBytesWritten;
        public NativeOverlapped lpOverlapped;
        private string stringToEncode;
        private SafeFileHandle safeFileHandle;


        private void PrepareArgs()
        {
            RetrieveHFile();
            RetrieveLpBuffer();
            RetrieveNumberOfBytesToWrite();
            RetrieveOverlapped();
        }

        private void RetrieveLpBuffer()
        {
            Console.WriteLine("Input string to write");
            stringToEncode = Console.ReadLine();
            this.lpBuffer = Encoding.ASCII.GetBytes(stringToEncode);
            Console.WriteLine("String encoded and stored as byte[] using ASCII enconding");
        }
        
        private void RetrieveNumberOfBytesToWrite()
        {
            this.nNumberOfBytesToWrite = (uint) Encoding.ASCII.GetByteCount(stringToEncode);
            Console.WriteLine("Numbers of bytes to write: " + this.nNumberOfBytesToWrite + " bytes");
        }

        private void RetrieveHFile()
        {
            safeFileHandle = FileWriter.CreateFile(@"D:\Code\SD19\dotNET\UnmanagedCode\UnmanagedCode\Probando.txt", 0x40000000, 0, IntPtr.Zero, 3, 0, IntPtr.Zero);
            //this.safeFileHandle = safeFileHandle;
        }

        private void RetrieveOverlapped()
        {
            NativeOverlapped over = new NativeOverlapped();
            over.InternalHigh = IntPtr.Zero;
            over.EventHandle = IntPtr.Zero;
            over.OffsetHigh = 0;
            this.lpOverlapped = over;
        }

        public void Execute()
        { 
            PrepareArgs();
            Console.WriteLine("Operation successful? " + FileWriter.WriteFileOne(safeFileHandle,
                                                                                lpBuffer,
                                                                                nNumberOfBytesToWrite,
                                                                                out lpNumberOfBytesWritten,
                                                                                ref lpOverlapped)
                                                                                );
            safeFileHandle.Close();
            safeFileHandle.Dispose();
            this.hFile = new IntPtr();
        }
    }
}
