using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Supine.UltralightSharp {

  [PublicAPI]
  [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
  [return: NativeTypeName("size_t")]
  public unsafe delegate UIntPtr SurfaceDefinitionGetSizeCallback([NativeTypeName("void *")] void* userData);

  namespace Safe {

    [PublicAPI]
    public delegate UIntPtr SurfaceDefinitionGetSizeCallback(IntPtr userData);

  }

}