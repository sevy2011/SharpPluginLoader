﻿using System;
using System.Linq;

namespace SharpPluginLoader.Core
{
    /// <summary>
    /// Represents a function pointer to a native function with no return type and no arguments. Equivalent to <see cref="NativeAction"/>.
    /// </summary>
    public class NativeFunction
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe void Invoke() => ((delegate* unmanaged[Fastcall]<void>)_funcPtr)();

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute"/></remarks>
        public unsafe void InvokeUnsafe() => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<void>)_funcPtr)();
    }
    
    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke() => ((delegate* unmanaged[Fastcall]<TRet>)_funcPtr)();

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe() => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<TRet>)_funcPtr)();
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1) => ((delegate* unmanaged[Fastcall]<T1, TRet>)_funcPtr)(arg1);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, TRet>)_funcPtr)(arg1);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2) => ((delegate* unmanaged[Fastcall]<T1, T2, TRet>)_funcPtr)(arg1, arg2);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, TRet>)_funcPtr)(arg1, arg2);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, TRet>)_funcPtr)(arg1, arg2, arg3);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, TRet>)_funcPtr)(arg1, arg2, arg3);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, TRet>)_funcPtr)(arg1, arg2, arg3, arg4);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, TRet>)_funcPtr)(arg1, arg2, arg3, arg4);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15);
    }

    /// <summary>
    /// Represents a function pointer to a native function with the given return type and arguments.
    /// </summary>
    public class NativeFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TRet>
    {
        private readonly unsafe void* _funcPtr;

        public unsafe NativeFunction(nint funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        public unsafe NativeFunction(long funcPtr)
        {
            _funcPtr = (void*)funcPtr;
        }

        /// <summary>
        /// Invokes the function pointer.
        /// </summary>
        public unsafe TRet Invoke(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) => ((delegate* unmanaged[Fastcall]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);

        /// <summary>
        /// Invokes the function pointer without transitioning the Garbage Collector. Use this for very short functions.
        /// </summary>
        /// <remarks> See <see href="https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.suppressgctransitionattribute">SuppressGCTransitionAttribute</see></remarks>
        public unsafe TRet InvokeUnsafe(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16) => ((delegate* unmanaged[Fastcall, SuppressGCTransition]<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TRet>)_funcPtr)(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16);
    }
}
