using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace UnmanagedCode
{
    class FileWriter
    {
        private readonly WriteHolder _dataHolder = new WriteHolder();
        private static uint _bytesToWrite;

        private static NativeOverlapped _overlapped = new NativeOverlapped
        {
            InternalHigh = IntPtr.Zero,
            EventHandle = IntPtr.Zero,
            OffsetHigh = 0
        };
        private static readonly string _pathOne = @"D:\Code\SD19\dotNET\UnmanagedCode\UnmanagedCode\SafeHandler.txt";
        private static readonly string _pathTwo = @"D:\Code\SD19\dotNET\UnmanagedCode\UnmanagedCode\IntPtr.txt";


        private void PrepareArgs()
        {
            RetrieveHFile();
            RetrieveLpBuffer();
            RetrieveNumberOfBytesToWrite();
        }

        private void RetrieveLpBuffer()
        {
            Console.WriteLine("Input string to write");
            _dataHolder.StringToWrite = Console.ReadLine();
            _dataHolder.Buffer = Encoding.ASCII.GetBytes(_dataHolder.StringToWrite);
            Console.WriteLine("String {0} encoded and stored as byte[] using ASCII encoder", _dataHolder.StringToWrite);
        }
        
        private void RetrieveNumberOfBytesToWrite()
        {
            _dataHolder.BytesToWrite = (uint) Encoding.ASCII.GetByteCount(_dataHolder.StringToWrite);
            Console.WriteLine("Numbers of bytes to write: {0} bytes", _dataHolder.BytesToWrite);
        }
        
        private void RetrieveHFile()
        {
            _dataHolder.HandlerFile = WriteAPI.CreateFile(_pathOne, (uint)GenericAccess.GENERIC_WRITE, 0, IntPtr.Zero, 3, 0, IntPtr.Zero);
            _dataHolder.PointerToHandler = 
                WriteAPI.CreateFile(_pathTwo, 
                                    (uint) GenericAccess.GENERIC_WRITE, 
                                    0, // Prevents other processes from opening a file or device if they request delete, read, or write access. 
                                    IntPtr.Zero, // This parameter can be NULL. Same as new IntPtr(0x0) but without a IntPtr instance.
                                    3, // Opens a file or device, only if it exists. 
                                    0, 
                                    IntPtr.Zero // This param can be NULL.
                ).DangerousGetHandle();
        }

        public void Execute()
        { 
            PrepareArgs();
            Console.WriteLine("Operation successful? {0} ",
                              WriteAPI.WriteFileOne(_dataHolder.HandlerFile,
                                                    _dataHolder.Buffer,
                                                    _dataHolder.BytesToWrite,
                                                    out _bytesToWrite,
                                                    ref _overlapped)
                            );
            Console.WriteLine("Operation successful? {0} ", 
                                WriteAPI.WriteFileTwo(_dataHolder.PointerToHandler,
                                                      _dataHolder.Buffer,
                                                      _dataHolder.BytesToWrite,
                                                      out _bytesToWrite,
                                                      ref _overlapped)
                             );
            _dataHolder.HandlerFile.SetHandleAsInvalid();
            _dataHolder.HandlerFile.Close();
            _dataHolder.HandlerFile.Dispose();
            _dataHolder.PointerToHandler = IntPtr.Zero;
        }
    }
}
