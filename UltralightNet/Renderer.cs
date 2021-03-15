using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UltralightNet
{
	public static partial class Methods
	{
		[DllImport("Ultralight")]
		public static extern IntPtr ulCreateRenderer(IntPtr config);

		/// <summary>Destroy the renderer.</summary>
		[DllImport("Ultralight")]
		public static extern void ulDestroyRenderer(IntPtr renderer);

		/// <summary>Update timers and dispatch internal callbacks (JavaScript and network).</summary>
		[DllImport("Ultralight")]
		public static extern void ulUpdate(IntPtr renderer);

		/// <summary>Render all active Views.</summary>
		[DllImport("Ultralight")]
		public static extern void ulRender(IntPtr renderer);

		/// <summary>Attempt to release as much memory as possible. Don't call this from any callbacks or driver code.</summary>
		[DllImport("Ultralight")]
		public static extern void ulPurgeMemory(IntPtr renderer);

		[DllImport("Ultralight")]
		public static extern void ulLogMemoryUsage(IntPtr renderer);
	}

	public class Renderer : IDisposable
	{
		public IntPtr Ptr
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private set;
		}

		public Renderer(IntPtr ptr, bool dispose = false)
		{
			Ptr = ptr;
			IsDisposed = !dispose;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Renderer(ULConfig config) => Ptr = Methods.ulCreateRenderer(config.Ptr);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update() => Methods.ulUpdate(Ptr);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Render() => Methods.ulRender(Ptr);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void PurgeMemory() => Methods.ulPurgeMemory(Ptr);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void LogMemoryUsage() => Methods.ulLogMemoryUsage(Ptr);

		public bool IsDisposed
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private set;
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		~Renderer() => Dispose();
		public void Dispose()
		{
			if (IsDisposed) return;
			Methods.ulDestroyRenderer(Ptr);

			IsDisposed = true;
			GC.SuppressFinalize(this);
		}
	}
}
