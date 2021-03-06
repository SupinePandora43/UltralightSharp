using System.IO;
using UltralightNet;
using UltralightNet.AppCore;
using System;
using System.Runtime.InteropServices;

namespace UltralightNetTestApplication
{
	class Program
	{
		static void Main()
		{
			//ULConfig config = new();
			//Renderer renderer = new(config);

			//Session session = Session.DefaultSession(renderer);
			//Session session = new(renderer, false, "asd");

			//AppCoreMethods.ulEnableDefaultLogger("./log.txt");
			//AppCoreMethods.ulEnablePlatformFileSystem("./");
			//AppCoreMethods.ulEnablePlatformFontLoader();

			//Ultralight.View view = new(renderer.Ptr, 512, 512, false, session.Ptr);
			//IntPtr view = ulCreateView(renderer.Ptr, 256, 256, 0, IntPtr.Zero, 0);
			//View view = new(renderer, 512, 512);

			// load order
			if(OperatingSystem.IsLinux()){
				//NativeLibrary.Load("libgio-2.0.so");
				//NativeLibrary.Load("libglib-2.0.so");
				//NativeLibrary.Load("libgmodule-2.0.so");
				//NativeLibrary.Load("libgobject-2.0.so");
				//NativeLibrary.Load("libgthread-2.0.so");
				//NativeLibrary.Load("/usr/lib64/ld-linux-x86-64.so.2");
				//NativeLibrary.Load("libpng12.so.0");
				//NativeLibrary.Load("libpng16.so.16");
				//NativeLibrary.Load("libffi.so.6");
				//NativeLibrary.Load("./libgstreamer-full-1.0.so");
				//NativeLibrary.Load("UltralightCore");
				//string absoluteAssemblyLocationDir = Path.GetDirectoryName(typeof(Program).Assembly.Location);
				//string absoluteRuntimeNativesDir = Path.Combine(absoluteAssemblyLocationDir, "runtimes", "linux-x64", "native");
				//NativeLibrary.Load(Path.Combine(absoluteRuntimeNativesDir, "libgstreamer-full-1.0.so"));
			}
			unsafe {
				Console.WriteLine("test123тест123");
				ULStringGeneratedDllImportMarshaler marshaler = new("test123тест123");
				Console.WriteLine(marshaler.ToManaged());
				marshaler.FreeNative();
				ULString* str = (ULString*)Methods.ulCreateStringUTF16("test123тест123", (uint)"test123тест123".Length);
				Console.WriteLine(str->ToManaged());
				//Console.WriteLine(Marshal.PtrToStringUni(Methods.ulStringGetData((IntPtr)str), (int)Methods.ulStringGetLength((IntPtr)str)));
				Console.WriteLine(Marshal.PtrToStringUni((IntPtr)str->data, (int)str->length));
			}
			AppCoreMethods.ulEnablePlatformFontLoader();
			AppCoreMethods.ulEnableDefaultLogger("./ullog.txt");
			AppCoreMethods.ulEnablePlatformFileSystem(Path.GetDirectoryName(typeof(Program).Assembly.Location));
			Console.WriteLine("creating renderer");
			ULConfig cfg = new();
			Renderer renderer = new(cfg);
			Console.WriteLine("done");
		}
	}
}
