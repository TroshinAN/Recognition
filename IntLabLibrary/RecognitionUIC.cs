using System;
using System.Runtime.InteropServices;

namespace IntLabLibrary
{
    using DllReturnType = System.Int32;
    using DllHandleType = System.Int64;

    internal sealed class RecognitionUIC : Recognition
    {
        const string dll_file_name = "intlab.uic.ire.x64.dll";
        static RecognitionUIC instance = null;
        static readonly object padlock = new object();

        public static RecognitionUIC GetInterface()
        {
            lock (padlock)
            {
                instance = instance ?? new RecognitionUIC();
                return instance;
            }
        }

        // delegate construction to the base class
        private RecognitionUIC() : base(LibraryType.UIC)
        { }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_LibraryInit", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType LibraryInit_(byte[] lib_config, UInt32 config_size, byte[] options);
        protected override DllReturnType DLL_LibraryInit(byte[] lib_config, UInt32 config_size, byte[] options)
        {
            return LibraryInit_(lib_config, config_size, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_LibraryFree", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType LibraryFree_();
        protected override DllReturnType DLL_LibraryFree()
        {
            return LibraryFree_();
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_CreateAggregator", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllHandleType CreateAggregator_(byte[] inst_config, UInt32 config_size, byte[] options);
        protected override DllHandleType DLL_CreateAggregator(byte[] inst_config, UInt32 config_size, byte[] options)
        {
            return CreateAggregator_(inst_config, config_size, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_ReleaseAggregator", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType ReleaseAggregator_(DllHandleType aggregator_obj);
        protected override DllReturnType DLL_ReleaseAggregator(DllHandleType aggregator_obj)
        {
            return ReleaseAggregator_(aggregator_obj);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_AddImageSource", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllHandleType AddImageSource_(DllHandleType aggregator_obj, byte[] inst_config, UInt32 config_size, byte[] options);
        protected override DllHandleType DLL_AddImageSource(DllHandleType aggregator_obj, byte[] inst_config, UInt32 config_size, byte[] options)
        {
            return AddImageSource_(aggregator_obj, inst_config, config_size, options);
        }


        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_Setup", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType Setup_(DllHandleType aggregator_obj, byte[] input_data, UInt32 data_size, byte[] options);
        protected override DllReturnType DLL_Setup(DllHandleType aggregator_obj, byte[] input_data, UInt32 data_size, byte[] options)
        {
            return Setup_(aggregator_obj, input_data, data_size, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_Reset", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType Reset_(DllHandleType aggregator_obj, byte[] options);
        protected override DllReturnType DLL_Reset(DllHandleType aggregator_obj, byte[] options)
        {
            return Reset_(aggregator_obj, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_Process", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType Process_(DllHandleType obj, byte[] input_data, UInt32 data_size, byte[] options);
        protected override DllReturnType DLL_Process(DllHandleType obj, byte[] input_data, UInt32 data_size, byte[] options)
        {
            return Process_(obj, input_data, data_size, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_GetResult", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType GetResult_(DllHandleType obj, byte[] data_output, UInt32 data_size, ref UInt32 data_written, byte[] options);
        protected override DllReturnType DLL_GetResult(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options)
        {
            data_written = 0;
            return GetResult_(obj, data_output, data_size, ref data_written, options);
        }

        [DllImport(dll_file_name, EntryPoint = "IRE_UIC_GetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern DllReturnType GetLastError_(DllHandleType obj, byte[] data_output, UInt32 data_size, ref UInt32 data_written, byte[] options);
        protected override DllReturnType DLL_GetLastError(DllHandleType obj, byte[] data_output, UInt32 data_size, out UInt32 data_written, byte[] options)
        {
            data_written = 0;
            return GetLastError_(obj, data_output, data_size, ref data_written, options);
        }
    }
}
